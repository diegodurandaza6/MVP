using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.SolrClient;
using Web.SolrJobsClient;

namespace JobAlertService
{
    public class Program
    {
        static string emailtemplete = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["emailtemplete"]);
        static string connectstring = ConfigurationManager.ConnectionStrings["mySqlCon"].ToString();
        const string appName = "Job Alert Service";
        static bool EnableSsl = Convert.ToBoolean(ConfigurationManager.ConnectionStrings["EnableSsl"]);
        static bool UseDefaultCredentials = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["UseDefaultCredentials"]);
        static string FromEmail = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["FromEmail"]);
        static string FromEmailPassword = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["FromEmailPassword"]);
        static string SmtpHost = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["smtphost"]);
        static string smtpPort = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["smtpPort"]);
 

        static DataSet ds = new DataSet();
        private static Mutex mutex = null;
        Int32 checkrows = 0;
        static void Main(string[] args)
        {
            JobsModel model = new JobsModel();
            bool createdNew;
            mutex = new Mutex(true, appName, out createdNew);
            if (!createdNew)
            {
                Console.WriteLine(appName + " is already running & press any key for exist.");
                Console.ReadKey();
                return;
            }
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = MySqlHelper.ExecuteDataset(connectstring, "sp_getjobalertdata").Tables[0];
              
                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("start  alert...");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            string JobTitle = Convert.ToString(dt.Rows[i]["JobTitle"]);
                            string location = Convert.ToString(dt.Rows[i]["location"]);

                            if (Convert.ToInt32(dt.Rows[i]["alertid"]) == 1)
                            { 
                                #region for job alert
                                string body = "";
                                body = "<table width='100%' style ='width: 850px; margin: 0 auto; box-shadow: 0 1px 2px rgba(0,0,0,0.2); border-bottom: 1px solid #ddd'><tbody><tr><td style='padding:0px 0px 5px'><h2 style='margin:0;color:#000000;font-weight:400;font-size:23px;line-height:1.333'><a>Your alert for @JobTitle</a></h2></td></tr><tr><td style='padding:0 4px 16px'><p style='margin:0;color:#000000;font-weight:200;font-size:16px;line-height:1.5'>@jobcount new job  match your preferences.</p></br>To stop receiving these type emails please click here to<a href='@Unsubscribe'> unsubscribe</a></td></tr></tbody></table>";
                                body = body.Replace("@JobTitle", '"' + JobTitle + '"');
                                body = body.Replace("@Unsubscribe", "http://mvptalentmarket.com/Home/alertunsubscribe?Id=" + encrypt(Convert.ToString(dt.Rows[i]["Id"])) + "_1");
                                MailMessage mailMsg = new MailMessage();

                                SolrJobsSearch objJobSolrSearch = new SolrJobsSearch();
                                var searchOption = new Web.SolrJobs.Helpers.IndexedSearchOption();

                                if (JobTitle != null)
                                {
                                    searchOption.JobTitle = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(JobTitle.Trim().ToLower());
                                }
                                 
                                    searchOption.location = location;
                                
                                searchOption.jobstatusid = 2;
                                searchOption.SearchType = 1;
                                int TotalCount = 0;
                                string msg = "";
                                model.CurrentPageIndex = 1;
                                model.maxRows = 30;
                                model.SolrJobListCollection = objJobSolrSearch.ExecuteSearchAsSearchResult1(searchOption, Convert.ToInt32(model.CurrentPageIndex), model.maxRows, out TotalCount, out msg);
                                  
                                body = body.Replace("@jobcount", Convert.ToString(model.SolrJobListCollection.Count));
                                if (model.SolrJobListCollection != null)
                                {
                                    if (model.SolrJobListCollection.Count > 0)
                                    {
                                        Console.WriteLine("Finf solr row");
                                        foreach (var item in model.SolrJobListCollection)
                                        {
                                            string path = emailtemplete + "jobalerttemplete.html";
                                            using (StreamReader reader = new StreamReader(path))
                                            {
                                                mailMsg.Body = reader.ReadToEnd();
                                                mailMsg.Body = mailMsg.Body.Replace("@jobtitle", item.jobtitle);
                                                mailMsg.Body = mailMsg.Body.Replace("@CategoryName", item.CategoryName.Trim());
                                                mailMsg.Body = mailMsg.Body.Replace("@description", item.Description);
                                                mailMsg.Body = mailMsg.Body.Replace("@Designation", item.Designation);
                                                mailMsg.Body = mailMsg.Body.Replace("@location", item.location);
                                                mailMsg.Body = mailMsg.Body.Replace("@jobid", encrypt(Convert.ToString(item.Id)));
                                                mailMsg.Body = mailMsg.Body.Replace("@ImagePath", item.ImagePath);
                                                body += mailMsg.Body;
                                            }
                                        }
                                        string toemail = dt.Rows[i]["Email"].ToString();
                                        string bodytext = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title>MVP Talent Market</title><meta http-equiv='Content-Type' content='text/html;charset=ISO-8859-1'></head><body>@body</body></html>";
                                        mailMsg.Body = bodytext.Replace("@body", body);

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

                                        mailMsg.From = new MailAddress(FromEmail, "MVP Talent Market Alerts");
                                        mailMsg.To.Add(toemail);

                                        var alertsubject = "_count new job(s) for _keyword";
                                        alertsubject = alertsubject.Replace("_count", Convert.ToString(model.SolrJobListCollection.Count));
                                        alertsubject = alertsubject.Replace("_keyword", '"' + Convert.ToString(dt.Rows[i]["JobTitle"]) + '"');

                                        mailMsg.Subject = alertsubject;

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
                                        Console.WriteLine("Job Email sent...");
                                        UpdateLastAlertsent(Convert.ToString(dt.Rows[i]["Id"]));
                                        Console.WriteLine("Job Row update...");
                                        System.Threading.Thread.Sleep(1000);
                                    }

                                }
                                #endregion 
                            }
                            else
                            {
                                #region candidate
                                
                                MailMessage mailMsg = new MailMessage();
                                string body = "";
                                body = "<table   width='100%'style ='width: 850px; margin: 0 auto;  box-shadow: 0 1px 2px rgba(0,0,0,0.2); border-bottom: 1px solid #ddd'><tbody><tr><td style='padding:0px 0px 5px'><h2 style='margin:0;color:#000000;font-weight:400;font-size:23px;line-height:1.333'><a>Your alert for @JobTitle</a></h2></td></tr><tr><td style='padding:0 4px 16px'><p style='margin:0;color:#000000;font-weight:200;font-size:16px;line-height:1.5'>@jobcount new  match your preferences.</p></br>To stop receiving these type emails please click here to<a href='@Unsubscribe'> unsubscribe</a></td></tr></tbody></table>";
                                body = body.Replace("@JobTitle", '"' + JobTitle + '"');
                                body = body.Replace("@Unsubscribe", "http://mvptalentmarket.com/Home/alertunsubscribe?Id=" + encrypt(Convert.ToString(dt.Rows[i]["Id"])) + "_2");
                                model.checkId = 2;
                                model.CurrentPageIndex = model.CurrentPageIndex == null ? 1 : model.CurrentPageIndex;
                                model.maxRows = Convert.ToInt32(ConfigurationManager.AppSettings["MaxRow"]);
                                model.OffsetId = Convert.ToInt64((model.CurrentPageIndex - 1) * model.maxRows);


                                SolrSearch objSolrSearch = new SolrSearch();
                                var searchOption = new Web.SolrClient.Helpers.IndexedSearchOption();
                                searchOption.SearchType = 1;
                                model.maxRows = 30;
                                int TotalCount = 0;
                                string msg = "";
                                searchOption.ProfileCheckId = 1;
                                if (JobTitle != null)
                                {
                                    searchOption.Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(JobTitle.Trim().ToLower());
                                }
                                if (location != null)
                                {
                                    searchOption.location = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(location.Trim().ToLower());
                                }
                                 
                                CandidateListModel model1 = new CandidateListModel();
                                model1.CandiateList = objSolrSearch.ExecuteSearchAsSearchResult1(searchOption, Convert.ToInt32(model.CurrentPageIndex), model.maxRows, out TotalCount, out msg);
                                 
                                if (model1.CandiateList != null)
                                {
                                    if (model1.CandiateList.Count > 0)
                                    {
                                        body = body.Replace("@jobcount", Convert.ToString(model1.CandiateList.Count));
                                        foreach (var item in model1.CandiateList)
                                        {
                                            string path = emailtemplete + "candidateClientalerttemplete.html";
                                            using (StreamReader reader = new StreamReader(path))
                                            {

                                                mailMsg.Body = reader.ReadToEnd();
                                                mailMsg.Body = mailMsg.Body.Replace("@title", item.current_job_title);
                                                mailMsg.Body = mailMsg.Body.Replace("@EducationlevelName", item.EducationlevelName);
                                                mailMsg.Body = mailMsg.Body.Replace("@desiredtitle1", item.DesiredTitle1);
                                                mailMsg.Body = mailMsg.Body.Replace("@Job_location", item.location);
                                                mailMsg.Body = mailMsg.Body.Replace("@description", item.Description);
                                                mailMsg.Body = mailMsg.Body.Replace("@candidateid", encrypt(Convert.ToString(item.id)));
                                                mailMsg.Body = mailMsg.Body.Replace("@ImagePath", item.profile_image);
                                                body += mailMsg.Body;
                                            }
                                        }
                                        string toemail = dt.Rows[i]["Email"].ToString();
                                        string bodytext = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml'><head><title>MVP Talent Market</title><meta http-equiv='Content-Type' content='text/html;charset=ISO-8859-1'></head><body>@body</body></html>";
                                        mailMsg.Body = bodytext.Replace("@body", body);

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

                                        mailMsg.From = new MailAddress(FromEmail, "MVP Talent Market Alerts");
                                        mailMsg.To.Add(toemail);
                                        //mailMsg.CC.Add("nick@mail.ishoresoftware.com");

                                        var alertsubject = "_count new candidate(s) for _keyword";
                                        alertsubject = alertsubject.Replace("_count", Convert.ToString(model1.CandiateList.Count));
                                        alertsubject = alertsubject.Replace("_keyword", '"' + Convert.ToString(dt.Rows[i]["JobTitle"]) + '"');

                                        mailMsg.Subject = alertsubject;
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
                                        Console.WriteLine("Candidate Email sent...");
                                        UpdateLastAlertsent(Convert.ToString(dt.Rows[i]["Id"]));
                                        Console.WriteLine("Candidate Row Update...");

                                        System.Threading.Thread.Sleep(10000);
                                    }
                                   
                                }
                               
                                #endregion
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No data found...");
                    System.Threading.Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                System.Threading.Thread.Sleep(2000);
            } 
        }

        private static void sendemail(string subject, string emailbody)
        {
            try
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
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }
        public static string encrypt(string encryptString)
        {

            string EncryptionKey = "123456789BCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }


        private static void UpdateLastAlertsent(string Id)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id",  Id)
            };
            string Query = "call sp_UpdateLastAlertsent(@Id)";
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
        }
    }
}
