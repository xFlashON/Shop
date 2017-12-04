using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccsess.Model;
using DataAccsess.Interfaces;

namespace DataAccsess.Repository
{
    class PriceTypeRepository : BaseRepository, IRepository<PriceType>
    {
        public PriceTypeRepository(DataModelContainer context) : base(context) { }

        public void Create(PriceType item)
        {
            throw new NotImplementedException();
        }

        public void Delete(PriceType item)
        {
            throw new NotImplementedException();
        }

        public PriceType Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PriceType> GetAll(Expression<Func<PriceType, bool>> func = null)
        {
            throw new NotImplementedException();
        }

        public void Update(PriceType item)
        {
            throw new NotImplementedException();
        }
    }
}
