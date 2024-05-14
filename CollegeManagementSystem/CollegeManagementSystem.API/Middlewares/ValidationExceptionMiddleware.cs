using CollegeManagementSystem.API.Validators.Exceptions;
using MassTransit.Internals;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementSystem.API.Middlewares;

public sealed class ValidationExceptionHandlingMiddleware(RequestDelegate next, ILogger<ValidationExceptionHandlingMiddleware> logger)
{
    private readonly RequestDelegate _next = next;
    private readonly ILogger<ValidationExceptionHandlingMiddleware> _logger = logger;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "ValidationFailure",
                Title = "Ошибка валидации",
                Detail = "Произошла одна или множество ошибок валидации"
            };

            if (exception.Errors is not null)
                problemDetails.Extensions["errors"] = exception.Errors;


            if (exception.Errors.Count > 1)
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            else
            {
                var error = exception.Errors[0];

                //context.Response.StatusCode = new StatusCodeResult(int.Parse(error.ToCode()));
            }

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}