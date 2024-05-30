using ProjectManagementSystem.Application.Models;

namespace ProjectManagementSystem.Application.Services;

public class ReportService : IReportService
{
    public Task<FileDTO> GetFinalGradesReport(IReadOnlyCollection<StudentGradesDTO> studentGrades)
    {
        throw new NotImplementedException();
    }

    public Task<FileDTO> GetWorkAssignmentReport(IReadOnlyCollection<StudentWorkAssignmentDTO> studentWorkAssignments)
    {
        throw new NotImplementedException();
    }
}
