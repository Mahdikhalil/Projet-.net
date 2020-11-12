using Gp.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Product
    {

        public int ProductId { get; set; }
        [Required(ErrorMessage ="OBLIGATOIRE !!!")]
        [StringLength(25)]
        [MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="data du production")]
        public DateTime DateProduction { get; set; }

        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]

        public float Price { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Image { get; set; }

        [ForeignKey("CategoryFk")]
        public Category Category { get; set; }

        public int? CategoryFk { get; set; }
       
        public virtual ICollection<Provider> Providers { get; set; }
        public virtual ICollection<Facture> Factures { get; set; }
        public Product(string name, DateTime dateProduction, int quantity, float price, string description)
        {
            Name = name;
            DateProduction = dateProduction;
            Quantity = quantity;
            Price = price;
            Description = description;
        }
        public Product() { }
        public override string ToString()
        {
            return "name ="+Name+" date = "+DateProduction;
        }
        public virtual void GetMyType()
        {
            Console.WriteLine("je suis un produit");
        }
        

    }
}
