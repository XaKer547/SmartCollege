using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Students.Events;
using SharedKernel;

namespace CollegeManagementSystem.Domain.Students;

public sealed class Student : Entity<StudentId>
{
    private Student()
    {
        Id = new StudentId();
    }

    public string FirstName { get; private set; }
    public string MiddleName { get; private set; }
    public string LastName { get; private set; }
    public bool Graduated { get; private set; }
    public Group Group { get; private set; }
    public string Email { get; private set; }

    public static Student Create(string firstName, string middlename, string lastName, Group group)
    {
        var student = new Student()
        {
            FirstName = firstName,
            MiddleName = middlename,
            LastName = lastName,
            Group = group
        };

        var studentCreatedEvent = new StudentCreatedEvent(student);

        student.AddEvent(studentCreatedEvent);

        return student;
    }
    public void Delete()
    {
        var studentDeletedEvent = new StudentDeletedEvent(Id);

        AddEvent(studentDeletedEvent);
    }
    public void Graduate(bool graduated)
    {
        Graduated = graduated;

        var studentGraduatedEvent = new StudentGraduatedEvent(Id, Graduated);

        AddEvent(studentGraduatedEvent);
    }
    public void Update(string firstname, string middlename, string lastname, Group group)
    {
        FirstName = firstname;
        MiddleName = middlename;
        LastName = lastname;
        Group = group;

        var studentUpdatedEvent = new StudentUpdatedEvent(this);

        AddEvent(studentUpdatedEvent);
    }
}
