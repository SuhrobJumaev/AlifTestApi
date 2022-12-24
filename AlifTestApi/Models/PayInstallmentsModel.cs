using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlifTestApi.Models
{
    public class PayInstallmentsModel
    {
    
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string PhoneNumber { get; set; }
        public decimal CreditRange { get; set; }


    }
}
