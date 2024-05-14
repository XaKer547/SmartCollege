using SharedKernel;

namespace CollegeManagementSystem.Domain.Posts;

public sealed class PostId : EntityId
{
    public PostId(Guid id) : base(id) { }
    public PostId() : base() { }
}
