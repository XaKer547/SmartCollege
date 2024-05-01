using Duende.IdentityServer.Test;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartCollage.SSO;
using SmartCollage.SSO.Data;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAntiforgery();

var identitySettings = builder.Configuration.GetRequiredSection(nameof(IdentityServerSettings))
                                            .Get<IdentityServerSettings>()!;

var connectionString = builder.Configuration.GetConnectionString("LocalConnection");

var migrationsAssembly = Assembly.GetExecutingAssembly().GetName().Name;

builder.Services.AddDbContext<AuthorizationDbContext>(options =>
{
    options.UseSqlServer(connectionString,
         sql => sql.MigrationsAssembly(migrationsAssembly));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;

    options.Lockout.AllowedForNewUsers = false;

    options.User.AllowedUserNameCharacters += " ";

    options.Password.RequiredLength = 6;
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

    options.UserInteraction.LoginUrl = "/login";
})
   .AddInMemoryApiResources(identitySettings.ApiResources)
   .AddInMemoryApiScopes(identitySettings.ApiScopes)
   .AddInMemoryClients(identitySettings.Clients)
   .AddInMemoryIdentityResources(identitySettings.IdentityResources)
   .AddAspNetIdentity<IdentityUser>()
   .AddTestUsers([
       new TestUser()
       {
           SubjectId = "a9ea0f25-b964-409f-bcce-c923266249b4",
           Username = "MickMining",
           Password = "MickPassword",
           Claims = [
               new Claim("given_name", "Mick"),
               new Claim("family_name", "Mining")
               ]
       }
       ]);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAntiforgery();
app.UseAuthentication();

app.UseIdentityServer();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
