using COMMON;
using CORE.CoreEntity.Enums;
using MODEL.Entities;
using SERVICE.Repository;
using SERVICE.ViewModels;
using SERVICE.ViewModels.AppUserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UI.Filter;
using UI.Models.Basket;
using UI.Roller;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        CategoryService _categoryService = new CategoryService();
        SubCategoryService _subCategoryService = new SubCategoryService();
        ProductService _productService = new ProductService();
        AppUserService _appUserService = new AppUserService();
        AppUserRoleService _appUserRoleService = new AppUserRoleService();
        //ProductService _productService = new ProductService();

        public ActionResult Index()
        {
            TempData["User"] = HttpContext.Session["User"] as AppUser;
            TempData["Category"] = HttpContext.Session["Category"] as Category;
            TempData["SubCategory"] = HttpContext.Session["SubCategory"] as SubCategory;
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.SubCategories = _subCategoryService.GetAll();
            ViewBag.Products = _productService.GetAll();

            return View(_productService.GetAll());
        }


        [AllowAnonymous]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser login)
        {
           
            if (ModelState.IsValid)
            {
                var m = _appUserService.Login(login);
                UserRole userRole = new UserRole();
                login.Role = userRole.GetRolesForUser(login.UserName)[0].ToString();
                if (m)
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, false);
                    
                    var k = _appUserService.GetUser(login);
                    Session["User"] = k;

                    return RedirectToAction("Index", "Home");
                }                

            }
            else
            {
                ViewBag.Error = "Kullanıcı bulunamadı";
                return View();

            }


            return View(login);
        }






        public ActionResult AddToCart(Guid id)
        {


            CartItem basket = Session["Basket"] == null ? new CartItem() : Session["Basket"] as CartItem;


            Product eklenecekUrun = _productService.GetById(id);
            Cart cart = new Cart();
            cart.ID = eklenecekUrun.ID;
            cart.Price = eklenecekUrun.UnitPrice;
            cart.ImagePath = eklenecekUrun.ImagePath;
            cart.ProductName = eklenecekUrun.ProductName;
            cart.SubCategoryName = _subCategoryService.GetById(eklenecekUrun.SubCategoryId).SubCategoryName;
            basket.AddProduct(cart);
            Session["Basket"] = basket;
            return RedirectToAction("Index");
        }
        public ActionResult Products()
        {
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.SubCategories = _subCategoryService.GetAll();
            return View(_productService.GetAll());
        }

        public ActionResult ProductDetail(Guid id)
        {

            ViewBag.Products = _productService.GetAll();
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.SubCategories = _subCategoryService.GetAll();
            Product pr = new Product();
            var p = _productService.GetDefault(x => x.ID == id);
            return View(p);
        }


        public ActionResult ProductsByCategory(Guid id)
        {
            ViewBag.Categories = _categoryService.GetAll();
            ViewBag.SubCategories = _subCategoryService.GetAll();
            return View(_productService.GetProductsByCategoryId(id));
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Register(AppUser model, HttpPostedFileBase imagePath)
        {
            model.ImagePath = ImageUploader.UploadImage("~/Content/user-image/", imagePath);

            var result = _appUserService.Any(x => x.Email == model.Email);
            if (result)
            {
                TempData["Error"] = $"{model.Email} daha önce kayıt edilmiş.";
                return View();
            }
            else
            {
                if (_appUserService.Any(x => x.UserName == model.UserName))
                {
                    TempData["Error"] = $"{model.UserName} daha önce kayıt edilmiş.";
                    return View();
                }
                else
                {
                    model.ActivationId = Guid.NewGuid();
                    _appUserService.Add(model);
                    string message = $"Kullanıcı başarılı şekilde oluşturuldu.\nkayıt işlemini tamamlamak için lütfen aşağıdaki linki tıklayın.\n" + "https://localhost:44347/" + "Home/Complete/" + model.ActivationId;
                    MailSender.SendEmail(model.Email, "Kayıt İşlemi", message);
                    return RedirectToAction("Success", model);
                }

            }

        }


        public ActionResult Success(AppUser model)
        {
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Complete(Guid id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var result = _appUserService.Any(x => x.ActivationId == id);
                if (result)
                {
                    AppUser user = _appUserService.GetSingle(x => x.ActivationId == id);
                    user.IsActive = true;
                    _appUserService.Update(user);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }

}
