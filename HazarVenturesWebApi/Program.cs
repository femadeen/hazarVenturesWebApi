using HazarVenturesWebApi.HazarVenturesContext;
using HazarVenturesWebApi.Implementations.Repositories;
using HazarVenturesWebApi.Implementations.Services;
using HazarVenturesWebApi.Interfaces.Repositories;
using HazarVenturesWebApi.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(s => s.AddPolicy("RegisterStudent", s =>
{
    s.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();
}));

builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<ILecturerService, LecturerService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<ILecturerRepository, LecturerRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IGeneralService, GeneralService>();




builder.Services.AddDbContext<HazarVenturesDbContext>(options => {
    options.UseMySql(builder.Configuration.GetConnectionString("HazarVenturesWebApi"), new MySqlServerVersion(new Version(8, 0, 22)));
});

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
app.UseCors("RegisterStudent");

app.Run();
