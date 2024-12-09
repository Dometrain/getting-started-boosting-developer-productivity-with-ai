using Microsoft.EntityFrameworkCore;
using OrderManager.API.Extensions;
using OrderManager.DbContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// configure EF Core with a connection string from the appsettings file
builder.Services.AddDbContext<OrderManagerDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrderManagerDB"));
}); 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.RegisterOrdersEndpoints();
app.RegisterProductsEndpoints();
app.RegisterVendorsEndpoints();

app.Run();
 