using Microsoft.EntityFrameworkCore;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {

        public OrderRepository(OrderContext dbcontext) : base(dbcontext)
        {
                
        }

        public async Task<IEnumerable<Order>> GetOrderByUserName(string username)
        {
            var orderList = await _dbcontext.Orders
                                    .Where(o => o.UserName == username)
                                    .ToListAsync();
            return orderList;
        }
    }
}
