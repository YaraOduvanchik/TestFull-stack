using System.Data;
using Backend.Application.Clients;
using Backend.Application.Data;
using Backend.Application.DateInterval;
using Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IDbConnection>(sp =>
{
    var configuration = sp.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});

builder.Services.AddScoped<GetTestsDataHandler>();
builder.Services.AddScoped<UploadTestsDataHandler>();

builder.Services.AddScoped<GetClientsWithMoreThanTwoContactsHandler>();
builder.Services.AddScoped<GetClientsWithContactsHandler>();

builder.Services.AddScoped<GetDateIntervalsHandler>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();