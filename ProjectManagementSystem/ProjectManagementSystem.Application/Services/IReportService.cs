using ProjectManagementSystem.Application.Models;

namespace ProjectManagementSystem.Application.Services;

public interface IReportService
{
    Task<FileDTO> GetFinalGradesReport(IReadOnlyCollection<StudentGradesDTO> studentGrades);
    Task<FileDTO> GetWorkAssignmentReport(IReadOnlyCollection<StudentWorkAssignmentDTO> studentWorkAssignments);
}
