using Microsoft.EntityFrameworkCore;
using RentalAttireBackend.Application;
using RentalAttireBackend.Infrastracture.Persistence.DataContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

//DBContext
builder.Services.AddDbContext<RentalAttireContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("RentalAttireDB")));

//MediatR
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(AssemblyMarker).Assembly));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
