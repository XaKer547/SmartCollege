﻿using FluentValidation;
using MediatR;
using ProjectManagementSystem.API.Validators.Models;

namespace ProjectManagementSystem.API.Validators.Behaviors;
public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseRequest
{
    private readonly IEnumerable<IValidator<TRequest>> validators = validators;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationFailures = await Task.WhenAll(
            validators.Select(validator => validator.ValidateAsync(context)));

        var errors = validationFailures
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => new ValidationError(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage,
                validationFailure.ErrorCode))
            .ToList();

        if (errors.Count != 0)
            throw new Exceptions.ValidationException(errors);

        var response = await next();

        return response;
    }
}