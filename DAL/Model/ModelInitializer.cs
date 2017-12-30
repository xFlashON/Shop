using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    class ModelInitializer: CreateDatabaseIfNotExists<Container>
    {
        protected override void Seed(Container context)
        {

            base.Seed(context);

            var pType = new ProductType(){Name = "Группа товара 1"};

            context.ProductTypeSet.Add(pType);

            context.ProductSet.AddRange(Enumerable.Range(1, 10)
                .Select(n => new Product() { Name = $"Товар {n}", ProductType = pType, ShortDescription =$"Описание товара {n}" }));

            context.ProductTypeSet.AddRange(Enumerable.Range(2, 2).Select(x => new ProductType() {Name = $"Группа товара {x}"})
                .ToList());

            context.PriceTypeSet.Add(new PriceType() { Name = "Розничная цена" });

            context.NewsSet.Add(new News() { Date = DateTime.Now, Title = "Ознакомительная информация", Content = "<b>Приветствуем Вас в нашем магазине</b><br> " +
                " Для доступа к настройкам авторизируйтесь <br>" +
                "* первый добавляемый пользователь получает административные права!"});

            context.SaveChanges();

        }
    }
}
