using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementSystem.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProjectsController : ControllerBase
{
    /// <summary>
    /// Добавить студенческую работу
    /// </summary>
    /// <response code="201">Успешно создана</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на добавление студенческой работы</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    public async Task<IActionResult> CreateProject()
    {
        return Ok();
    }

    /// <summary>
    /// Получить студенческие работу
    /// </summary>
    /// <response code="200"></response>
    [HttpGet]
    [ProducesResponseType(200)] // add type
    public async Task<IActionResult> GetProjects()
    {
        return Ok();
    }

    /// <summary>
    /// Получить студенческую работу
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <response code="200"></response>
    /// <response code="404">работа не найдена</response>
    [HttpGet("{projectId}")]
    [ProducesResponseType(200)] // add type
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetProject(Guid projectId)
    {
        return Ok();
    }

    /// <summary>
    /// Завершить студенческую работу
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <response code="200"></response>
    /// <response code="400">Работа уже завершена</response>
    /// <response code="403">Пользователь не имеет доступ на завершение студенческой работы</response>
    /// <response code="404">работа не найдена</response>
    [HttpPatch("{projectId}/complete")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> CompleteProject(Guid projectId)
    {
        return Ok();
    }

    /// <summary>
    /// Обновить работу
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <response code="204">Успешное обновление</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на изменение работы</response>
    /// <response code="404">работа не найдена</response>
    [HttpPut("{projectId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateProject(Guid projectId)
    {
        return Ok();
    }

    /// <summary>
    /// Добавить этап работы
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <response code="201">Успешно добавлен</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на добавление этапов работы</response>
    /// <response code="404">работа не найдена</response>
    [HttpPost("{projectId}/stages")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> AddProjectStage(Guid projectId)
    {
        return Ok();
    }

    /// <summary>
    /// Обновить этап работы
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <param name="stageId">Идентификатор этапа работы</param>
    /// <response code="204">Успешное обновление</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на изменение этапа работы</response>
    /// <response code="404">работа не найдена</response>
    [HttpPatch("{projectId}/stages/{stageId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateProjectStage(Guid projectId, Guid stageId)
    {
        return Ok();
    }

    /// <summary>
    /// Удалить этап работы
    /// </summary>
    /// <param name="projectId">Идентификатор работы</param>
    /// <param name="stageId">Идентификатор этапа работы</param>
    /// <response code="204">Успешное удаление</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на удаление этапа работы</response>
    /// <response code="404">работа не найдена</response>
    [HttpDelete("{projectId}/stages/{stageId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteProjectStage(Guid projectId, Guid stageId)
    {
        return Ok();
    }

    // [HttpGet("{projectId}/stages")]
}
