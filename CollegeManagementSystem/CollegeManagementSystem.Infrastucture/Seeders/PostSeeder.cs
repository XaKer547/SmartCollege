using CollegeManagementSystem.Domain.Posts;
using Microsoft.EntityFrameworkCore;
using SmartCollege.SSO.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeManagementSystem.Infrastucture.Seeders
{
    public partial class DbSeeder
    {
        private async Task PostSeeder()
        {
            var roleExists = await _collegeManagementSystemDbContext.Posts.AnyAsync();
            if (!roleExists)
            {
                var roleNames = Enum.GetValues<Roles>();

                foreach (var role in roleNames)
                {
                    _collegeManagementSystemDbContext.AddEntity(new Post
                    {
                        Name = role.ToString()
                    });
                }
            }
        }
    }
}
