using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DAL.Model;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class ProductImageRepository:BaseRepository<ProductImage>, IRepository<ProductImage>
    {
        public ProductImageRepository(Container context) : base(context) { }
        
    }
}