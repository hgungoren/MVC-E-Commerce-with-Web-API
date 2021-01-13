using COMMON;
using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.InsanKaynaklari.Controllers
{
    public class HomeController : Controller
    {
        EmployeeService employeeService = new EmployeeService();
        SellerService sellerService = new SellerService();
        // GET: InsanKaynaklari/Home
        [Authorize(Roles ="InsanKaynaklari,Admin")]
        public ActionResult Index()
        {
            ViewBag.Seller = sellerService.GetAll();
            return View(employeeService.GetActive());
        }
        public ActionResult AddEmployee()
        {
            ViewBag.SellerName = sellerService.GetActive();
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee, HttpPostedFileBase imagePath)
        {
            employee.ImagePath = ImageUploader.UploadImage("~/Content/user-image/", imagePath);
            employeeService.Add(employee);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateEmployee(Guid id)
        {
            ViewBag.Sellers = sellerService.GetActive();
            var updated = employeeService.GetById(id);
            return View(updated);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            employeeService.Update(employee);
            return RedirectToAction("Index");

        }

        public ActionResult DeleteEmployee(Guid id)
        {
            employeeService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}