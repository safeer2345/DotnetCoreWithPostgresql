using FirstProject.Data;
using FirstProject.PlanData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<PlanDataInterface, PlanDataImplementation>();
//builder.Services.AddDbContext<PlanDataContext>(o => o.UseNpgsql(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")));
builder.Services.AddDbContext<PlanDataContext>(o => o.UseNpgsql(builder.Configuration.GetConnectionString("plansDb")));
builder.Services.AddScoped<PlanDataInterface, SqlPlanData>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
