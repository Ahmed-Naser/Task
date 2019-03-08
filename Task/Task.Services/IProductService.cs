using System;
using System.Collections.Generic;
using System.Text;
using Task.Core.Domain;

namespace Task.Services
{
    public partial interface IProductService
    {

        #region Products

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="product">Product</param>
        void DeleteProduct(NaseejProduct product);

        /// <summary>
        /// Gets product
        /// </summary>
        /// <param name="productId">Product identifier</param>
        /// <returns>Product</returns>
        NaseejProduct GetProductById(int productId);

        /// <summary>
        /// Inserts a product
        /// </summary>
        /// <param name="product">Product</param>
        void InsertProduct(NaseejProduct product);

        /// <summary>
        /// Updates the product
        /// </summary>
        /// <param name="product">Product</param>
        void UpdateProduct(NaseejProduct product);

        #endregion

    }
}
