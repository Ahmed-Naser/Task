using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task.Core.Domain;
using Task.Factories;
using Task.Infrastructure.Mapper.Extensions;
using Task.Models;
using Task.Services;

namespace Task.Controllers
{
    public class ProductController : Controller
    {
        #region fields
        private readonly IProductService _productService;
        private readonly IPictureService _pictureService;
        private readonly IProductModelFactory _productModelFactory;
        #endregion

        #region ctor
        public ProductController(IPictureService pictureService,
               IProductService productService,
               IProductModelFactory productModelFactory)
        {
            _pictureService = pictureService;
            _productService = productService;
            _productModelFactory = productModelFactory;
        }
        #endregion


        #region Methods

        #region Product list / create / edit / delete

        public IActionResult Index()
        {
            return RedirectToAction("List");

        }

        public virtual IActionResult List()
        {
            //prepare model
            var model = _productModelFactory.PrepareProductSearchModel(new ProductSearchModel());

            return View(model);
        }

        public virtual IActionResult Create()
        {
            //prepare model
            var model = _productModelFactory.PrepareProductModel(new ProductModel(), null);

            return View(model);
        }
        [HttpPost]
        public virtual IActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                //product
                var product = model.ToEntity<Product>();
                product.Id = model.Id;
                product.LastUpdated = DateTime.UtcNow;
                _productService.InsertProduct(product);
            }
            return View(model);
        }

        public virtual IActionResult Edit(int id)
        {
            //try to get a product with the specified id
            var product = _productService.GetProductById(id);
            if (product == null || product.Deleted)
                return RedirectToAction("List");

            //prepare model
            var model = _productModelFactory.PrepareProductModel(null, product);

            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Edit(ProductModel model)
        {
            //try to get a product with the specified id
            var product = _productService.GetProductById(model.Id);
            if (product == null || product.Deleted)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                //product
                product.Id = model.Id;
                product = model.ToEntity(product);

                product.LastUpdated = DateTime.UtcNow;
                _productService.UpdateProduct(product);
            }
            //prepare model
            model = _productModelFactory.PrepareProductModel(model, product
);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Delete(int id)
        {
            //try to get a product with the specified id
            var product = _productService.GetProductById(id);
            if (product == null)
                return RedirectToAction("List");

            _productService.DeleteProduct(product);
            return RedirectToAction("List");

        }
        #endregion

        #endregion
    }
}