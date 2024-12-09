using Microsoft.EntityFrameworkCore;
using OrderManager.API.Extensions;
using OrderManager.API.Repositories;
using OrderManager.API.UnitsOfWork;
using OrderManager.DbContexts;
using OrderManager.Entities;

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

builder.Services.AddScoped<IGenericRepository<Order>, GenericRepository<Order>>();
builder.Services.AddScoped<IGenericRepository<OrderLine>, GenericRepository<OrderLine>>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<CreateOrderWithOrderLinesUnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler();
}

app.UseHttpsRedirection();

app.RegisterOrdersEndpoints();
app.RegisterProductsEndpoints();
app.RegisterVendorsEndpoints();

app.Run();
 