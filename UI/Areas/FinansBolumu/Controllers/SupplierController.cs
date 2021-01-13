using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.FinansBolumu.Controllers
{
    public class SupplierController : Controller
    {
        SupplierService _supplierService = new SupplierService();
        ProductService _productService = new ProductService();

        // GET: FinansBolumu/Supplier
        public ActionResult Index(string product)
        {
            ViewBag.Products = _productService.GetDefault(x => x.ProductName == product);
            return View(_supplierService.GetActive());
        }
        public ActionResult AddSupplier()
        {
            ViewBag.Supplier = _supplierService.GetActive();
            return View();
        }
        [HttpPost]
        public ActionResult AddSupplier(Supplier supplier)
        {
            _supplierService.Add(supplier);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateSupplier(Guid id)
        {
            var updated = _supplierService.GetById(id);
            return View(updated);
        }
        [HttpPost]
        public ActionResult UpdateSupplier(Supplier supplier)
        {
            _supplierService.Update(supplier);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSupplier(Guid id)
        {
            _supplierService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}