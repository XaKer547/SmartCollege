using CollegeManagementSystem.Domain.Posts;
using CollegeManagementSystem.Infrastucture.Data;

namespace CollegeManagementSystem.API.Validators.Posts;

public class PostExistsValidator(CollegeManagementSystemDbContext context) : EntityExistsValidator<PostId, Post>(context)
{

}
