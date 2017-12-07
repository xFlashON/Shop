using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace DAL.Model
{
    public class Container : DbContext
    {
        public virtual DbSet<Product> ProductSet { get; set; }
        public virtual DbSet<ProductType> ProductTypeSet { get; set; }
        public virtual DbSet<PriceType> PriceTypeSet { get; set; }
        public virtual DbSet<Price> PricesSet { get; set; }
        public virtual DbSet<ProductImage> ProductImageSet { get; set; }
        public virtual DbSet<Order> OrderSet { get; set; }
        public virtual DbSet<OrderRow> OrderRowsSet { get; set; }
        public virtual DbSet<News> NewsSet { get; set; }

        public Container() : base("name=DataContainer")
        {
            Database.SetInitializer(new ModelInitializer());
        }

    }
}
