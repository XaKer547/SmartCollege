using CollegeManagementSystem.Application.Commands.Employees;
using CollegeManagementSystem.Application.Queries.Employees;
using CollegeManagementSystem.Domain.Employees;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.DTOs.Employees;

namespace CollegeManagementSystem.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class EmployeesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Добавить сотрудника
    /// </summary>
    /// <response code="201">Успешно создана</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на добавление сотрудника</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeCommand createEmployee)
    {
        var employeeId = await mediator.Send(createEmployee);

        return Ok(employeeId);
    }

    /// <summary>
    /// Обновить сотрудника
    /// </summary>
    /// <param name="employeeId">Идентификатор сотрудника</param>
    /// <response code="204">Успешное обновление</response>
    /// <response code="400">Запрос не прошел валидацию</response>
    /// <response code="403">Пользователь не имеет доступ на изменение сотрудника</response>
    /// <response code="404">сотрудник не найдена</response>
    [HttpPut("{employeeId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateEmployee(Guid employeeId, UpdateEmployeeDTO updateEmployee)
    {
        var command = new UpdateEmployeeCommand()
        {
            EmployeeId = new EmployeeId(employeeId),
            FirstName = updateEmployee.FirstName,
            MiddleName = updateEmployee.MiddleName,
            LastName = updateEmployee.LastName,
        };

        await mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// Получить сотрудников
    /// </summary>
    /// <response code="200"></response>
    /// <response code="403">Пользователь не имеет доступ на получение списка сотрудников</response>
    [HttpGet]
    [ProducesResponseType(200)] // add type
    [ProducesResponseType(403)]
    public async Task<IActionResult> GetEmployees()
    {
        var query = new GetEmployeesQuery();

        await mediator.Send(query);

        return Ok();
    }

    /// <summary>
    /// Получить сотрудника
    /// </summary>
    /// <param name="employeeId">Идентификатор сотрудника</param>
    /// <response code="200"></response>
    /// <response code="403">Пользователь не имеет доступ на получение сотрудника</response>
    /// <response code="404">сотрудник не найдена</response>
    [HttpGet("{employeeId}")]
    [ProducesResponseType(200)] // add type
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetEmployee(Guid employeeId)
    {
        var query = new GetEmployeeQuery()
        {
            EmployeeId = new EmployeeId(employeeId)
        };

        await mediator.Send(query);

        return Ok();
    }

    /// <summary>
    /// Удалить сотрудника
    /// </summary>
    /// <param name="employeeId">Идентификатор сотрудника</param>
    /// <response code="204">сотрудник удалена</response>
    /// <response code="403">Пользователь не имеет доступ на удаление сотрудника</response>
    /// <response code="404">сотрудник не найден</response>
    [HttpDelete("{employeeId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteEmployee(Guid employeeId)
    {
        var command = new DeleteEmployeeCommand()
        {
            EmployeeId = new EmployeeId(employeeId),
        };

        await mediator.Send(command);

        return Ok();
    }

    //block unblock
}
