using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccsess.Model;
using DataAccsess.Interfaces;

namespace DataAccsess.Repository
{
    public class PricesRepository : BaseRepository, IRepository<Prices>
    {
        public PricesRepository(DataModelContainer context) : base(context)
        {
        }

        public void Create(Prices item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Prices item)
        {
            throw new NotImplementedException();
        }

        public Prices Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Prices> GetAll(Expression<Func<Prices, bool>> func = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Prices item)
        {
            throw new NotImplementedException();
        }

  
    }
}