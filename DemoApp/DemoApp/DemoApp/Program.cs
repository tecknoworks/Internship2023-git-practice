using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new ProducesAttribute("application/json"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<SchoolContext>(options =>
options.UseSqlServer(builder.Configuration["ConnectionStrings:Local"]));

builder.Services.AddScoped<IStudentsDataService, StudentsDataService>();
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IPersonsDataService, PersonsDataService>();
builder.Services.AddScoped<IPersonsService, PersonsService>();
builder.Services.AddScoped<ITeachersDataService, TeachersDataService>();
builder.Services.AddScoped<ITeachersService, TeachersService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
