using Microsoft.EntityFrameworkCore;
using Recruiting_API.Utility;
using Recruiting_ApplicationCore.Contract.Repository;
using Recruiting_ApplicationCore.Contract.Service;
using Recruiting_Infrastructure.Data;
using Recruiting_Infrastructure.Repository;
using Recruiting_Infrastructure.Service;
using JwtAuthenticationManager;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddControllers();
builder.Services.AddLogging();

builder.Services.AddCustomJwttokenService();
// CORS Injection
builder.Services.AddCors(option =>
{
    // AddPolicy -> to add policy defined who can access the microservice
    option.AddDefaultPolicy(policy =>
    {
        // AllowAnyOrigin -> everyone can access the microservice
        // WithOrigins -> specify who can access
        // policy.WithOrigins("https://www.google.com", "https://www.microsoft.com");

        // Any Http method is allowed (ex. Get request to read data from this microservice database
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Repository Injection
builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<IJobRequirementRepository, JobRequirementRepository>();
builder.Services.AddScoped<ISubmissionRepository, SubmissionRepository>();
builder.Services.AddScoped<ISubmissionStatusRepository, SubmissionStatusRepository>();

// Service Injection
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<IJobRequirementService, JobRequirementService>();
builder.Services.AddScoped<ISubmissionService, SubmissionService>();
builder.Services.AddScoped<ISubmissionStatusService, SubmissionStatusService>();

// DbContext Injection
var connectionString = Environment.GetEnvironmentVariable("RecruitingDbContext");
builder.Services.AddDbContext<RecruitingDbContext>(option => {
    if (connectionString != null && connectionString.Length > 1)
        option.UseSqlServer(connectionString);
    else
        option.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDbContext"));
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseMiddleware<MiddlewareExtension>();
}

app.UseAuthentication();
app.UseRouting();
app.UseAuthorization(); // Authenticatation should be on top of Authorization
app.UseCors();
app.MapControllers();

app.Run();

