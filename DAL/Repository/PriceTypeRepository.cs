using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.Model;
using DAL.Interfaces;

namespace DAL.Repository
{
    class PriceTypeRepository : BaseRepository<PriceType>, IRepository<PriceType>
    {
        public PriceTypeRepository(Container context) : base(context) { }

    }
}
