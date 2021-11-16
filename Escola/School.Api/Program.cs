using Microsoft.EntityFrameworkCore;
using School.Core.Contexts;
using School.Core.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SchoolConnection");
builder.Services.AddDbContext<DataContext>(options => 
    options.UseSqlServer(connectionString, o => o.MigrationsAssembly("School.Api"))
);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();

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
