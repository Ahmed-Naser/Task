using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Core.Domain
{
    public partial class Product : BaseEntity
    {
        private ICollection<ProductPicture> _productPictures;

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the date
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity has been deleted
        /// </summary>
        public bool Deleted { get; set; }

        /// <summary>
        /// Gets or sets the collection of ProductPicture
        /// </summary>
        public virtual ICollection<ProductPicture> ProductPictures
        {
            get => _productPictures ?? (_productPictures = new List<ProductPicture>());
            protected set => _productPictures = value;
        }
    }
}
