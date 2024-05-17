﻿using CollegeManagementSystem.Domain.Employees;
using CollegeManagementSystem.Infrastucture.Data;

namespace CollegeManagementSystem.API.Validators.Employees;

public class EmployeeExistsValidator(CollegeManagementSystemDbContext context) : UserExistsValidator<EmployeeId, Employee>(context)
{

}
