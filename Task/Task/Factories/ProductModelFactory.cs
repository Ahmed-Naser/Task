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
        private readonly IPictureService _pictureService;

        #endregion

        #region ctor
        public ProductModelFactory(IProductService productService,
               IPictureService pictureService)
        {
            _productService = productService;
            _pictureService = pictureService;
        }
        #endregion

        public ProductModel PrepareProductModel(ProductModel model, Product product)
        {
            if (product != null)
            {
                //fill in model values from the entity
                model = model ?? product.ToModel<ProductModel>();

                var Product = _productService.GetProductById(product.Id);
            }

            if (product == null)
            {
                model.LastUpdated = DateTime.Now;
            }

            return model;
        }

        public ProductSearchModel PrepareProductSearchModel(ProductSearchModel searchModel)
        {
            throw new NotImplementedException();
        }

    }
}
