using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CollegeManagementSystem.API.ErrorHandling.Filters;

public class ExceptionMappingFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        context.Result = GetExceptionResult(context.Exception);

        context.ExceptionHandled = true;
    }

    private static IActionResult GetExceptionResult(Exception exception)
    {
        return exception switch
        {
            //InputValidationException e => HandleValidationException(e),
            //EntityNotFoundException e => HandleNotFoundException(e),
            //ExternalAuthenticationPreventedException e => HandleCannotAuthenticateExternal(e),
            //_ => HandleUnknownException(exception)
        };
    }
}
