using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Students;
using SharedKernel;

namespace ProjectManagementSystem.Domain.StudentProjectStages;

public class StudentProjectStage : Entity<StudentProjectStageId>
{
    private StudentProjectStage()
    {
        Id = new StudentProjectStageId();
    }

    public ProjectStage Stage { get; private set; }
    public Student Student { get; private set; }

    public static StudentProjectStage Create(ProjectStage stage, Student student)
    {
        var studentStage = new StudentProjectStage()
        {
            Stage = stage,
            Student = student,
        };

        return studentStage;
    }
}