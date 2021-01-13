using COMMON;
using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Halklaİliskiler.Controllers
{
    public class ProductController : Controller
    {
        SenderMessageService _senderMessageService = new SenderMessageService();
        DefectiveProductService _defectiveProductService = new DefectiveProductService();
        ProductReturnService _productReturnService = new ProductReturnService();
        SupplierService _supplierService = new SupplierService();
        // GET: Halklaİliskiler/Product
        public ActionResult Index()
        {
            //ViewBag.DefectiveProducts = _supplierService.GetAll();
            return View(_defectiveProductService.GetAll());

        }

        

        public ActionResult Reply(Guid id)
        {
            

            var getById = _senderMessageService.GetById(id);
            return View(getById);
        }

        [HttpPost]
        public ActionResult Reply(SenderMessage senderMessage, string email)
        {
            if (ModelState.IsValid)
            {

                senderMessage.Date = DateTime.Now;
                SenderMessageService _senderMessageService = new SenderMessageService();
                senderMessage.ID = new Guid();

                //if (Session["User"] == null)
                //{
                //    TempData["Basarisiz"] = "Lütfen önce giriş yapmayı deneyiniz.";
                //    return RedirectToAction("Login", "Home");

                //}


                TempData["Basarili"] = " -Mesaj Gönderildi.";
                //string message = "Şİkayetinizi/görüşünüzü";
                MailSender.SendEmail(senderMessage.Email, "EvimiKur", senderMessage.Message);
                _senderMessageService.Add(senderMessage);

                return RedirectToAction("Reply", senderMessage);

            }
            return View();
        }

        public ActionResult GoodsReturn()
        {
            return View(_productReturnService.GetAll());
        }

        //public ActionResult AddProduct()
        //{
        //    ViewBag.DefectiveProduct = _supplierService.GetActive();
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddProduct(DefectiveProduct defectiveProduct, HttpPostedFileBase imagePath)
        //{
        //    defectiveProduct.ImagePath = ImageUploader.UploadImage("~/Content/image/", imagePath);
        //    _defectiveProductService.Add(defectiveProduct);
        //    return RedirectToAction("Index");
        //}
    }
}