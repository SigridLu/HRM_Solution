using Microsoft.EntityFrameworkCore;
using Onboarding_API.Utility;
using Onboarding_ApplicationCore.Contract.Repository;
using Onboarding_ApplicationCore.Contract.Service;
using Onboarding_Infrastructure.Data;
using Onboarding_Infrastructure.Repository;
using Onboarding_Infrastructure.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddControllers();
builder.Services.AddLogging();

// Repository Injection
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeCategoryRepository, EmployeeCategoryRepository>();
builder.Services.AddScoped<IEmployeeStatusRepository, EmployeeStatusRepository>();
builder.Services.AddScoped<IEmployeeRoleRepository, EmployeeRoleRepository>();

// Service Injection
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeCategoryService, EmployeeCategoryService>();
builder.Services.AddScoped<IEmployeeStatusService, EmployeeStatusService>();
builder.Services.AddScoped<IEmployeeRoleService, EmployeeRoleService>();

var connectionString = Environment.GetEnvironmentVariable("OnboardingDbContext");
builder.Services.AddDbContext<OnboardingDbContext>(option => {
    if (connectionString != null && connectionString.Length > 1)
        option.UseSqlServer(connectionString);
    else
        option.UseSqlServer(builder.Configuration.GetConnectionString("OnboardingDbContext"));
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

app.UseAuthorization();

app.MapControllers();

app.Run();

