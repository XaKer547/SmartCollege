namespace CollegeManagementSystem.API.Validators.Models;

public sealed class ValidationError(string propertyName, string errorMessage)
{
    public string PropertyName { get; } = propertyName;
    public string ErrorMessage { get; } = errorMessage;
}
