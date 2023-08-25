using MySql.Data.MySqlClient;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace PaymentScheduler
{
    public class Program
    {
        static string emailtemplete = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["emailtemplete"]);
        static string connectstring = ConfigurationManager.ConnectionStrings["mySqlCon"].ToString();
        const string appName = "Payment Service";
        static bool EnableSsl = Convert.ToBoolean(ConfigurationManager.ConnectionStrings["EnableSsl"]);
        static bool UseDefaultCredentials = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["UseDefaultCredentials"]);
        static string FromEmail = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["FromEmail"]);
        static string FromEmailPassword = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["FromEmailPassword"]);
        static string SmtpHost = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["smtphost"]);
        static string smtpPort = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["smtpPort"]);


        static DataSet ds = new DataSet();
        private static Mutex mutex = null;
    
        static void Main(string[] args)
        {

           







            //Item item = new Item();
            //item.name = "Item Name";
            //item.currency = "USD";
            //item.price = "1";
            //item.quantity = "1";
            //item.sku = "sku";

            //List<Item> itms = new List<Item>();
            //itms.Add(item);
            //ItemList itemList = new ItemList();
            //itemList.items = itms;

            //CreditCardToken credCardToken = new CreditCardToken();
            //credCardToken.credit_card_id = "cardId"; // Set card Id generate by paypal

            //Details details = new Details();
            //details.shipping = "0";
            //details.subtotal = "1";
            //details.tax = "0";

            ////Specify the Total Amount
            //Amount amnt = new Amount();
            //amnt.currency = "USD";
            //// Total must be equal to the sum of shipping, tax and subtotal.
            //amnt.total = "1";
            //amnt.details = details;

            ////Create Transaction Object
            //Transaction tran = new Transaction();
            //tran.amount = amnt;
            //tran.description = "This is the recurring payment transaction";
            //tran.item_list = itemList;

            ////Adding the transaction above to the list
            //List<Transaction> transactions = new List<Transaction>();
            //transactions.Add(tran);

            //FundingInstrument fundInstrument = new FundingInstrument();
            //fundInstrument.credit_card_token = credCardToken;

            ////Adding the Funding Instrument to the list
            //List<FundingInstrument> fundingInstrumentList = new List<FundingInstrument>();
            //fundingInstrumentList.Add(fundInstrument);

            //Payer payr = new Payer();
            //payr.funding_instruments = fundingInstrumentList;
            //payr.payment_method = "credit_card";
            ////Finally Making payment Object and filling it with values
            //Payment pymnt = new Payment();
            //pymnt.intent = "sale";
            //pymnt.payer = payr;
            //pymnt.transactions = transactions;

            //APIContext apiContext = Configuration.GetAPIContext();
            //Payment createdPayment = pymnt.Create(apiContext);
        }

    }
}
