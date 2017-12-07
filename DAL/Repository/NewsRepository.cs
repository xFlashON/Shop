using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Model;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class NewsRepository:BaseRepository<News>, IRepository<News>
    {
        public NewsRepository(Container context) : base(context) { }

    }
}