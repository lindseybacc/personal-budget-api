using BudgetHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin() // Allow all origins — for development only
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// 2. Add  DbContext with PostgreSQL connection string
builder.Services.AddDbContext<BudgetAppContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 3. Add controllers for API endpoints
builder.Services.AddControllers();

// 4. Add SignalR for real-time
builder.Services.AddSignalR();
builder.Services.AddDbContext<BudgetAppContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// 5. Optional: Add Swagger for API documentation & testing
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
var app = builder.Build();

// Middleware pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS policy
app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthorization();

// Map controllers (API endpoints)
app.MapControllers();

// Map SignalR hub
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Map API controllers
    endpoints.MapHub<BudgetHub>("/budgetHub"); // Keep your SignalR hub
});

app.Run();