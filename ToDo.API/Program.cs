using Microsoft.EntityFrameworkCore;
using ToDo.API.Data;
using ToDo.API.Repositories;
using ToDo.API.Repositories.Interfaces;
using ToDo.API.Services;
using ToDo.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoDbConnection")));

builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<IToDoItemService, ToDoItemService>();
builder.Services.AddAutoMapper(typeof(Program));

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
