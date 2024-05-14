using ProjectManagementSystem.Domain.Groups;
using SharedKernel;

namespace ProjectManagementSystem.Domain.Students;

public sealed class Student : Entity<StudentId>
{
    private Student()
    { }

    public string Firstname { get; private set; }
    public string Middlename { get; private set; }
    public string Lastname { get; private set; }
    public bool Graduated { get; private set; }
    public Group Group { get; private set; }
    public string Email { get; private set; }
}
