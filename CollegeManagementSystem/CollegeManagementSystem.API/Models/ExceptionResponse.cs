using System.Net;

namespace CollegeManagementSystem.API.Models
{
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);
}
