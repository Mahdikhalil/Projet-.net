using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gp.Domain
{
    public class Facture
    {
        [Key]
        [Column(Order =0)]
        public DateTime DateAchat { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("ClientFk")]
        public Client Client { get; set; }
        [Key]
        [Column(Order = 1)]
        public int ClientFk { get; set; }
        [ForeignKey("ProductFk")]
        public Product Product{ get; set; }
        [Key]
        [Column(Order = 2)]
        public int ProductFk { get; set; }

    }
}
