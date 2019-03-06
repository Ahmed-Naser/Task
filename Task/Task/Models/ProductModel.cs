using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task.Models
{
    public partial class ProductModel : BaseNopEntityModel
    {
        public override int Id { get; set; }
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
