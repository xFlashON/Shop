using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccsess.Model;

namespace DataAccsess.Repository
{
    public class NewsRepository:BaseRepository, IRepository<News>
    {
        public NewsRepository(DataModelContainer context) : base(context)
        {
        }

        public IEnumerable<News> GetAll(Expression<Func<News, bool>> func = null)
        {
            throw new NotImplementedException();
        }

        public News Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(News item)
        {
            throw new NotImplementedException();
        }

        public void Update(News item)
        {
            throw new NotImplementedException();
        }

        public void Delete(News item)
        {
            throw new NotImplementedException();
        }
    }
}