using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    class ModelInitializer:DropCreateDatabaseAlways <Container>
    {
        protected override void Seed(Container context)
        {

            base.Seed(context);

            var pType = new ProductType(){Name = "Type1"};

            context.ProductTypeSet.Add(pType);

            context.ProductSet.AddRange(Enumerable.Range(1, 10)
                .Select(n => new Product() {Name = $"Product {n}", ProductType = pType, ShortDescription=n.ToString()}));

            context.ProductTypeSet.AddRange(Enumerable.Range(2, 5).Select(x => new ProductType() {Name = $"Type {x}"})
                .ToList()); 


            context.SaveChanges();

        }
    }
}
