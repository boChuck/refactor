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

        public IQueryable<TShirt> tshirts { get; set; }
        TShirtRepository tr { get; set; }
        public ICurrency iCurrency { get; set; }
        public List<Product> ps { get; set; }

        public TShirtController(List<Product> products, ICurrency currency, IReadOnlyRepository<TShirt> tr)
        {
            ps = products;
            iCurrency = currency;
            this.tr = (TShirtRepository)tr;
            tshirts = this.tr.GetAll();
        }

        public TShirtController()
        {

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
