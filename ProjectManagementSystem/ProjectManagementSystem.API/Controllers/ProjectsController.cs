using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManagementSystem.Application.Commands.Projects;
using ProjectManagementSystem.Application.Commands.ProjectStages;
using ProjectManagementSystem.Application.Commands.ProjectStagesAnswers;
using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Application.Queries.Projects;
using ProjectManagementSystem.Application.Queries.ProjectStages;
using ProjectManagementSystem.Domain.Disciplines;
using ProjectManagementSystem.Domain.Groups;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Students;
using SharedKernel.DTOs.Projects;
using SharedKernel.DTOs.ProjectStages;

namespace ProjectManagementSystem.API.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ProjectsController(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;

    /// <summary>
    /// �������� ������������ ������
    /// </summary>
    /// <response code="201">������� �������</response>
    /// <response code="400">������ �� ������ ���������</response>
    /// <response code="403">������������ �� ����� ������ �� ���������� ������������ ������</response>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    public async Task<IActionResult> CreateProject(CreateProjectCommand command)
    {
        var projectId = await mediator.Send(command);

        return Created(string.Empty, projectId);
    }

    /// <summary>
    /// �������� ������������ ������
    /// </summary>
    /// <response code="200"></response>
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IReadOnlyCollection<ProjectDTO>))]
    public async Task<IActionResult> GetProjects()
    {
        var query = new GetProjectsQuery();

        var projects = await mediator.Send(query);

        return Ok(projects);
    }

    /// <summary>
    /// �������� ������������ ������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <response code="200"></response>
    /// <response code="404">������ �� �������</response>
    [HttpGet("{projectId}")]
    [ProducesResponseType(200, Type = typeof(ProjectDTO))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetProject(Guid projectId)
    {
        var query = new GetProjectQuery()
        {
            ProjectId = new ProjectId(projectId)
        };

        var project = await mediator.Send(query);

        return Ok(project);
    }

    /// <summary>
    /// ��������� ������������ ������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <response code="200"></response>
    /// <response code="400">������ ��� ���������</response>
    /// <response code="403">������������ �� ����� ������ �� ���������� ������������ ������</response>
    /// <response code="404">������ �� �������</response>
    [HttpPatch("{projectId}/complete")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> CompleteProject(Guid projectId)
    {
        var command = new CompleteProjectCommand()
        {
            ProjectId = new ProjectId(projectId)
        };

        await mediator.Send(command);

        return Ok();
    }

    /// <summary>
    /// �������� ������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <response code="204">�������� ����������</response>
    /// <response code="400">������ �� ������ ���������</response>
    /// <response code="403">������������ �� ����� ������ �� ��������� ������</response>
    /// <response code="404">������ �� �������</response>
    [HttpPatch("{projectId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateProject(Guid projectId, UpdateProjectDTO updateProject)
    {
        var command = new UpdateProjectCommand()
        {
            ProjectId = new ProjectId(projectId),
            Name = updateProject.Name,
            SubjectArea = updateProject.SubjectArea,
            DisciplineId = new DisciplineId(updateProject.DisciplineId),
            GroupId = new GroupId(updateProject.GroupId),
            ProjectType = updateProject.ProjectType
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// �������� ���� ������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <response code="201">������� ��������</response>
    /// <response code="400">������ �� ������ ���������</response>
    /// <response code="403">������������ �� ����� ������ �� ���������� ������ ������</response>
    /// <response code="404">������ �� �������</response>
    [HttpPost("{projectId}/stages")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> AddProjectStage(Guid projectId, IEnumerable<IFormFile>? files)
    {
        files.Select(f =>
        {
            long fileSize = f.Length;
            string fileType = f.ContentType;

            byte[] bytes;

            using (var stream = new MemoryStream())
            {
                f.CopyTo(stream);

                bytes = stream.ToArray();
            }

            var dto = new FileDTO()
            {
                Name = f.Name + Path.GetExtension(f.FileName),
                File = bytes
            };

            return dto;
        });

        //var command = new CreateProjectStageCommand()
        //{
        //    ProjectId = new ProjectId(projectId),
        //    Deadline = createProjectStage.Deadline,
        //    Description = createProjectStage.Description,
        //    Name = createProjectStage.Name,
        //};

        //var projectStageId = await mediator.Send(command);
        
        return Ok();

        //return Created(string.Empty, projectStageId);
    }

    /// <summary>
    /// �������� ���� ������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <param name="stageId">������������� ����� ������</param>
    /// <response code="204">�������� ����������</response>
    /// <response code="400">������ �� ������ ���������</response>
    /// <response code="403">������������ �� ����� ������ �� ��������� ����� ������</response>
    /// <response code="404">������ �� �������</response>
    [HttpPatch("{projectId}/stages/{stageId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateProjectStage(Guid projectId, Guid stageId, UpdateProjectStageDTO updateProjectStage)
    {
        //handle files

        var command = new UpdateProjectStageCommand()
        {
            ProjectId = new ProjectId(projectId),
            ProjectStageId = new ProjectStageId(stageId),
            Deadline = updateProjectStage.Deadline,
            Description = updateProjectStage.Description,
            Name = updateProjectStage.Name,
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// ������� ���� ������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <param name="stageId">������������� ����� ������</param>
    /// <response code="204">�������� ��������</response>
    /// <response code="400">������ �� ������ ���������</response>
    /// <response code="403">������������ �� ����� ������ �� �������� ����� ������</response>
    /// <response code="404">������ �� �������</response>
    [HttpDelete("{projectId}/stages/{stageId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(403)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteProjectStage(Guid projectId, Guid stageId)
    {
        var command = new DeleteProjectStageCommand()
        {
            ProjectId = new ProjectId(projectId),
            ProjectStageId = new ProjectStageId(stageId),
        };

        await mediator.Send(command);

        return NoContent();
    }

    /// <summary>
    /// �������� ����� ������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <param name="stageId">������������� ����� ������</param>
    /// <response code="200"></response>
    /// <response code="404">������ �� �������</response>
    [HttpGet("{projectId}/stages")]
    [ProducesResponseType(200, Type = typeof(IReadOnlyCollection<ProjectStageDTO>))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetProjectStages(Guid projectId)
    {
        var query = new GetProjectStagesQuery()
        {
            ProjectId = new ProjectId(projectId)
        };

        var stages = await mediator.Send(query);

        return Ok(stages);
    }

    /// <summary>
    /// �������� ����� ������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <param name="stageId">������������� ����� ������</param>
    /// <response code="200"></response>
    /// <response code="404">������ ��� ���� ������ �� ������</response>
    [HttpGet("{projectId}/stages/{stageId}")]
    [ProducesResponseType(200, Type = typeof(ProjectStageDTO))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetProjectStage(Guid projectId, Guid stageId)
    {
        var query = new GetProjectStageQuery()
        {
            ProjectId = new ProjectId(projectId),
            ProjectStageId = new ProjectStageId(stageId)
        };

        var stage = await mediator.Send(query);

        return Ok(stage);
    }

    /// <summary>
    /// ��������� ����� �� �������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <param name="stageId">������������� ����� ������</param>
    /// <response code="200"></response>
    /// <response code="404">������ ��� ���� ������ �� ������</response>
    [HttpPost("{projectId}/stages/{stageId}/answer")]
    [ProducesResponseType(201, Type = typeof(ProjectStageDTO))]
    [ProducesResponseType(404)]
    public async Task<IActionResult> AnswerStage(Guid projectId, Guid stageId, IFormFile file)
    {
        //handle file

        //

        var command = new CreateProjectStageAnswerCommand()
        {
            ProjectId = new ProjectId(projectId),
            ProjectStageId = new ProjectStageId(stageId),

        };

        var answerId = await mediator.Send(command);

        return Created(string.Empty, answerId);
    }

    /// <summary>
    /// ������� ������ ��������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <param name="stageId">������������� ����� ������</param>
    /// <response code="201"></response>
    /// <response code="404">������ ��� ���� ������ �� ������</response>
    [HttpPatch("{projectId}/stages/{stageId}/answer/return")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> ReturnStageAnswer(Guid projectId, Guid stageId, IFormFile file, [FromBody] string remark)
    {
        //handle File



        //

        var command = new ReturnProjectStageAnswerCommand()
        {
            ProjectId = new ProjectId(projectId),
            ProjectStageId = new ProjectStageId(stageId),
            Remark = remark
        };

        await mediator.Send(command);

        return Created();
    }

    /// <summary>
    /// �������� ����� �� �������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <param name="stageId">������������� ����� ������</param>
    /// <response code="204"></response>
    /// <response code="404">������ ��� ���� ������ �� ������</response>
    [HttpPatch("{projectId}/stages/{stageId}/answer")]
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> ChangeStageAnswer(Guid projectId, Guid stageId, IFormFile file)
    {
        //handle file

        //

        var command = new UpdateProjectStageAnswerCommand()
        {
            ProjectId = new ProjectId(projectId),
            ProjectStageId = new ProjectStageId(stageId),

        };

        await mediator.Send(command);

        return Created();
    }

    /// <summary>
    /// ��������� ������ �� ����
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <param name="stageId">������������� ����� ������</param>
    /// <response code="204"></response>
    /// <response code="404">������ ��� ���� ������ �� ������</response>
    [HttpPatch("{projectId}/stages/{stageId}/grade")]
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GradeProjectStage(Guid projectId, Guid stageId, GradeProjectStageDTO gradeProjectStage)
    {
        var command = new GradeProjectStageCommand()
        {
            ProjectId = new ProjectId(projectId),
            StudentId = new StudentId(gradeProjectStage.StudentId),
            ProjectStageId = new ProjectStageId(stageId),
            Grade = gradeProjectStage.Grade,
        };

        await mediator.Send(command);

        return Created();
    }

    /// <summary>
    /// ��������� �������� ������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <response code="204"></response>
    /// <response code="404">������ ��� ���� ������ �� ������</response>
    [HttpPatch("{projectId}/grade")]
    [ProducesResponseType(201)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GradeProject(Guid projectId, GradeProjectDTO gradeProject)
    {
        var command = new GradeProjectCommand()
        {
            ProjectId = new ProjectId(projectId),
            StudentId = new StudentId(gradeProject.StudentId),
            Grade = gradeProject.Grade,
        };

        await mediator.Send(command);

        return Created();
    }

    /// <summary>
    /// �������� ��������� �������� ������
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <response code="204"></response>
    /// <response code="404">������ ��� ���� ������ �� ������</response>
    [HttpGet("{projectId}/reports/final-grades")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetFinalGradesReport(Guid projectId)
    {
        var query = new GetProjectFinalGradesQuery()
        {
            ProjectId = new ProjectId(projectId)
        };

        var grades = await mediator.Send(query);

        return File(grades.File, "text/csv", grades.Name);
    }

    /// <summary>
    /// �������� ��������� �������������� �����
    /// </summary>
    /// <param name="projectId">������������� ������</param>
    /// <response code="204"></response>
    /// <response code="404">������ ��� ���� ������ �� ������</response>
    [HttpGet("{projectId}/reports/work-assingment")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetWorkAssingmentReport(Guid projectId)
    {
        var query = new GetProjectWorkAssignmentQuery()
        {
            ProjectId = new ProjectId(projectId)
        };

        var assignment = await mediator.Send(query);

        return File(assignment.File, "text/csv", assignment.Name);
    }
}