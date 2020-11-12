using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Provider
    {
        [Key]
        public int id { get; set; }
        public string UserName { get; set; }
        // public string Password { get; set; }

        private string password;
        [DataType(DataType.Password)]
        [Required]
        [MaxLength(25)]
        [MinLength(5)]
        public string Password
        {
            get { return password; }
            
            set {
            if ((value.Length>20)||(value.Length <5))
                        {
                    Console.WriteLine("Password doit contenir de 5 à 20 caractéres");
                         }
                else { password = value; }
            }
        }
        // public string ConfirmPassword { get; set; }
        private string confirmPassword;

        [Required]
        [DataType(DataType.Password)]
        [NotMapped]
        [MaxLength(25)]
        [MinLength(5)]
        [Compare("Password",ErrorMessage ="Confirm password doit avoir la même valeur que password")]
        public string ConfirmPassword
        {
            get { return confirmPassword; }

            set
            {
                if (value.Equals(Password))
                {
                    confirmPassword = value;
                }
                else { Console.WriteLine("Password et confirmPassword doivent avoir la même valeur");  }
            }
        }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public DateTime DateCreation { get; set; }
        public bool IsApproved { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Boolean Login(string userName,string password)
        {
            return ((UserName.CompareTo(userName)==0) && (password.CompareTo(Password)==0));
        }
        public Boolean Login(string userName, string password,string email=null)
        {
            if(email!=null)
            return (UserName.Equals(userName) && password.Equals(Password) && email.Equals(Email));
           else
                return ((UserName.CompareTo(userName) == 0) && (password.CompareTo(Password) == 0));
        }

        public static void SetIsApproved(Provider p)
        {
            p.IsApproved = p.Password.Equals(p.ConfirmPassword);
        }

        public static void SetIsApproved(string password,string confirmPassword,Boolean isApproved)
        {
            isApproved = password.Equals(confirmPassword);
        }

        public void Getdetails()
        {
            Console.WriteLine(UserName);
            for(int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine(Products.ElementAt(i));
            }
        }

        public void Getdetailss()
        {
            Console.WriteLine(UserName);
            foreach (Product p in Products)
            {
                Console.WriteLine(p);
            }
        }

        public List<Product> GetProducts(string filterType,string filterValue)
        {
            List<Product> l = new List<Product>();
            switch (filterType)
            {
                case "Name": 
                    foreach(Product p in Products)
                    {
                        if (p.Name.Equals(filterValue))
                            l.Add(p);
                    }break;
                case "Price":
                    foreach (Product p in Products)
                    {
                        if (p.Price==float.Parse(filterValue))
                            l.Add(p);
                    }break;

            }
            return l;
        }

    }
}
