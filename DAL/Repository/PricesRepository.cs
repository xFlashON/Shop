using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Model;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class PricesRepository : BaseRepository<Price>, IRepository<Price>
    {
        public PricesRepository(Container context) : base(context) { }
        
    }
}