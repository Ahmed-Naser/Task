using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    public partial class ProductModel : BaseNopEntityModel
    {
        public override int Id { get; set; }

        [Required]
        public int ItemCount { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrices { get; set; }
        public double Total { get; set; }

    }
}
