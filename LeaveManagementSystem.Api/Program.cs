﻿using AutoMapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Controllers (Critical Missing Line)
builder.Services.AddControllers();  // 👈 Add this

// Database Configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Automatic Migrations (Development Only)
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// Middleware Ordering Fix
app.UseRouting();       // 👈 Doit être avant MapControllers()
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();   // 👈 Active les contrôleurs
app.Run();