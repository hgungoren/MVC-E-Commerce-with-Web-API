using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models.Basket;

namespace UI.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            var basket = Session["Basket"] as CartItem;
            Options options = new Options();
            options.ApiKey = "sandbox-aahiymRipuyibk2FG4xdR8BfB6DFx5s7";
            options.SecretKey = "sandbox-jd0c2GCYPsyFJtJTyxTKfkJKgA9URr5r";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";



            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = "123456789";
            foreach (var item in basket.MyBasket)
            {
                request.Price = item.SubTotal.ToString();
                request.BasketId = item.ID.ToString();
                request.PaidPrice = item.SubTotal.ToString();
            }


            request.Currency = Currency.TRY.ToString();

            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = "https://localhost:44366/"; /// Geri Dönüş Urlsi

            List<int> enabledInstallments = new List<int>();
            enabledInstallments.Add(2);
            enabledInstallments.Add(3);
            enabledInstallments.Add(6);
            enabledInstallments.Add(9);
            request.EnabledInstallments = enabledInstallments;

            Buyer buyer = new Buyer();
            var user = Session["User"] as AppUser;
            buyer.Id = user.ID.ToString();
            buyer.Name = user.Name;
            buyer.Surname = user.LastName;
            buyer.GsmNumber = user.PhoneNumber;
            buyer.Email = user.Email;
            buyer.IdentityNumber = user.TCKN;
            buyer.LastLoginDate = "2020-09-05 12:43:35";
            buyer.RegistrationDate = "2020-09-04 15:12:09";
            buyer.RegistrationAddress = user.Address;
            buyer.Ip = user.CreatedIP;
            buyer.City = user.City;
            buyer.Country = user.Country;
            buyer.ZipCode = user.ZipCode;
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = user.Name + " " + user.LastName;
            shippingAddress.City = user.City;
            shippingAddress.Country = user.Country;
            shippingAddress.Description = user.Address;
            shippingAddress.ZipCode = user.ZipCode;
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = user.Name + " " + user.LastName;
            billingAddress.City = user.City;
            billingAddress.Country = user.Country;
            billingAddress.Description = user.Address;
            billingAddress.ZipCode = user.ZipCode;
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();

            foreach (var item in basket.MyBasket) //Session'da tutmuş oldugum sepette bulunan ürünler
            {
                BasketItem firstBasketItem = new BasketItem();
                firstBasketItem.Id = item.ID.ToString();
                firstBasketItem.Name = item.ProductName;
                firstBasketItem.Category1 = item.SubCategoryName;
                //firstBasketItem.Category2 = "Ürün";
                firstBasketItem.ItemType = BasketItemType.PHYSICAL.ToString();
                firstBasketItem.Price = item.SubTotal.ToString();
                basketItems.Add(firstBasketItem);
            }

            request.BasketItems = basketItems;
            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
            ViewBag.Iyzico = checkoutFormInitialize.CheckoutFormContent; //View Dönüş yapılan yer, Burada farklı yöntemler ile View gönderim yapabilirsiniz.
            return View();
        }
        public ActionResult Sonuc(RetrieveCheckoutFormRequest model)
        {

            string data = "";
            Options options = new Options();
            options.ApiKey = "sandbox-aahiymRipuyibk2FG4xdR8BfB6DFx5s7";
            options.SecretKey = "sandbox-jd0c2GCYPsyFJtJTyxTKfkJKgA9URr5r";
            options.BaseUrl = "https://sandbox-api.iyzipay.com";
            data = model.Token;
            RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest();
            request.Token = data;
            CheckoutForm checkoutForm = CheckoutForm.Retrieve(request, options);
            if (checkoutForm.PaymentStatus == "SUCCESS")
            {

                return RedirectToAction("Onay");
            }

            return View();
        }
    }
    
}