using CollegeManagementSystem.Application.Queries.Posts;
using CollegeManagementSystem.Domain.Helpers;
using CollegeManagementSystem.Domain.Services;
using MediatR;
using SharedKernel.DTOs.Posts;
using SmartCollege.SSO.Shared;

namespace CollegeManagementSystem.Application.QueryHandlers.Posts;

public sealed class GetPostsQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetPostsQuery, IReadOnlyCollection<PostDTO>>
{
    private readonly IUnitOfWork unitOfWork = unitOfWork;

    public Task<IReadOnlyCollection<PostDTO>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<PostDTO> posts = null;
        //[.. unitOfWork.Repository.Select(r => new PostDTO
        //{
        //    Id = r.Id,
        //    Name = r.Name
        //})];

        return Task.FromResult(posts);
    }
}
