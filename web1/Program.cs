using Microsoft.EntityFrameworkCore;
using Web1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddDbContext<ProductContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ProductDb"),
        sqlOptions => sqlOptions.EnableRetryOnFailure()
    )
);

builder.Services.AddScoped<ProductContext>();

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
