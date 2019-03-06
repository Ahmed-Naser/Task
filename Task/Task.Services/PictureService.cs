using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Core;
using Task.Core.Domain;
using Task.Data;

namespace Task.Services
{
    public partial class PictureService : IPictureService
    {
        #region fields
        private readonly IDbContext _dbContext;
        private readonly IRepository<Picture> _pictureRepository;
        private readonly IRepository<PictureBinary> _pictureBinaryRepository;
        private readonly IRepository<ProductPicture> _productPictureRepository;
        #endregion

        #region ctor
        public PictureService(IDbContext dbContext,
            IRepository<Picture> pictureRepository,
            IRepository<PictureBinary> pictureBinaryRepository,
            IRepository<ProductPicture> productPictureRepository)
        {
            _dbContext = dbContext;
            _pictureRepository = pictureRepository;
            _pictureBinaryRepository = pictureBinaryRepository;
            _productPictureRepository = productPictureRepository;
        }

        public Picture GetPictureById(int pictureId)
        {
            throw new NotImplementedException();
        }
        #endregion

        public IList<Picture> GetPicturesByProductId(int productId, int recordsToReturn = 0)
        {
            if (productId == 0)
                return new List<Picture>();

            var query = from p in _pictureRepository.Table
                        join pp in _productPictureRepository.Table on p.Id equals pp.PictureId
                        orderby pp.DisplayOrder, pp.Id
                        where pp.ProductId == productId
                        select p;

            if (recordsToReturn > 0)
                query = query.Take(recordsToReturn);

            var pics = query.ToList();
            return pics;
        }

        public Picture GetProductPicture(Product product, string attributesXml)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            var productPicture = GetPicturesByProductId(product.Id, 1).FirstOrDefault();
            if (productPicture != null)
                return productPicture;

            return productPicture;
        }

        public Picture InsertPicture(byte[] pictureBinary, string mimeType, string altAttribute = null, string titleAttribute = null, bool isNew = true, bool validateBinary = true)
        {
            var picture = new Picture
            {
                MimeType = mimeType,
                TitleAttribute = titleAttribute,
                IsNew = isNew
            };
            _pictureRepository.Insert(picture);
            return picture;
        }

        public Picture UpdatePicture(int pictureId, byte[] pictureBinary, string mimeType, string seoFilename, string altAttribute = null, string titleAttribute = null, bool isNew = true, bool validateBinary = true)
        {
            var picture = GetPictureById(pictureId);
            if (picture == null)
                return null;
            _pictureRepository.Update(picture);

            return picture;

        }
    }
}
