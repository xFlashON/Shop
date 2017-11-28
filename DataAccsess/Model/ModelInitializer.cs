using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsess.Model
{
    class ModelInitializer:DropCreateDatabaseAlways<DataModelContainer>
    {
        protected override void Seed(DataModelContainer context)
        {
            var pType = new ProductType(){Name = "Type1"};

            context.ProductTypeSet.Add(pType);
            context.SaveChanges();
            //base.Seed(context);
        }
    }
}
