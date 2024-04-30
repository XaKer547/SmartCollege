using CollegeManagementSystem.Domain.Groups;
using CollegeManagementSystem.Domain.Specializations;
using CollegeManagementSystem.Domain.Students.Events;
using SharedKernel;

namespace CollegeManagementSystem.Domain.Students;

public sealed class Student : Entity
{
    private Student()
    {
        Id = new StudentId();
    }

    public StudentId Id { get; private set; }
    public string Firstname { get; private set; }
    public string Middlename { get; private set; }
    public string Lastname { get; private set; }
    public bool Graduated { get; private set; }
    public Group Group { get; private set; }

    public static Student Create(string firstName, string middlename, string lastName, Group group)
    {
        var student = new Student()
        {
            Firstname = firstName,
            Middlename = middlename,
            Lastname = lastName,
            Group = group
        };

        var studentCreatedEvent = new StudentCreatedEvent()
        {
            Student = student
        };

        student.AddEvent(studentCreatedEvent);

        return student;
    }
    public void Delete()
    {
        var studentDeletedEvent = new StudentDeletedEvent()
        {
            StudentId = Id
        };

        AddEvent(studentDeletedEvent);
    }
    public void Graduate(bool graduated)
    {
        var studentGraduatedEvent = new StudentGraduatedEvent()
        {
            Id = Id,
            Graduated = graduated
        };

        AddEvent(studentGraduatedEvent);
    }
    public void Update(string firstname, string middlename, string lastname, Group group)
    {
        Firstname = firstname;
        Middlename = middlename;
        Lastname = lastname;
        Group = group;

        var studentUpdatedEvent = new StudentUpdatedEvent()
        {
            Student = this
        };

        AddEvent(studentUpdatedEvent);
    }
}
