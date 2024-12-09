using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManager.API.Models;
using OrderManager.DbContexts;
using OrderManager.Entities;
using OrderManager.Models;

namespace OrderManager.API.Handlers;

public static class OrdersHandlers
{ 
       
    public static async Task<Ok<IEnumerable<OrderDto>>> GetOrdersAsync(
       OrderManagerDbContext orderManagerDbContext,
       [FromServices] IMapper mapper,
       bool includeOrderLines = false)
    {
        var orderEntities = includeOrderLines
            ? await orderManagerDbContext.Orders.Include(o => o.OrderLines).ToListAsync()
            : await orderManagerDbContext.Orders.ToListAsync();
        return TypedResults.Ok(mapper.Map<IEnumerable<OrderDto>>(orderEntities)); 
    }

    public static async Task<Results<NotFound, Ok<OrderDto>>> GetOrderAsync(
        OrderManagerDbContext orderManagerDbContext,
        [FromServices] IMapper mapper, 
        int orderId)
    {
        var orderEntity = await orderManagerDbContext.Orders
            .Include(o => o.OrderLines)
            .FirstOrDefaultAsync(o => o.Id == orderId);

        if (orderEntity == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(mapper.Map<OrderDto>(orderEntity));
    }

    public static async Task<CreatedAtRoute<OrderDto>> CreateOrderAsync(
        OrderManagerDbContext orderManagerDbContext,
        [FromServices] IMapper mapper,
        OrderWithOrderLinesForCreationDto orderWithOrderLinesForCreationDto)
    {
        var orderEntity = mapper.Map<Order>(orderWithOrderLinesForCreationDto);
        orderManagerDbContext.Add(orderEntity);
        await orderManagerDbContext.SaveChangesAsync();

        var orderToReturn = mapper.Map<OrderDto>(orderEntity);

        return TypedResults.CreatedAtRoute(
            orderToReturn,
            "GetOrder",
            new
            {
                orderId = orderToReturn.Id
            });
    }
}
