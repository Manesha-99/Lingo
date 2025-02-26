using Lingo.Data;
using Lingo.Mapping;
using Lingo.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<ISlangsRepository, SQLSlangsRepository>();

builder.Services.AddDbContext<LingoDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SlangsDbContextConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
