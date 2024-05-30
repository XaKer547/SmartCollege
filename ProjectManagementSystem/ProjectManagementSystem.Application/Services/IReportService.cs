using ProjectManagementSystem.Application.Models;

namespace ProjectManagementSystem.Application.Services;

public interface IReportService
{
    Task<FileDTO> GetFinalGradesReport(string groupName, IReadOnlyCollection<StudentGradesDTO> studentGrades);
    Task<FileDTO> GetWorkAssignmentReport(string groupName, IReadOnlyCollection<StudentWorkAssignmentDTO> studentWorkAssignments);
}
