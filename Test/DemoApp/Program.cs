using BusinessLayer.Services;
using DataAccessLayer;
using DataAccessLayer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<IPersonLogicService, PersonLogicService>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddScoped<IStudentLogicService, StudentLogicService>();
builder.Services.AddScoped<IStudentService,  StudentService>();

builder.Services.AddScoped<ITeacherLogicService, TeacherLogicService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddDbContext<SchoolDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Local")));

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
