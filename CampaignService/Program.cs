using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace CampaignService
{
    public class Program
    {
        static string connectstring = ConfigurationManager.ConnectionStrings["mySqlCon"].ToString();
        const string appName = " Campaign Service Application";
        static string CampaignEmail = System.Configuration.ConfigurationManager.AppSettings["EmailbodyUrl"];
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
            bool createdNew;
            mutex = new Mutex(true, appName, out createdNew);
            if (!createdNew)
            {
                Console.WriteLine(appName + " is already running & press any key for exist.");
                Console.ReadKey();
                return;
            }
            DataSet ds = new DataSet();
            ds = MySqlHelper.ExecuteDataset(connectstring, "sp_getcompaigncontact");

            if (ds.Tables[0].Rows.Count > 0)
            {
                //MailEmail send 
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    long ContactId = ds.Tables[1].Rows[i]["Id"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[1].Rows[i]["Id"]);
                    if (ContactId > 0)
                    {
                        try
                        {
                            Console.WriteLine("Start...");
                            string Name = ds.Tables[1].Rows[i]["name"] is DBNull ? "Sir/Ma'am" : Convert.ToString(ds.Tables[1].Rows[i]["name"]);
                            Name = ds.Tables[1].Rows[i]["name"] is "" ? "Sir/Ma'am" : Convert.ToString(ds.Tables[1].Rows[i]["name"]);
                            Name = ds.Tables[1].Rows[i]["name"] is " " ? "Sir/Ma'am" : Convert.ToString(ds.Tables[1].Rows[i]["name"]);
                            MailMessage mailMsg = new MailMessage();
                            string ContectEmail = ds.Tables[1].Rows[i]["email"].ToString();
                            mailMsg.IsBodyHtml = true;
                            mailMsg.From = new MailAddress(FromEmail, "MVP Talent Market");

                            //mailMsg.CC.Add("nick@mail.ishoresoftware.com");
                            mailMsg.To.Add(ContectEmail == null ? string.Empty : ContectEmail.Trim());
                            mailMsg.Subject = ds.Tables[0].Rows[0]["Subject"].ToString();
                            mailMsg.Body = ds.Tables[0].Rows[0]["EmailBody"].ToString();
                            mailMsg.Body = mailMsg.Body.Replace("@name", Name);

                            string UnsubscribeLink = "<a href='" + CampaignEmail + "/unsubscribe?ids= " + Encrypt(ds.Tables[1].Rows[i]["Id"].ToString()) + " '>Unsubscribe</a>";

                            mailMsg.Body = mailMsg.Body.Replace("@unsubscribe", UnsubscribeLink);

                            mailMsg.Body = mailMsg.Body + "<br/>" + "<img   src='" + CampaignEmail + "/Campaignread?ids=@Encryptid' height='0' width='0'/>";
                            mailMsg.Body = mailMsg.Body.Replace("@Encryptid", ds.Tables[0].Rows[0]["Id"].ToString() + "_" + ds.Tables[1].Rows[i]["Id"].ToString());

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

                            SmtpClient smtp = new SmtpClient(SmtpHost, Convert.ToInt32(smtpPort));
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

                            UpdateCampaignEmailStatus(1, ds.Tables[1].Rows[i]["Id"].ToString(), ds.Tables[0].Rows[0]["campaigntypeid"].ToString());
                            Console.WriteLine("Email sent ." + ContectEmail);

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            UpdateCampaignEmailStatus(2, ds.Tables[1].Rows[i]["Id"].ToString(), ds.Tables[0].Rows[0]["campaigntypeid"].ToString());
                        }
                        System.Threading.Thread.Sleep(45000);
                    }
                }
            }
        }
        private static void sendemail(string subject, string emailbody)
        {
            MailMessage mailMsg1 = new MailMessage();
            mailMsg1.IsBodyHtml = true;
            mailMsg1.From = new MailAddress(FromEmail, "MVP Talent matket");
            mailMsg1.To.Add("mailtosinghnagendra@gmail.com");
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
        }






        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        private static void UpdateCampaignEmailStatus(int Id, string contactId, string campaigntypeid)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id",  Id),
                  new MySqlParameter("contactId", contactId),
                  new MySqlParameter("campaigntypeid", campaigntypeid),
            };
            string Query = "call UpdateCampaignEmailStatus(@Id,@contactId,@campaigntypeid)";
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
        }
    }
}
