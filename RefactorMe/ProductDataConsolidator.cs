using RefactorMe.DontRefactor.Data;
using RefactorMe.DontRefactor.Data.Implementation;
using RefactorMe.DontRefactor.Models;
using RefactorMe.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RefactorMe
{
    public class ProductDataConsolidator
    {
        public static List<Product> Get() {
            var ps = new List<Product>();
            var currency = new Currency();
            CollectProducts(ps, currency);
            return ps;
        }

        public static List<Product> GetInUSDollars() {
            var ps = new List<Product>();
            var currency = new RateUS();
            CollectProducts(ps, currency);
            return ps;
        }

        public static List<Product> GetInEuros() {
            var ps = new List<Product>();
            var currency = new RateEuro();
            CollectProducts(ps, currency);
            return ps;
        }

        static void CollectProducts(List<Product> ps, ICurrency currency)
        {
            var lawnmoverDB = new LawnmowerRepository();
            var lawnmoverController = new LawnmoverController(ps, currency, lawnmoverDB);
            lawnmoverController.Add();
            var phoneCaseDB = new PhoneCaseRepository();
            var phoneCaseController = new PhoneCaseController(ps, currency, phoneCaseDB);
            phoneCaseController.Add();
            var tshirtDB = new TShirtRepository();
            var tShirtController = new TShirtController(ps, currency, tshirtDB);
            tShirtController.Add();
        }
    }
}
