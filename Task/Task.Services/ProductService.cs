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
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductPicture> _productPictureRepository;
        #endregion

        #region ctor
        public ProductService(
            IDbContext dbContext,
            IRepository<Product> productRepository,
            IRepository<ProductPicture> productPictureRepository)
        {
            _dbContext = dbContext;
            _productRepository = productRepository;
            _productPictureRepository = productPictureRepository;

        }
        #endregion

        public virtual void DeleteProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            product.Deleted = true;
            //delete product
            UpdateProduct(product);
        }

        public virtual void DeleteProductPicture(ProductPicture productPicture)
        {
            throw new NotImplementedException();
        }

        public virtual Product GetProductById(int productId)
        {
            if (productId == 0)
                return null;
            return _productRepository.GetById(productId);
        }

        public virtual ProductPicture GetProductPictureById(int productPictureId)
        {
            if (productPictureId == 0)
                return null;

            return _productPictureRepository.GetById(productPictureId);
        }

        public virtual IList<ProductPicture> GetProductPicturesByProductId(int productId)
        {
            var query = from pp in _productPictureRepository.Table
                        where pp.ProductId == productId
                        orderby pp.DisplayOrder, pp.Id
                        select pp;
            var productPictures = query.ToList();
            return productPictures;
        }

        public virtual IDictionary<int, int[]> GetProductsImagesIds(int[] productsIds)
        {
            var productPictures = _productPictureRepository.Table.Where(p => productsIds.Contains(p.ProductId)).ToList();

            return productPictures.GroupBy(p => p.ProductId).ToDictionary(p => p.Key, p => p.Select(p1 => p1.PictureId).ToArray());
        }

        public virtual void InsertProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            //insert
            _productRepository.Insert(product);
        }

        public virtual void InsertProductPicture(ProductPicture productPicture)
        {
            if (productPicture == null)
                throw new ArgumentNullException(nameof(productPicture));

            _productPictureRepository.Insert(productPicture);
        }

        public virtual void UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            //update
            _productRepository.Update(product);
        }

        public virtual void UpdateProductPicture(ProductPicture productPicture)
        {
            if (productPicture == null)
                throw new ArgumentNullException(nameof(productPicture));

            _productPictureRepository.Update(productPicture);
        }

    }
}
