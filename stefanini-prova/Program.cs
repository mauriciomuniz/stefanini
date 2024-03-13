using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using stefanini_prova.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEntityFrameworkNpgsql()
    .AddDbContext<Contexto>(options =>
    {
        options.UseNpgsql(conn => conn.MigrationsAssembly("stefanini-prova"));
        options.UseNpgsql(builder.Configuration.GetConnectionString("Postgre")); 
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
