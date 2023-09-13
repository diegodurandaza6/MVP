using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace EmailService
{
    public class Program
    {
        static string connectstring = ConfigurationManager.ConnectionStrings["mySqlCon"].ToString();
        static string emailtemplete = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["emailtemplete"]);

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
            const string appName = " follow up Service Application";
            bool createdNew;
            mutex = new Mutex(true, appName, out createdNew);
            Console.WriteLine("start");
            if (!createdNew)
            {
                Console.WriteLine(appName + " is already running & press any key for exist.");
                Console.ReadKey();
                return;
            }
            getfollowuprecord();

            try
            {
                //------- 3 follow up 
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Console.WriteLine("Remainder 3 start");
                    MailMessage mailMsg = new MailMessage();
                    Int64 Id = Convert.ToInt64(ds.Tables[0].Rows[i]["Id"]);

                    string path = emailtemplete + "3followup.html";

                    using (StreamReader reader = new StreamReader(path))
                    {
                        mailMsg.Body = reader.ReadToEnd();

                        mailMsg.Body = mailMsg.Body.Replace("@TemplateRemainder3", ds.Tables[0].Rows[i]["Description3"].ToString());

                        mailMsg.Body = mailMsg.Body.Replace("@MainEmailTemplate", ds.Tables[0].Rows[i]["Description"].ToString());
                        mailMsg.Body = mailMsg.Body.Replace("@MaineMailSentDate", Convert.ToDateTime(ds.Tables[0].Rows[i]["createdate"]).ToString("f"));

                        mailMsg.Body = mailMsg.Body.Replace("@EmailTemplateRemainder1", ds.Tables[0].Rows[i]["Description1"].ToString());
                        mailMsg.Body = mailMsg.Body.Replace("@Reminder1SentDate", Convert.ToDateTime(ds.Tables[0].Rows[i]["FirstFollowDate"]).ToString("f"));

                        mailMsg.Body = mailMsg.Body.Replace("@EmailTemplateRemainder2", ds.Tables[0].Rows[i]["Description2"].ToString());
                        mailMsg.Body = mailMsg.Body.Replace("@Reminder2SentDate", Convert.ToDateTime(ds.Tables[0].Rows[i]["secondFollowDate"]).ToString("f"));

                    }

                    mailMsg.Body = mailMsg.Body.Replace("@name", ds.Tables[0].Rows[i]["Name"].ToString() + " " + ds.Tables[0].Rows[i]["LastName"].ToString());
                    mailMsg.From = new MailAddress(FromEmail, "MVP Talent Market");
                    mailMsg.To.Add(ds.Tables[0].Rows[i]["Email"].ToString());
                    //mailMsg.CC.Add("nick@mail.ishoresoftware.com");
                    mailMsg.Subject = ds.Tables[0].Rows[i]["Subject"].ToString();
                    mailMsg.IsBodyHtml = true;
                    string bodytext = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title>My Proposal</title><meta http-equiv='Content-Type' content='text/html;charset=ISO-8859-1'></head><body>@body</body></html>";
                    mailMsg.Body = bodytext.Replace("@body", mailMsg.Body);

                    AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, null, "text/plain");
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, null, "text/html");

                    plainView.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                    htmlView.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

                    mailMsg.AlternateViews.Add(plainView);
                    mailMsg.AlternateViews.Add(htmlView);

                    mailMsg.SubjectEncoding = System.Text.Encoding.UTF8;
                    mailMsg.BodyEncoding = System.Text.Encoding.UTF8;

                    mailMsg.Headers.Add("List-Unsubscribe", "<mailto:" + FromEmail + "?subject=unsubscribe>");
                    mailMsg.Sender = new MailAddress(FromEmail);

                    SmtpClient smtp = new SmtpClient(smtpPort, Convert.ToInt32(smtpPort));
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Host = SmtpHost;
                    smtp.EnableSsl = EnableSsl;
                    smtp.UseDefaultCredentials = UseDefaultCredentials;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(FromEmail, FromEmailPassword);
                    if (i == 0)
                    {
                        sendemail(mailMsg.Subject, mailMsg.Body);
                    }
                    smtp.Send(mailMsg);
                    updatefollowuprecord(Id, 4);
                    Console.WriteLine("Sent");
                    //Random random = new Random();
                    //int randomNumber = random.Next(60000, 120000);
                    System.Threading.Thread.Sleep(60000);
                }
                //------- 2 follow up 
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    Console.WriteLine("Remainder 2 start");
                    MailMessage mailMsg = new MailMessage();
                    Int64 Id = Convert.ToInt64(ds.Tables[1].Rows[i]["Id"]);

                    string path = emailtemplete + "2followup.html";
                    using (StreamReader reader = new StreamReader(path))
                    {
                        mailMsg.Body = reader.ReadToEnd();

                        mailMsg.Body = mailMsg.Body.Replace("@EmailTemplateRemainder2", ds.Tables[1].Rows[i]["Description2"].ToString());

                        mailMsg.Body = mailMsg.Body.Replace("@EmailTemplateRemainder1", ds.Tables[1].Rows[i]["Description1"].ToString());
                        mailMsg.Body = mailMsg.Body.Replace("@Reminder1SentDate", Convert.ToDateTime(ds.Tables[1].Rows[i]["FirstFollowDate"]).ToString("f"));

                        mailMsg.Body = mailMsg.Body.Replace("@MainEmailTemplate", ds.Tables[1].Rows[i]["Description"].ToString());
                        mailMsg.Body = mailMsg.Body.Replace("@MaineMailSentDate", Convert.ToDateTime(ds.Tables[1].Rows[i]["secondFollowDate"]).ToString("f"));

                    }

                    mailMsg.Body = mailMsg.Body.Replace("@name", ds.Tables[1].Rows[i]["Name"].ToString() + " " + ds.Tables[1].Rows[i]["LastName"].ToString());
                    mailMsg.From = new MailAddress(FromEmail, "MVP Talent Market");
                    mailMsg.To.Add(ds.Tables[1].Rows[i]["Email"].ToString());
                   // mailMsg.CC.Add("nick@mail.ishoresoftware.com");
                    mailMsg.Subject = ds.Tables[1].Rows[i]["Subject"].ToString();
                    mailMsg.IsBodyHtml = true;

                    string bodytext = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title>My Proposal</title><meta http-equiv='Content-Type' content='text/html;charset=ISO-8859-1'></head><body>@body</body></html>";
                    mailMsg.Body = bodytext.Replace("@body", mailMsg.Body);

                    AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, null, "text/plain");
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, null, "text/html");

                    plainView.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                    htmlView.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

                    mailMsg.AlternateViews.Add(plainView);
                    mailMsg.AlternateViews.Add(htmlView);

                    mailMsg.SubjectEncoding = System.Text.Encoding.UTF8;
                    mailMsg.BodyEncoding = System.Text.Encoding.UTF8;

                    mailMsg.Headers.Add("List-Unsubscribe", "<mailto:" + FromEmail + "?subject=unsubscribe>");
                    mailMsg.Sender = new MailAddress(FromEmail);

                    SmtpClient smtp = new SmtpClient(smtpPort, Convert.ToInt32(smtpPort));
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Host = SmtpHost;
                    smtp.EnableSsl = EnableSsl;
                    smtp.UseDefaultCredentials = UseDefaultCredentials;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(FromEmail, FromEmailPassword);
                    if (i == 0)
                    {
                        sendemail(mailMsg.Subject, mailMsg.Body);
                    }
                    smtp.Send(mailMsg);
                    updatefollowuprecord(Id, 3);
                    Console.WriteLine("Sent");
                    System.Threading.Thread.Sleep(60000);
                }
                //------- 1 follow up 
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    Console.WriteLine("Remainder 1 start");
                    MailMessage mailMsg = new MailMessage();
                    Int64 Id = Convert.ToInt64(ds.Tables[2].Rows[i]["Id"]);

                    string Description1 = ds.Tables[2].Rows[i]["Description1"].ToString();

                    string Date = "<br/>" + "On " + Convert.ToDateTime(ds.Tables[2].Rows[i]["createdate"]).ToString("f") + " MVP Talent Market   " + "<" + FromEmail + "> wrote:" + "<br/><br/>";
                    mailMsg.Body = ds.Tables[2].Rows[i]["Description1"].ToString() + "<br/>" + Date + "<div style='margin-left:15px;border-left:1px solid gray;padding-left:5px;'>" + ds.Tables[2].Rows[i]["Description"].ToString() + "</div>";

                    mailMsg.Body = mailMsg.Body.Replace("@name", ds.Tables[2].Rows[i]["Name"].ToString() + " " + ds.Tables[2].Rows[i]["LastName"].ToString());


                    string bodytext = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title>My Proposal</title><meta http-equiv='Content-Type' content='text/html;charset=ISO-8859-1'></head><body>@body</body></html>";
                    mailMsg.Body = bodytext.Replace("@body", mailMsg.Body);

                    AlternateView plainView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, null, "text/plain");
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(mailMsg.Body, null, "text/html");

                    plainView.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                    htmlView.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;

                    mailMsg.AlternateViews.Add(plainView);
                    mailMsg.AlternateViews.Add(htmlView);

                    mailMsg.SubjectEncoding = System.Text.Encoding.UTF8;
                    mailMsg.BodyEncoding = System.Text.Encoding.UTF8;

                    mailMsg.Headers.Add("List-Unsubscribe", "<mailto:" + FromEmail + "?subject=unsubscribe>");
                    mailMsg.Sender = new MailAddress(FromEmail);

                    mailMsg.From = new MailAddress(FromEmail, "MVP Talent Market");
                    mailMsg.To.Add(ds.Tables[2].Rows[i]["Email"].ToString());
                   // mailMsg.CC.Add("nick@mail.ishoresoftware.com");
                    mailMsg.Subject = ds.Tables[2].Rows[i]["Subject"].ToString();
                    mailMsg.IsBodyHtml = true;
                    mailMsg.Sender = new MailAddress(FromEmail);
                    SmtpClient smtp = new SmtpClient(smtpPort, Convert.ToInt32(smtpPort));
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Host = SmtpHost;
                    smtp.EnableSsl = EnableSsl;
                    smtp.UseDefaultCredentials = UseDefaultCredentials;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(FromEmail, FromEmailPassword);
                    if (i == 0)
                    {
                        sendemail(mailMsg.Subject, mailMsg.Body);
                    }
                    smtp.Send(mailMsg);
                    updatefollowuprecord(Id, 2);
                    Console.WriteLine("Sent");
                    System.Threading.Thread.Sleep(60000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                System.Threading.Thread.Sleep(6000000);
            }
        }
        private static void sendemail(string subject, string emailbody)
        {
            MailMessage mailMsg1 = new MailMessage();
            mailMsg1.IsBodyHtml = true;
            mailMsg1.From = new MailAddress(FromEmail, "MVP Talent matket");
            mailMsg1.To.Add("diego@cloudavengers.io");
            mailMsg1.Subject = subject;
            mailMsg1.Body = emailbody;
            mailMsg1.Sender = new MailAddress(FromEmail);
            SmtpClient smtp = new SmtpClient(SmtpHost, Convert.ToInt32(smtpPort));
            smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            smtp.Host = SmtpHost;
            smtp.EnableSsl = EnableSsl;
            smtp.UseDefaultCredentials = UseDefaultCredentials;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(FromEmail, FromEmailPassword);
            smtp.Send(mailMsg1);
            Console.WriteLine("Sent on diego ");
        }
        static DataSet getfollowuprecord()
        {
            ds = MySqlHelper.ExecuteDataset(connectstring, "sp_getfollowuprecord");
            return ds;
        }
        static void updatefollowuprecord(long Id, long SentCount)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id",  Id),
                  new MySqlParameter("SentCount", SentCount),
            };
            string Query = "call sp_updatefollowuprecord(@Id,@SentCount)";
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
        }
    }
}
