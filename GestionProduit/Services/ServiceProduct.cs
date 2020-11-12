using Data;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceProduct
    {
        public List<Product> products = new List<Product>();
        public Func<string,List<Product>> FindProduct;
        public Action<Category> ScanProduct;

        //Data 
        public GpContext ctx = new GpContext();
        public void AddProduct(Product p)
        {
            ctx.Products.Add(p);    
        }
        public void SaveChanges()
        {
            ctx.SaveChanges();
        }

        //.
        public ServiceProduct()
        {
            FindProduct = c => {List<Product> lst= new List<Product>();
                foreach (Product p in products)
                {if (p.Name.StartsWith(c))
                        lst.Add(p);
                }
                return lst;
            };

            FindProduct = c =>
            {
                
               return products.Where(p => p.Name.StartsWith(c)).ToList();
               
            };

            ScanProduct = ca =>
            {
                List<string> lstp = new List<string>();
                lstp = products.Where(p => p.Category.CategoryId == ca.CategoryId).OrderBy(p=>p.Price)
                .Select(p=> p.Name).
                ToList();
                foreach (string p in lstp)
                {
                    Console.WriteLine(p);
                }
            };


        }

        public IEnumerable<Chemical> Get5Chemical(float price)
        {
            var req = (from p in products
                      where p.Price > price
                      select p).OfType<Chemical>();
            return req.Skip(2).Take(5);
        }

        public IEnumerable<Chemical> Get5ChemicalLambda(float price)
        {
            return products.Where(p => p.Price > price).OfType<Chemical>().Skip(2).Take(5);
        }

        public float GetAveragePrice()
        {
            return products.Average(p => p.Price);
        }
        
        public float GetMaxPrice()
        {
            return products.Max(p => p.Price);
        }

        public int GetCountProduct(String city)
        {
            return products.OfType<Chemical>().Where(c => c.City == city).Count();
        }

        public IEnumerable<Chemical> GetChemicalCity()
        {
            //return products.OfType<Chemical>().OrderBy(p=>p.City);

            var req = from p in products.OfType<Chemical>()
                      orderby p.City
                      select p;
            return req;

        }



        public void GetChemicalGroupByCity()
        {
            var req=products.OfType<Chemical>().OrderByDescending(p => p.City).GroupBy(c => c.City);
            foreach(var g in req)
            {
                Console.WriteLine(g.Key);
                foreach(var p in g)
                {
                    Console.WriteLine(p.Name);
                }
            }

            var req2 = from prod in products.OfType<Chemical>()
                       orderby prod.City descending
                       group prod by prod.City;
                     


        }







    }
}
