using Duende.IdentityServer.AspNetIdentity;
using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.OpenApi.Models;
using SmartCollege.SSO;
using SmartCollege.SSO.Data;
using SmartCollege.SSO.Data.Entities;
using SmartCollege.SSO.Handlers.Commands;
using SmartCollege.SSO.HostedServices;
using SmartCollege.SSO.Models;
using SmartCollege.SSO.Models.Accounts;
using SmartCollege.SSO.Models.Commands;
using SmartCollege.SSO.Models.Commands.Account;
using SmartCollege.SSO.Models.Commands.RepresentativeOfCompany;
using SmartCollege.SSO.Shared;
using SmartCollege.SSO.Validators;
using SmartCollege.SSO.Validators.AccountByAdmin;
using SmartCollege.SSO.Validators.AccountCommands;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(x =>
{
    x.AddSeq(builder.Configuration.GetSection("SeqLogging"));
});

builder.Services.AddMediatR(x=>
{
    x.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<CreateRepresentativeOfCompanyCommand>, CreateAccountCommandValidator>();
builder.Services.AddScoped<IValidator<UpdatePasswordCommand>, UpdatePasswordCommandValidator>();
builder.Services.AddScoped<IValidator<UpdateRepresentativeOfCompanyCommand>, UpdateAccountCommandValidator>();

builder.Services.AddScoped<IValidator<UpdateAccountByAdminDto>, UpdateAccountByAdminValidator>();
builder.Services.AddScoped<IValidator<CreateAccountByAdminDto>, CreateAccountByAdminValidator>();

builder.Services.AddTransient<UserHierarchy>();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumers(typeof(Program).Assembly);

    x.UsingRabbitMq((context, conf) =>
    {
        conf.Host("localhost", 5672, "/", c =>
        {
            c.Username("guest");
            c.Password("guest");
        });
        conf.ConfigureEndpoints(context);
    });
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder => builder
        .WithOrigins("https://localhost:7137")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddAntiforgery();

var identitySettings = builder.Configuration.GetRequiredSection(nameof(IdentityServerSettings))
                                            .Get<IdentityServerSettings>()!;

builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("RepresentationRolePolicy", x =>
    {
        x.RequireClaim(ClaimsIdentity.DefaultRoleClaimType, Roles.RepresentativeOfTheCompany.ToString());
    });
});

builder.Services.AddDbContext<AuthorizationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("LocalConnection");

    options.UseNpgsql(connectionString);
});

builder.Services.AddHostedService<ApplyMigrationService>();
builder.Services.AddHostedService<InizializationRoleBGService>();

builder.Services.AddIdentity<AccountIdentity, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;

    options.Lockout.AllowedForNewUsers = false;

    options.Password.RequiredLength = 8;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultEmailProvider;
})
    .AddEntityFrameworkStores<AuthorizationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
})
   .AddInMemoryApiResources(identitySettings.ApiResources)
   .AddInMemoryApiScopes(identitySettings.ApiScopes)
   .AddInMemoryClients(identitySettings.Clients)
   .AddInMemoryIdentityResources(identitySettings.IdentityResources)
   .AddAspNetIdentity<AccountIdentity>()
   .AddResourceOwnerValidator<AccountOwnerPasswordValidator>()
   .AddProfileService<ProfileService<AccountIdentity>>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseCors();

app.UseAntiforgery();
app.UseAuthentication();

app.UseIdentityServer();

app.UseAuthorization();

app.MapControllers()
    .RequireCors();

app.Run();
