using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RefactorMe.DontRefactor.Models;
using RefactorMe.ExchangeRate;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.Controller;
using RefactorMe.DontRefactor.Data;

namespace RefactorMe
{
   public class PhoneCaseController : IProductController
    {
        public IQueryable<PhoneCase> PhoneCases { get; set; }
        PhoneCaseRepository pcr { get; set; }
        public ICurrency iCurrency { get; set; }
        public List<Product> ps { get; set; }

        public PhoneCaseController(List<Product> products, ICurrency currency, IReadOnlyRepository<PhoneCase> pcr)
        {
            ps = products;
            iCurrency = currency;
            this.pcr = (PhoneCaseRepository)pcr;
            PhoneCases = this.pcr.GetAll();
        }

        public PhoneCaseController()
        {

        }
        public string GetProductType()
        {
            return "Phone Case";
        }

        public void Add()
        {
            foreach (var i in PhoneCases)
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
