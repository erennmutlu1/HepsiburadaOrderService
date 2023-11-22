using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaOrderService.Models.HepsiburadaContext
{
   public class HepsiburadaPriceContext
    {
        [Key]
        public long Id { get; set; }
        public string currency { get; set; }
        public double amount { get; set; }
    }
}
