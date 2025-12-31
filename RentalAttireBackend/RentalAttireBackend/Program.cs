using Microsoft.EntityFrameworkCore;
using RentalAttireBackend.Application;
using RentalAttireBackend.Application.Mapping;
using RentalAttireBackend.Domain.Interfaces;
using RentalAttireBackend.Infrastracture.Persistence.DataContext;
using RentalAttireBackend.Infrastracture.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//DBContext
builder.Services.AddDbContext<RentalAttireContext>(x => x.UseNpgsql(builder.Configuration.GetConnectionString("RentalAttireDB")));

//MediatR
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblies(typeof(AssemblyMarker).Assembly));

//AutoMapper
builder.Services.AddAutoMapper(x => x.AddProfile<MappingProfile>());

//Scopes
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
