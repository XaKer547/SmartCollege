using ProjectManagementSystem.Application.Models;
using System.Text;

namespace ProjectManagementSystem.Application.Services;

public class ReportService : IReportService
{
    public Task<FileDTO> GetFinalGradesReport(string groupName, IReadOnlyCollection<StudentGradesDTO> studentGrades)
    {
        var builder = new StringBuilder("ФИО,Оценка\n");

        foreach (var studentGrade in studentGrades)
        {
            var value = $"{studentGrade.StudentFullName},{studentGrade.Grade}";

            builder.AppendLine(value);
        }

        var file = new FileDTO()
        {
            File = Encoding.UTF8.GetBytes(builder.ToString()),
            Name = $"Итоговые_оценки_{groupName}.csv"
        };

        return Task.FromResult(file);
    }

    public Task<FileDTO> GetWorkAssignmentReport(string groupName, IReadOnlyCollection<StudentWorkAssignmentDTO> studentWorkAssignments)
    {
        var builder = new StringBuilder("ФИО,Название проекта\n");

        foreach (var studentWorkAssignment in studentWorkAssignments)
        {
            var value = $"{studentWorkAssignment.StudentFullName},{studentWorkAssignment.WorkName}";

            builder.AppendLine(value);
        }

        var file = new FileDTO()
        {
            File = Encoding.UTF8.GetBytes(builder.ToString()),
            Name = $"распределение_работ_{groupName}.csv"
        };

        return Task.FromResult(file);
    }
}
