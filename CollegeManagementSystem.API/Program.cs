using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using System.Reflection;
using static IdentityModel.OidcConstants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(m => m.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "oidc";
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = "http://localhost:5213";
        options.RequireHttpsMetadata = false;

        options.ClientId = "CollegeManagementSystem.API";
        options.ClientSecret = "4ccd8311a94ec24e7db7eaeb10521ffa2ba98df49503db2e1ea3a000beabbabe";

        options.ResponseType = GrantTypes.ClientCredentials;

        options.Scope.Clear();
        options.Scope.Add("openid");

        options.GetClaimsFromUserInfoEndpoint = true;
        options.SaveTokens = true;
    });

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "College management system",
            Version = "v1",
        });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    options.SwaggerEndpoint("/swagger/v1/swagger.json",
    "College management system v1"));
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
