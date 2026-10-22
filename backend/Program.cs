using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<CantinaDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Cantina")
    )
);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
