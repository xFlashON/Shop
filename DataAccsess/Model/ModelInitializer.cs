using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Model
{
    class ModelInitializer:CreateDatabaseIfNotExists <DataModelContainer>
    {
        protected override void Seed(DataModelContainer context)
        {

            base.Seed(context);

            var pType = new ProductType(){Name = "Type1"};

            context.ProductTypeSet.Add(pType);

            context.ProductSet.AddRange(Enumerable.Range(1, 10)
                .Select(n => new Product() {Name = $"Product {n}", ProductType = pType}));


            context.SaveChanges();

        }
    }
}
