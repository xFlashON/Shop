using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccsess.Model;

namespace DataAccsess.Repository
{
    public class OrderRepository:BaseRepository,IRepository<Order>
    {
        public OrderRepository(DataModelContainer context) : base(context)
        {
        }

        public IEnumerable<Order> GetAll(Expression<Func<Order, bool>> func = null)
        {
            throw new NotImplementedException();
        }

        public Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Order item)
        {
            throw new NotImplementedException();
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order item)
        {
            throw new NotImplementedException();
        }
    }
}