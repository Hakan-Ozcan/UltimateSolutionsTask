using BusinessLayer_.Abstract;
using BusinessLayer_.Concrete;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(options =>
   options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
builder.Host.UseSerilog((builderContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(builderContext.Configuration)
    .WriteTo.Logger(Log.Logger)
);
// ---------------Service-------------------- /
builder.Services.AddScoped(typeof(IEmployeeService), typeof(EmployeeManager));
// ----------------DAL------------------ /
builder.Services.AddScoped<IEmployee, GenericRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();  
app.UseAuthorization();

app.MapControllers();

app.Run();
