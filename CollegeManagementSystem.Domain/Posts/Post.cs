using SharedKernel;

namespace CollegeManagementSystem.Domain.Posts;

public sealed class Post : Entity<PostId>
{
    public string Name { get; private set; }
}
