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
    public class HomeController : Controller
    {
        CategoryService _categoryService = new CategoryService();
        SubCategoryService _subCategoryService = new SubCategoryService();
        ProductService _productService = new ProductService();
        AppUserService _appUserService = new AppUserService();
        EmployeeService _employeeService = new EmployeeService();
        SellerService _sellerService = new SellerService();
        SupplierPaymentService _supplierPaymentService = new SupplierPaymentService();
        PaymentService _paymentService = new PaymentService();
        SupplierService _supplierService = new SupplierService();
        OrderDetailService _orderDetailService = new OrderDetailService();
        AppDbContext db = new AppDbContext();



        // GET: FinansBolumu/Home
        public ActionResult Index()
        {
            return View(_employeeService.GetActive());
        }

        public ActionResult _PartialDashboard()
        {
            ViewBag.ProductCount = db.Products.Count();
            ViewBag.EmployeeCount = db.Employees.Count();
            return PartialView();
        }

        public ActionResult AddEmployee()
        {
            ViewBag.SellerName = _sellerService.GetActive();
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(Employee employee, HttpPostedFileBase imagePath)
        {
            employee.ImagePath = ImageUploader.UploadImage("~/Content/user-image/", imagePath);
            _employeeService.Add(employee);
            return RedirectToAction("Index");
        }

        public ActionResult UpdateEmployee(Guid id)
        {
            ViewBag.SellerName2 = _sellerService.GetActive();
            var updated = _employeeService.GetById(id);
            return View(updated);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            _employeeService.Update(employee);
            return RedirectToAction("Index");

        }

        public ActionResult DeleteEmployee(Guid id)
        {
            _employeeService.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult SalaryPage()
        {
            return View(_employeeService.GetAll());
        }
        [HttpPost]
        public ActionResult SalaryPage(Guid id)
        {
            ViewBag.Salary = _employeeService.GetAll();
            return View(_employeeService.GetAll());
        }









        public ActionResult Payment(Guid id)
        {
            var getById = _employeeService.GetById(id);

            ViewBag.Payments = _paymentService.GetAll();

            return View(getById);
        }

        [HttpPost]
        public ActionResult Payment(Employee emp)
        {
            Payment payment = new Payment();
            if (emp.PrimShift == 0)
            {
                payment.TotalPrice = emp.Salary;
            }
            else
            {
                payment.TotalPrice = emp.Salary + Convert.ToDecimal(emp.PrimShift);
            }

            payment.EmployeeId = emp.ID;



            Employee employee = new Employee();


            _paymentService.Add(payment);
            return RedirectToAction("Index");
        }













        public ActionResult Permission(Guid id)
        {
            var getById = _employeeService.GetById(id);
            return View(getById);
        }
        [HttpPost]
        public ActionResult Permission(Employee employee)
        {
            _employeeService.Add(employee);
            return View(employee);
        }
        public ActionResult Index2()
        {
            DovizKuruIslemleri islemler = new DovizKuruIslemleri();
            IEnumerable<DovizKuruModel> liste = islemler.DovizKurlari();
            return View(liste);
        }

        public ActionResult DovizKuru(string CurrencyCode)
        {
            DovizKuruIslemleri islemler = new DovizKuruIslemleri();
            var kur = islemler.DovizKurlari().FirstOrDefault(a => a.CurrencyCode.Equals(CurrencyCode));
            if (kur == null)
                return Json("404");
            return Json(kur, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SupplierPayment()
        {
            return View(_supplierService.GetActive());
        }
        [HttpPost]
        public ActionResult SupplierPayment(Guid id, Supplier supplier)
        {
            var result = _supplierService.GetById(id);
            return View();
        }















        public ActionResult SupplierPay(Guid id)
        {
            var getById = _supplierService.GetById(id);
            ViewBag.SupplierPayments = _supplierPaymentService.GetAll();
            return View(getById);
        }

        [HttpPost]
        public ActionResult SupplierPay(Supplier supplier)
        {

            SupplierPayment sp = new SupplierPayment();


            if (supplier.SupplierPayment != 0)
            {
                sp.SupplierPay = Convert.ToDecimal(supplier.SupplierPayment);
            }
            sp.SupplierId = supplier.ID;
            sp.ID = new Guid();
            _supplierPaymentService.Add(sp);

            return RedirectToAction("Index");
        }
    }
}


