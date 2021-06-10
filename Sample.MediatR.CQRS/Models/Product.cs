using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.MediatR.CQRS.Models
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(120)]
        public string Barcode { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public decimal BuyingPrice { get; set; }
        public string ConfidentialData { get; set; }
    }
}
