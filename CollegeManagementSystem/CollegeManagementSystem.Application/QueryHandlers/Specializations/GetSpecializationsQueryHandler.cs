﻿using CollegeManagementSystem.Application.Queries.Specializations;
using CollegeManagementSystem.Domain.Services;
using MediatR;
using SharedKernel.DTOs.Specializations;

namespace CollegeManagementSystem.Application.QueryHandlers.Specializations;

public sealed class GetSpecializationsQueryHandler(ICollegeManagementSystemRepository repository) : IRequestHandler<GetSpecializationsQuery, IReadOnlyCollection<SpecializationDTO>>
{
    public Task<IReadOnlyCollection<SpecializationDTO>> Handle(GetSpecializationsQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<SpecializationDTO> specializations = [.. repository.Specializations.Select(s => new SpecializationDTO
        {
            Id = s.Id.Value,
            Name = s.Name,
        })];

        return Task.FromResult(specializations);
    }
}
