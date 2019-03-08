using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Core.Domain;
using Task.Infrastructure.Mapper.Extensions;
using Task.Models;
using Task.Services;

namespace Task.Factories
{
    public partial class ProductModelFactory : IProductModelFactory
    {
        #region fields
        private readonly IProductService _productService;
        #endregion

        #region ctor
        public ProductModelFactory(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        public ProductModel PrepareProductModel(ProductModel model, NaseejProduct product)
        {
            if (product != null)
            {
                //fill in model values from the entity
                model = model ?? product.ToModel<ProductModel>();  // Auomapper and dto

                var Product = _productService.GetProductById(product.Id);
            }

            if (product == null)
            {
                if (model.ItemCount > model.Quantity)
                {
                    throw new Exception();
                }

            }

            return model;
        }
    }
}
