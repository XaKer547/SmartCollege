using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Students.Events;
using CollegeManagementSystem.Domain.Users;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Domain.Students;

public sealed class Student : User<StudentId>
{
    private Student()
    {
        Id = new StudentId();
    }

    public bool Graduated { get; private set; }
    public Group Group { get; private set; }

    public static Student Create(string firstName, string middlename, string lastName, string email, Group group)
    {
        var student = new Student()
        {
            FirstName = firstName,
            MiddleName = middlename,
            LastName = lastName,
            Email = email,
            Group = group,
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

    public override void Update(string email, string password, Roles[] roles)
    {
        base.Update(email, password, roles);

        var studentUpdatedEvent = new StudentUpdatedEvent(this);

        AddEvent(studentUpdatedEvent);
    }
}