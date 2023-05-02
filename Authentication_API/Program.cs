using Authentication_API.Utility;
using Authentication_ApplicationCore.Contract.Repository;
using Authentication_ApplicationCore.Contract.Service;
using Authentication_Infrastructure.Data;
using Authentication_Infrastructure.Repository;
using Authentication_Infrastructure.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Identity;
using Authentication_ApplicationCore.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

builder.Services.AddControllers();
builder.Services.AddLogging();

// Identity Injection
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AuthenticationDbContext>().AddDefaultTokenProviders();

// JWT Injection
builder.Services.AddSingleton<JwtTokenHandler>();

// Repository Injection
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();

// Service Injection
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

var connectionString = Environment.GetEnvironmentVariable("AuthenticationDbContext");
builder.Services.AddDbContext<AuthenticationDbContext>(option => {
    if (connectionString != null && connectionString.Length > 1)
        option.UseSqlServer(connectionString);
    else
        option.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationDbContext"));
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
app.UseAuthorization();

app.MapControllers();

app.Run();

