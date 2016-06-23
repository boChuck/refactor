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
    public class LawnmoverController : IProductController
    {
        public IQueryable<Lawnmower> lawnmovers;
        LawnmowerRepository lr;
        public ICurrency iCurrency;
        public List<Product> ps;


        public LawnmoverController(List<Product> products, ICurrency currency, IReadOnlyRepository<LawnmowerRepository> lr)
        {
            ps = products;
            iCurrency = currency;
            this.lr = (LawnmowerRepository)lr;
            lawnmovers = this.lr.GetAll();
        }

        public string GetProductType()
        {
            return "Lawnmower";
        }

        public void Add()
        {
            foreach (var i in lawnmovers)
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
