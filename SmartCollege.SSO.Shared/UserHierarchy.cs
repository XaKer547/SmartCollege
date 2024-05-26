﻿namespace SmartCollege.SSO.Shared;

public class UserHierarchy
{
    private readonly Dictionary<Roles, IReadOnlyCollection<Roles>> _hierarchy;

    public UserHierarchy()
    {
        _hierarchy = new Dictionary<Roles, IReadOnlyCollection<Roles>>
        {
            { Roles.Student, Array.Empty<Roles>() },
            { Roles.Teacher, Array.Empty<Roles>() },
            { Roles.HeadOfDepartment, new [] {
                Roles.Student,
                Roles.Teacher,
                Roles.HeadOfDepartment,
                Roles.ClassroomTeacher,
            } },
            { Roles.ClassroomTeacher, new[]
            {
                Roles.Student
            }}
        };
    }

    public bool CheckHierarchyByRole(Roles createrRole, Roles role)
    {
        var roles = _hierarchy[createrRole];

        return roles.Contains(role);
    }

    public bool CheckHierarchyByRoles(IReadOnlyCollection<Roles> createrRoles, IReadOnlyCollection<Roles> roles)
    {
        foreach (var createrRole in createrRoles)
        {
            foreach (var role in roles)
            {
                if (CheckHierarchyByRole(createrRole, role))
                    return true;
            }
        }

        return false;
    }
}
