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
        readonly IReadOnlyRepository<PhoneCase> _repository;
        readonly ICurrency _currency;

        public PhoneCaseController(ICurrency currency, IReadOnlyRepository<PhoneCase> pcr)
        {

            _currency = currency;
            _repository = pcr;
           
        }


        public string GetProductType()
        {
            return "Phone Case";
        }

        public IEnumerable<Product> GetCurrencyConvertedItems()
        {
            foreach (var i in _repository.GetAll())
            {
                yield return new Product
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = _currency.ConvertPrice(i.Price),
                    Type = GetProductType()
                };
            }
        }
    }
}
