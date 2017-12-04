using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DataAccsess.Model;
using DataAccsess.Interfaces;

namespace DataAccsess.Repository
{
    public class ProductImageRepository:BaseRepository, IRepository<ProductImage>
    {
        public ProductImageRepository(DataModelContainer context) : base(context)
        {
        }

        public IEnumerable<ProductImage> GetAll(Expression<Func<ProductImage, bool>> func = null)
        {
            throw new NotImplementedException();
        }

        public ProductImage Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(ProductImage item)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductImage item)
        {
            throw new NotImplementedException();
        }

        public void Delete(ProductImage item)
        {
            throw new NotImplementedException();
        }
    }
}