using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        DefectiveProductService _defectiveProductService = new DefectiveProductService();
        ProductReturnService _productReturnService = new ProductReturnService();
        ProductService _productService = new ProductService();

        public ActionResult Index()
        {
            TempData["Products"] = _productService.GetActive();
            return View();
        }

        [HttpPost]
        public ActionResult Index(DefectiveProduct defectiveProduct)
        {
            


                defectiveProduct.Date = DateTime.Now;
                //defectiveProduct.ID = new Guid();
                //var urun  = _defectiveProductService.GetSingle(x=>x.ProductId==defectiveProduct.Product.ID);
                //defectiveProduct.ProductId = urun;
                //var x = _defectiveProductService.GetById(defectiveProduct.Product.ID);
                //defectiveProduct.ID = new Guid();

                if (Session["User"] == null)
                {
                    TempData["Basarisiz"] = "Lütfen önce giriş yapmayı deneyiniz.";
                    return RedirectToAction("Login", "Home");

                }

                _defectiveProductService.Add(defectiveProduct);
                return RedirectToAction("Index");
            
        }

        public ActionResult ReturnProduct()
        {
            TempData["Products"] = _productService.GetActive();
            return View();
        }

        [HttpPost]
        public ActionResult ReturnProduct(ProductReturn productReturn)
        {
            productReturn.Date = DateTime.Now;


            if (Session["User"] == null)
            {
                TempData["Basarisiz"] = "Lütfen önce giriş yapmayı deneyiniz.";
                return RedirectToAction("Login", "Home");

            }

            _productReturnService.Add(productReturn);
            return RedirectToAction("ReturnProduct");
        }
    }
}