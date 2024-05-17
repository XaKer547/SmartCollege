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

    public new Roles Roles => Roles.Student;

    public bool Graduated { get; private set; }
    public Group Group { get; private set; }

    public static Student Create(string firstName, string middlename, string lastName, Group group, string email, string password)
    {
        var student = new Student()
        {
            FirstName = firstName,
            MiddleName = middlename,
            LastName = lastName,
            Email = email,
            Group = group,
        };

        student.CreateAccount(password, [Roles.Student]);

        var studentCreatedEvent = new StudentCreatedEvent(student);

        student.AddEvent(studentCreatedEvent);

        return student;
    }
    public void Delete()
    {
        DeleteAccount();

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
    public void Update(string password, bool blocked)
    {
        UpdateAccount(password, [Roles], blocked);

        var studentUpdatedEvent = new StudentUpdatedEvent(this);

        AddEvent(studentUpdatedEvent);
    }

    public new void UpdateAccount(string password, Roles[] roles, bool blocked)
    {
        Update(password, blocked);
    }
}