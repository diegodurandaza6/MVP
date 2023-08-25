
using DALC4NET;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace PaymentScheduler
{
    public class TransactionByCard
    {


        private DBHelper _dbHelper = new DBHelper();
        public bool PaymentScheduler()
        {
            PaymentViewModel model = new PaymentViewModel();

            DataTable dt = new DataTable();
            dt = _dbHelper.ExecuteDataTable("sp_recurringpayment", CommandType.StoredProcedure);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Item item = new Item();
                item.name = "Item Name";
                item.currency = "USD";
                item.price = dt.Rows[i]["PlanAmount"].ToString();
                item.quantity = "1";
                item.sku = "sku";

                List<Item> itms = new List<Item>();
                itms.Add(item);
                ItemList itemList = new ItemList();
                itemList.items = itms;

                CreditCardToken credCardToken = new CreditCardToken();
                credCardToken.credit_card_id = dt.Rows[i]["CreditCardId"].ToString();

                //Specify Payment Details
                Details details = new Details();
                details.shipping = "0";
                details.subtotal = dt.Rows[i]["PlanAmount"].ToString();
                details.tax = "0";

                //Specify the Total Amount
                Amount amnt = new Amount();
                amnt.currency = "USD";
                // Total must be equal to the sum of shipping, tax and subtotal.
                amnt.total = dt.Rows[i]["PlanAmount"].ToString();
                amnt.details = details;

                //Create Transaction Object
                Transaction tran = new Transaction();
                tran.amount = amnt;
                tran.description = "This is the recurring payment transaction";
                tran.item_list = itemList;

                //Adding the transaction above to the list
                List<Transaction> transactions = new List<Transaction>();
                transactions.Add(tran);

                FundingInstrument fundInstrument = new FundingInstrument();
                fundInstrument.credit_card_token = credCardToken;

                //Adding the Funding Instrument to the list
                List<FundingInstrument> fundingInstrumentList = new List<FundingInstrument>();
                fundingInstrumentList.Add(fundInstrument);

                Payer payr = new Payer();
                payr.funding_instruments = fundingInstrumentList;
                payr.payment_method = "credit_card";
                //Finally Making payment Object and filling it with values
                Payment pymnt = new Payment();
                pymnt.intent = "sale";
                pymnt.payer = payr;
                pymnt.transactions = transactions;

                try
                {
                    APIContext apiContext = Configuration.GetAPIContext();
                    Payment createdPayment = pymnt.Create(apiContext);

                    DBParameterCollection param = new DBParameterCollection();
                    param.Add(new DBParameter("p_UserId", dt.Rows[i]["UserId"].ToString()));
                    param.Add(new DBParameter("p_PlantId", dt.Rows[i]["PlanId"].ToString()));
                    param.Add(new DBParameter("p_PlanName", dt.Rows[i]["PlanName"].ToString()));
                    param.Add(new DBParameter("p_Amount", dt.Rows[i]["PlanAmount"].ToString()));
                    param.Add(new DBParameter("p_TransactionId", createdPayment.id));
                    param.Add(new DBParameter("p_CreditCardId", dt.Rows[i]["CreditCardId"].ToString()));
                    param.Add(new DBParameter("p_TypeId", 1));

                    _dbHelper.ExecuteNonQuery("sp_MakePayment", param, CommandType.StoredProcedure);

                    string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);

                    string body = string.Empty;
                    using (StreamReader reader = new StreamReader(EmailTempletePath + "PaymentSuccessfully.html"))
                    {
                        body = reader.ReadToEnd();
                    }

                    body = body.Replace("{Name}", dt.Rows[i]["Name"].ToString() + dt.Rows[i]["LastName"].ToString());

                    body = body.Replace("{Amount}", Convert.ToString(dt.Rows[i]["PlanAmount"].ToString()));
                    body = body.Replace("{TransactionId}", createdPayment.id);
                    body = body.Replace("{ProductName}", dt.Rows[i]["PlanName"].ToString());
                    string subject = "Recurring payment successful.";



                    string FromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmail"];
                    string FromEmailPassword = System.Configuration.ConfigurationManager.AppSettings["FromEmailPassword"];
                    string smtphost = System.Configuration.ConfigurationManager.AppSettings["smtphost"];
                    Int32 smtpPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["smtpPort"]);
                    bool EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EnableSsl"]);
                    bool UseDefaultCredentials = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["UseDefaultCredentials"]);

                    MailMessage mailMsg = new MailMessage();
                    mailMsg.IsBodyHtml = true;
                    mailMsg.From = new MailAddress(FromEmail, "mailtosinghnagendra@gmail.com");
                    mailMsg.To.Add(dt.Rows[i]["Email"].ToString());
                    mailMsg.Subject = subject;
                    mailMsg.Body = body;
                    mailMsg.Headers.Add("List-Unsubscribe", "<mailto:" + FromEmail + "?subject=unsubscribe>");
                    mailMsg.Sender = new MailAddress(FromEmail);
                    SmtpClient smtp = new SmtpClient(smtphost, Convert.ToInt32(25));
                    smtp.EnableSsl = EnableSsl;
                    smtp.UseDefaultCredentials = UseDefaultCredentials;
                    mailMsg.IsBodyHtml = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(FromEmail, FromEmailPassword);
                    smtp.Host = smtphost;
                    //smtp.Send(mailMsg);



                }
                catch (Exception ex)
                {

                }
                System.Threading.Thread.Sleep(100);
            }
            return true;
        }

    }
}
