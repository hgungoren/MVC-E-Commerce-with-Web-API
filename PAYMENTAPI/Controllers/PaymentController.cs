using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models.Basket;

namespace PAYMENTAPI.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateOrder(CartItem cartitem)
        {
            var user = Session["User"] as MODEL.Entities.AppUser;
            Dictionary<string, object> options = new Dictionary<string, object>();
            var basket = Session["Basket"] as UI.Models.Basket.CartItem;
            foreach (var item in basket.MyBasket)
            {
                options.Add("amount", item.SubTotal);

            }
            // Generate random receipt number for order
            Random randomObj = new Random();
            string transactionId = randomObj.Next(10000000, 100000000).ToString();

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_8Fpa4f3WdrjoGg", "PAt174ZGjIG22ojQNE5iLiqX");


            options.Add("receipt", transactionId);
            options.Add("currency", "INR");
            options.Add("payment_capture", "0"); // 1 - automatic  , 0 - manual
                                                 //options.Add("notes", "-- You can put any notes here --");
            Razorpay.Api.Order orderResponse = client.Order.Create(options);
            string orderId = orderResponse["id"].ToString();

            // Create order model for return on view
            OrderModel orderModel = new OrderModel();
            orderModel.orderId = orderResponse.Attributes["id"];
            orderModel.razorpayKey = "rzp_test_8Fpa4f3WdrjoGg";

            orderModel.address = user.Address;
            orderModel.contactNumber = user.PhoneNumber;
            orderModel.email = user.Email;
            orderModel.name = user.Name + " " + user.LastName;


            foreach (var item in basket.MyBasket)
            {
                orderModel.amount = item.SubTotal;
            }



            // Return on PaymentPage with Order data
            return View("PaymentPage", orderModel);
        }

        public class OrderModel
        {
            public string orderId { get; set; }
            public string razorpayKey { get; set; }
            public decimal amount { get; set; }
            public string currency { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string contactNumber { get; set; }
            public string address { get; set; }
            public string description { get; set; }
        }


        [HttpPost]
        public ActionResult Complete()
        {
            // Payment data comes in url so we have to get it from url

            // This id is razorpay unique payment id which can be use to get the payment details from razorpay server
            string paymentId = Request.Params["rzp_paymentid"];

            // This is orderId
            string orderId = Request.Params["rzp_orderid"];

            Razorpay.Api.RazorpayClient client = new Razorpay.Api.RazorpayClient("rzp_test_8Fpa4f3WdrjoGg", "PAt174ZGjlG22ojQNE5iLiqX");

            Razorpay.Api.Payment payment = client.Payment.Fetch(paymentId);

            // This code is for capture the payment 
            Dictionary<string, object> options = new Dictionary<string, object>();
            options.Add("amount", payment.Attributes["amount"]);
            Razorpay.Api.Payment paymentCaptured = payment.Capture(options);
            string amt = paymentCaptured.Attributes["amount"];

            //// Check payment made successfully

            if (paymentCaptured.Attributes["status"] == "captured")
            {
                // Create these action method
                return RedirectToAction("Success");
            }
            else
            {
                return RedirectToAction("Failed");
            }
        }

        public ActionResult Success()
        {
            return View();
        }

        public ActionResult Failed()
        {
            return View();
        }
    }
}