using System.Data;
using System.Data.SqlClient;
using Interview_API.Utility;
using Interview_ApplicationCore.Contract.Repository;
using Interview_ApplicationCore.Contract.Service;
using Interview_Infrastructure.Data;
using Interview_Infrastructure.Repository;
using Interview_Infrastructure.Service;
using JwtAuthenticationManager;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddControllers();
builder.Services.AddLogging();

// JWT Service Injcetion
builder.Services.AddCustomJwttokenService();

// Repository Injection
builder.Services.AddScoped<IInterviewRepository, InterviewRepository>();
builder.Services.AddScoped<IInterviewerRepository, InterviewerRepository>();
builder.Services.AddScoped<IInterviewFeedbackRepository, InterviewFeedbackRepository>();
builder.Services.AddScoped<IInterviewTypeRepository, InterviewTypeRepository>();
builder.Services.AddScoped<IRecruiterRepository, RecruiterRepository>();

// Service Injection
builder.Services.AddScoped<IInterviewerService, InterviewerService>();
builder.Services.AddScoped<IInterviewService, InterviewService>();
builder.Services.AddScoped<IInterviewFeedbackService, InterviewFeedbackService>();
builder.Services.AddScoped<IInterviewTypeService, InterviewTypeService>();
builder.Services.AddScoped<IRecruiterService, RecruiterService>();

builder.Services.AddScoped<InterviewDbContext, InterviewDbContext>();
//var connectionString = Environment.GetEnvironmentVariable("InterviewDbContext");
// Inject IDbConnection, with implementation from SqlConnection class.
//builder.Services.AddTransient<IDbConnection>(sp => new SqlConnection(connectionString));

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

// Authentication -> Routing -> Authorization
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();

