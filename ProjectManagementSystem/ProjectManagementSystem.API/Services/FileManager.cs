using FluentValidation;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using ProjectManagementSystem.API.Validators.Grops;
using ProjectManagementSystem.API.Validators.Models;
using ProjectManagementSystem.Application.Models;
using ProjectManagementSystem.Domain.Projects;
using ProjectManagementSystem.Domain.ProjectStages;
using ProjectManagementSystem.Domain.Services;
using ProjectManagementSystem.Infrastucture.Common;

namespace ProjectManagementSystem.API.Services;

public class FileManager(ProjectManagementSystemDbContext context, IWebHostEnvironment webHost) : IFileManager
{
    private readonly ProjectManagementSystemDbContext context = context;
    private readonly IWebHostEnvironment webHost = webHost;

    public async Task<Guid> SaveFile(ProjectStageId projectStageId, IFormFile file)
    {
        var stage = context.ProjectStages.Include(p => p.Project)
            .SingleOrDefault(p => p.Id == projectStageId);

        if (stage is null)
        {
            var error = new ValidationError("", "Данный проект или его этап не существует", "404");

            throw new Validators.Exceptions.ValidationException([error]);
        }

        var name = file.Name + Path.GetExtension(file.FileName);

        var pinnedFile = PinnedFile.Create(stage.Project.Name, stage.Name, name);

        using var stream = File.Create(pinnedFile.GetPath());

        await file.CopyToAsync(stream);

        return pinnedFile.Id;
    }

    public async Task<Guid[]> SaveFiles(ProjectStageId projectStageId, IEnumerable<IFormFile> files)
    {
        var stage = context.ProjectStages.Include(p => p.Project)
         .SingleOrDefault(p => p.Id == projectStageId);

        if (stage is null)
        {
            var error = new ValidationError("", "Данный проект или его этап не существует", "404");

            throw new Validators.Exceptions.ValidationException([error]);
        }

        var filesGuids = new List<Guid>();

        foreach (var file in files)
        {
            var name = file.Name + Path.GetExtension(file.FileName);

            var pinnedFile = PinnedFile.Create(stage.Project.Name, stage.Name, name);

            using var stream = File.Create(pinnedFile.GetPath());

            await file.CopyToAsync(stream);

            filesGuids.Add(pinnedFile.Id);
        }

        return [.. filesGuids];
    }
}