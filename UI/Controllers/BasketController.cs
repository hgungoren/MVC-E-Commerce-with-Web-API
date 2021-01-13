using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;
using UI.Models.Basket;


namespace UI.Controllers
{
    public class BasketController : Controller
    {
        OrderService _orderService = new OrderService();
        OrderDetailService _orderDetailService = new OrderDetailService();
        ProductService _productService = new ProductService();
        // GET: Basket
        public ActionResult Index()
        {
            if (Session["Basket"] != null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");

        }

        Random rnd = new Random();
        public ActionResult CheckOut()
        {
            AppUser user;
            if (Session["User"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            user = Session["User"] as AppUser;
            if (Session["Basket"] != null)
            {
                CartItem sepet = Session["Basket"] as CartItem;
                Order siparis = new Order();
                siparis.AppUserId = user.ID;
                siparis.OrderDate = DateTime.Now;
                siparis.MasterId = rnd.Next(1, 10000);

                foreach (var item in sepet.MyBasket)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    var product = _productService.GetSingle(x => x.ID == item.ID);
                    orderDetails.Product = product;
                    orderDetails.Quantity = Convert.ToInt32(item.Quantity);
                    orderDetails.UnitPrice = item.Price;
                    orderDetails.TotalPrice = (item.Quantity) * (item.Price);

                    _orderDetailService.Add(orderDetails);
                }
                //todo: master id random oalrak tanımlandığı için daha önce aynı sayı tanımlanmışsa başka bir random atanacak.
                _orderService.Add(siparis);
                TempData["Siparis"] = $"{siparis.MasterId} nolu siparişiniz alınmıştır. ";
                Session.Remove("Basket");
            }
            return View();
        }

        [HttpPost]
        public JsonResult UpdateCart(UpdateCartVM updateCart)
        {
            var cart = Session["Basket"] as CartItem;
            if (Session["Basket"] != null)
            {
                cart = Session["Basket"] as CartItem;
                cart.UpdateProduct(updateCart.Quantity, updateCart.Id);

            }
            return Json(cart);
        }
        [HttpGet]
        public ActionResult DeleteCart(Guid id)
        {
            if (HttpContext.Session["Basket"] != null)
            {
                CartItem cartItem = (CartItem)HttpContext.Session["Basket"];                

                cartItem.RemoveFromCart(id);
                
            }
            return RedirectToAction("Index","Basket");
        }
        
    }
}