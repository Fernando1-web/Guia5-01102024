using FJMA.API.Endpoints;
using FJMA.API.Models.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FJMAContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

builder.Services.AddScoped<ProductFJMADAL>();

var app = builder.Build();

app.AddProductFJMAEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();