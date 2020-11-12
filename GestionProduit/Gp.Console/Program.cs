using Domain;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;


namespace GUI
{
    class Program
    {
     
        static void Main(string[] args)
        {
           
            //****initialiseur d'objet****
            Product p = new Product() {Name="pomme",Price=50.3f,Description="Produit Frais",Quantity=552,DateProduction=DateTime.Now};
            ServiceProduct sp = new ServiceProduct();
            sp.AddProduct(p);
            
            sp.SaveChanges();
            Console.WriteLine("base crée avec succée");
            Console.ReadKey();

        }
    }
}
