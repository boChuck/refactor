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

        readonly IReadOnlyRepository<TShirt> _repository;
        readonly ICurrency _currency;


        public TShirtController( ICurrency currency, IReadOnlyRepository<TShirt> tr)
        {
            _currency = currency;
            _repository = tr;
        }

       
        public string GetProductType()
        {
            return "T-Shirt";
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
