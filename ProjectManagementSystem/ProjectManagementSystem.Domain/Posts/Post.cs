using SharedKernel;

namespace ProjectManagementSystem.Domain.Posts;

public sealed class Post : Entity<PostId>
{
    public string Name { get; private set; }
}
