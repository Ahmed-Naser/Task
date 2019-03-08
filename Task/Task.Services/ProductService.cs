using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Core;
using Task.Core.Domain;
using Task.Data;

namespace Task.Services
{
    public partial class ProductService : IProductService
    {
        #region fields
        private readonly IDbContext _dbContext;
        private readonly IRepository<NaseejProduct> _productRepository;
        #endregion

        #region ctor
        public ProductService(
            IDbContext dbContext,
            IRepository<NaseejProduct> productRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
        }
        #endregion

        public virtual void DeleteProduct(NaseejProduct product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            product.Deleted = true;
            //delete product
            UpdateProduct(product);
        }

        public virtual NaseejProduct GetProductById(int productId)
        {
            if (productId == 0)
                return null;
            return _productRepository.GetById(productId);
        }

        public virtual void InsertProduct(NaseejProduct product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            //insert
            _productRepository.Insert(product);
        }

        public virtual void UpdateProduct(NaseejProduct product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            //update
            _productRepository.Update(product);
        }

    }
}
