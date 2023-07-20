using AutoMapper;
using ECommerce.Api.Orders.Db;
using ECommerce.Api.Orders.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Api.Orders.Providers
{
    public class OrdersProvider : IOrdersProvider
    {
        private OrdersDbContext dbContext { get ; set; }
        private ILogger<OrdersProvider> logger { get; set; }
        private IMapper mapper { get; set; }
        public OrdersProvider(OrdersDbContext dbContext, ILogger<OrdersProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();
        }

        private void SeedData()
        {
            dbContext.Add(new Order() { Id = 1, CustomerId = 2, Items = null, Total = 0 });
            dbContext.Add(new Order() { Id = 2, CustomerId = 1, Items = null, Total = 0 });
            dbContext.Add(new Order() { Id = 3, CustomerId = 4, Items = null, Total = 0 });
        }

        public async Task<(bool isSuccess, IEnumerable<Models.Order> orders, string ErrorMessage)> GetOrdersAsync()
        {
            try
            {
                var orders = await dbContext.Orders.ToListAsync();
                if(orders != null && orders.Any())
                {
                    var result = mapper.Map<IEnumerable<Db.Order>, IEnumerable<Models.Order>>(orders);
                    return (true, result, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool isSuccess, Models.Order order, string ErrorMessage)> GetOrderAsync(int id)
        {
            try
            {
                var order = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == id);
                if (order != null)
                {
                    var result = mapper.Map<Db.Order, Models.Order>(order);
                    return (true, result, null);
                }
                return (false, null, "Not Found");
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }
    }
}
