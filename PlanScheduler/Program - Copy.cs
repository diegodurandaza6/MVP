using MySql.Data.MySqlClient;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlanScheduler
{
    class Program
    {
        static string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["Email_Template"]);
        static string connectstring = ConfigurationManager.ConnectionStrings["mySqlCon"].ToString();
        static bool EnableSsl = Convert.ToBoolean(ConfigurationManager.ConnectionStrings["EnableSsl"]);
        static bool UseDefaultCredentials = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["UseDefaultCredentials"]);
        static string FromEmail = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["FromEmail"]);
        static string FromEmailPassword = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["FromEmailPassword"]);
        static string smtphost = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["smtphost"]);
        static string smtpPort = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["smtpPort"]);


        static DataSet ds = new DataSet();
        static DataTable dt = new DataTable();
        private static Mutex mutex1 = null;

        static void Main(string[] args)
        {
            getfollowuprecord();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        StripeConfiguration.ApiKey = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["Secretkey"]);

                        Int64 price = Convert.ToInt64(dt.Rows[i]["Price"]) * 100;

                        string Plan = dt.Rows[i]["PlanName"].ToString();

                        var Product_options = new ProductCreateOptions { Name = "Recurring Payment For " + Plan + " Plan" };
                        var Product_service = new ProductService();
                        var product = Product_service.Create(Product_options);
                        var ProductId = product.Id;

                        var Price_options = new PriceCreateOptions
                        {
                            Product = ProductId,
                            UnitAmount = price,
                            Currency = "usd",
                            Recurring = new PriceRecurringOptions { Interval = "month" },
                        };
                        var Price_service = new PriceService();
                        var Price = Price_service.Create(Price_options);
                        var PriceId = Price.Id;

                        var options = new SubscriptionCreateOptions
                        {
                            Customer = dt.Rows[i]["CreditCardId"].ToString(),
                            Items = new List<SubscriptionItemOptions>
                                {
                                    new SubscriptionItemOptions
                                    {
                                        Price = PriceId,
                                    },
                                }, 
                        };
                        var service = new SubscriptionService();
                        var result = service.Create(options);
                        Console.WriteLine("Payment ");
                         
                        saveRecurringPlan(Convert.ToInt64(dt.Rows[i]["UserId"]), Convert.ToInt64(dt.Rows[i]["PlanId"]), result.Id, result.CustomerId);

                        Console.WriteLine("Data Save"); 
                        string body = string.Empty;
                        using (StreamReader reader = new StreamReader(EmailTempletePath + "PaymentSuccessfully.html"))
                        {
                            body = reader.ReadToEnd();
                        }

                        body = body.Replace("{Name}", dt.Rows[i]["Name"].ToString() + dt.Rows[i]["LastName"].ToString());

                        body = body.Replace("{Amount}", Convert.ToString(dt.Rows[i]["Price"].ToString()));

                        body = body.Replace("{PlanName}", dt.Rows[i]["PlanName"].ToString());
                        string subject = "MVP Talent Market - Recurring plan successful.";

                        MailMessage mailMsg = new MailMessage();
                        mailMsg.IsBodyHtml = true;
                        mailMsg.From = new MailAddress(FromEmail, "MVP Talent Market");
                        mailMsg.To.Add(dt.Rows[i]["Email"].ToString());
                        mailMsg.Subject = subject;
                        mailMsg.Body = body;
                        mailMsg.Headers.Add("List-Unsubscribe", "<mailto:" + FromEmail + "?subject=unsubscribe>");
                        mailMsg.Sender = new MailAddress(FromEmail);
                        SmtpClient smtp = new SmtpClient(Convert.ToString(smtphost), Convert.ToInt32(smtpPort));
                        smtp.EnableSsl = EnableSsl;
                        smtp.UseDefaultCredentials = UseDefaultCredentials;
                        mailMsg.IsBodyHtml = true;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(FromEmail, FromEmailPassword);
                        smtp.Host = smtphost;
                        smtp.Send(mailMsg);
                        Console.WriteLine("email send");
                        System.Threading.Thread.Sleep(60000);
                    }
                    catch (Exception ex)
                    {
                        errorlog(Convert.ToInt64(dt.Rows[i]["UserId"]), ex.Message);
                    }
                    System.Threading.Thread.Sleep(100);
                }
            }
        }

        private static void saveRecurringPlan(Int64 p_UserId, Int64 p_PlantId, string paymentId, string CustomerId)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("p_UserId",  p_UserId),
                   new MySqlParameter("p_PlantId",  p_PlantId),
                    new MySqlParameter("p_paymentId",  paymentId),
                   new MySqlParameter("p_CustomerId",  CustomerId)
            };
            string Query = "call sp_saveRecurringPlan(@p_UserId,@p_PlantId,@p_paymentId,@p_CustomerId)";
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
        }

        private static void errorlog(Int64 p_UserId, string errormessage)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("id",  p_UserId),
                   new MySqlParameter("error",  errormessage)
            };
            string Query = "call sp_Error(@id,@error)";
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
        }



        static DataTable getfollowuprecord()
        {

            dt = MySqlHelper.ExecuteDataset(connectstring, "sp_recurringpayment").Tables[0];
            return dt;
        }

    }
}
