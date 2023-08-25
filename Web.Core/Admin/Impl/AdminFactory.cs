using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Web.Core.Candidate.Impl;
using Web.Core.Common.Impl;
using Web.Model.Admin;
using Web.Model.Client;
using Web.Model.Common;

namespace Web.Core.Admin.Impl
{
    public class AdminFactory
    {
        CandidateFactory objCandidateFactory = new CandidateFactory();
        internal void GetCompanyDetailById(ClientModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["Id"]));
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Website = Convert.ToString(dt.Rows[0]["Website"]);
                model.Zip = Convert.ToString(dt.Rows[0]["zipcode"]);
                model.Location = Convert.ToString(dt.Rows[0]["Location"]);
                model.Address = Convert.ToString(dt.Rows[0]["Address"]);
                model.Description = Convert.ToString(dt.Rows[0]["Description"]);
                model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"]);
            }

        }

        internal void emailpopup(EmailTempleteViewModel model, DataSet ds)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["Id"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["Id"]));
                model.clientcontactId = Convert.ToInt64(ds.Tables[0].Rows[0]["clientcontactId"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["clientcontactId"]));
                model.emailtempleteid = Convert.ToInt64(ds.Tables[0].Rows[0]["emailtempleteid"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["emailtempleteid"]));
                model.Subject = Convert.ToString(ds.Tables[0].Rows[0]["Subject"]);
                model.Description = Convert.ToString(ds.Tables[0].Rows[0]["Description"]);
                model.Description1 = Convert.ToString(ds.Tables[0].Rows[0]["Description1"]);
                model.Description2 = Convert.ToString(ds.Tables[0].Rows[0]["Description2"]);
                model.Description3 = Convert.ToString(ds.Tables[0].Rows[0]["Description3"]);
                model.FirstFollowDate = ds.Tables[0].Rows[0]["FirstFollowDate"].ToString(); // ds.Tables[0].Rows[0]["FirstFollowDate"] is DBNull ? "" : Convert.ToDateTime( ).ToString("MM/dd/yyyy");
                model.secondFollowDate = ds.Tables[0].Rows[0]["secondFollowDate"].ToString(); // ds.Tables[0].Rows[0]["FirstFollowDate"] is DBNull ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["secondFollowDate"]).ToString("MM/dd/yyyy");
                model.thirdfollowdate = ds.Tables[0].Rows[0]["thirdfollowdate"].ToString(); // ds.Tables[0].Rows[0]["FirstFollowDate"] is DBNull ? "" : Convert.ToDateTime(ds.Tables[0].Rows[0]["thirdfollowdate"]).ToString("MM/dd/yyyy");
                model.isfollow = Convert.ToInt64(ds.Tables[0].Rows[0]["isfollow"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["isfollow"]));

            }

            model.Collectionemailtemplete = (from DataRow row in ds.Tables[1].Rows
                                             select new DropDownViewModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 Name = Convert.ToString(row["Name"])

                                             }).ToList();


            model.Collectionclientcontact = (from DataRow row in ds.Tables[2].Rows
                                             select new DropDownViewModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 Name = Convert.ToString(row["Name"]),
                                                 Email = Convert.ToString(row["Email"])
                                             }).ToList();


            model.candidategroupcollection = (from DataRow row in ds.Tables[3].Rows
                                              select new DropDownViewModel
                                              {
                                                  Id = Convert.ToInt64(row["Id"]),
                                                  Name = Convert.ToString(row["Name"])
                                              }).ToList();
        }

        internal void pipeline(ClientModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.PipelineCollection = (from DataRow row in ds.Tables[0].Rows
                                            select new ClientModel
                                            {
                                                Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                pipelineId = Convert.ToString(row["pipelineId"]),
                                                Company = Convert.ToString(row["Name"]),
                                                Website = Convert.ToString(row["website"]),
                                                Name = Convert.ToString(row["contactname"]),
                                                Email = Convert.ToString(row["Email"]),
                                                Pipelinename = Convert.ToString(row["Pipelinename"]),
                                                ClientId = Convert.ToInt64(row["ClientId"] is DBNull ? 0 : Convert.ToInt64(row["ClientId"])),
                                                Ids = Convert.ToString(EncryptDecrypt.encrypt(row["ClientId"].ToString()).ToString()),
                                                ClientContactPhone = Convert.ToString(row["phone"]),
                                            }).ToList();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                model.PipelineStatusCollection = (from DataRow row in ds.Tables[1].Rows
                                                  select new ClientModel
                                                  {
                                                      Id = Convert.ToInt32(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                      Name = Convert.ToString(row["Name"])

                                                  }).ToList();
            }

        }

        internal void GetCompanyIdByEmail(ClientModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Ids = Convert.ToString(EncryptDecrypt.encrypt(dt.Rows[0]["clientid"].ToString()));

            }
            else
            {
                model.Ids = "0";
            }
        }

        internal void sharedJob(JobsModel model, DataSet ds)
        {
            model.JobListCollection = (from DataRow row in ds.Tables[0].Rows
                                       select new JobsModel
                                       {

                                           Id = Convert.ToInt64(row["Id"]),
                                           Ids = EncryptDecrypt.encrypt(row["Id"].ToString()),
                                           jobtitle = Convert.ToString(row["JobTitle"]),
                                           JobTypeName = Convert.ToString(row["typeName"]),
                                           JobStatusName = Convert.ToString(row["StatusName"]),
                                           City = Convert.ToString(row["StatusName"]),
                                           WorkExperienceMax = Convert.ToString(row["MaxExeperience"]),
                                           //qualificationName = Convert.ToString(row["qualificationName"]),
                                           JobCategoryName = Convert.ToString(row["categoryName"]),
                                           createddate = Convert.ToString(row["CreatedDate"]),
                                           UserName = Convert.ToString(row["ClientName"]),
                                           SharedJobDate = row["AdminSharedDate"] is DBNull ? "" : Convert.ToDateTime(row["AdminSharedDate"]).ToShortDateString(),
                                           ClientName = Convert.ToString(row["NameOfCompany"]),
                                       }).ToList();

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.pageno);
            }

            model.ClientCollection = (from DataRow row in ds.Tables[1].Rows
                                      select new DropDownViewModel
                                      {
                                          Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                          Ids = EncryptDecrypt.encrypt(Convert.ToString(row["Id"])),
                                          Name = Convert.ToString(row["Name"] is DBNull ? " " : row["Name"])

                                      }).ToList();


            model.JobStatusCollection = (from DataRow row in ds.Tables[2].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                             Name = Convert.ToString(row["Name"])

                                         }).ToList();
        }

        internal void Alert(Alertmodel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            model.alertjobcollection = (from DataRow row in dt.Rows
                                        select new Alertmodel
                                        {
                                            Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                            AlertId = Convert.ToInt64(row["AlertId"] is DBNull ? 0 : Convert.ToInt64(row["AlertId"])),
                                            JobTitle = Convert.ToString(row["JobTitle"]),
                                            location = Convert.ToString(row["location"]),
                                            AlertName = Convert.ToString(row["AlertName"]),
                                            Name = Convert.ToString(row["Name"]),
                                            Email = Convert.ToString(row["Email"]),
                                            StatusId = Convert.ToInt64(row["statusid"] is DBNull ? 0 : Convert.ToInt64(row["statusid"])),
                                            Createddate = Convert.ToDateTime(row["Createddate"]).ToShortDateString(),
                                            lastsentdate = row["Createddate"] is DBNull ? "" : Convert.ToDateTime(row["Createddate"]).ToShortDateString(),
                                        }).ToList();
        }

        internal void addnewrole(RoleViewModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.statusId = Convert.ToInt16(ds.Tables[0].Rows[0]["statusId"]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                string Page = "";
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    Page += ds.Tables[1].Rows[i]["SubMenuId"].ToString() + ",";
                }
                model.PageId = Page.Remove(Page.Length - 1, 1); ;
            }
        }

        internal void generalmessagesdetails(ClientModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            model.ClienConversationcollection = (from DataRow row in dt.Rows
                                                 select new ClientModel
                                                 {
                                                     Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                     EnquireyId = Convert.ToInt64(row["sendenuireyId"] is DBNull ? 0 : Convert.ToInt64(row["sendenuireyId"])),
                                                     fromId = Convert.ToInt64(row["fromId"] is DBNull ? 0 : Convert.ToInt64(row["fromId"])),
                                                     ToId = Convert.ToInt64(row["ToId"] is DBNull ? 0 : Convert.ToInt64(row["ToId"])),
                                                     Name = Convert.ToString(row["messagesenderName"]),
                                                     CreatedDate = Convert.ToString(row["CreatedDate"]),
                                                     CreateBy = Convert.ToInt64(row["CreatedBy"]),
                                                     Description = Convert.ToString(row["Massege"]).ToString(),
                                                     clientLogo = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + row["ImageFile"].ToString()),
                                                     // Title = Convert.ToString(row["sendquerytitle"]),

                                                 }).ToList();
            if (ds.Tables[2].Rows.Count > 0)
            {
                model.Title = ds.Tables[2].Rows[0]["Title"].ToString();
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                model.AccountTypeId = ds.Tables[3].Rows[0]["AccountTypeId"] is DBNull ? 0 : Convert.ToInt32(ds.Tables[3].Rows[0]["AccountTypeId"]);
                model.Name = ds.Tables[3].Rows[0]["Name"] is DBNull ? "" : ds.Tables[3].Rows[0]["Name"].ToString();
                model.LastName = ds.Tables[3].Rows[0]["LastName"] is DBNull ? "" : ds.Tables[3].Rows[0]["LastName"].ToString();
                model.Email = ds.Tables[3].Rows[0]["Email"] is DBNull ? "" : ds.Tables[3].Rows[0]["Email"].ToString();
                model.ClientPhone = ds.Tables[3].Rows[0]["PhoneNo"] is DBNull ? "" : ds.Tables[3].Rows[0]["PhoneNo"].ToString();
                model.Address = ds.Tables[3].Rows[0]["Address1"] is DBNull ? "" : ds.Tables[3].Rows[0]["Address1"].ToString();
                model.Location = ds.Tables[3].Rows[0]["Location"] is DBNull ? "" : ds.Tables[3].Rows[0]["Location"].ToString();
                model.Role = ds.Tables[3].Rows[0]["RoleName"] is DBNull ? "" : ds.Tables[3].Rows[0]["RoleName"].ToString();
                model.ClientId = Convert.ToInt64(ds.Tables[3].Rows[0]["UserId"]);
                model.CandidateId = Convert.ToInt64(ds.Tables[3].Rows[0]["UserId"]);
            }
            
            //if (dt1.Rows.Count > 0)
            //{
            //    model.ClientId = Convert.ToInt64(dt1.Rows[0]["ClientId"]);
            //}
            //if (ds.Tables[2].Rows.Count > 0)
            //{
            //    model.Title = Convert.ToString(ds.Tables[2].Rows[0]["Title"]);
            //    model.CandidateId = Convert.ToInt64(ds.Tables[2].Rows[0]["CandidateId"]);
            //}



        }

        internal void CreateCompany(ClientModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Status = Convert.ToInt64(dt.Rows[0]["StatusId"]);
            }
            if (model.LoginAccess == 1)
            {
                string Subject = "";
                string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);

                Subject = "Welcome to MVP Talent."; // Your MVP Talent account has been created!

                string body = string.Empty;
                using (StreamReader reader = new StreamReader(EmailTempletePath + "CandidateCreateEmail.html"))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{{Name}}", model.Name + " " + model.LastName);
                body = body.Replace("{{Email}}", model.Email);
                body = body.Replace("{{Phone}}", model.Phone1);
                body = body.Replace("{{Password}}", model.Password);
                body = body.Replace("{{Title}}", model.Position);
                body = body.Replace("{{id}}", Encrypt(Convert.ToString(dt.Rows[0]["Id"])));
                sendEmail(Subject, body, model.Email);
            }
        }

        internal void ClientProfileById(ClientModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Name = dt.Rows[0]["Name"].ToString();
                model.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                model.ClientPhone = dt.Rows[0]["PhoneNo"].ToString();
                model.Website = dt.Rows[0]["Website"].ToString();
                model.Location = dt.Rows[0]["Location"].ToString();
                model.Zip = dt.Rows[0]["Zipcode"].ToString();
                model.Address = dt.Rows[0]["Address"].ToString();
                model.FaceBook = dt.Rows[0]["FacebookUrl"].ToString();
                model.Twitter = dt.Rows[0]["twitterUrl"].ToString();
                model.Linkdin = dt.Rows[0]["Linkedinurl"].ToString();
                //model.clientLogo = dt.Rows[0]["ImageFile"].ToString();
                model.Description = dt.Rows[0]["Description"].ToString();
                model.clientLogo = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/CandidateImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + dt.Rows[0]["Id"].ToString() + "/" + dt.Rows[0]["ImageFile"].ToString());

            }
        }

        internal void AutoCompleteClient(ClientModel model, DataTable dt)
        {

            model.clientlistcollection = (from DataRow row in dt.Rows
                                          select new DropDownViewModel
                                          {
                                              Id = Convert.ToInt64(row["UserId"] is DBNull ? 0 : row["UserId"]),
                                              Name = Convert.ToString(row["clientname"])
                                          }).ToList();


        }

        internal void GeneralMessages(ClientModel model, DataSet ds)
        {



            DataTable dt = ds.Tables[0];
            model.generalmessagecollection = (from DataRow row in dt.Rows
                                              select new ClientModel
                                              {
                                                  Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                  Unreadcount = Convert.ToInt64(row["Unreadcount"] is DBNull ? 0 : Convert.ToInt64(row["Unreadcount"])),
                                                  Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString()).ToString()),
                                                  Fromname = Convert.ToString(row["Fromname"]),
                                                  ToName = Convert.ToString(row["ToName"]),
                                                  // ClientId = Convert.ToInt64(row["ClientId"] is DBNull ? 0 : Convert.ToInt64(row["ClientId"])),
                                                  Title = Convert.ToString(row["Title"]),
                                                  CreatedDate = Convert.ToDateTime(row["Createddate"]).ToShortDateString(),
                                                  Email = Convert.ToString(row["Email"])
                                              }).ToList();
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.Name = ds.Tables[1].Rows[0]["Name"].ToString() + " " + ds.Tables[1].Rows[0]["Email"].ToString() + ")";
            }
            if (dt.Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
        }

        internal void messagesdetail(Candidateconversationmodel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.candidateconversationcollection = (from DataRow row in ds.Tables[0].Rows
                                                         select new CandidateConversationEditModel
                                                         {
                                                             Id = Convert.ToInt64(row["CreatedBy"] is DBNull ? 0 : Convert.ToInt64(row["CreatedBy"])),
                                                             AccountTypeId = Convert.ToInt64(row["AccountTypeId"] is DBNull ? 0 : Convert.ToInt64(row["AccountTypeId"])),
                                                             Description = Convert.ToString(row["Massege"]),
                                                             Name = Convert.ToString(row["messagesendername"]),
                                                             SendName = Convert.ToString(row["SendName"]),
                                                             createddate = Convert.ToString(row["Createddate"]),
                                                             frmId = Convert.ToInt64(row["FromId"] is DBNull ? 0 : Convert.ToInt64(row["FromId"])),
                                                             CreateBy = Convert.ToInt64(row["CreatedBy"] is DBNull ? 0 : Convert.ToInt64(row["CreatedBy"])),
                                                             imageFile = Convert.ToString(row["ImageFile"]),
                                                             FileName = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + row["ImageFile"].ToString()),
                                                             clientlogo = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/CandidateImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + row["CreatedBy"].ToString() + "/" + row["ImageFile"].ToString()),

                                                         }).ToList();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                // candidate detail
                model.CandidateId = Convert.ToInt64(ds.Tables[1].Rows[0]["UserId"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[1].Rows[0]["UserId"]));
                model.CandidateImage = Convert.ToString(ds.Tables[1].Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + ds.Tables[1].Rows[0]["ImageFile"].ToString());
                model.CandidateName = Convert.ToString(ds.Tables[1].Rows[0]["Name"]) + " " + Convert.ToString(ds.Tables[1].Rows[0]["LastName"]);
                model.CandidateEmail = Convert.ToString(ds.Tables[1].Rows[0]["Email"]);
                model.CandidatePhoneNo = Convert.ToString(ds.Tables[1].Rows[0]["PhoneNo"]);
                model.CandidateTitle = Convert.ToString(ds.Tables[1].Rows[0]["Title"]);
                model.CandidateLocation = Convert.ToString(ds.Tables[1].Rows[0]["Location"]);
                model.location = Convert.ToString(ds.Tables[1].Rows[0]["location"]);
                model.CandidateEmail = Convert.ToString(ds.Tables[1].Rows[0]["Email"]);
                model.zipcode = Convert.ToString(ds.Tables[1].Rows[0]["Zipcode"]);
                model.CandidateJobTypeName = Convert.ToString(ds.Tables[1].Rows[0]["jobtype"]);
                model.Salery = Convert.ToString(ds.Tables[1].Rows[0]["Salery"]);

                model.DesiredTitle1 = Convert.ToString(ds.Tables[1].Rows[0]["DesiredTitle1"]);
                model.DesiredTitle2 = Convert.ToString(ds.Tables[1].Rows[0]["DesiredTitle2"]);

            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                model.ClientId = Convert.ToInt64(ds.Tables[2].Rows[0]["UserId"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[2].Rows[0]["UserId"]));
                model.ClientImage = Convert.ToString(ds.Tables[2].Rows[0]["ImageFile"] is DBNull ? "/FileUpload/CandidateImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + ds.Tables[2].Rows[0]["UserId"].ToString() + "/" + ds.Tables[2].Rows[0]["ImageFile"].ToString());
                model.ClientName = Convert.ToString(ds.Tables[2].Rows[0]["Name"]) + " " + Convert.ToString(ds.Tables[2].Rows[0]["LastName"]);
                model.ClientEmail = Convert.ToString(ds.Tables[2].Rows[0]["Email"]);
                model.ClientPhoneNo = Convert.ToString(ds.Tables[2].Rows[0]["PhoneNo"]);
                model.ClientWebsite = Convert.ToString(ds.Tables[2].Rows[0]["CompanyWebsite"]);
                model.compnayname = Convert.ToString(ds.Tables[2].Rows[0]["CompanyName"]);
                model.location = Convert.ToString(ds.Tables[2].Rows[0]["CompanyLoaction"]);
            }



            if (ds.Tables[3].Rows.Count > 0)
            {
                model.JobId = Convert.ToInt64(ds.Tables[3].Rows[0]["JobId"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[3].Rows[0]["JobId"]));
                model.JobTitle = ds.Tables[3].Rows[0]["JobTitle"].ToString();
                model.qualificationName = ds.Tables[3].Rows[0]["qualificationName"].ToString();
                model.JobTypeName = ds.Tables[3].Rows[0]["typeName"].ToString();
                model.DesignationName = ds.Tables[3].Rows[0]["DesignationName"].ToString();
                model.location = ds.Tables[3].Rows[0]["Location"].ToString();
                model.MinSalary = ds.Tables[3].Rows[0]["MinSalary"].ToString();
                model.MaxSalary = ds.Tables[3].Rows[0]["MaxSalary"].ToString();
                model.jobcategory = ds.Tables[3].Rows[0]["jobcategoryName"].ToString();
            }

        }

        internal void messages(Candidateconversationmodel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.CollectionList = (from DataRow row in ds.Tables[0].Rows
                                        select new CandidateConversationEditModel
                                        {
                                            Unreadcount = Convert.ToInt64(row["Unreadcount"] is DBNull ? 0 : Convert.ToInt64(row["Unreadcount"])),
                                            Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                            Ids = EncryptDecrypt.encrypt(row["Id"].ToString()),
                                            CandidateName = Convert.ToString(row["CandidateName"]),
                                            ClientName = Convert.ToString(row["ClientName"]),
                                            JobTitle = Convert.ToString(row["JobTitle"]),
                                            Date = Convert.ToDateTime(row["Createddate"]).ToShortDateString(),
                                        }).ToList();

            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.Collection = (from DataRow row in ds.Tables[1].Rows
                                    select new DropDownViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                        Name = Convert.ToString(row["Name"]),
                                    }).ToList();

            }


            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
        }

        internal void getpage(RoleListModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Collection = (from DataRow row in dt.Rows
                                    select new DropDownViewModel
                                    {
                                        Id = Convert.ToInt16(row["SubMenuId"]),
                                        Name = Convert.ToString(row["SubMenuName"]),
                                    }).ToList();


            }
        }

        internal void Role(RoleListModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Collection = (from DataRow row in dt.Rows
                                    select new DropDownViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                        StatusId = Convert.ToInt64(row["statusId"] is DBNull ? 0 : Convert.ToInt64(row["statusId"])),
                                        Name = Convert.ToString(row["Name"]),
                                        Date = Convert.ToDateTime(row["CreatedDate"]).ToShortDateString(),

                                    }).ToList();

            }
        }

        internal void UserList(UserManagmentmodel model, DataTable dt)
        {
            model.UserListcollection = (from DataRow row in dt.Rows
                                        select new UserManagmentmodel
                                        {
                                            Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                            Ids = EncryptDecrypt.encrypt(row["Id"].ToString()),
                                            FirstName = Convert.ToString(row["Name"]),
                                            RoleName = Convert.ToString(row["RoleName"]),
                                            Email = Convert.ToString(row["Email"]),
                                            Phoneno = Convert.ToString(row["PhoneNo"]),
                                            StatusId = Convert.ToInt64(row["Status"] is DBNull ? 0 : Convert.ToInt64(row["Status"])),
                                            Createddate = Convert.ToDateTime(row["craetedate"]).ToShortDateString(),

                                        }).ToList();
        }

        internal void AdminUsermanage(UserManagmentmodel model, DataTable dt)
        {
            if (dt.Rows[0]["StatusId"].ToString() == "2")
            {
                string Subject = "";
                model.StatusId = Convert.ToInt64(dt.Rows[0]["StatusId"]);
                string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);

                Subject = "Welcome to MVP Talent."; // Your MVP Talent account has been created!

                string body = string.Empty;
                using (StreamReader reader = new StreamReader(EmailTempletePath + "CandidateCreateEmail.html"))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{{Name}}", model.FirstName);
                body = body.Replace("{{Email}}", model.Email);
                body = body.Replace("{{Phone}}", model.Phoneno);
                body = body.Replace("{{Password}}", model.Password);

                body = body.Replace("{{id}}", Encrypt(Convert.ToString(dt.Rows[0]["CurrentId"])));
                sendEmail(Subject, body, model.Email);
            }
            model.StatusId = Convert.ToInt64(dt.Rows[0]["StatusId"]);
            model.Id = Convert.ToInt64(dt.Rows[0]["CurrentId"]);
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


        internal void Users(UserManagmentmodel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];

            if (dt.Rows.Count > 0)
            {
                var Password = dt.Rows[0]["Password"].ToString();
                var Salt = dt.Rows[0]["Salt"].ToString();
                var decreptPassword = Craptography.Decrypt(Password, Salt);
                model.Password = decreptPassword;
                model.FirstName = Convert.ToString(dt.Rows[0]["Name"]);
                model.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                model.Phoneno = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                model.RoleId = Convert.ToInt64(dt.Rows[0]["RoleId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["RoleId"]));
            }


            model.rolecollection = (from DataRow row in dt1.Rows
                                    select new DropDownViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                        Name = Convert.ToString(row["Name"])
                                    }).ToList();
        }

        internal void sharjobIdziprecuiter(JobsModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.JobPostStatus = Convert.ToInt64(dt.Rows[0]["JobPostStatus"]);
            }
        }

        internal void getTagBytype566Id(CampaignModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.CampaigntypeCollection = (from DataRow row in dt.Rows
                                                select new DropDownViewModel
                                                {
                                                    Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                    Name = Convert.ToString(row["Name"])
                                                }).ToList();
            }
        }

        internal void NewLetter(EnquiresViewModel model, DataTable dt)
        {
            model.Newlettercollection = (from DataRow row in dt.Rows
                                         select new EnquiresViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                             Name = Convert.ToString(row["Name"]),
                                             Email = Convert.ToString(row["email"]),
                                             Date = Convert.ToDateTime(row["createddate"]).ToShortDateString()
                                         }).ToList();
        }

        internal void campaignhistory(CampaignModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["type"].ToString() == "2")
                {
                    model.Campaigncontactcollection = (from DataRow row in ds.Tables[0].Rows
                                                       select new CampaignModel
                                                       {
                                                           Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                           Name = Convert.ToString(row["Name"]),
                                                           Email = Convert.ToString(row["email"]),
                                                           count = Convert.ToString(row["count"]),
                                                           Phone = Convert.ToString(row["phone"]),
                                                           ComapnyName = Convert.ToString(row["clientcompanyname"]),
                                                       }).ToList();
                }
                else
                {
                    model.Campaigncontactcollection = (from DataRow row in ds.Tables[0].Rows
                                                       select new CampaignModel
                                                       {
                                                           Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                           Name = Convert.ToString(row["Name"] + "" + row["LastName"]),
                                                           Email = Convert.ToString(row["email"]),
                                                           count = Convert.ToString(row["count"]),
                                                           Phone = Convert.ToString(row["phone"]),

                                                       }).ToList();
                }


            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.campaigntypeid = Convert.ToInt64(ds.Tables[1].Rows[0]["type"]);

            }


            model.campaigncollection = (from DataRow row in ds.Tables[2].Rows
                                        select new CampaignModel
                                        {
                                            Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                            Name = Convert.ToString(row["Name"])
                                        }).ToList();
        }

        internal void Campaign(CampaignModel model, DataSet ds)
        {
            model.campaigncollection = (from DataRow row in ds.Tables[0].Rows
                                        select new CampaignModel
                                        {
                                            Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                            Name = Convert.ToString(row["Name"]),
                                            Subject = Convert.ToString(row["Subject"]),
                                            contactcount = Convert.ToInt64(row["Emailcount"]),
                                            sentcontactcount = Convert.ToInt64(row["sentemailcount"]),
                                            emailbody = Convert.ToString(row["EmailBody"]),
                                            CStatusId = Convert.ToInt64(row["CampaignStatus"] is DBNull ? 0 : Convert.ToInt64(row["CampaignStatus"])),
                                            StatusName = Convert.ToString(row["StatusName"]),
                                        }).ToList();

            model.CampaignstatusCollection = (from DataRow row in ds.Tables[1].Rows
                                              select new DropDownViewModel
                                              {
                                                  Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                  Name = Convert.ToString(row["Name"])
                                              }).ToList();
        }

        internal void NewCampaign(CampaignModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["Id"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["Id"]));
                model.Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                model.Subject = Convert.ToString(ds.Tables[0].Rows[0]["Subject"]);
                model.emailbody = Convert.ToString(ds.Tables[0].Rows[0]["EmailBody"]);
                model.CStatusId = Convert.ToInt64(ds.Tables[0].Rows[0]["CampaignStatus"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["CampaignStatus"]));
                model.campaigntypeid = Convert.ToInt64(ds.Tables[0].Rows[0]["campaigntypeid"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["campaigntypeid"]));

            }

            model.CampaignstatusCollection = (from DataRow row in ds.Tables[1].Rows
                                              select new DropDownViewModel
                                              {
                                                  Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                  Name = Convert.ToString(row["Name"])
                                              }).ToList();


            model.CampaigntypeCollection = (from DataRow row in ds.Tables[2].Rows
                                            select new DropDownViewModel
                                            {
                                                Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                Name = Convert.ToString(row["Name"])
                                            }).ToList();



            if (ds.Tables[3].Rows.Count > 0)
            {
                string tag = "";
                for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                {
                    tag += ds.Tables[3].Rows[i]["tagId"].ToString() + ",";
                }
                model.tagids = tag.Remove(tag.Length - 1, 1); ;
            }


        }

        internal void emailEditpopup(EmailTempleteViewModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["Id"]));
                model.Subject = Convert.ToString(dt.Rows[0]["subject"]);
                model.Description1 = Convert.ToString(dt.Rows[0]["Description1"]);
                model.Description2 = Convert.ToString(dt.Rows[0]["Description2"]);
                model.Description3 = Convert.ToString(dt.Rows[0]["Description3"]);
            }
        }

        internal void SubmissionProfile(JobsModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.submissionprofilelistcollection = (from DataRow row in ds.Tables[0].Rows
                                                         select new JobsModel
                                                         {
                                                             Id = Convert.ToInt64(row["UserId"]),
                                                             Ids = EncryptDecrypt.encrypt(row["UserId"].ToString()),
                                                             Name = Convert.ToString(row["Name"] + " " + Convert.ToString(row["LastName"])),
                                                             Email = Convert.ToString(row["Email"]),
                                                             Phone = Convert.ToString(row["PhoneNo"]),
                                                             location = Convert.ToString(row["Location"]),
                                                             zipcode = Convert.ToString(row["Zipcode"]),
                                                             JobId = Convert.ToInt64(row["applyjobJobId"]),
                                                             InterviewSId = Convert.ToInt64(row["InterviewStatusId"] is DBNull ? 0 : Convert.ToInt64(row["InterviewStatusId"])),
                                                             applyjobId = Convert.ToInt64(row["applyjobId"])
                                                         }).ToList();
            }



            model.JobListCollection = (from DataRow row in ds.Tables[1].Rows
                                       select new JobsModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Ids = EncryptDecrypt.encrypt(row["Id"].ToString()),
                                           Name = Convert.ToString(row["JobTitle"])

                                       }).ToList();
            model.JobStatusCollection = (from DataRow row in ds.Tables[2].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                             Name = Convert.ToString(row["Name"])

                                         }).ToList();
        }

        internal void Createuploadresumesave(JobsModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.StatusId = Convert.ToInt64(ds.Tables[0].Rows[0]["StatusId"]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.UserId = Convert.ToInt64(ds.Tables[1].Rows[0]["v_CurrentId"]);
            }
        }

        internal void getassignByEmail(ClientModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Status = Convert.ToInt64(dt.Rows[0]["StatusId"]);
                if (model.Status == 1)
                {
                    model.ClientId = Convert.ToInt64(dt.Rows[0]["UserId"]);
                    model.CompanyName = Convert.ToString(dt.Rows[0]["CompanyName"]);
                    model.Website = Convert.ToString(dt.Rows[0]["Website"]);
                    model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    model.Phone1 = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                    model.Address = Convert.ToString(dt.Rows[0]["Address1"]);
                    model.CountryId = Convert.ToInt64(dt.Rows[0]["CountryId"]);
                    model.StateId = Convert.ToInt64(dt.Rows[0]["StateId"]);
                    model.Zip = Convert.ToString(dt.Rows[0]["Zipcode"]);
                    model.CountryName = Convert.ToString(dt.Rows[0]["CountryName"]);
                    model.StateName = Convert.ToString(dt.Rows[0]["StateName"]);
                    model.CityName = Convert.ToString(dt.Rows[0]["CityName"]);
                }

            }
        }

        internal void InterviewSchedulepopup(ClientModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            DataTable dt2 = ds.Tables[2];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["Id"]));
                model.ClientId = Convert.ToInt64(dt.Rows[0]["ClientId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["ClientId"]));
                model.CandidateId = Convert.ToInt64(dt.Rows[0]["CandidateId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["CandidateId"]));
                 

                string[] subs = dt.Rows[0]["Interviewdate"].ToString().Split('-');

                var InterviewDate = subs[1] + "-" + subs[2] + "-" + subs[0] + " " + dt.Rows[0]["InterviewTime"].ToString();


                model.InterviewDate = InterviewDate; // Convert.ToString(dt.Rows[0]["Interviewdate"] is DBNull ? "" : dt.Rows[0]["InterviewDate"] + " "+  dt.Rows[0]["InterviewTime"]);
                model.Title = Convert.ToString(dt.Rows[0]["tilte"]);
                model.Description = Convert.ToString(dt.Rows[0]["Description"]);
                model.CreatedDate = Convert.ToString(dt.Rows[0]["CreatedDate"]);
                model.Location = Convert.ToString(dt.Rows[0]["Location"]);
                model.InterviewBcc = Convert.ToString(dt.Rows[0]["Bcc"]);
                model.InterviewCc = Convert.ToString(dt.Rows[0]["CC"]);

                model.CandidateName = Convert.ToString(dt.Rows[0]["CandidateName"]);
                model.Email = Convert.ToString(dt.Rows[0]["CandidateEmail"]);
                model.ClientName = Convert.ToString(dt.Rows[0]["ClientName"]);
                model.ClientEmail = Convert.ToString(dt.Rows[0]["ClientEmail"]);
                model.CreatedByName = Convert.ToString(dt.Rows[0]["CreatedByName"]);
                model.Jobtitle = Convert.ToString(dt.Rows[0]["JobTitle"]);
            }
            //if(dt1.Rows.Count > 0)
            //{
            //    model.ClientEmail = Convert.ToString(dt1.Rows[0]["ClientEmail"]);
            //    model.ClientName = Convert.ToString(dt1.Rows[0]["FirstName"]) + ' ' + Convert.ToString(dt1.Rows[0]["LastName"]);
            //}
            if (dt2.Rows.Count > 0)
            {
                model.CandidateName = Convert.ToString(dt2.Rows[0]["FirstName"]) + ' ' + Convert.ToString(dt2.Rows[0]["LastName"]);
                model.Email = Convert.ToString(dt2.Rows[0]["CandidateEmail"]);
            }
            model.joblistcollection = (from DataRow row in ds.Tables[3].Rows
                                       select new ClientModel
                                       {
                                           Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                           Title = Convert.ToString(row["JobTitle"])


                                       }).ToList();
        }

        internal void UpdateInterviewschedule(ClientModel model, DataSet ds)

        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                string Subject = string.Empty;
                if (model.Id > 0)
                {
                     Subject = "Interview Reschedule - " + Convert.ToString(ds.Tables[1].Rows[0]["JobTitle"]) + " - " + Convert.ToString(ds.Tables[1].Rows[0]["Interviewdate"]) + " " + Convert.ToString(ds.Tables[1].Rows[0]["InterviewTime"]);
                }
                else
                {
                     Subject = "Interview Schedule - " + Convert.ToString(ds.Tables[1].Rows[0]["JobTitle"]) + " - " + Convert.ToString(ds.Tables[1].Rows[0]["Interviewdate"]) + " " + Convert.ToString(ds.Tables[1].Rows[0]["InterviewTime"]);
                }

                string EmailTempletePath = string.Empty;
                if (model.Id > 0)
                {
                     EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]) + "RescheduleInterviewEmail.html";
                }
                else
                {
                     EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]) + "InterviewEmail.html";
                }
                //model.StatusId = Convert.ToInt64(dt.Rows[0]["StatusId"]);                

                /* Subject = model.candidateTitle;*/ // Your MVP Talent account has been created!
                string body = string.Empty;


                using (StreamReader reader = new StreamReader(EmailTempletePath))
                {
                    body = reader.ReadToEnd();
                }

                body = body.Replace("{{JobTitle}}", Convert.ToString(ds.Tables[1].Rows[0]["JobTitle"]));
                body = body.Replace("{{InterViewDate}}", Convert.ToString(ds.Tables[1].Rows[0]["Interviewdate"] + " " + ds.Tables[1].Rows[0]["InterviewTime"]));
                body = body.Replace("{{CandidateName}}", model.CandidateName);
                body = body.Replace("{{ClientName}}", model.ClientName);
                body = body.Replace("{{Location}}", model.Location);
                body = body.Replace("{{JobId}}", Convert.ToString(model.JobId));
                body = body.Replace("{{Description}}", model.Description);

                string toEmail = model.Email + ',' + model.ClientEmail;


                //sendEmail(Subject, body, toEmail);
                string FromEmailName = System.Configuration.ConfigurationManager.AppSettings["FromEmailName"];
                string FromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmail"];
                string FromEmailPassword = System.Configuration.ConfigurationManager.AppSettings["FromEmailPassword"];
                string smtphost = System.Configuration.ConfigurationManager.AppSettings["smtphost"];
                Int32 smtpPort = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["smtpPort"]);
                bool EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["EnableSsl"]);
                bool UseDefaultCredentials = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["UseDefaultCredentials"]);

                MailMessage mailMsg = new MailMessage();
                if (model.InterviewBcc != null)
                {
                    mailMsg.Bcc.Add(model.InterviewBcc);
                }
                if (model.InterviewCc != null)
                {
                    mailMsg.CC.Add(model.InterviewCc);
                }
                mailMsg.IsBodyHtml = true;
                mailMsg.From = new MailAddress(FromEmail, FromEmailName);
                mailMsg.To.Add(toEmail);
                mailMsg.Subject = Subject;
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
                smtp.Send(mailMsg);
            }


        }

        internal void InterviewSceduleList(ClientModel model, DataSet ds)
        {
            model.interviewListCollection = (from DataRow row in ds.Tables[0].Rows

                                             select new ClientModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                 ClientId = Convert.ToInt64(row["ClientId"] is DBNull ? 0 : Convert.ToInt64(row["ClientId"])),
                                                 CandidateId = Convert.ToInt64(row["CandidateId"]),
                                                 Ids = Convert.ToString(EncryptDecrypt.encrypt(row["CandidateId"].ToString())),
                                                 candidateTitle = Convert.ToString(row["tilte"]),
                                                 InterviewDate = Convert.ToString(row["Interviewdate"] is DBNull ? "" : row["Interviewdate"] + " " + row["InterviewTime"]),
                                                 CandidateName = Convert.ToString(row["CandidateName"]),
                                                 Email = Convert.ToString(row["CandidateEmail"]),
                                                 ClientName = Convert.ToString(row["ClientName"]),
                                                 ClientEmail = Convert.ToString(row["ClientEmail"]),
                                                 Location = Convert.ToString(row["ClientName"]),
                                                 InterviewBcc = Convert.ToString(row["ClientName"]),
                                                 InterviewCc = Convert.ToString(row["ClientName"]),
                                                 Title = Convert.ToString(row["tilte"]),
                                                 JobId = Convert.ToInt64(row["JobId"] is DBNull ? 0 : Convert.ToInt64(row["JobId"])),


                                             }).ToList();

            model.Adminjobcollection = (from DataRow row in ds.Tables[1].Rows
                                        select new DropDownViewModel
                                        {

                                            Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),

                                            Name = Convert.ToString(row["JobTitle"])

                                        }).ToList();
            model.sharedjobCompanycollection = (from DataRow row in ds.Tables[2].Rows
                                                select new DropDownViewModel
                                                {
                                                    Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                    Name = Convert.ToString(row["name"])

                                                }).ToList();
            model.sharedjobcollection = (from DataRow row in ds.Tables[3].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                             Name = Convert.ToString(row["JobTitle"])

                                         }).ToList();
        }

        internal void shortlist(ClientModel model, DataTable dt)
        {
            model.GetShortList = (from DataRow row in dt.Rows
                                  select new ClientModel
                                  {
                                      Id = Convert.ToInt32(row["Id"]),
                                      CandidateName = Convert.ToString(row["Name"]),
                                      Phone1 = Convert.ToString(row["PhoneNo"]),
                                      ClientName = Convert.ToString(row["clientName"])
                                  }).ToList();
        }

        internal void ClientSendenquery(ClientModel model, DataTable dt)
        {
            model.clientsendenuerycollection = (from DataRow row in dt.Rows
                                                select new ClientModel
                                                {
                                                    Id = Convert.ToInt64(row["Id"]),
                                                    Unreadcount = Convert.ToInt64(row["Unreadcount"]),
                                                    Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString())),
                                                    ClientId = Convert.ToInt64(row["ClientId"]),
                                                    Name = Convert.ToString(row["Name"]),
                                                    Email = Convert.ToString(row["Email"]),
                                                    Phone1 = Convert.ToString(row["Phone"]),
                                                    Description = Convert.ToString(row["Description"]),
                                                    CandidateName = Convert.ToString(row["FirstName"]) + " " + Convert.ToString(row["LastName"]),
                                                    CreatedDate = Convert.ToString(row["Updateddate"] is DBNull ? "" : Convert.ToDateTime(row["Updateddate"]).ToString("dd/MM/yyyy")),
                                                    FileName = Convert.ToString(row["fileName"] is DBNull ? "" : Convert.ToString(row["fileName"])),
                                                    FilePath = "/" + "FileUpload/Interviewrequest" + "/" + Convert.ToInt64(row["ClientId"]) + "/" + Convert.ToString(row["fileName"])
                                                }).ToList();

            if (dt.Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }


        }


        internal void interviewsrequestbycandidates(ClientModel model, DataTable dt)
        {
            model.clientsendenuerycollection = (from DataRow row in dt.Rows
                                                select new ClientModel
                                                {
                                                    Id = Convert.ToInt64(row["Id"]),
                                                    Unreadcount = Convert.ToInt64(row["Unreadcount"]),
                                                    Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString())),
                                                    ClientId = Convert.ToInt64(row["ClientId"]),
                                                    Jobtitle = Convert.ToString(row["JobTitle"]),
                                                    Name = Convert.ToString(row["FirstName"]),
                                                    LastName = Convert.ToString(row["LastName"]),
                                                    Email = Convert.ToString(row["Email"]),
                                                    Phone1 = Convert.ToString(row["PhoneNo"]),
                                                    requestmoreinfo = Convert.ToInt64(row["requestmoreinfo"]),
                                                    CreatedDate = Convert.ToString(row["Updateddate"] is DBNull ? "" : Convert.ToDateTime(row["Updateddate"]).ToString("dd/MM/yyyy")),

                                                }).ToList();

            if (dt.Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }


        }


        internal void AddCompanyToDoPopUp(ClientModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Subject = Convert.ToString(dt.Rows[0]["Subject"]);
                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                model.DueDate = Convert.ToString(dt.Rows[0]["Date"] is DBNull ? "" : Convert.ToDateTime(dt.Rows[0]["Date"]).ToString("dd MMM yyyy"));
                model.ZoneId = Convert.ToString(dt.Rows[0]["ZoneId"]);
            }

            model.TimeZoneCollection = (from DataRow row in ds.Tables[1].Rows
                                        select new DropDownViewModel
                                        {
                                            Ids = Convert.ToString(row["value"]),
                                            Name = Convert.ToString(row["text"])

                                        }).ToList();
        }

        internal void MeetingActiveTab(Dashboardmodel model, DataTable dt)
        {

            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                model.Subject = Convert.ToString(dt.Rows[0]["Subject"]);
                model.Description = Convert.ToString(dt.Rows[0]["Description"]);
                model.TypeId = Convert.ToInt64(dt.Rows[0]["TypeId"]);
                model.Date = Convert.ToString(dt.Rows[0]["Date"] is DBNull ? "" : Convert.ToDateTime(dt.Rows[0]["Date"]).ToString("dd MMM yyyy"));
            }
        }

        internal void Dashboarddetail(Dashboardmodel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Companycount = Convert.ToInt64(ds.Tables[0].Rows[0]["Companycount"]);
                model.Candidatecount = Convert.ToInt64(ds.Tables[1].Rows[0]["Candidatecount"]);
                model.Enquirescount = Convert.ToInt64(ds.Tables[2].Rows[0]["Enquirescount"]);

                model.InterviewCount = Convert.ToInt64(ds.Tables[6].Rows[0]["interviewcount"]);

                model.GeneralMessagesCount = Convert.ToInt64(ds.Tables[7].Rows[0]["GeneralMessagesCount"]);
                model.InterviewsRequestCount = Convert.ToInt64(ds.Tables[8].Rows[0]["InterviewsRequestCount"]);

                model.SharedJobCount = Convert.ToInt64(ds.Tables[9].Rows[0]["SharedJobCount"]);


            }
            model.mettingschedulecollection = (from DataRow row in ds.Tables[3].Rows
                                               select new Dashboardmodel
                                               {
                                                   Id = Convert.ToInt64(row["Id"]),
                                                   ClientId = Convert.ToInt64(row["ClientId"]),
                                                   Subject = Convert.ToString(row["Subject"]),
                                                   Email = Convert.ToString(row["Email"]),
                                                   Description = Convert.ToString(row["Description"]),
                                                   TypeId = Convert.ToInt64(row["TypeId"]),
                                                   Date = Convert.ToString(row["Date"] is DBNull ? "" : Convert.ToDateTime(row["Date"]).ToString("dd/MM/yyyy"))

                                               }).ToList();

            if (ds.Tables[4].Rows.Count > 0)
            {

                model.Collection = (from DataRow row in ds.Tables[4].Rows
                                    select new EnquiresViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"]),
                                        Name = Convert.ToString(row["Name"]),
                                        LastName = Convert.ToString(row["LastName"]),
                                        Email = Convert.ToString(row["Email"]),
                                        subject = Convert.ToString(row["subject"]),
                                        message = Convert.ToString(row["message"]),
                                        Phoneno = Convert.ToString(row["Phoneno"]),
                                        Date = Convert.ToString(row["createdate"] is DBNull ? "" : Convert.ToDateTime(row["createdate"]).ToString("dd/MM/yyyy"))

                                    }).ToList();
            }


            if (ds.Tables[10].Rows.Count > 0)
            {

                model.UpcomingInterviewscolloction = (from DataRow row in ds.Tables[10].Rows
                                                      select new Dashboardmodel
                                                      {
                                                          Id = Convert.ToInt64(row["Id"]),
                                                          Name = Convert.ToString(row["Name"]),
                                                          Lastname = Convert.ToString(row["LastName"]),
                                                          Date = Convert.ToString(row["Interviewdate"] is DBNull ? "" : row["Interviewdate"] + " " + row["InterviewTime"])

                                                      }).ToList();
            }


            model.Jobcount = Convert.ToInt64(ds.Tables[5].Rows[0]["Jobcount"]);
            model.InterviewsRequestCount_Candidate = Convert.ToInt64(ds.Tables[11].Rows[0]["InterviewsRequestCount_Candidate"]);
        }

        internal void replyenquire(EnquiresViewModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                string Date = "On " + Convert.ToDateTime(dt.Rows[0]["createdate"]).ToString("f") + " MVP Talent Market   " + " wrote:" + "<br/>";
                string msg = dt.Rows[0]["replymessage"].ToString() + "<br/><br/>" + Date + "<div style='margin-left:15px;border-left:1px solid gray;padding-left:5px;'>" + dt.Rows[0]["message"].ToString() + "</div>";
                sendEmail("Re: " + model.subject, msg, model.Email);
            }
        }

        internal void AddClientContact(ClientModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Status = Convert.ToInt64(dt.Rows[0]["StatusId"]);

                if (model.Status == 2)
                {
                    if (model.LoginAccess == 1)
                    {
                        string Subject = "";
                        model.Status = Convert.ToInt64(dt.Rows[0]["StatusId"]);
                        string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);

                        Subject = "Welcome to MVP Talent."; // Your MVP Talent account has been created!

                        string body = string.Empty;
                        using (StreamReader reader = new StreamReader(EmailTempletePath + "CandidateCreateEmail.html"))
                        {
                            body = reader.ReadToEnd();
                        }
                        body = body.Replace("{{Name}}", model.Name + " " + model.LastName);
                        body = body.Replace("{{Email}}", model.Email);
                        body = body.Replace("{{Phone}}", model.Phone1);
                        body = body.Replace("{{Password}}", model.Password);
                        body = body.Replace("{{Title}}", model.Position);
                        body = body.Replace("{{id}}", Encrypt(Convert.ToString(dt.Rows[0]["CurrentId"])));
                        sendEmail(Subject, body, model.Email);
                    }
                }



            }
        }
        internal void emailsendDetailsById(EmailTempleteViewModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                //model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
            }
        }

        internal void GetEmailTemplateById(EmailTempleteViewModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Subject = Convert.ToString(dt.Rows[0]["Subject"]);
                model.Description = Convert.ToString(dt.Rows[0]["Description"]);
                model.Description1 = Convert.ToString(dt.Rows[0]["Description1"]);
                model.Description2 = Convert.ToString(dt.Rows[0]["Description2"]);
                model.Description3 = Convert.ToString(dt.Rows[0]["Description3"]);
            }
        }

        internal void clientdetail(ClientModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Ids = Convert.ToString(EncryptDecrypt.encrypt(dt.Rows[0]["Id"].ToString()));
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Website = Convert.ToString(dt.Rows[0]["Website"]);
                model.Zip = Convert.ToString(dt.Rows[0]["zipcode"]);

                model.Address = Convert.ToString(dt.Rows[0]["Address"]);
                model.Location = Convert.ToString(dt.Rows[0]["Location"]);
                model.Description = Convert.ToString(dt.Rows[0]["Description"]);
                model.FileName = Convert.ToString(ds.Tables[0].Rows[0]["ImageFile"]);
                model.FilePath = "/" + "FileUpload" + "/" + "/" + "CompanyImage" + "/" + Convert.ToInt64(ds.Tables[0].Rows[0]["Id"]) + "/" + ds.Tables[0].Rows[0]["ImageFile"].ToString();
            }
            model.clientContactForm = (from DataRow row in ds.Tables[1].Rows
                                       select new ClientModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Status = Convert.ToInt64(row["Status"]),
                                           LoginAccess = Convert.ToInt64(row["CompanyUserLoginAccess"]),
                                           ClientId = Convert.ToInt64(row["CompanyId"] is DBNull ? 0 : Convert.ToInt64(row["CompanyId"])),
                                           Name = Convert.ToString(row["Name"]),
                                           LastName = Convert.ToString(row["LastName"]),
                                           Position = Convert.ToString(row["Title"]),
                                           Email = Convert.ToString(row["Email"]),
                                           Phone1 = Convert.ToString(row["PhoneNo"]),
                                           UseraccountprofileId = Convert.ToInt64(row["UseraccountprofileId"]),
                                           //Linkdin = Convert.ToString(row["LinkedIn"]),
                                           //Instagram = Convert.ToString(row["Instagram"]),
                                           pipeline = Convert.ToString(row["pipeline"]),
                                           pipelineId = Convert.ToString(row["pipelineId"]),
                                           isubscribe = Convert.ToInt64(row["Isubscribe"]),
                                           //PrimaryEmail = Convert.ToInt64(row["PrimaryEmail"] is DBNull ? 0 : Convert.ToInt64(row["PrimaryEmail"]))
                                       }).ToList();

            if (ds.Tables[2].Rows.Count > 0)
            {
                model.ColloctionEmail = (from DataRow row in ds.Tables[2].Rows
                                         select new EmailTempleteViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             Subject = Convert.ToString(row["Subject"]),
                                             Email = Convert.ToString(row["Email"]),
                                             createdate = Convert.ToString(row["createdate"]),
                                             secondFollowDate = Convert.ToString(row["secondFollowDate"]),
                                             FirstFollowDate = Convert.ToString(row["FirstFollowDate"]),
                                             thirdfollowdate = Convert.ToString(row["thirdfollowdate"]),
                                             isfollow = Convert.ToInt64(row["isfollow"]),
                                             emailtempleteid = Convert.ToInt64(row["emailtempleteid"]),
                                             Description1 = Convert.ToString(row["Description1"]),
                                             Description2 = Convert.ToString(row["Description2"]),
                                             Description3 = Convert.ToString(row["Description3"]),
                                             isread = Convert.ToInt64(row["isread"]),
                                             sentstatus = Convert.ToInt64(row["sentcount"]),
                                         }).ToList();
            }
            model.Notescollection = (from DataRow row in ds.Tables[3].Rows
                                     select new ClientModel
                                     {

                                         Id = Convert.ToInt64(row["Id"]),
                                         comments = Convert.ToString(row["Notes"]),
                                         Name = Convert.ToString(row["UserName"]),
                                         DueDate = Convert.ToString(row["CreatedDate"])
                                     }).ToList();

            model.CompanyToDoCollection = (from DataRow row in ds.Tables[4].Rows
                                           select new ClientModel
                                           {
                                               Id = Convert.ToInt64(row["Id"]),
                                               Subject = Convert.ToString(row["Subject"]),
                                               Email = Convert.ToString(row["Email"]),
                                               DueDate = Convert.ToString(row["Date"] is DBNull ? "" : Convert.ToDateTime(row["Date"]).ToShortDateString()),
                                               Status = Convert.ToInt64(row["StatusId"])
                                           }).ToList();

            model.Clienttagcollection = (from DataRow row in ds.Tables[5].Rows
                                         select new Tagsmodel
                                         {

                                             Id = Convert.ToInt64(row["Id"]),
                                             TagId = Convert.ToInt64(row["TagId"] is DBNull ? 0 : Convert.ToInt64(row["TagId"])),
                                             CId = Convert.ToInt64(row["CId"] is DBNull ? 0 : Convert.ToInt64(row["CId"])),
                                             CandidateTag = Convert.ToString(row["Name"] is DBNull ? "" : Convert.ToString(row["Name"]))


                                         }).ToList();
            if (ds.Tables[6].Rows.Count > 0)
            {
                model.ClientJobsCollection = (from DataRow row in ds.Tables[6].Rows
                                              select new ClientModel
                                              {
                                                  JobId = Convert.ToInt64(row["Id"] is DBNull ? 0 : row["Id"]),
                                                  Jobtitle = Convert.ToString(row["JobTitle"] is DBNull ? "" : row["JobTitle"]),
                                                  jobStatus = Convert.ToInt64(row["JobStatusId"] is DBNull ? 0 : row["JobStatusId"]),
                                              }).ToList();
            }
            if (ds.Tables[7].Rows.Count > 0)
            {
                model.interviewListCollection = (from DataRow row in ds.Tables[7].Rows
                                                 select new ClientModel
                                                 {
                                                     Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : row["Id"]),
                                                     CandidateName = Convert.ToString(row["CandidateName"] is DBNull ? "" : row["CandidateName"]),
                                                     InterviewDate = Convert.ToString(row["Interviewdate"] + " " + row["InterviewTime"]),
                                                     InterviewerName = Convert.ToString(row["ClientName"] is DBNull ? "" : row["ClientName"]),
                                                     Subject = Convert.ToString(row["tilte"] is DBNull ? "" : row["tilte"]),
                                                 }).ToList();
            }
            if (ds.Tables[8].Rows.Count > 0)
            {
                model.SubmissionCollection = (from DataRow row in ds.Tables[8].Rows
                                              select new ClientModel
                                              {
                                                  CandidateId = Convert.ToInt64(row["CandidateId"] is DBNull ? 0 : row["CandidateId"]),
                                                  CandidateName = Convert.ToString(row["CandidateName"]),
                                                  SubmissionDate = Convert.ToDateTime(row["SubmissionDate"]).ToString("dd MMMM yyyy"),
                                                  Jobtitle = Convert.ToString(row["JobTitle"] is DBNull ? "" : row["JobTitle"]),
                                              }).ToList();
            }


        }

        internal void getmessagebyId(EnquiresViewModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Name = Convert.ToString(dt.Rows[0]["name"]);

                model.LastName = Convert.ToString(dt.Rows[0]["LastName"]);

                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                model.Phoneno = Convert.ToString(dt.Rows[0]["Phoneno"]);
                model.subject = Convert.ToString(dt.Rows[0]["subject"]);
                model.message = Convert.ToString(dt.Rows[0]["message"]);
                model.replymessage = Convert.ToString(dt.Rows[0]["replymessage"]);
                model.createdate = Convert.ToString(dt.Rows[0]["createdate"]);
                model.updateddate = Convert.ToString(dt.Rows[0]["updateddate"]);
                model.updatedby = Convert.ToInt32(dt.Rows[0]["updatedby"]);
                string EmailTempletePath = System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"];
                string fromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmail"];
                string Adminsign = string.Empty;
                string Subject = "";
                Subject = model.subject;
                using (StreamReader reader = new StreamReader(EmailTempletePath + "reply.html"))
                {
                    Adminsign = reader.ReadToEnd();
                }
                string Date = "<br/>" + Convert.ToDateTime(dt.Rows[0]["createdate"]).ToString("f") + fromEmail + model.Email + "  " + "<br/>";
                Adminsign = Adminsign.Replace("@reply", model.replymessage);
                Adminsign = Adminsign.Replace("@Date", Date);
                Adminsign = Adminsign.Replace("@mesage", model.message);

                 //sendEmail(Subject, Adminsign, model.Email);


                model.enquierycollection = (from DataRow row in dt.Rows
                                            select new EnquiresViewModel
                                            {
                                                Id = Convert.ToInt64(row["Id"]),
                                                Name = Convert.ToString(row["Name"] ) + " " + Convert.ToString(row["LastName"]),
                                                Email = Convert.ToString(row["Email"]),
                                                Phoneno = Convert.ToString(row["Phoneno"]),
                                                subject = Convert.ToString(row["subject"]),
                                                message = Convert.ToString(row["message"]),
                                                createdate = Convert.ToString(row["createdate"]),
                                                updatedby = Convert.ToInt32(row["updatedby"]),
                                                updateddate = Convert.ToString(row["updateddate"]),
                                                replymessage = Convert.ToString(row["replymessage"]),
                                                AdminName = Convert.ToString(row["adminname"])
                                            }).ToList();
            }
        }

        private void sendEmail(string Subject, string MsgBody, string ToMailAddress)
        {
            string FromEmailName = System.Configuration.ConfigurationManager.AppSettings["FromEmailName"];
            string FromEmail = System.Configuration.ConfigurationManager.AppSettings["FromEmail"];
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
            SmtpClient smtp = new SmtpClient(smtphost, Convert.ToInt32(25));
            smtp.EnableSsl = EnableSsl;
            smtp.UseDefaultCredentials = UseDefaultCredentials;
            mailMsg.IsBodyHtml = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(FromEmail, FromEmailPassword);
            smtp.Host = smtphost;
            smtp.Send(mailMsg);
        }




        internal void ClientContact(ClientModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                //model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.LastName = Convert.ToString(dt.Rows[0]["Lastname"]);
                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                model.Position = Convert.ToString(dt.Rows[0]["Title"]);
                model.Phone1 = Convert.ToString(dt.Rows[0]["Phone"]);
                model.Linkdin = Convert.ToString(dt.Rows[0]["Linkedinurl"]);

            }
        }

        internal void profile(ProfileViewModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Name = Convert.ToString(ds.Tables[0].Rows[0]["Name"] is DBNull ? "" : Convert.ToString(ds.Tables[0].Rows[0]["Name"]));
                model.Email = Convert.ToString(ds.Tables[0].Rows[0]["Email"] is DBNull ? "" : Convert.ToString(ds.Tables[0].Rows[0]["Email"]));
                model.PhoneNo = Convert.ToString(ds.Tables[0].Rows[0]["PhoneNo"] is DBNull ? "" : Convert.ToString(ds.Tables[0].Rows[0]["PhoneNo"]));
                model.CompanyName = Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"] is DBNull ? "" : Convert.ToString(ds.Tables[0].Rows[0]["CompanyName"]));
                model.companywebsite = Convert.ToString(ds.Tables[0].Rows[0]["Website"] is DBNull ? "" : Convert.ToString(ds.Tables[0].Rows[0]["Website"]));
                model.LastName = Convert.ToString(ds.Tables[0].Rows[0]["LastName"] is DBNull ? "" : Convert.ToString(ds.Tables[0].Rows[0]["LastName"]));
                model.CityName = Convert.ToString(ds.Tables[0].Rows[0]["CityName"] is DBNull ? "" : Convert.ToString(ds.Tables[0].Rows[0]["CityName"]));
                model.StateId = Convert.ToInt64(ds.Tables[0].Rows[0]["StateId"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["StateId"]));
                model.FileName = Convert.ToString(ds.Tables[0].Rows[0]["ImageFile"] is DBNull ? "" : Convert.ToString(ds.Tables[0].Rows[0]["ImageFile"]));
                model.location = Convert.ToString(ds.Tables[0].Rows[0]["Location"] is DBNull ? "" : Convert.ToString(ds.Tables[0].Rows[0]["Location"]));

            }
            model.CountryId = 1;
            model.CountryCollection = (from DataRow row in ds.Tables[1].Rows
                                       select new DropDownViewModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Name = Convert.ToString(row["Name"])

                                       }).ToList();
            model.StateCollection = (from DataRow row in ds.Tables[2].Rows
                                     select new DropDownViewModel
                                     {
                                         Id = Convert.ToInt64(row["Id"]),
                                         Name = Convert.ToString(row["Name"])
                                     }).ToList();
        }

        internal void enquires(EnquiresViewModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            if (dt.Rows.Count > 0)
            {
                model.Collection = (from DataRow row in dt.Rows
                                    select new EnquiresViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"]),
                                        Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString())),
                                        Name = Convert.ToString(row["Name"]),
                                        LastName = Convert.ToString(row["LastName"]),

                                        createdate = Convert.ToString(row["createdate"]),
                                        Email = Convert.ToString(row["Email"]),
                                        Phoneno = Convert.ToString(row["Phoneno"]),
                                        subject = Convert.ToString(row["subject"]),
                                        message = Convert.ToString(row["message"]),
                                        statusid = Convert.ToString(row["statusid"]),
                                        replymessage = Convert.ToString(row["replymessage"]),
                                    }).ToList();
            }
            if (dt.Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                Double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }

            model.enquerytypecollection = (from DataRow row in dt1.Rows
                                           select new DropDownViewModel
                                           {

                                               Id = Convert.ToInt64(row["Id"]),
                                               Name = Convert.ToString(row["Name"])

                                           }).ToList();
        }

        internal void ClientList(ClientModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            model.GetClientList = (from DataRow row in dt.Rows
                                   select new ClientModel
                                   {
                                       Id = Convert.ToInt64(row["Id"]),
                                       Status = Convert.ToInt64(row["StatusId"]),
                                       Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString()).ToString()),
                                       Name = Convert.ToString(row["Name"]),
                                       Website = Convert.ToString(row["website"]), 
                                       Zip = Convert.ToString(row["zipcode"]),  
                                       Location = Convert.ToString(row["Location"] is DBNull ? "" : Convert.ToString(row["Location"])),
                                   }).ToList();

            if (dt.Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }

            if(ds.Tables[1].Rows.Count>0)
            {
                model.MileCollection = (from DataRow row in ds.Tables[1].Rows
                                        select new ClientModel { 
                                            MileId = Convert.ToInt64(row["Id"]),
                                            Name = Convert.ToString(row["Name"]),
                                        }).ToList();
            }
        }

        internal void CityList(ClientModel model, DataTable dt)
        {
            model.CityCollection = (from DataRow row in dt.Rows
                                    select new DropDownViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"]),
                                        Name = Convert.ToString(row["Name"])
                                    }).ToList();
        }


        internal void StateList(ClientModel model, DataTable dt)
        {
            model.StateCollection = (from DataRow row in dt.Rows
                                     select new DropDownViewModel
                                     {
                                         Id = Convert.ToInt64(row["Id"]),
                                         Name = Convert.ToString(row["Name"])
                                     }).ToList();
        }



        internal void getcontactbycompanyId(ClientModel model, DataTable dt)
        {
            model.StateCollection = (from DataRow row in dt.Rows
                                     select new DropDownViewModel
                                     {
                                         Id = Convert.ToInt64(row["UserId"]),
                                         Name = Convert.ToString(row["Name"])
                                     }).ToList();
        }


        internal void email(EmailTempleteViewModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Collection = (from DataRow row in dt.Rows
                                    select new EmailTempleteViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"]),
                                        Name = Convert.ToString(row["Name"]),
                                        Subject = Convert.ToString(row["Subject"]),
                                        Description = Convert.ToString(row["Description"]),
                                        Description1 = Convert.ToString(row["Description1"]),
                                        Description2 = Convert.ToString(row["Description2"]),
                                        Description3 = Convert.ToString(row["Description3"]),
                                        StatusId = Convert.ToInt64(row["StatusId"]),
                                    }).ToList();
            }

        }

        internal void GetEmailTempleteById(EmailTempleteViewModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Subject = Convert.ToString(dt.Rows[0]["Subject"]);
                model.Description = Convert.ToString(dt.Rows[0]["Description"]);
                model.Description1 = Convert.ToString(dt.Rows[0]["Description1"]);
                model.Description2 = Convert.ToString(dt.Rows[0]["Description2"]);
                model.Description3 = Convert.ToString(dt.Rows[0]["Description3"]);
            }
        }

        internal void ActivationEmailToContact(ClientModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Password = Craptography.Decrypt(dt.Rows[0]["Password"].ToString(), dt.Rows[0]["Salt"].ToString());
                string Subject = "Account activation email!!.";
                string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(EmailTempletePath + "AccountActivationEmailResend.html"))
                {
                    body = reader.ReadToEnd();
                }

                body = body.Replace("{{Name}}", Convert.ToString(dt.Rows[0]["Name"]));
                body = body.Replace("{{Email}}", Convert.ToString(dt.Rows[0]["Email"]));
                body = body.Replace("{{Password}}", Convert.ToString(model.Password));
                body = body.Replace("{{id}}", LoginFactory.Encrypt(Convert.ToString(model.Id)));

                sendEmail(Subject, body, Convert.ToString(dt.Rows[0]["Email"]));
            }
        }
    }
}
