using api.Admin.Filters;
using api.Admin.Services;
using api.Department.Repository;
using api.Department.Service;
using api.Employee.Repository;
using api.Employee.Service;
using api.Infrastructure.Database;
using api.Infrastructure.Middleware;
using api.Site.Repository;
using api.Site.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database connection

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

// ----------------- Repositories -------------

builder.Services.AddScoped<ISiteRepository, SiteRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

// ----------------- Services -----------------
builder.Services.AddScoped<ISiteService, SiteService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

builder.Services.AddSingleton<IAuthTokenService, AuthTokenService>(provider =>
{
    var config = provider.GetRequiredService<IConfiguration>();
    var secret = config.GetSection("Env").GetValue<string>("SECRET");
    if (secret == null)
    {
        throw new Exception("Secret is not defined in the configuration file");
    }
    return new AuthTokenService(secret);

});

builder.Services.AddSingleton<AdminAuthorize>();




var app = builder.Build();

// ----------------- Middleware -------------
app.UseMiddleware<ExecptionMiddleware>();

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
