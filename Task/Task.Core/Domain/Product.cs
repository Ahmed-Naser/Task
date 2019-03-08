using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Core.Domain
{
    public partial class NaseejProduct : BaseEntity
    {

        /// <summary>
        /// Gets or sets the item count
        /// </summary>
        public decimal ItemCount { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal UnitPrices { get; set; }

        /// <summary>
        /// Gets or sets the total
        /// </summary>
        public double Total { get; set; }

        public bool Deleted { get; set; }

    }
}
