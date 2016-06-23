using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.DontRefactor.Models;
using RefactorMe.ExchangeRate;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Data;
using RefactorMe.Controller;

namespace RefactorMe
{
   public class TShirtController : IProductController
    {

        IQueryable<TShirt> tshirts;
        TShirtRepository tr;
        public ICurrency iCurrency;
        public List<Product> ps;

        public TShirtController(List<Product> products, ICurrency currency, IReadOnlyRepository<TShirtRepository> tr)
        {
            ps = products;
            iCurrency = currency;
            this.tr = (TShirtRepository)tr;
            tshirts = this.tr.GetAll();
        }


        public string GetProductType()
        {
            return "T-Shirt";
        }
        public void Add()
        {
            foreach (var i in tshirts)
            {
                ps.Add(new Product
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price * iCurrency.GetRate(),
                    Type = GetProductType()
                });
            }
        }
    }
}
