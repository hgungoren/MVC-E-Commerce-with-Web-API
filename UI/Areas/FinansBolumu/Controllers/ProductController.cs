using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MODEL.Entities;

using MODEL.Context;
using COMMON;

namespace UI.Areas.FinansBolumu.Controllers
{
    public class ProductController : Controller
    {
        SupplierService _supplierService = new SupplierService();
        ProductService _productService = new ProductService();
        SubCategoryService _subCategoryService = new SubCategoryService();
        SellerService _sellerService = new SellerService();

        // GET: FinansBolumu/Product
        public ActionResult Index()
        {
            ViewBag.Supplier = _supplierService.GetActive();
            return View(_productService.GetActive());
        }
        public ActionResult AddProduct()
        {
            ViewBag.Supplier = _supplierService.GetActive();
            ViewBag.SubCategory = _subCategoryService.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase imagePath)
        {

            product.ImagePath = ImageUploader.UploadImage("~/Content/image/", imagePath);
            _productService.Add(product);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateProduct(Guid id)
        {
            ViewBag.SellerName = _sellerService.GetActive();
            ViewBag.Supplier = _supplierService.GetAll();
            ViewBag.SubCategory = _subCategoryService.GetAll();

            var updated = _productService.GetById(id);
            return View(updated);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            ViewBag.SellerName = _sellerService.GetActive();
            ViewBag.Supplier = _supplierService.GetAll();
            ViewBag.SubCategory = _subCategoryService.GetAll();
            _productService.Update(product);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEmployee(Guid id)
        {
            _productService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}