using Gp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Chemical : Product
    {
        public string LabName { get; set; }
        public Adress Adress { get; set; }
        public string City { get; set; }
        public override void GetMyType()
        {
            base.GetMyType();
            Console.WriteLine("Chemical");
        }
    }
}
