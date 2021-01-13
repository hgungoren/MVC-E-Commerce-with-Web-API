using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.SatınAlma.Controllers
{
    public class SellerController : Controller
    {
        SellerService sellerService = new SellerService();
        SellerProductService productService = new SellerProductService();
        
        // GET: SatınAlma/Seller
        public ActionResult Index()
        {
            return View(sellerService.GetActive());
        }
        public ActionResult SellerProductDetail(Guid id)
        {
            SellerProduct sellerProduct = new SellerProduct();
            var sellerid = productService.GetById(id);
            ViewBag.SellerProducts = productService.GetDefault(x=>x.Seller.ID==id).ToList();
            return View(sellerService.GetDefault(x=>x.ID==id));
        }

        //[HttpPost]
        //public ActionResult SellerProductDetail(Seller seller)
        //{
        //    SellerProduct sellerProduct = new SellerProduct();
        //    var name = productService.GetSingle(x => x.Product.ProductName==seller.prod)
        //    return View();


            
        //}
    }
}