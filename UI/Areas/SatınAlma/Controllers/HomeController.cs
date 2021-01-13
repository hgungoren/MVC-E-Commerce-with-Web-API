using MODEL.Context;
using MODEL.Entities;
using SERVICE.Repository;
using SERVICE.ViewModels.AppUserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.SatınAlma.Controllers
{
    public class HomeController : Controller
    {
        ProductService _productService = new ProductService();
        SellerService _sellerService = new SellerService();
        SupplierService _supplierService = new SupplierService();
        AppUserService _appUserService = new AppUserService();
        SubCategoryService subCategory = new SubCategoryService();
        SupplierService supplierService = new SupplierService();
       

        AppDbContext db = new AppDbContext();
        // GET: SatınAlma/Home
        [Authorize(Roles ="SatinAlma,Admin")]
        public ActionResult Index()
        {
            ViewBag.ProductCount = db.Products.Count();
            ViewBag.SellerCount = db.Sellers.Count();
            ViewBag.SupplierCount = db.Suppliers.Count();
            //ViewBag.SubCats = subCategory.GetDefault(x=>x.ID==id);
            //ViewBag.Suppliers = supplierService.GetAll();
            return View(_productService.GetActive());
        }

        public ActionResult AddProduct()
        {
            ViewBag.SellerName = _sellerService.GetActive();
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product product)
        {

            _productService.Add(product);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateProduct(Guid id)
        {

            var updated = _productService.GetById(id);
            return View(updated);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            _productService.Update(product);
            return RedirectToAction("Index");

        }

        public ActionResult DeleteEmployee(Guid id)
        {
            _productService.Remove(id);
            return RedirectToAction("Index");
        }
        //public ActionResult Login()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Login(LoginVM loginVM)
        //{

        //    if (ModelState.IsValid)
        //    {


        //        var result = _appUserService.Login(loginVM);
        //        if (result)
        //        {

        //            var user = _appUserService.GetUser(loginVM);

        //            Session["User"] = user;

        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ViewBag.Error = "Kullanıcı bulunamadı";
        //            return View();
        //        }



        //    }
        //    return View(loginVM);
        //}
    }
}