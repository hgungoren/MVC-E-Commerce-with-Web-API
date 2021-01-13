using COMMON;
using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.SatınAlma.Controllers
{
    public class BuyProductController : Controller
    {
        SupplierProductService _supplierProductService = new SupplierProductService();
        SupplierContactService supplierContact = new SupplierContactService();
        // GET: SatınAlma/BuyProduct
        public ActionResult BuyProduct()
        {
            return View(_supplierProductService.GetActive());
        }
        [HttpPost]
        public ActionResult BuyProduct(SupplierProduct supplierProduct)
        {
            _supplierProductService.Add(supplierProduct);

            return RedirectToAction("BuyProduct");
        }
        public ActionResult SendMailRequest(Guid id)
        {
            var re = supplierContact.GetById(id);
            return View(re);
        }
        [HttpPost]
        public ActionResult SendMailRequest(SupplierContact supplierProduct)
        {
            if (ModelState.IsValid)
            {
                supplierProduct.Date = DateTime.Now;
                SupplierProductService _supplierProductService = new SupplierProductService();
                var mail = _supplierProductService.GetSingle(x => x.Email == supplierProduct.Email).ToString() ;
                supplierProduct.ID = new Guid();
                TempData["Basarili"] = "Teşekkürler en kısa zamanda tarafınıza dönüş yapılacaktır";
               
                MailSender.SendEmail(supplierProduct.Email, "EvimiKur", supplierProduct.Message);
                

                return RedirectToAction("Success", supplierProduct);
            }

            return View();
        }
        public ActionResult Success(SupplierContact supplierProduct)
        {
            if (supplierProduct == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(supplierProduct);
            }
        }
    }
}