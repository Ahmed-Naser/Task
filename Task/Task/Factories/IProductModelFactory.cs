using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Core.Domain;
using Task.Models;

namespace Task.Factories
{
    public partial interface IProductModelFactory
    {
        /// <summary>
        /// Prepare product model
        /// </summary>
        /// <param name="model">Product model</param>
        /// <param name="product">Product</param>
        /// <returns>Product model</returns>
        ProductModel PrepareProductModel(ProductModel model, NaseejProduct product);
    }
}
