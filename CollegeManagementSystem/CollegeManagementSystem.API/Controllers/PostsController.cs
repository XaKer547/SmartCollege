using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementSystem.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class PostsController : ControllerBase
{
    /// <summary>
    /// Получить список должностей
    /// </summary>
    /// <response code="200"></response>
    /// <response code="403">Пользователь не имеет доступ на получение списка должностей</response>
    [HttpGet]
    [ProducesResponseType(200)] // add type
    [ProducesResponseType(403)]
    public async Task<IActionResult> GetPosts()
    {
        return Ok();
    }
}
