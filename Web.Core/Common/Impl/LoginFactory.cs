using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;


namespace Web.Core.Common.Impl
{
    public class LoginFactory
    {
        DataTable dt = new DataTable();
        internal void CandidateLogin(LoginModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {

                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                model.UsertypeId = Convert.ToInt64(dt.Rows[0]["AccountTypeId"]);
                model.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                model.UsertypeName = Convert.ToString(dt.Rows[0]["AccountTypeName"]);
                model.Name = Convert.ToString(dt.Rows[0]["Name"]) + " " + Convert.ToString(dt.Rows[0]["LastName"]);
                model.FirstName = Convert.ToString(dt.Rows[0]["Name"]);
                model.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                model.Phone = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                model.Title = Convert.ToString(dt.Rows[0]["Title"]);
                model.RoleId = Convert.ToInt32(dt.Rows[0]["RoleId"]);
                model.CompanyId = Convert.ToInt32(dt.Rows[0]["CompanyId"]);
                model.FileName = Convert.ToString(dt.Rows[0]["CompanyImage"]);
                //model.FilePath = "/" + "FileUpload" + "/" + "/" + "CompanyImage" + "/" + model.CompanyId + "/" + dt.Rows[0]["CompanyImage"].ToString();

                if (model.UsertypeId == 3)
                {
                    model.Image = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["ImageFile"].ToString());

                }
                else
                {
                    if (dt.Rows[0]["CompanyImage"].ToString().Length > 0)
                    {
                        model.Image = Convert.ToString(dt.Rows[0]["CompanyImage"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/" + "FileUpload" + "/" + "/" + "CompanyImage" + "/" + model.CompanyId + "/" + dt.Rows[0]["CompanyImage"].ToString());
                    }
                    else
                    {
                        model.Image = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + Convert.ToInt32(dt.Rows[0]["UserId"]) + "/" + dt.Rows[0]["ImageFile"].ToString());
                    }
                }

                model.Status = 1;
            }

        }
        internal void AppliedJob(JobsModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.StatusId = Convert.ToInt64(ds.Tables[0].Rows[0]["v_status"]);
            }
        }

        internal void CandidateDetailsbyId(CandidateModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {

                model.UserId = Convert.ToInt64(dt.Rows[0]["UserId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["UserId"]));
                model.Name = Convert.ToString(dt.Rows[0]["Name"]) + " " + Convert.ToString(dt.Rows[0]["LastName"]);
                model.Phone = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                model.location = Convert.ToString(dt.Rows[0]["location"]);
                model.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                model.PreferredEMail = Convert.ToString(dt.Rows[0]["PreferredEMail"]);
                model.DesiredTitle1 = Convert.ToString(dt.Rows[0]["DesiredTitle1"]);
                model.DesiredTitle2 = Convert.ToString(dt.Rows[0]["DesiredTitle2"]);
                model.JobTypeId = Convert.ToInt64(dt.Rows[0]["jobtype"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["jobtype"]));
                model.Industry = Convert.ToInt64(dt.Rows[0]["Industry"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["Industry"]));

                model.IndustryName = Convert.ToString(dt.Rows[0]["IndustryName"]);
                model.jobtypeName = Convert.ToString(dt.Rows[0]["jobtypeName"]);

                model.Phone = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                model.Title = Convert.ToString(dt.Rows[0]["Title"]);

                model.Relocation = Convert.ToString(dt.Rows[0]["Relocation"]);
                model.Certifications = Convert.ToString(dt.Rows[0]["Certifications"]);

                model.PorfileDescerption = Convert.ToString(dt.Rows[0]["Description"]);
                model.Address1 = Convert.ToString(dt.Rows[0]["Address1"]);
                model.Address2 = Convert.ToString(dt.Rows[0]["Address2"]);
                model.experienceName = Convert.ToString(dt.Rows[0]["experienceName"]);
                model.Title = Convert.ToString(dt.Rows[0]["Title"]);
                model.Facebook = Convert.ToString(dt.Rows[0]["FacebookUrl"]);
                model.Twitter = Convert.ToString(dt.Rows[0]["twitterUrl"]);
                model.Linkedin = Convert.ToString(dt.Rows[0]["Linkedinurl"]);
                model.qualificationname = Convert.ToString(dt.Rows[0]["educationlevel"]);
                model.CurrentSalary = Convert.ToString(dt.Rows[0]["Current_Salary"]);
                model.expectedSalary = Convert.ToString(dt.Rows[0]["expected_Salary"]);
                model.educationlevel = Convert.ToString(dt.Rows[0]["educationlevel"]);

                model.Zipcode = Convert.ToString(dt.Rows[0]["Zipcode"]);
                model.resumeName = Convert.ToString(dt.Rows[0]["Resumefile"]);
                model.Resumefile = "/" + "FileUpload/CandidateResume" + "/" + Convert.ToString(dt.Rows[0]["UserId"]) + "/" + Convert.ToString(dt.Rows[0]["Resumefile"]);
                //model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"]);
                // model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidate.png" : "/FileUpload/CandidateImage/" + Convert.ToInt32(dt.Rows[0]["UserId"]) + "/" + dt.Rows[0]["ImageFile"]);

                model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["ImageFile"].ToString());

            }

            model.EducationCollection = (from DataRow row in ds.Tables[1].Rows
                                         select new CandidateModel
                                         {
                                             educationId = Convert.ToInt64(row["Id"]),
                                             Education = Convert.ToString(row["education"]),
                                             EducaStartYear = Convert.ToString(row["year"]),
                                             EducaEndYear = Convert.ToString(row["EducationEnd"]),
                                             univarsity = Convert.ToString(row["university"]),
                                             description = Convert.ToString(row["description"]),
                                             visibleName = Convert.ToString(row["visibleName"]),
                                             visibleid = Convert.ToInt64(row["visibleid"])
                                         }).ToList();

            model.workexperiencecollection = (from DataRow row in ds.Tables[2].Rows
                                              select new CandidateModel
                                              {
                                                  workId = Convert.ToInt64(row["Id"]),
                                                  Title = Convert.ToString(row["title"]),
                                                  Todate = Convert.ToString(row["todate"] is DBNull ? "" : Convert.ToDateTime(row["todate"]).ToString("MM/dd/yyyy")),
                                                  Fromdate = Convert.ToString(row["fromdate"] is DBNull ? "" : Convert.ToDateTime(row["fromdate"]).ToString("MM/dd/yyyy")),
                                                  description = Convert.ToString(row["description"]),
                                                  visibleName = Convert.ToString(row["visibleName"]),
                                                  visibleid = Convert.ToInt64(row["visibleid"])
                                              }).ToList();
            model.Awardscecollection = (from DataRow row in ds.Tables[3].Rows
                                        select new CandidateModel
                                        {
                                            awardId = Convert.ToInt64(row["Id"]),
                                            Title = Convert.ToString(row["title"]),
                                            year = Convert.ToString(row["year"]),
                                            description = Convert.ToString(row["description"]),
                                            visibleName = Convert.ToString(row["visibleName"])

                                        }).ToList();

            model.portfoliocecollection = (from DataRow row in ds.Tables[4].Rows
                                           select new CandidateModel
                                           {
                                               PortfolioId = Convert.ToInt64(row["Id"]),
                                               UserId = Convert.ToInt64(row["CreatedBy"]),
                                               FileName = Convert.ToString(row["FileName"]),

                                               FileUpload = "/" + "FileUpload" + "/" + "/" + "PortfolioImage" + "/" + Convert.ToInt64(row["CandidateId"]) + "/" + row["FileName"].ToString(),
                                               Link = Convert.ToString(row["Link"]),
                                               description = Convert.ToString(row["description"]),
                                               visibleName = Convert.ToString(row["visibleName"]),
                                               visibleid = Convert.ToInt64(row["visibleid"])

                                           }).ToList();

            model.SkillCollection = (from DataRow row in ds.Tables[5].Rows
                                     select new CandidateModel
                                     {
                                         Id = Convert.ToInt64(row["Id"]),
                                         skill = Convert.ToString(row["skillName"]),
                                         percentage = Convert.ToString(row["percentage"]),
                                         visibleName = Convert.ToString(row["visibleName"])
                                     }).ToList();
            if (ds.Tables[6].Rows.Count > 0)
            {
                model.VideoTitle = ds.Tables[6].Rows[0]["Title"].ToString();
                model.VideoUrl = ds.Tables[6].Rows[0]["Url"].ToString();
                model.description = ds.Tables[6].Rows[0]["Description"].ToString();
                model.visibleName = ds.Tables[6].Rows[0]["visibleName"].ToString();
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                model.ClientId = Convert.ToInt64(ds.Tables[7].Rows[0]["Id"]);
                model.Email = Convert.ToString(ds.Tables[7].Rows[0]["Email"]);
                model.CandidateName = Convert.ToString(ds.Tables[7].Rows[0]["Name"]);
                model.CandidatePhone = Convert.ToString(ds.Tables[7].Rows[0]["PhoneNo"]);
                model.AccountType = Convert.ToInt64(ds.Tables[7].Rows[0]["AccountTypeId"]);
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                model.favoriteStatusId = Convert.ToInt64(ds.Tables[8].Rows[0]["statusId"]);
            }



            model.candidaterefrencecollection = (from DataRow row in ds.Tables[9].Rows
                                                 select new CandidateModel
                                                 {
                                                     refrenceId = Convert.ToInt64(row["Id"]),
                                                     // CandidateId = Convert.ToInt64(row["CandidateId"]),
                                                     Name = Convert.ToString(row["Name"]),
                                                     Phone = Convert.ToString(row["Phone"]),
                                                     Email = Convert.ToString(row["Email"]),
                                                     Title = Convert.ToString(row["Title"]),

                                                 }).ToList();


            model.SimilarCandidatescollection = (from DataRow row in ds.Tables[10].Rows
                                                 select new CandidateModel
                                                 {
                                                     JobTypeId = Convert.ToInt64(row["jobtype"] is DBNull ? 0 : Convert.ToInt64(row["jobtype"])),
                                                     UserId = Convert.ToInt64(row["UserId"] is DBNull ? 0 : Convert.ToInt64(row["UserId"])),
                                                     Name = Convert.ToString(row["Name"]),
                                                     Title = Convert.ToString(row["Title"]),
                                                     imageFile = Convert.ToString(row["ImageFile"]),
                                                     FileUpload = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + row["ImageFile"].ToString()),
                                                     location = Convert.ToString(row["Location"]),
                                                     educationlevel = Convert.ToString(row["educationlevel"]),
                                                     jobtypeName = Convert.ToString(row["jobtypename"]),
                                                     experienceName = Convert.ToString(row["experienceName"]),

                                                 }).ToList();



            model.LicensesCertifications = (from DataRow row in ds.Tables[11].Rows
                                            select new CandidateModel
                                            {
                                                Id = Convert.ToInt64(row["Id"]),
                                                Education = Convert.ToString(row["education"]),
                                                year = Convert.ToString(row["year"] is DBNull ? "" : Convert.ToDateTime(row["year"]).ToString("MM/dd/yyyy")),
                                                EndYear = Convert.ToString(row["EducationEnd"] is DBNull ? "" : Convert.ToDateTime(row["EducationEnd"]).ToString("MM/dd/yyyy")),

                                                univarsity = Convert.ToString(row["university"]),
                                                description = Convert.ToString(row["description"]),
                                                visibleName = Convert.ToString(row["visibleName"]),
                                                visibleid = Convert.ToInt64(row["visibleId"] is DBNull ? 0 : Convert.ToInt64(row["visibleId"])),
                                            }).ToList();



            model.JobCollection = (from DataRow row in ds.Tables[12].Rows
                                   select new DropDownViewModel
                                   {
                                       Id = Convert.ToInt64(row["Id"]),
                                       Title = Convert.ToString(row["JobTitle"]),
                                       Location = Convert.ToString(row["Location"]).Replace(", USA", "")
                                   }).ToList();
        }

        internal string getzipcodeforzipcodesizedecrease(DataTable dt)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<ZipCodeVIewModel> GetAllZipCodewithlatlong(DataTable dt)
        {
            return (from DataRow row in dt.Rows
                    select new ZipCodeVIewModel
                    {
                        ZipCode = Convert.ToInt64(row["Zcta"]),
                        lat = Convert.ToDouble(row["Latitude"]),
                        log = Convert.ToDouble(row["Longitude"]),
                    }).ToList();
        }

        internal IEnumerable<MainMenu> GetAllMenuSubmenu(DataSet ds)
        {
            if (ds.Tables.Count != 3) throw new Exception("Inavlid Main Menu Query");


            var SubMenuRoles = (from DataRow row in ds.Tables[2].Rows
                                select new SubMenuRole
                                {
                                    MenuId = Convert.ToInt32(row["MenuId"]),
                                    SubMenuId = Convert.ToInt32(row["SubMenuId"]),
                                    RoleId = Convert.ToInt32(row["RoleId"])
                                }).ToList();
            var SubMenus = (from DataRow row in ds.Tables[1].Rows
                            select new SubMenu
                            {
                                MenuId = Convert.ToInt32(row["MenuId"]),
                                SubMenuId = Convert.ToInt32(row["SubMenuId"]),
                                Url = Convert.ToString(row["Url"]),
                                SubMenuName = Convert.ToString(row["SubMenuName"]),
                                Area = Convert.ToString(row["Area"]),
                                Controller = Convert.ToString(row["Controller"]),
                                Action = Convert.ToString(row["Action"]),
                                ishidden = Convert.ToBoolean(row["ishidden"])

                            }).ToList();
            var MainMenus = (from DataRow row in ds.Tables[0].Rows
                             select new MainMenu
                             {
                                 MenuId = Convert.ToInt16(row["MenuId"]),
                                 MenuName = Convert.ToString(row["MenuName"]),

                             }).ToList();

            //var LimitedSubMenus = SubMenus.Where(x=>SubMenuRoles.Select(z => z.SubMenuId).Contains(x.SubMenuId));
            //var LimitedMainMenus = MainMenus.Where(x => SubMenuRoles.Select(z => z.MenuId).Contains(x.MenuId));

            foreach (var item in SubMenus)
            {
                item.SubMenuRoles = SubMenuRoles.Where(x => x.SubMenuId == item.SubMenuId);
            }

            foreach (var item in MainMenus)
            {
                item.SubMenus = SubMenus.Where(x => x.MenuId == item.MenuId);
            }

            return MainMenus;
        }

        internal void sendemail(JobsModel model)
        {
            string[] emails = model.Email.Split(',');

            foreach (var email in emails)
            {
                sendEmail(model.subject, model.description, email);
            }


        }

        private void createNode(string pName, XmlTextWriter writer)
        {



        }


        internal void ZipRecruiter(DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            XmlTextWriter writer = new XmlTextWriter(Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["xmlpath"]), null);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Source");

            writer.WriteStartElement("lastBuildDate");
            writer.WriteString(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
            writer.WriteEndElement();

            writer.WriteStartElement("publisherurl");
            writer.WriteString("http://mvptalentmarket.com/Home/ziprecruitersharejob");
            writer.WriteEndElement();

            writer.WriteStartElement("publisher");
            writer.WriteString("mvptalentmarket");
            writer.WriteEndElement();

            foreach (DataRow row in dt.Rows)
            {
                // var url = "http://mvptalentmarket.com/Home/jobdetail?Ids=" + EncryptDecrypt.encrypt(Convert.ToString(row["Id"]));
                var url = "http://mvptalentmarket.com/Home/jobdetail?Ids=" + row["Id"].ToString();

                writer.WriteStartElement("job");

                writer.WriteStartElement("referencenumber");
                writer.WriteString(Convert.ToString(row["Id"]));
                writer.WriteEndElement();

                writer.WriteStartElement("title");
                writer.WriteString(Convert.ToString(row["JobTitle"]));
                writer.WriteEndElement();

                writer.WriteStartElement("description");
                writer.WriteString("<![CDATA[" + Convert.ToString(row["Desription"]) + "]]>");
                writer.WriteEndElement();

                writer.WriteStartElement("country");
                writer.WriteString(Convert.ToString(row["CountryName"]));
                writer.WriteEndElement();

                writer.WriteStartElement("city");
                writer.WriteString(Convert.ToString(row["CityName"]));
                writer.WriteEndElement();

                writer.WriteStartElement("state");
                writer.WriteString(Convert.ToString(row["StateName"]));
                writer.WriteEndElement();

                writer.WriteStartElement("postalcode");
                writer.WriteString(Convert.ToString(row["zipcode"]));
                writer.WriteEndElement();

                writer.WriteStartElement("company");
                writer.WriteString(Convert.ToString(row["Company"]));
                writer.WriteEndElement();

                writer.WriteStartElement("date");
                writer.WriteString(Convert.ToString(row["UpdatedDate"]));
                writer.WriteEndElement();

                writer.WriteStartElement("email");
                writer.WriteString(Convert.ToString(row["Email"]));
                writer.WriteEndElement();

                writer.WriteStartElement("url");
                writer.WriteString("<![CDATA[" + url + "]]>");
                writer.WriteEndElement();

                //writer.WriteStartElement("address");
                //writer.WriteString("1615 Ocen Ave");
                //writer.WriteEndElement();

                writer.WriteStartElement("jobtype");
                writer.WriteString(Convert.ToString(row["typeName"]));
                writer.WriteEndElement();

                writer.WriteStartElement("experience");
                writer.WriteString(Convert.ToString(row["MinExeperience"]));
                writer.WriteEndElement();

                writer.WriteStartElement("education");
                writer.WriteString(Convert.ToString(row["qualificationname"]));
                writer.WriteEndElement();

                //writer.WriteStartElement("compensation_interval");
                //writer.WriteString("hourly");
                //writer.WriteEndElement();

                //writer.WriteStartElement("compensation_min");
                //writer.WriteString(10);
                //writer.WriteEndElement();

                writer.WriteStartElement("compensation_max");
                writer.WriteString(Convert.ToString(row["MaxSalary"]));
                writer.WriteEndElement();


                writer.WriteStartElement("compensation_currency");
                writer.WriteString("USD");
                writer.WriteEndElement();

                //writer.WriteStartElement("benefits");
                //writer.WriteStartElement("medical");
                //writer.WriteString("1");
                //writer.WriteEndElement();

                //writer.WriteStartElement("dental");
                //writer.WriteString("1");
                //writer.WriteEndElement();


                //writer.WriteStartElement("vision");
                //writer.WriteString("0");
                //writer.WriteEndElement();

                //writer.WriteStartElement("life_insurance");
                //writer.WriteString("1");
                //writer.WriteEndElement();

                //writer.WriteStartElement("retirement_savings");
                //writer.WriteString("0");
                //writer.WriteEndElement();
                //writer.WriteEndElement();

                writer.WriteEndElement();
            }
            if (ds.Tables[0].Rows.Count == 0)
            {
                writer.WriteStartElement("record");
                writer.WriteString("No record found");
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();


        }

        internal void GetLocation(DataTable dt, LoginModel model)
        {
            if (dt.Rows.Count > 0)
            {
                model.CollectionLocation = (from DataRow row in dt.Rows
                                            select new LocationDropdown
                                            {
                                                label = row["Location"].ToString().ToLower(),
                                                val = Convert.ToInt32(row["Id"]),
                                            }).ToList();
            }
        }

        internal void plandetails(PlanModel model, DataTable dt)
        {

            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Price = Convert.ToString(dt.Rows[0]["Price"]);
                model.noofjob = Convert.ToString(dt.Rows[0]["noofjob"]);
                model.noofinterview = Convert.ToString(dt.Rows[0]["noofinterview"]);
                model.noofsubmission = Convert.ToString(dt.Rows[0]["noofsubmission"]);
                model.Description = Convert.ToString(dt.Rows[0]["Description"]);
                model.validdate = Convert.ToDateTime(dt.Rows[0]["ValidPlanDate"]).ToShortDateString();
                model.CreatedDate = Convert.ToDateTime(dt.Rows[0]["createddate"]).ToShortDateString();
                model.transactionno = Convert.ToString(dt.Rows[0]["paymentId"]);
            }
        }

        internal void plan(PlanModel model, DataTable dt)
        {
            model.PlanListCollection = (from DataRow row in dt.Rows
                                        select new PlanModel
                                        {
                                            Id = Convert.ToInt64(row["Id"]),
                                            Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString())),
                                            Name = Convert.ToString(row["Name"]),
                                            Price = Convert.ToString(row["Price"]),
                                            Description = Convert.ToString(row["Description"]),
                                            PlanStatusId = Convert.ToInt64(row["PlanStatus"]),
                                            PlanTypeId = Convert.ToInt64(row["PlanTypeId"] is DBNull ? 0 : Convert.ToInt64(row["PlanTypeId"])),
                                            PlanTypeName = Convert.ToString(row["PlanTypeName"])

                                        }).ToList();






        }

        internal void Jobsautocomplete(JobsModel model, DataTable dt)
        {
            model.JobsCollection = (from DataRow row in dt.Rows
                                    select new JobsModel
                                    {
                                        //Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                        jobtitle = Convert.ToString(row["JobTitle"]),
                                    }).ToList();
        }

        internal void creategustcandidate(JobsModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.StatusId = Convert.ToInt64(dt.Rows[0]["StatusId"]);
                if (model.StatusId == 1)
                {
                    string Subject = "";

                    string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);

                    Subject = "Welcome to MVP Talent."; // Your MVP Talent account has been created!

                    string body = string.Empty;
                    using (StreamReader reader = new StreamReader(EmailTempletePath + "GustCandidate.html"))
                    {
                        body = reader.ReadToEnd();
                    }
                    body = body.Replace("{{Name}}", model.Name);
                    body = body.Replace("{{Email}}", model.Email);
                    body = body.Replace("{{Phone}}", model.Phone);
                    body = body.Replace("{{Password}}", model.Password);
                    sendEmail(Subject, body, model.Email);
                }

                //FileInfo fi = new FileInfo(model.FileName);
                //StreamReader sr = fi.OpenText();
                //string s = "";
                //while ((s = sr.ReadLine()) != null)
                //{
                //    model.description = s;
                //}

            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(ds.Tables[1].Rows[0]["v_CurrentId"]);
            }
        }

        internal void CandidateJobapplyLogin(JobsModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                var Status = dt.Rows[0]["Status"].ToString();
                if (Status == "9")
                {
                    model.StateId = 9;
                }
                else
                {
                    var Password = dt.Rows[0]["Password"].ToString();
                    var Salt = dt.Rows[0]["Salt"].ToString();
                    var decreptPassword = Craptography.Decrypt(Password, Salt);
                    if (model.Password == decreptPassword)
                    {
                        model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                        model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                        model.UsertypeId = Convert.ToInt64(dt.Rows[0]["AccountTypeId"]);
                        model.UsertypeName = Convert.ToString(dt.Rows[0]["AccountTypeName"]);
                        model.Name = Convert.ToString(dt.Rows[0]["Name"]) + " " + Convert.ToString(dt.Rows[0]["LastName"]);
                        model.FirstName = Convert.ToString(dt.Rows[0]["Name"]);
                        model.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                        model.Phone = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                        model.Title = Convert.ToString(dt.Rows[0]["Title"]);
                        model.Image = "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["ImageFile"].ToString();

                        model.StateId = Convert.ToInt64(dt.Rows[0]["Status"]);
                    }
                    else
                    {
                        model.StateId = 4;
                    }
                }
            }
            else
            {
                model.StateId = 5;
            }





        }

        internal void GetHomeIndex(JobsModel model, DataSet ds)
        {


            model.StateCollection = (from DataRow row in ds.Tables[0].Rows
                                     select new DropDownViewModel
                                     {
                                         Id = Convert.ToInt64(row["Id"]),
                                         Name = Convert.ToString(row["Name"])
                                     }).ToList();
            model.JobTypeCollection = (from DataRow row in ds.Tables[1].Rows
                                       select new DropDownViewModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Name = Convert.ToString(row["Name"])

                                       }).ToList();


            model.LatestCandidatesCollection = (from DataRow row in ds.Tables[2].Rows
                                                select new DropDownViewModel
                                                {
                                                    Id = Convert.ToInt64(row["Id"]),
                                                    Name = Convert.ToString(row["Name"]) + " " + Convert.ToString(row["LastName"]),
                                                    Ids = EncryptDecrypt.encrypt(row["UserId"].ToString()),
                                                    Description = Convert.ToString(row["Description"]),
                                                    Experiencename = Convert.ToString(row["experiencename"]),
                                                    Location = Convert.ToString(row["Location"]),
                                                    salary = Convert.ToString(row["salary"]),
                                                    Zipcode = Convert.ToString(row["Zipcode"]),
                                                    Jobtype = Convert.ToString(row["JobtypeName"]),
                                                    EducationlevelsName = Convert.ToString(row["educationlevelsName"]),
                                                    DesiredTitle1 = Convert.ToString(row["DesiredTitle1"]),
                                                    DesiredTitle2 = Convert.ToString(row["DesiredTitle2"]),
                                                    Title = Convert.ToString(row["Title"]),
                                                    imagepath = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + row["ImageFile"].ToString())

                                                }).ToList();


        }

        internal void job(JobsModel model, DataSet ds)
        {

            model.JobListCollection = (from DataRow row in ds.Tables[0].Rows
                                       select new JobsModel
                                       {

                                           Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                           Ids = EncryptDecrypt.encrypt(row["Id"].ToString()),
                                           UserId = Convert.ToInt64(row["UserId"] is DBNull ? 0 : Convert.ToInt64(row["UserId"])),
                                           jobtitle = Convert.ToString(row["JobTitle"]),
                                           JobTypeName = Convert.ToString(row["typeName"]),
                                           JobStatusName = Convert.ToString(row["StatusName"]),
                                           City = Convert.ToString(row["City"]),
                                           WorkExperienceMax = Convert.ToString(row["MaxExeperience"]),
                                           qualificationName = Convert.ToString(row["qualificationName"]),
                                           createddate = Convert.ToString(row["CreatedDate"]),
                                           CountyName = Convert.ToString(row["CountryName"]),
                                           StateName = Convert.ToString(row["StateName"]),
                                           DesignationName = Convert.ToString(row["DesignationName"]),
                                           JobCategoryName = Convert.ToString(row["categoryName"]),
                                           CityName = Convert.ToString(row["CityName"]),
                                           ClientId = Convert.ToInt64(row["ClientId"] is DBNull ? 0 : Convert.ToInt64(row["ClientId"])),
                                           FileName = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + Convert.ToInt32(row["UserId"]) + "/" + row["ImageFile"]),
                                           FileName_Company = Convert.ToString(row["CompanyImage"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/" + "FileUpload" + "/" + "/" + "CompanyImage" + "/" + Convert.ToInt64(row["CompanyId"]) + "/" + row["CompanyImage"].ToString()),
                                           PositionLevelName = Convert.ToString(row["PositionLevelName"] is DBNull ? "" : row["PositionLevelName"])
                                       }).ToList();


            model.JobTypeCollection = (from DataRow row in ds.Tables[1].Rows
                                       select new DropDownViewModel
                                       {
                                           Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                           Name = Convert.ToString(row["Name"])

                                       }).ToList();
            model.JobCategoryCollection = (from DataRow row in ds.Tables[2].Rows
                                           select new DropDownViewModel
                                           {
                                               Id = Convert.ToInt64(row["Jid"] is DBNull ? 0 : Convert.ToInt64(row["Jid"])),
                                               Name = Convert.ToString(row["Name"])

                                           }).ToList();

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }

            model.JobSearchdaysCollection = (from DataRow row in ds.Tables[3].Rows
                                             select new DropDownViewModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                 Name = Convert.ToString(row["Name"])

                                             }).ToList();


            model.StateCollection = (from DataRow row in ds.Tables[4].Rows
                                     select new DropDownViewModel
                                     {
                                         Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                         Name = Convert.ToString(row["Name"])
                                     }).ToList();


            if (ds.Tables[6].Rows.Count > 0)
            {
                model.SearchCollection = (from DataRow row in ds.Tables[6].Rows
                                          select new JobsModel
                                          {
                                              Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                              jobtitle = Convert.ToString(row["JobTitle"]),
                                              location = Convert.ToString(row["Location"]),
                                              JobCategoryName = Convert.ToString(row["categoryName"]),
                                              Jobtype = Convert.ToString(row["typeName"]),
                                              Designation = Convert.ToString(row["Designation"]),
                                              MinSalary = Convert.ToString(row["MinSalary"]),
                                              MaxSalary = Convert.ToString(row["MaxSalary"]),
                                              ClientId = Convert.ToInt64(row["ClientId"] is DBNull ? 0 : Convert.ToInt64(row["ClientId"])),
                                              Image = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + Convert.ToInt32(row["UserId"]) + "/" + row["ImageFile"].ToString()),
                                              FileName_Company = Convert.ToString(row["CompanyImage"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/" + "FileUpload" + "/" + "/" + "CompanyImage" + "/" + Convert.ToInt64(row["CompanyId"]) + "/" + row["CompanyImage"].ToString()),
                                              PositionLevelName = Convert.ToString(row["PositionLevelName"] is DBNull ? "" : row["PositionLevelName"])
                                          }).ToList();

            }
            model.Milescollection = (from DataRow row in ds.Tables[7].Rows
                                     select new DropDownViewModel
                                     {
                                         Id = Convert.ToInt64(row["milesid"] is DBNull ? 0 : Convert.ToInt64(row["milesid"])),
                                         Name = Convert.ToString(row["Name"])
                                     }).ToList();

        }

        internal void CreateContactUs(ContactUs model)
        {

            string Subject = "";

            string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);
            string AdminEmail = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"]);

            Subject = model.SubJect;
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(EmailTempletePath + "ContactUsEnquery.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{Name}}", model.Name);
            body = body.Replace("{{Email}}", model.Email);
            body = body.Replace("{{Phone}}", model.Phone);
            body = body.Replace("{{Message}}", model.Message);
            sendEmail(Subject, body, AdminEmail);

        }

        internal void unsubscribe(LoginModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ContactId = ds.Tables[0].Rows[0]["clientcontactId"].ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.Collection = (from DataRow row in ds.Tables[1].Rows
                                    select new DropDownViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"]),
                                        Name = Convert.ToString(row["Name"]),

                                    }).ToList();
            }
        }

        internal void CreateCandidate(LoginModel model, DataTable dt)
        {
            if (dt.Rows[0]["StatusId"].ToString() == "2")
            {
                string Subject = "";
                model.Status = Convert.ToInt64(dt.Rows[0]["StatusId"]);
                string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);

                Subject = "Verify an email address in your account"; // Your MVP Talent account has been created!

                string body = string.Empty;
                using (StreamReader reader = new StreamReader(EmailTempletePath + "CandidateCreateEmail.html"))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{{Name}}", model.Name);
                body = body.Replace("{{Email}}", model.Email);
                body = body.Replace("{{Phone}}", model.Phone);
                body = body.Replace("{{Password}}", model.Password);
                body = body.Replace("{{Title}}", model.Title);
                body = body.Replace("{{id}}", Encrypt(Convert.ToString(dt.Rows[0]["CurrentId"])));
                //sendEmail(Subject, body, model.Email);
            }

            model.Id = Convert.ToInt64(dt.Rows[0]["CurrentId"]);

        }

        internal void ChangePasswordEmail(LoginModel model, DataTable dt)
        {
            throw new NotImplementedException();
        }
        internal void ForgotPassword(LoginModel model, DataSet ds)
        {
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                string Subject = "";
                model.Status = Convert.ToInt64(ds.Tables[0].Rows[0]["Status"]);
                string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);
                Subject = "Reset Your MVP Telent Account.";
                var query = Encrypt(Convert.ToString(dt.Rows[0]["Id"]));
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(EmailTempletePath + "ResetPasswordEmail.html"))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{{Name}}", Convert.ToString(dt.Rows[0]["FirstName"]));
                body = body.Replace("{{Email}}", Convert.ToString(dt.Rows[0]["Email"]));
                body = body.Replace("{{ResetPassword}}", query);
                sendEmail(Subject, body, model.Email);
            }
            else
            {
                dt = ds.Tables[0];
                model.Status = Convert.ToInt64(dt.Rows[0]["Status"]);
            }
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


        private void sendEmail(string Subject, string MsgBody, string ToMailAddress)
        {
            string FromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmail"];
            string FromEmailName = System.Configuration.ConfigurationManager.AppSettings["FromEmailName"];
            string FromEmailPassword = System.Configuration.ConfigurationManager.AppSettings["FromEmailPassword"];
            string smtphost = System.Configuration.ConfigurationManager.AppSettings["smtphost"];
            Int32 smtpPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["smtpPort"]);
            bool EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EnableSsl"]);
            bool UseDefaultCredentials = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["UseDefaultCredentials"]);
            var plainView = AlternateView.CreateAlternateViewFromString(MsgBody, null, "text/plain");
            var htmlView = AlternateView.CreateAlternateViewFromString(MsgBody, null, "text/html");
            MailMessage mailMsg = new MailMessage();
            mailMsg.IsBodyHtml = true;
            mailMsg.From = new MailAddress(FromEmail, FromEmailName);
            mailMsg.To.Add(ToMailAddress);
            mailMsg.Subject = Subject;
            mailMsg.Body = MsgBody;
            mailMsg.Headers.Add("List-Unsubscribe", "<mailto:" + FromEmail + "?subject=unsubscribe>");
            mailMsg.Sender = new MailAddress(FromEmail);
            mailMsg.AlternateViews.Add(plainView);
            mailMsg.AlternateViews.Add(htmlView);
            SmtpClient smtp = new SmtpClient(smtphost, Convert.ToInt32(smtpPort));
            smtp.EnableSsl = EnableSsl;
            smtp.UseDefaultCredentials = UseDefaultCredentials;
            mailMsg.IsBodyHtml = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(FromEmail, FromEmailPassword);
            smtp.Host = smtphost;
            smtp.Send(mailMsg);
        }
    }
}