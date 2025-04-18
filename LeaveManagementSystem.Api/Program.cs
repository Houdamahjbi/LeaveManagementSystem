using AutoMapper;
using Infrastructure.Data;
using LeaveManagementSystem.Application.Features.Commands.Employees;
using LeaveManagementSystem.Application.Interfaces;
using LeaveManagementSystem.Application.Mapping;
using LeaveManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Contrôleurs
builder.Services.AddControllers();

// Base de données
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// MediatR (Configuration Unique)
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(UpdateEmployeeCommand).Assembly));

// AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Migrations (Dev uniquement)
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// Middleware
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.Run();