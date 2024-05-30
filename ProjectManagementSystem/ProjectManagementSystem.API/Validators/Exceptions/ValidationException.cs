using ProjectManagementSystem.API.Validators.Models;

namespace ProjectManagementSystem.API.Validators.Exceptions;

public sealed class ValidationException(List<ValidationError> errors) : Exception
{
    public List<ValidationError> Errors { get; } = errors;
}
