
using MvpTelent.Security;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp; 
using System;
using System.Collections.Generic; 
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.Core.Candidate;
using Web.Core.Candidate.Impl;
using Web.Core.Payment;
using Web.Core.Payment.Impl;
using Web.Model.Paypal;

namespace MvpTelent.Controllers
{
    [CustomAuthorization(AccountTypes = new long[] { 3, 2 })]
    public class PaypalController : BaseController
    {
        IPayment _objPayment = new PaymentService();
        ICandidate _IobjCandidate = new CandidateService();

        private String _paypalEnvironment = System.Configuration.ConfigurationManager.AppSettings["mode"]; //live
        private String _clientId = System.Configuration.ConfigurationManager.AppSettings["client_Id"];
        private String _secret = System.Configuration.ConfigurationManager.AppSettings["client_Secret"];
        PaymentViewModel model = new PaymentViewModel();

         

        public async Task<ActionResult> Paypalvtwo(string Cancel = null)
        {
            #region local_variables
             
            if (Session["CurrentPaln_Id"] != null)
            {
                if (Convert.ToInt64(Session["CurrentPaln_Id"]) > 0)
                {
                    model.PlanId = Convert.ToInt64(Session["CurrentPaln_Id"]);
                    _objPayment.GetPlanById(model);
                }
            }  
            MyPaypalPayment.MyPaypalSetup payPalSetup = new MyPaypalPayment.MyPaypalSetup { Environment = _paypalEnvironment, ClientId = _clientId, Secret = _secret };
             
            List<string> paymentResultList = new List<string>();

            #endregion

            #region check_payment_cancellation
             
            if (!string.IsNullOrEmpty(Cancel) && Cancel.Trim().ToLower() == "true")
            {
                paymentResultList.Add("You cancelled the transaction.");
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), "You cancelled the transaction.");
                return RedirectToAction("error", "Home");
                 
            }

            #endregion

            payPalSetup.PayerApprovedOrderId = Request["token"];
            string PayerID = Request["PayerID"];
                       
            if (string.IsNullOrEmpty(PayerID))
            {
                #region order_creation
                
                try
                {
                    
                    payPalSetup.RedirectUrl = Request.Url.Scheme + "://" + Request.Url.Authority + "/Paypal/Paypalvtwo?";
                    HttpResponse response = await MyPaypalPayment.createOrder(payPalSetup, model);

                    var statusCode = response.StatusCode;
                    Order result = response.Result<Order>();
                    Console.WriteLine("Status: {0}", result.Status);
                    Console.WriteLine("Order Id: {0}", result.Id);
                    Console.WriteLine("Intent: {0}", result.CheckoutPaymentIntent);
                    Console.WriteLine("Links:");
                    foreach (PayPalCheckoutSdk.Orders.LinkDescription link in result.Links)
                    {
                        Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                        if (link.Rel.Trim().ToLower() == "approve")
                        {
                            payPalSetup.ApproveUrl = link.Href;
                        }
                    }

                    if (!string.IsNullOrEmpty(payPalSetup.ApproveUrl))
                        return Redirect(payPalSetup.ApproveUrl);
                }
                catch (Exception ex)
                {
                    paymentResultList.Add("There was an error in processing your payment");
                    paymentResultList.Add("Details: " + ex.Message);
                    _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
                    return RedirectToAction("error", "Home");
                }

                #endregion
            }
            else
            {
                #region order_execution
                 
                 HttpResponse response = await MyPaypalPayment.captureOrder(payPalSetup);
                try
                {
                    var statusCode = response.StatusCode;
                    Order result = response.Result<Order>();
                    Console.WriteLine("Status: {0}", result.Status);
                    Console.WriteLine("Capture Id: {0}", result.Id);
                     
                    if (result.Status.Trim().ToUpper() == "COMPLETED")

                    paymentResultList.Add("Payment Successful. Thank you.");
                    paymentResultList.Add("Payment State: " + result.Status);
                    paymentResultList.Add("Payment ID: " + result.Id);

                    #region null_checks
                    if (result.PurchaseUnits != null && result.PurchaseUnits.Count > 0 && result.PurchaseUnits[0].Payments != null && result.PurchaseUnits[0].Payments.Captures != null && result.PurchaseUnits[0].Payments.Captures.Count > 0)
                    #endregion
                    paymentResultList.Add("Transaction ID: " + result.PurchaseUnits[0].Payments.Captures[0].Id);

                    model.result = 1;
                    model.UserId = Convert.ToInt64(Session["Id"]);
                    model.PlanId = model.PlanId;
                    model.Amount = model.Amount;
                    model.PlanName = Convert.ToString(model.PlanName);
                    model.TransactionId = result.PurchaseUnits[0].Payments.Captures[0].Id;
                    model.StatusId = 1;
                    model.CreditCardId = "0";
                    model.PaymentId = result.Id;
                    Session["result.Id"] = result.Id;
                    _objPayment.MakePayment(model);
                }
                catch (Exception ex)
                {
                   
                    paymentResultList.Add("There was an error in processing your payment");
                    paymentResultList.Add("Details: " + ex.Message);
                    _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
                    return RedirectToAction("error", "Home");
                }

                #endregion

            }
            return RedirectToAction("success", "Home");
            
        }

         
        public class MyPaypalPayment
        { 
            public static PayPalHttpClient client(MyPaypalSetup paypalEnvironment)
            {
                PayPalEnvironment environment = null;

                if (paypalEnvironment.Environment == "live")
                {
                    // Creating a live environment
                    environment = new LiveEnvironment(paypalEnvironment.ClientId, paypalEnvironment.Secret);
                }
                else
                {
                    // Creating a sandbox environment
                    environment = new SandboxEnvironment(paypalEnvironment.ClientId, paypalEnvironment.Secret);
                }

                // Creating a client for the environment
                PayPalHttpClient client = new PayPalHttpClient(environment);
                return client;
            }
             
            public async static Task<HttpResponse> createOrder(MyPaypalSetup paypalSetup, PaymentViewModel model)
            {
                HttpResponse response = null;

                try
                {

                    // Construct a request object and set desired parameters
                    // Here, OrdersCreateRequest() creates a POST request to /v2/checkout/orders
                    #region order_creation
                    var order = new OrderRequest()
                    {
                        CheckoutPaymentIntent = "CAPTURE",
                        PurchaseUnits = new List<PurchaseUnitRequest>()
                        {
                            new PurchaseUnitRequest()
                            {
                                Items = new List<Item>()
                                {
                                    new Item()
                                    {
                                        Quantity = "1",
                                        Name = model.PlanName,
                                        Sku = "Sku",
                                        Tax = new PayPalCheckoutSdk.Orders.Money(){ CurrencyCode = "USD", Value = "0" },
                                        UnitAmount = new PayPalCheckoutSdk.Orders.Money(){ CurrencyCode = "USD", Value = "0" }
                                    },
                                },

                                AmountWithBreakdown = new AmountWithBreakdown()
                                {
                                    CurrencyCode = "USD",
                                    Value = model.Amount,

                                    AmountBreakdown = new AmountBreakdown()
                                    {
                                        TaxTotal = new PayPalCheckoutSdk.Orders.Money()
                                        {
                                            CurrencyCode = "USD",
                                            Value = "0"
                                        },
                                        Shipping = new PayPalCheckoutSdk.Orders.Money()
                                        {
                                            CurrencyCode = "USD",
                                            Value = "0"
                                        },
                                        ItemTotal = new PayPalCheckoutSdk.Orders.Money()
                                        {
                                            CurrencyCode = "USD",
                                            Value = model.Amount
                                        }
                                    }
                                }

                            }
                        },
                        ApplicationContext = new ApplicationContext()
                        {
                            ReturnUrl = paypalSetup.RedirectUrl,
                            CancelUrl = paypalSetup.RedirectUrl + "&Cancel=true"
                        }
                    };

                    #endregion

                    //IMPORTANT
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    // Call API with your client and get a response for your call
                    var request = new OrdersCreateRequest();
                    request.Prefer("return=representation");
                    request.RequestBody(order);
                    PayPalHttpClient paypalHttpClient = client(paypalSetup);
                    response = await paypalHttpClient.Execute(request);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);
                    throw;
                }
                return response;
            }
             
            public async static Task<HttpResponse> captureOrder(MyPaypalSetup paypalSetup)
            {
                // Construct a request object and set desired parameters
                // Replace ORDER-ID with the approved order id from create order
                var request = new OrdersCaptureRequest(paypalSetup.PayerApprovedOrderId);
                request.RequestBody(new OrderActionRequest());
                PayPalHttpClient paypalHttpClient = client(paypalSetup);
                HttpResponse response = await paypalHttpClient.Execute(request);
                return response;
            }

            public class MyPaypalSetup
            { 
                public String Environment { get; set; } 
                public String ClientId { get; set; } 
                public String Secret { get; set; } 
                public String RedirectUrl { get; set; } 
                public String ApproveUrl { get; set; } 
                public String PayerApprovedOrderId { get; set; }
            } 
        }
          
       
        /// <summary>
        /// payment
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult MakePaymentSuccess(PaymentViewModel model)
        {
            try
            {
                PaymentViewModel objPaymentViewModel = new PaymentViewModel();
                objPaymentViewModel.PlanId = Convert.ToInt64(model.PlanId);
                _objPayment.GetPlanById(objPaymentViewModel); 

                model.UserId = Convert.ToInt64(Session["Id"]);
                model.PlanId = model.PlanId;
                model.Amount = objPaymentViewModel.Amount;
                model.PlanName = Convert.ToString(objPaymentViewModel.PlanName);
                model.TransactionId = model.subscriptionID;
                model.Status = "1";
                model.CreditCardId = "1";
                model.PaymentId = model.OrderID;
                Session["result.Id"] = model.OrderID;
                _objPayment.MakePayment(model);
                 
            }
            catch (Exception ex)
            {
                _IobjCandidate.Error(Session["Id"] is null ? 0 : Convert.ToInt64(Session["Id"]), Convert.ToString(ex));
            }
            return Json(JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// error
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult test()
        {


          





            Session["CurrentPaln_Id"] = null;
            Session["result.Id"] = null;
            return View(model);
        }


    }
}