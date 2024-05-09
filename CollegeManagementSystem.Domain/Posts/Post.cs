namespace CollegeManagementSystem.Domain.Posts;

public sealed class Post
{
    public PostId Id { get; init; }
    public string Name { get; private set; }
}
