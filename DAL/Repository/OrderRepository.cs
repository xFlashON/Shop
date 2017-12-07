using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Model;
using DAL.Interfaces;
using System.Linq;

namespace DAL.Repository
{
    public class OrderRepository:BaseRepository<Order>,IRepository<Order>
    {
        public OrderRepository(Container context) : base(context){}

        public override Order Get(int id)
        {
            return context.OrderSet.AsNoTracking().Include("OrderRows").FirstOrDefault(i => i.Id == id);
        }
    }
}