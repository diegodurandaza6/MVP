using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Web.Core.Common.Impl;
using Web.Model.Admin;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;
using Web.Model.Paypal;

namespace Web.Core.Candidate.Impl
{
    public class CandidateFactory
    {

        DataTable Dt = new DataTable();
        DataSet ds = new DataSet();


        internal void CadidateList(CandidateModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];    

            if (ds.Tables[1].Rows.Count > 0)
            {
                model.MileCollection = (from DataRow row in ds.Tables[1].Rows
                                        select new ClientModel
                                        {
                                            MileId = Convert.ToInt64(row["Id"]),
                                            Name = Convert.ToString(row["Name"]),
                                        }).ToList();
            }

        }

        internal void CandidateDelete(CandidateModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.CreateBy = Convert.ToInt32(dt.Rows[0]["Id"]);
                model.Name = dt.Rows[0]["Name"].ToString();
                model.LastName = dt.Rows[0]["LastName"].ToString();
                model.location = dt.Rows[0]["Location"].ToString();
                model.Email = dt.Rows[0]["Email"].ToString();
                model.Phone = dt.Rows[0]["PhoneNo"].ToString();
                model.ProfileCheck_Id = dt.Rows[0]["ProfileCheckId"].ToString();
                model.Title = dt.Rows[0]["Title"].ToString();
                model.IndustryName = dt.Rows[0]["IndustryName"].ToString();
                model.StateId = dt.Rows[0]["StateId"].ToString();
                model.StateName = dt.Rows[0]["StateName"].ToString();
                model.CityName = dt.Rows[0]["CityName"].ToString();
                model.Zipcode = dt.Rows[0]["Zipcode"].ToString();
                model.EducationlevelName = dt.Rows[0]["EducationlevelsName"].ToString();
                model.JobTypeId = Convert.ToInt64(dt.Rows[0]["jobtype"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["jobtype"]));

                model.JobType = dt.Rows[0]["JobtypeName"].ToString();
                model.description = dt.Rows[0]["Description"].ToString();
                model.DesiredTitle1 = dt.Rows[0]["DesiredTitle1"].ToString();
                model.DesiredTitle2 = dt.Rows[0]["DesiredTitle2"].ToString();


                model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["ImageFile"].ToString());
                model.Resumefile = Convert.ToString(dt.Rows[0]["ResumeFile"] is DBNull ? " " : dt.Rows[0]["ResumeFile"].ToString());



            }
        }

        internal void CandidateAwardspopup(CandidateModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Title = Convert.ToString(dt.Rows[0]["Title"]);
                model.year = Convert.ToString(dt.Rows[0]["year"]);
                model.description = Convert.ToString(dt.Rows[0]["description"]);
                model.visibleid = Convert.ToInt64(dt.Rows[0]["visibleid"]);
            }

            model.visibleidCollection = (from DataRow row in ds.Tables[1].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             Name = Convert.ToString(row["Name"])

                                         }).ToList();
        }
        internal void CandidateEducationpopup(CandidateModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Education = Convert.ToString(dt.Rows[0]["education"]);
                model.EducaStartYear = Convert.ToString(dt.Rows[0]["year"]);
                model.EducaEndYear = Convert.ToString(dt.Rows[0]["EducationEnd"]);
                model.univarsity = Convert.ToString(dt.Rows[0]["university"]);
                model.description = Convert.ToString(dt.Rows[0]["description"]);
                model.visibleid = Convert.ToInt64(dt.Rows[0]["visibleid"]);
            }

            model.visibleidCollection = (from DataRow row in ds.Tables[1].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             Name = Convert.ToString(row["Name"])

                                         }).ToList();
        }

        internal void ResumeImageUpload(CandidateModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {

                model.CreateBy = Convert.ToInt32(dt.Rows[0]["Id"]);
                model.experience = Convert.ToString(dt.Rows[0]["experience"]);
                model.Name = dt.Rows[0]["Name"].ToString();
                model.LastName = dt.Rows[0]["LastName"].ToString();
                model.location = dt.Rows[0]["location"].ToString();
                model.Email = dt.Rows[0]["Email"].ToString();
                model.Phone = dt.Rows[0]["PhoneNo"].ToString();
                model.ProfileCheck_Id = dt.Rows[0]["ProfileCheckId"].ToString();
                model.Title = dt.Rows[0]["Title"].ToString();
                model.IndustryName = dt.Rows[0]["IndustryName"].ToString();
                model.StateId = dt.Rows[0]["StateId"].ToString();
                model.StateName = dt.Rows[0]["StateName"].ToString();
                model.CityName = dt.Rows[0]["CityName"].ToString();
                model.Zipcode = dt.Rows[0]["Zipcode"].ToString();
                model.EducationlevelName = dt.Rows[0]["EducationlevelsName"].ToString();
                model.JobTypeId = Convert.ToInt64(dt.Rows[0]["jobtype"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["jobtype"]));
                model.description = dt.Rows[0]["Description"].ToString();
                model.DesiredTitle1 = dt.Rows[0]["DesiredTitle1"].ToString();
                model.DesiredTitle2 = dt.Rows[0]["DesiredTitle2"].ToString();


                model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["ImageFile"].ToString());
                model.Resumefile = Convert.ToString(dt.Rows[0]["ResumeFile"] is DBNull ? " " : dt.Rows[0]["ResumeFile"].ToString());
            }
        }

        internal void ProfileImageUpload(CandidateModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.CreateBy = Convert.ToInt32(dt.Rows[0]["Id"]);
                model.Name = dt.Rows[0]["Name"].ToString();
                model.LastName = dt.Rows[0]["LastName"].ToString();
                model.Email = dt.Rows[0]["Email"].ToString();
                model.Phone = dt.Rows[0]["PhoneNo"].ToString();
                model.ProfileCheck_Id = dt.Rows[0]["ProfileCheckId"].ToString();
                model.Title = dt.Rows[0]["Title"].ToString();
                model.IndustryName = dt.Rows[0]["IndustryName"].ToString();
                model.StateId = "0";
                model.StateName = dt.Rows[0]["StateName"].ToString();
                model.location = dt.Rows[0]["location"].ToString();
                model.CityName = dt.Rows[0]["CityName"].ToString();
                model.Zipcode = dt.Rows[0]["Zipcode"].ToString();
                model.EducationlevelName = dt.Rows[0]["EducationlevelsName"].ToString();
                model.JobTypeId = Convert.ToInt64(dt.Rows[0]["jobtype"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["jobtype"]));


                model.description = dt.Rows[0]["Description"].ToString();
                model.DesiredTitle1 = dt.Rows[0]["DesiredTitle1"].ToString();
                model.DesiredTitle2 = dt.Rows[0]["DesiredTitle2"].ToString();


                model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["ImageFile"].ToString());
                model.Resumefile = Convert.ToString(dt.Rows[0]["ResumeFile"] is DBNull ? " " : dt.Rows[0]["ResumeFile"].ToString());
            }
        }

        internal void UpdateCandidate(CandidateModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.CreateBy = Convert.ToInt32(dt.Rows[0]["Id"]);
                model.Name = dt.Rows[0]["Name"].ToString();
                model.LastName = dt.Rows[0]["LastName"].ToString();
                model.location = dt.Rows[0]["location"].ToString();
                model.Email = dt.Rows[0]["Email"].ToString();
                model.Phone = dt.Rows[0]["PhoneNo"].ToString();
                model.ProfileCheck_Id = dt.Rows[0]["ProfileCheckId"].ToString();
                model.Title = dt.Rows[0]["Title"].ToString();
                model.IndustryName = dt.Rows[0]["IndustryName"].ToString();
                model.StateId = dt.Rows[0]["StateId"].ToString();
                model.StateName = dt.Rows[0]["StateName"].ToString();
                model.CityName = dt.Rows[0]["CityName"].ToString();
                model.Zipcode = dt.Rows[0]["Zipcode"].ToString();
                model.EducationlevelName = dt.Rows[0]["EducationlevelsName"].ToString();
                model.JobTypeId = Convert.ToInt64(dt.Rows[0]["jobtype"]);
                model.JobType = dt.Rows[0]["JobtypeName"].ToString();
                model.description = dt.Rows[0]["Description"].ToString();
                model.DesiredTitle1 = dt.Rows[0]["DesiredTitle1"].ToString();
                model.DesiredTitle2 = dt.Rows[0]["DesiredTitle2"].ToString();
                model.Certifications = dt.Rows[0]["Certifications"].ToString();
                model.Relocation = dt.Rows[0]["Relocation"].ToString();

                model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["ImageFile"].ToString());
                model.Resumefile = Convert.ToString(dt.Rows[0]["ResumeFile"] is DBNull ? " " : dt.Rows[0]["ResumeFile"].ToString());



            }
        }

        internal void AutoCompleteCandidatetags(CandidateModel model, DataTable dt)
        {
            model.candidatetagvaluecollection = (from DataRow row in dt.Rows
                                                 select new DropDownViewModel
                                                 {
                                                     Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : row["Id"]),
                                                     Name = Convert.ToString(row["Name"])
                                                 }).ToList();

        }

        internal void getallunreadmessage(ClientModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Unreadcount = Convert.ToInt64(ds.Tables[0].Rows.Count);

            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.generalmessagecount = Convert.ToInt64(ds.Tables[1].Rows.Count);
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                model.pipelinemessagecount = Convert.ToInt64(ds.Tables[2].Rows.Count);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                model.submitedprofilecount = Convert.ToInt64(ds.Tables[3].Rows.Count);

            }




            model.totalcount = (model.Unreadcount) + (model.generalmessagecount) + (model.pipelinemessagecount) + (model.submitedprofilecount);






        }
        internal void messageslist(Candidateconversationmodel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.candidateconversationcollection = (from DataRow row in ds.Tables[0].Rows
                                                         select new CandidateConversationEditModel
                                                         {
                                                             Ids = EncryptDecrypt.encrypt(row["CandidateConversationId"].ToString()),
                                                             Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                             CandidateConversationId = Convert.ToInt64(row["CandidateConversationId"]),
                                                             Name = Convert.ToString(row["Name"]),
                                                             JobId = Convert.ToInt64(row["JobId"] is DBNull ? 0 : Convert.ToInt64(row["JobId"])),

                                                             JobTitle = Convert.ToString(row["JobTitle"]),
                                                             Description = Convert.ToString(row["Massege"]),
                                                             Date = Convert.ToDateTime(row["Createddate"]).ToShortDateString(),
                                                             Unreadcount = Convert.ToInt64(row["Unreadcount"] is DBNull ? 0 : Convert.ToInt64(row["Unreadcount"])),


                                                         }).ToList();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    model.TotalRowCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRowCount"]);
                    double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                    model.PageCount = (int)Math.Ceiling(pageCount);
                    model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
                }
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
                model.Email = Convert.ToString(dt.Rows[0]["RegisteredEmail"]);
                model.Featured = Convert.ToInt64(dt.Rows[0]["Featured"]);

                model.CreateBy = Convert.ToInt64(dt.Rows[0]["CreatedBy"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["CreatedBy"]));
                model.CreatedByName = Convert.ToString(dt.Rows[0]["CreatedByName"]);
                model.createddate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]).ToString("MM/dd/yyyy");
                if (Convert.ToString(dt.Rows[0]["UpdateDate"]).Length > 0)
                {
                    model.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdateDate"]).ToString("MM/dd/yyyy");
                }
                model.AccountTypeName = Convert.ToString(dt.Rows[0]["AccountTypeName"]);

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
                                                  Company = Convert.ToString(row["company"]),
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
            if (ds.Tables[10].Rows.Count > 0)
            {
                model.SimilarCandidatescollection = (from DataRow row in ds.Tables[10].Rows
                                                     select new CandidateModel
                                                     {
                                                         Id = Convert.ToInt64(row["UserId"] is DBNull ? 0 : Convert.ToInt64(row["UserId"])),
                                                         Name = Convert.ToString(row["Name"]),
                                                         imageFile = Convert.ToString(row["ImageFile"]),
                                                         FileUpload = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + row["ImageFile"].ToString()),
                                                         location = Convert.ToString(row["Location"]),
                                                         educationlevel = Convert.ToString(row["educationlevel"]),
                                                         experienceName = Convert.ToString(row["experienceName"]),

                                                     }).ToList();
            }





            if (ds.Tables[13].Rows.Count > 0)
            {
                model.Pipelinestage = (from DataRow row in ds.Tables[13].Rows
                                       select new CandidateModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Ids = Convert.ToString(EncryptDecrypt.encrypt(row["JobId"].ToString())),
                                           JobId = Convert.ToInt16(row["JobId"]),
                                           jobtitle = Convert.ToString(row["JobTitle"]),
                                           InterviewStausName = Convert.ToString(row["interviewstatus"]),


                                       }).ToList();
            }
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

            if (ds.Tables[14].Rows.Count > 0)
            {
                model.Interviewcolloction = (from DataRow row in ds.Tables[14].Rows
                                             select new CandidateModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 Ids = Convert.ToString(EncryptDecrypt.encrypt(row["JobId"].ToString())),
                                                 JobId = Convert.ToInt16(row["JobId"]),
                                                 jobtitle = Convert.ToString(row["JobTitle"]),
                                                 InterviewDate = Convert.ToString(row["Interviewdate"] + " " + row["InterviewTime"]),


                                             }).ToList();
            }

        }

        internal void getAllPaymentHistory(PlansListModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                model.Collection = (from DataRow row in ds.Tables[0].Rows
                                    select new PlansViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"]),
                                        ClientName = Convert.ToString(row["Name"]) + " " + Convert.ToString(row["LastName"]),
                                        PlanName = Convert.ToString(row["PlanName"]),
                                        Amount = Convert.ToString(row["Amount"]),
                                        paymentId = Convert.ToString(row["paymentId"]),
                                        User_Id = Convert.ToString(EncryptDecrypt.encrypt(row["UserId"].ToString())),
                                        transactionno = Convert.ToString(row["paymentId"]),
                                        CompanyName = Convert.ToString(row["CompanyName"]),
                                        CustomerId = Convert.ToString(row["CreditCardId"]),
                                        CreateDate = Convert.ToDateTime(row["CreateDate"]).ToShortDateString(),
                                        ValidPlanDate = Convert.ToDateTime(row["ValidPlanDate"]).ToShortDateString(),
                                    }).ToList();

            }

            if (ds.Tables[1].Rows.Count > 0)
            {


            }
        }

        internal void getallzipcodeinradius(CandidateModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    var zipcode = "";
                    if (ds.Tables[0].Rows[i]["Zcta"].ToString().Length < 5)
                    {
                        zipcode = "0" + ds.Tables[0].Rows[i]["Zcta"].ToString();
                    }
                    else
                    {
                        zipcode = ds.Tables[0].Rows[i]["Zcta"].ToString();
                    }
                    model.Zipcode = model.Zipcode + zipcode + ',';
                }
                model.Zipcode = model.Zipcode.Remove(model.Zipcode.Length - 1);
            }
            string groupcandidateId = "";
            if (ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    groupcandidateId = groupcandidateId += ds.Tables[1].Rows[i]["candidateid"].ToString() + ",";
                }
                model.groupcandidateId = groupcandidateId.Remove(groupcandidateId.Length - 1, 1);
            } 
             
        }

        internal void submitedprofiledetail(Candidateconversationmodel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.candidateconversationcollection = (from DataRow row in ds.Tables[0].Rows
                                                         select new CandidateConversationEditModel
                                                         {
                                                             Description = Convert.ToString(row["Description"]),
                                                             AccountTypeId = Convert.ToInt64(row["AccountTypeId"]),
                                                             SendName = Convert.ToString(row["SendName"]),
                                                             createddate = Convert.ToString(row["Createddate"]),

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

            if (ds.Tables[4].Rows.Count > 0)
            {
                model.CompanyId = Convert.ToInt64(ds.Tables[4].Rows[0]["ClientId"]);
            }

        }

        internal void submitedprofile(Candidateconversationmodel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            model.submitedprofileCollection = (from DataRow row in dt.Rows
                                               select new Candidateconversationmodel
                                               {
                                                   Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                   createddate = Convert.ToDateTime(row["SubmitedByAdminDate"]).ToShortDateString(),
                                                   ClientName = Convert.ToString(row["ClientName"]),
                                                   JobTitle = Convert.ToString(row["JobTitle"]),
                                                   UnReadCount = Convert.ToInt64(row["Count"]),
                                                   CandidateName = Convert.ToString(row["Name"]),
                                                   JobId = Convert.ToInt64(row["JobId"]),
                                                   CandidateId = Convert.ToInt64(row["CandidateId"]),
                                                   ClientId = Convert.ToInt64(row["ClientId"])
                                               }).ToList();
        }

        internal void UpdateCandidateOnsolr(CandidateModel model, DataSet ds)
        {

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Name = ds.Tables[0].Rows[0]["Name"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                model.LastName = ds.Tables[0].Rows[0]["LastName"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["LastName"]);
                model.location = ds.Tables[0].Rows[0]["location"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["Location"]);
                model.Email = ds.Tables[0].Rows[0]["Email"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                model.Phone = ds.Tables[0].Rows[0]["PhoneNo"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["PhoneNo"]);
                model.ProfileCheck_Id = ds.Tables[0].Rows[0]["ProfileCheckId"] is DBNull ? "0" : Convert.ToString(ds.Tables[0].Rows[0]["ProfileCheckId"]);
                model.Title = ds.Tables[0].Rows[0]["Title"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["Title"]);
                model.IndustryName = ds.Tables[0].Rows[0]["IndustryName"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["IndustryName"]);

                model.Zipcode = ds.Tables[0].Rows[0]["Zipcode"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["Zipcode"]);
                model.Latitude = ds.Tables[0].Rows[0]["Latitude"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["Latitude"]);
                model.Longitude = ds.Tables[0].Rows[0]["Longitude"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["Longitude"]);


                model.EducationlevelName = ds.Tables[0].Rows[0]["EducationlevelsName"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["EducationlevelsName"]);
                model.JobTypeId = Convert.ToInt64(ds.Tables[0].Rows[0]["jobtype"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[0].Rows[0]["jobtype"]));
                model.Industry = Convert.ToInt32(ds.Tables[0].Rows[0]["Industry"] is DBNull ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["Industry"]));
                model.IndustryName = Convert.ToString(ds.Tables[0].Rows[0]["IndustryName"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["IndustryName"]));

                model.CurrentSalaryId = ds.Tables[0].Rows[0]["CurrentSalaryId"] is DBNull ? "0" : Convert.ToString(ds.Tables[0].Rows[0]["CurrentSalaryId"]);

                model.JobTypeName = ds.Tables[0].Rows[0]["JobtypeName"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["JobtypeName"]);
                model.description = ds.Tables[0].Rows[0]["Description"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["Description"]);
                model.DesiredTitle1 = ds.Tables[0].Rows[0]["DesiredTitle1"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["DesiredTitle1"]);
                model.DesiredTitle2 = ds.Tables[0].Rows[0]["DesiredTitle2"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["DesiredTitle2"]);
                model.FileName = Convert.ToString(ds.Tables[0].Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + ds.Tables[0].Rows[0]["ImageFile"].ToString());
                model.Resumefile = Convert.ToString(ds.Tables[0].Rows[0]["ResumeFile"] is DBNull ? " " : ds.Tables[0].Rows[0]["ResumeFile"].ToString());
                model.experienceName = ds.Tables[0].Rows[0]["experienceName"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["experienceName"]);
                model.experience = ds.Tables[0].Rows[0]["experience"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["experience"]);
                model.CurrentSalary = ds.Tables[0].Rows[0]["CurrentSalary"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["CurrentSalary"]);
                model.Certifications = ds.Tables[0].Rows[0]["Certifications"] is DBNull ? " " : Convert.ToString(ds.Tables[0].Rows[0]["Certifications"]);


            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    model.Candidateskill = model.Candidateskill += ds.Tables[1].Rows[i]["Name"].ToString() + ",";
                }
                model.Candidateskill = model.Candidateskill.Remove(model.Candidateskill.Length - 1, 1);
            }
            else
            {
                model.Candidateskill = " ";

            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    model.CandidateTag = model.CandidateTag += ds.Tables[2].Rows[i]["Name"].ToString() + ",";
                }
                model.CandidateTag = model.CandidateTag.Remove(model.CandidateTag.Length - 1, 1);

            }
            else
            {
                model.CandidateTag = " ";
            }
        }

        internal void AdminNotification(ClientModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Unreadcount = Convert.ToInt64(ds.Tables[0].Rows.Count);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.generalmessagecount = Convert.ToInt64(ds.Tables[1].Rows.Count);
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                model.pipelinemessagecount = Convert.ToInt64(ds.Tables[2].Rows.Count);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                model.submitedprofilecount = Convert.ToInt64(ds.Tables[3].Rows.Count);
            }



            model.totalcount = (model.Unreadcount) + (model.generalmessagecount) + (model.pipelinemessagecount) + (model.submitedprofilecount);

        }

        internal void CandidateNnotification(ClientModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.generalmessagecount = Convert.ToInt64(ds.Tables[0].Rows.Count);
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                model.pipelinemessagecount = Convert.ToInt64(ds.Tables[1].Rows.Count);
            }
            model.totalcount = (model.Unreadcount) + (model.generalmessagecount) + (model.pipelinemessagecount);

        }

        internal void generalmessagedetail(Candidateconversationmodel model, DataSet ds)
        {
            model.candidateconversationcollection = (from DataRow row in ds.Tables[0].Rows
                                                     select new CandidateConversationEditModel
                                                     {
                                                         Description = Convert.ToString(row["Massege"]),
                                                         Name = Convert.ToString(row["messagesenderName"]),
                                                         Date = Convert.ToString(row["Createddate"]),

                                                         CreateBy = Convert.ToInt64(row["CreatedBy"] is DBNull ? 0 : Convert.ToInt64(row["CreatedBy"])),
                                                         //FileName = Convert.ToString(row["ClientLogo"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : " /FileUpload/CandidateImage/" + Convert.ToInt32(row["CreatedBy"]) + "/" + row["ClientLogo"]),

                                                     }).ToList();



            if (ds.Tables[1].Rows.Count > 0)
            {
                model.CandidateId = Convert.ToInt64(ds.Tables[1].Rows[0]["UserId"]);
                model.AccountTypeId = ds.Tables[1].Rows[0]["AccountTypeId"] is DBNull ? 0 : Convert.ToInt32(ds.Tables[1].Rows[0]["AccountTypeId"]);
                model.Name = ds.Tables[1].Rows[0]["Name"] is DBNull ? "" : ds.Tables[1].Rows[0]["Name"].ToString();
                model.LastName = ds.Tables[1].Rows[0]["LastName"] is DBNull ? "" : ds.Tables[1].Rows[0]["LastName"].ToString();
                model.Email = ds.Tables[1].Rows[0]["Email"] is DBNull ? "" : ds.Tables[1].Rows[0]["Email"].ToString();
                model.ClientPhone = ds.Tables[1].Rows[0]["PhoneNo"] is DBNull ? "" : ds.Tables[1].Rows[0]["PhoneNo"].ToString();
                model.Address = ds.Tables[1].Rows[0]["Address1"] is DBNull ? "" : ds.Tables[1].Rows[0]["Address1"].ToString();
                model.location = ds.Tables[1].Rows[0]["Location"] is DBNull ? "" : ds.Tables[1].Rows[0]["Location"].ToString();
                model.Role = ds.Tables[1].Rows[0]["RoleName"] is DBNull ? "" : ds.Tables[1].Rows[0]["RoleName"].ToString();
            }


        }

        internal void generalmessagelist(Candidateconversationmodel model, DataSet ds)
        {
            model.generalmessagelistcollection = (from DataRow row in ds.Tables[0].Rows
                                                  select new CandidateConversationEditModel
                                                  {
                                                      //Ids = EncryptDecrypt.encrypt(row["Id"].ToString()),
                                                      //Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                      //ClientId = Convert.ToInt64(row["ClientId"]),
                                                      //CandidateId = Convert.ToInt64(row["CandidateId"]),
                                                      //Name = Convert.ToString(row["Name"]),
                                                      //JobTitle = Convert.ToString(row["Title"]),
                                                      //Description = Convert.ToString(row["Description"]),
                                                      //Date = Convert.ToDateTime(row["Createddate"]).ToShortDateString(), 
                                                      //RoleName = Convert.ToString(row["RoleName"] is DBNull ? "" : Convert.ToString(row["RoleName"])),


                                                      Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                      Unreadcount = Convert.ToInt64(row["Unreadcount"] is DBNull ? 0 : Convert.ToInt64(row["Unreadcount"])),
                                                      Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString()).ToString()),
                                                      Fromname = Convert.ToString(row["Fromname"]),
                                                      ToName = Convert.ToString(row["ToName"]),
                                                      // ClientId = Convert.ToInt64(row["ClientId"] is DBNull ? 0 : Convert.ToInt64(row["ClientId"])),
                                                      Title = Convert.ToString(row["Title"]),
                                                      createddate = Convert.ToDateTime(row["Createddate"]).ToShortDateString(),



                                                  }).ToList();

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }

        }

        internal void conversation(Candidateconversationmodel model, DataSet ds)
        {

            model.candidateconversationcollection = (from DataRow row in ds.Tables[0].Rows
                                                     select new CandidateConversationEditModel
                                                     {
                                                         Description = Convert.ToString(row["Massege"] is DBNull ? "" : Convert.ToString(row["Massege"])),
                                                         Name = Convert.ToString(row["SenderName"] is DBNull ? "" : Convert.ToString(row["SenderName"])),
                                                         Date = Convert.ToDateTime(row["Createddate"]).ToShortDateString(),
                                                         ClientCandidateId = Convert.ToInt64(row["ClientCandidateId"] is DBNull ? 0 : Convert.ToInt64(row["ClientCandidateId"])),
                                                         CreateBy = Convert.ToInt64(row["CreatedBy"] is DBNull ? 0 : Convert.ToInt64(row["CreatedBy"])),
                                                         FileName = Convert.ToString(row["ClientLogo"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : " /FileUpload/CandidateImage/" + Convert.ToInt32(row["CreatedBy"]) + "/" + row["ClientLogo"]),
                                                         RoleName = Convert.ToString(row["RoleName"] is DBNull ? "" : Convert.ToString(row["RoleName"])),

                                                     }).ToList();
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.ClientId = Convert.ToInt64(ds.Tables[1].Rows[0]["ClientId"]);
                model.imageFile = Convert.ToString(ds.Tables[0].Rows[0]["ClientLogo"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : " /FileUpload/CandidateImage/" + Convert.ToInt32(ds.Tables[0].Rows[0]["CreatedBy"]) + "/" + ds.Tables[0].Rows[0]["ClientLogo"]);

            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                model.JobTitle = Convert.ToString(ds.Tables[2].Rows[0]["JobTitle"]);
                model.JobTypeName = Convert.ToString(ds.Tables[2].Rows[0]["typeName"]);
                model.jobcategory = Convert.ToString(ds.Tables[2].Rows[0]["jobcategory"]);
                model.location = Convert.ToString(ds.Tables[2].Rows[0]["Location"]);
                model.zipcode = Convert.ToString(ds.Tables[2].Rows[0]["zipcode"]);
            }
        }

        public string days(DateTime date)
        {
            double days = (DateTime.Now - date).TotalDays;
            string[] Chars = Convert.ToString(days).Split('.');
            return Chars[0];
        }


        internal void getinterviewschedulelist(ClientModel model, DataTable dt)
        {
            model.interviewListCollection = (from DataRow row in dt.Rows

                                             select new ClientModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 Title = Convert.ToString(row["tilte"]),
                                                 InterviewDate = Convert.ToString(row["Interviewdate"] + " " + row["InterviewTime"]),
                                                 CreateBy = Convert.ToInt64(row["CreateBy"] is DBNull ? 0 : Convert.ToInt64(row["CreateBy"]))
                                             }).ToList();
        }

        internal void InterviewSchedulecalenderlist(ClientModel model, DataTable dt)
        {
            model.interviewListCollection = (from DataRow row in dt.Rows

                                             select new ClientModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 Title = Convert.ToString(row["tilte"]),
                                                 InterviewDate = Convert.ToString(row["Interviewdate"] is DBNull ? "" : row["Interviewdate"] + " " + row["InterviewTime"]),
                                             }).ToList();
        }

        internal void Candidatetagvalue(Tagsmodel model, DataSet ds)
        {

            model.candidatetagcollection = (from DataRow row in ds.Tables[0].Rows
                                            select new Tagsmodel
                                            {

                                                Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : row["Id"]),
                                                CandidateTag = Convert.ToString(row["Name"])

                                            }).ToList();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    model.CandidateTag = model.CandidateTag += ds.Tables[0].Rows[i]["Name"].ToString() + ",";
                }
                model.CandidateTag = model.CandidateTag.Remove(model.CandidateTag.Length - 1, 1);
            }

        }

        internal void CandidatesharedJobpopup(CandidateModel model, DataSet ds)
        {
            model.CompanyColloction = (from DataRow row in ds.Tables[0].Rows
                                       select new DropDownViewModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Name = Convert.ToString(row["name"])
                                       }).ToList();
            //model.candidatesharedjobcollection = (from DataRow row in ds.Tables[0].Rows
            //                                      select new CandidateModel
            //                                      {
            //                                          Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
            //                                          Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString())),
            //                                          jobtitle = Convert.ToString(row["JobTitle"]),
            //                                          JobTypeName = Convert.ToString(row["typeName"]),
            //                                          JobStatusName = Convert.ToString(row["StatusName"]),

            //                                          WorkExperienceMax = Convert.ToString(row["MaxExeperience"]),
            //                                          ClientName = Convert.ToString(row["ClientName"]),
            //                                          JobCategoryName = Convert.ToString(row["categoryName"]),
            //                                          createddate = Convert.ToString(row["CreatedDate"]),
            //                                          ClientId = Convert.ToInt64(row["ClientId"] is DBNull ? 0 : Convert.ToInt64(row["ClientId"]))
            //                                      }).ToList();


            model.ClientCollection = (from DataRow row in ds.Tables[1].Rows
                                      select new DropDownViewModel
                                      {
                                          Id = Convert.ToInt64(row["UserId"]),
                                          Ids = Convert.ToString(row["AccountTypeId"]),
                                          Name = Convert.ToString(row["Name"]) + " " + Convert.ToString(row["LastName"])
                                      }).ToList();

        }
        internal void getsharedjobbyclientid(CandidateModel model, DataTable dt)
        {
            model.candidatesharedjobcollection = (from DataRow row in dt.Rows
                                                  select new CandidateModel
                                                  {
                                                      Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                      Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString())),
                                                      jobtitle = Convert.ToString(row["JobTitle"]),
                                                      location = Convert.ToString(row["location"]),
                                                      JobTypeName = Convert.ToString(row["typeName"]),
                                                      JobStatusName = Convert.ToString(row["StatusName"]),
                                                      WorkExperienceMax = Convert.ToString(row["MaxExeperience"]),
                                                      ClientName = Convert.ToString(row["ClientName"]),
                                                      JobCategoryName = Convert.ToString(row["categoryName"]),
                                                      createddate = Convert.ToString(row["CreatedDate"]),
                                                      ClientId = Convert.ToInt64(row["ClientId"] is DBNull ? 0 : Convert.ToInt64(row["ClientId"]))
                                                  }).ToList();

        }
        internal void CandidateDetail(CandidateModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Address = Convert.ToString(dt.Rows[0]["Address"]);
                model.Education = Convert.ToString(dt.Rows[0]["Education"]);
                model.Phone = Convert.ToString(dt.Rows[0]["Phone"]);
                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                model.Title = Convert.ToString(dt.Rows[0]["Title"]);
                model.Password = Convert.ToString(dt.Rows[0]["Password"]);
            }
        }
        internal void Candidateworkexperiencepopup(CandidateModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Title = Convert.ToString(dt.Rows[0]["title"]);
                model.Company = Convert.ToString(dt.Rows[0]["company"]);
                model.Todate = Convert.ToString(dt.Rows[0]["todate"]);
                model.Fromdate = Convert.ToString(dt.Rows[0]["fromdate"]);
                model.description = Convert.ToString(dt.Rows[0]["description"]);
                model.visibleid = Convert.ToInt64(dt.Rows[0]["visibleid"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["visibleid"]));

            }
            model.visibleidCollection = (from DataRow row in ds.Tables[1].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             Name = Convert.ToString(row["Name"])

                                         }).ToList();
        }


        internal void AddUpdateSkillsPopup(CandidateModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.skill = Convert.ToString(dt.Rows[0]["skill"]);
                model.percentage = Convert.ToString(dt.Rows[0]["percentage"]);
                model.visibleid = Convert.ToInt64(dt.Rows[0]["visibleid"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["visibleid"]));

            }
            model.visibleidCollection = (from DataRow row in ds.Tables[1].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             Name = Convert.ToString(row["Name"])

                                         }).ToList();
        }

        internal void Candidaterefrencespopup(CandidateModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                //model.CandidateId = Convert.ToInt64(dt.Rows[0]["CandidateId"]);
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Phone = Convert.ToString(dt.Rows[0]["Phone"]);
                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                model.Title = Convert.ToString(dt.Rows[0]["Title"]);
            }
        }

        internal void LicensesCertificationspopup(CandidateModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {

                model.Education = Convert.ToString(ds.Tables[0].Rows[0]["education"]);
                model.year = Convert.ToString(ds.Tables[0].Rows[0]["year"] is DBNull ? "" : Convert.ToString(ds.Tables[0].Rows[0]["year"]));
                model.EndYear = Convert.ToString(ds.Tables[0].Rows[0]["EducationEnd"] is DBNull ? "" : Convert.ToString(ds.Tables[0].Rows[0]["EducationEnd"]));
                model.univarsity = Convert.ToString(ds.Tables[0].Rows[0]["university"]);
                model.description = Convert.ToString(ds.Tables[0].Rows[0]["description"]);
                model.visibleid = Convert.ToInt64(ds.Tables[0].Rows[0]["visibleid"]);
            }
            model.visibleidCollection = (from DataRow row in ds.Tables[1].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             Name = Convert.ToString(row["Name"])

                                         }).ToList();
        }

        internal void MySavedJobList(JobsModel model, DataTable dt)
        {
            model.MySavedJobsCollection = (from DataRow row in dt.Rows
                                           select new JobsModel
                                           {

                                               Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                               Ids = EncryptDecrypt.encrypt(row["JobId"].ToString()).ToString(),
                                               JobId = Convert.ToInt64(row["JobId"] is DBNull ? 0 : Convert.ToInt64(row["JobId"])),
                                               jobtitle = Convert.ToString(row["JobTitle"]),
                                               sortdescription = Convert.ToString(row["sortdescription"]),
                                               location = Convert.ToString(row["Location"]),
                                               zipcode = Convert.ToString(row["zipcode"]),
                                               Jobtype = Convert.ToString(row["jobtypeName"]),
                                               createddate = Convert.ToDateTime(row["CreatedDate"]).ToShortDateString(),
                                           }).ToList();


            if (dt.Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
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

                model.InterviewDate = Convert.ToString(dt.Rows[0]["Interviewdate"] is DBNull ? "" : dt.Rows[0]["Interviewdate"] + " " + dt.Rows[0]["InterviewTime"]);
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
            if (dt1.Rows.Count > 0)
            {
                model.ClientEmail = Convert.ToString(dt1.Rows[0]["ClientEmail"]);
                model.ClientName = Convert.ToString(dt1.Rows[0]["FirstName"]) + ' ' + Convert.ToString(dt1.Rows[0]["LastName"]);
            }
            if (dt2.Rows.Count > 0)
            {
                model.CandidateName = Convert.ToString(dt2.Rows[0]["FirstName"]) + ' ' + Convert.ToString(dt2.Rows[0]["LastName"]);
                model.Email = Convert.ToString(dt2.Rows[0]["CandidateEmail"]);
            }
        }

        internal void paymenthistory(PlansListModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count > 0)
            {
                model.Collection = (from DataRow row in dt.Rows
                                    select new PlansViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"]),
                                        TypeId = Convert.ToInt64(row["TypeId"] is DBNull ? 0 : Convert.ToInt64(row["TypeId"])),
                                        recurringpayment = Convert.ToInt64(row["recurringpayment"] is DBNull ? 0 : Convert.ToInt64(row["recurringpayment"])),
                                        PlanName = Convert.ToString(row["PlanName"]),
                                        Amount = Convert.ToString(row["Amount"]),
                                        CreateDate = Convert.ToDateTime(row["createddate"]).ToShortDateString(),
                                        PlanId = Convert.ToString(row["PlanId"]),
                                        //PaymentStopDate = row["PaymentStopDate"] is DBNull ? "" : Convert.ToDateTime(row["PaymentStopDate"]).ToShortDateString(),
                                        //PaymentStopBy = row["Name"] is DBNull ? "" : Convert.ToString(row["Name"]) ,

                                        //RefundDate = row["RefundDate"] is DBNull ? "" : Convert.ToDateTime(row["RefundDate"]).ToShortDateString(),
                                        //Refund = Convert.ToInt64(row["Refund"]),

                                        ValidPlanDate = Convert.ToDateTime(row["ValidPlanDate"]).ToShortDateString(),
                                        Plandateexpired = Convert.ToDateTime(DateTime.Now).ToShortDateString(),
                                        Status = planstatus(row["ValidPlanDate"].ToString()),
                                    }).ToList();

            }

            if (dt.Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }



            if (ds.Tables[1].Rows.Count > 0)
            {
                model.Name = Convert.ToString(ds.Tables[1].Rows[0]["Name"]);


                model.noofjob = Convert.ToInt64(ds.Tables[1].Rows[0]["noofjob"]);
                model.noofinterview = Convert.ToInt64(ds.Tables[1].Rows[0]["noofinterview"]);



                model.jobleft = Convert.ToInt64(ds.Tables[1].Rows[0]["leftjob"]);
                model.LeftInterview = Convert.ToInt64(ds.Tables[1].Rows[0]["leftinterview"]);


                model.Usesnoofjob = Convert.ToInt64(ds.Tables[1].Rows[0]["noofjob"]) - Convert.ToInt64(ds.Tables[1].Rows[0]["leftjob"]);
                model.Usesnoofinterview = Convert.ToInt64(ds.Tables[1].Rows[0]["noofinterview"]) - Convert.ToInt64(ds.Tables[1].Rows[0]["leftinterview"]);



                //model.noofsubmission = Convert.ToInt64(ds.Tables[1].Rows[0]["leftsubmission"]);
                model.ValidPlanDate = Convert.ToDateTime(ds.Tables[1].Rows[0]["ValidPlanDate"]).ToShortDateString();




            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                model.recurringpayment = Convert.ToInt32(ds.Tables[2].Rows[0]["recurringpayment"]);
                model.pId = Convert.ToString(ds.Tables[2].Rows[0]["paymentId"]);

                model.PaymentStopDate = ds.Tables[2].Rows[0]["PaymentStopDate"] is DBNull ? "" : Convert.ToString(ds.Tables[2].Rows[0]["PaymentStopDate"]);
                model.PaymentStopBy = ds.Tables[2].Rows[0]["Name"].ToString() + " " + ds.Tables[2].Rows[0]["LastName"].ToString();

                model.RefundDate = ds.Tables[2].Rows[0]["RefundDate"] is DBNull ? "" : Convert.ToString(ds.Tables[2].Rows[0]["RefundDate"]);
                model.RefundBy = ds.Tables[2].Rows[0]["RefundByName"].ToString() + " " + ds.Tables[2].Rows[0]["RefundByLastName"].ToString();

                model.RenewDate = ds.Tables[2].Rows[0]["PaymentRenewDate"] is DBNull ? "" : Convert.ToString(ds.Tables[2].Rows[0]["PaymentRenewDate"]);
                model.RenewBy = ds.Tables[2].Rows[0]["RewByName"].ToString() + " " + ds.Tables[2].Rows[0]["RewByLastName"].ToString();


            }

        }
        public string planstatus(string date)
        {
            if (Convert.ToDateTime(date) > DateTime.Now)
            {
                return "Current";
            }
            else
            {
                return "Expired";
            }

        }
        internal void Candidatedefaultimage(CandidateModel model, DataTable dt)
        {
            model.CandidatedefaultimageCollection = (from DataRow row in dt.Rows
                                                     select new CandidateModel
                                                     {

                                                         Id = Convert.ToInt64(row["Id"]),
                                                         FileName = Convert.ToString(row["ImageName"]),
                                                         FileUpload = "/" + "FileUpload/candidatedefaultImage" + "/" + Convert.ToString(row["ImageName"])

                                                     }).ToList();

        }

        internal void Plan(PlanModel model, DataSet ds)
        {

            model.PlanListCollection = (from DataRow row in ds.Tables[0].Rows
                                        select new PlanModel
                                        {

                                            Id = Convert.ToInt64(row["Id"]),
                                            Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString())),
                                            Name = Convert.ToString(row["Name"]),
                                            Price = Convert.ToString(row["Price"]),
                                            Description = Convert.ToString(row["Description"]),
                                            PlanStatusId = Convert.ToInt64(row["PlanStatus"]),
                                            PlanStatusName = Convert.ToString(row["PlanStatusName"]),
                                            Subscription = Convert.ToInt64(row["SubscriptionDays"] is DBNull ? 0 : Convert.ToInt64(row["SubscriptionDays"])),
                                            PlanTypeId = Convert.ToInt64(row["PlanTypeId"] is DBNull ? 0 : Convert.ToInt64(row["PlanTypeId"])),
                                            PlanTypeName = Convert.ToString(row["PlanTypeName"])

                                        }).ToList();
            model.PlanCollection = (from DataRow row in ds.Tables[1].Rows
                                    select new DropDownViewModel
                                    {

                                        Id = Convert.ToInt64(row["Id"]),
                                        Name = Convert.ToString(row["Name"])

                                    }).ToList();
            model.PlanTypeCollection = (from DataRow row in ds.Tables[2].Rows
                                        select new DropDownViewModel
                                        {

                                            Id = Convert.ToInt64(row["Id"]),
                                            Name = Convert.ToString(row["Name"])

                                        }).ToList();
        }

        internal void PlanCreatepopup(PlanModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Price = Convert.ToString(dt.Rows[0]["Price"]);
                model.Description = Convert.ToString(dt.Rows[0]["Description"]);
                model.PlanStatusId = Convert.ToInt64(dt.Rows[0]["PlanStatus"]);
                model.PlanStatusName = Convert.ToString(dt.Rows[0]["PlanStatusName"]);
                model.noofjob = Convert.ToString(dt.Rows[0]["noofjob"]);
                model.noofinterview = Convert.ToString(dt.Rows[0]["noofinterview"]);
                model.noofsubmission = Convert.ToString(dt.Rows[0]["noofsubmission"]);
                model.PlanTypeId = Convert.ToInt64(dt.Rows[0]["PlanTypeId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["PlanTypeId"]));
                model.Subscription = Convert.ToInt64(dt.Rows[0]["SubscriptionDays"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["SubscriptionDays"]));
                model.CreatedDate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]).ToShortDateString();
            }

            model.PlanCollection = (from DataRow row in ds.Tables[1].Rows
                                    select new DropDownViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"]),
                                        Name = Convert.ToString(row["Name"])
                                    }).ToList();

            model.PlanTypeCollection = (from DataRow row in ds.Tables[2].Rows
                                        select new DropDownViewModel
                                        {
                                            Id = Convert.ToInt64(row["Id"]),
                                            Name = Convert.ToString(row["Name"])
                                        }).ToList();
        }

        internal void CDetail(CandidateModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.UserId = Convert.ToInt64(dt.Rows[0]["UserId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["UserId"]));
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                model.location = Convert.ToString(dt.Rows[0]["Location"]);
                model.PreferredEMail = Convert.ToString(dt.Rows[0]["PreferredEMail"]);
                model.DesiredTitle1 = Convert.ToString(dt.Rows[0]["DesiredTitle1"]);
                model.DesiredTitle2 = Convert.ToString(dt.Rows[0]["DesiredTitle2"]);
                model.JobTypeId = Convert.ToInt64(dt.Rows[0]["jobtype"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["jobtype"]));
                model.Industry = Convert.ToInt64(dt.Rows[0]["Industry"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["Industry"]));
                model.IndustryName = Convert.ToString(dt.Rows[0]["IndustryName"]);
                model.jobtypeName = Convert.ToString(dt.Rows[0]["jobtypeName"]);
                model.Phone = Convert.ToString(dt.Rows[0]["PhoneNo"] is DBNull ? "" : dt.Rows[0]["PhoneNo"]);
                model.Title = Convert.ToString(dt.Rows[0]["Title"]);
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
                model.Certifications = Convert.ToString(dt.Rows[0]["Certifications"]);
                model.Relocation = Convert.ToString(dt.Rows[0]["Relocation"]);
                model.Email = Convert.ToString(dt.Rows[0]["RegisteredEmail"]);

                //model.CountryName = Convert.ToString(dt.Rows[0]["countryName"]);
                //model.StateName = Convert.ToString(dt.Rows[0]["StateName"]);
                //model.CityName = Convert.ToString(dt.Rows[0]["CityName"]);
                model.Zipcode = Convert.ToString(dt.Rows[0]["Zipcode"]);
                model.resumeName = Convert.ToString(dt.Rows[0]["Resumefile"]);
                model.imageFile = Convert.ToString(dt.Rows[0]["ImageFile"]);
                model.Resumefile = "/" + "FileUpload/CandidateResume" + "/" + Convert.ToString(dt.Rows[0]["UserId"]) + "/" + Convert.ToString(dt.Rows[0]["Resumefile"]);
                //model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"]);
                //model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidate.png" : "/FileUpload/CandidateImage/" + Convert.ToInt32(dt.Rows[0]["UserId"]) + "/" + dt.Rows[0]["ImageFile"]);
                //model.imageFile = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidate.png" : "/FileUpload/candidatedefaultImage/"  + dt.Rows[0]["ImageFile"]);
                model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["ImageFile"].ToString());
                model.Featured = Convert.ToInt64(dt.Rows[0]["Featured"]);

                model.CreateBy = Convert.ToInt64(dt.Rows[0]["CreatedBy"]);
                model.CreatedByName = Convert.ToString(dt.Rows[0]["CreatedByName"]);
                model.createddate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]).ToString("MM/dd/yyyy");

                if (Convert.ToString(dt.Rows[0]["UpdateDate"]).Length > 0)
                {
                    model.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdateDate"]).ToString("MM/dd/yyyy");
                }

                model.AccountTypeName = Convert.ToString(dt.Rows[0]["AccountTypeName"]);
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
                                             visibleid = Convert.ToInt64(row["visibleId"] is DBNull ? 0 : Convert.ToInt64(row["visibleId"])),
                                         }).ToList();
            if (ds.Tables[2].Rows.Count > 0)
            {
                model.workexperiencecollection = (from DataRow row in ds.Tables[2].Rows
                                                  select new CandidateModel
                                                  {
                                                      workId = Convert.ToInt64(row["Id"]),
                                                      Title = Convert.ToString(row["title"]),
                                                      Todate = Convert.ToString(row["todate"] is DBNull ? "" : Convert.ToDateTime(row["todate"]).ToString("MM/dd/yyyy")),
                                                      Fromdate = Convert.ToString(row["fromdate"] is DBNull ? "" : Convert.ToDateTime(row["fromdate"]).ToString("MM/dd/yyyy")),
                                                      description = Convert.ToString(row["description"]),
                                                      visibleName = Convert.ToString(row["visibleName"]),
                                                      Company = Convert.ToString(row["company"]),
                                                      visibleid = Convert.ToInt64(row["visibleId"] is DBNull ? 0 : Convert.ToInt64(row["visibleId"])),
                                                  }).ToList();
            }
            model.Awardscecollection = (from DataRow row in ds.Tables[3].Rows
                                        select new CandidateModel
                                        {
                                            awardId = Convert.ToInt64(row["Id"]),
                                            Title = Convert.ToString(row["title"]),
                                            year = Convert.ToString(row["year"]),
                                            description = Convert.ToString(row["description"]),
                                            visibleName = Convert.ToString(row["visibleName"]),
                                            visibleid = Convert.ToInt64(row["visibleId"] is DBNull ? 0 : Convert.ToInt64(row["visibleId"])),

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
                                               visibleid = Convert.ToInt64(row["visibleId"] is DBNull ? 0 : Convert.ToInt64(row["visibleId"])),
                                           }).ToList();
            if (ds.Tables[5].Rows.Count > 0)
            {
                model.SkillCollection = (from DataRow row in ds.Tables[5].Rows
                                         select new CandidateModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             skill = Convert.ToString(row["skillname"]),
                                             percentage = Convert.ToString(row["percentage"]),
                                             visibleName = Convert.ToString(row["visibleName"]),

                                         }).ToList();
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                model.VideoTitle = ds.Tables[6].Rows[0]["Title"].ToString();
                model.VideoUrl = ds.Tables[6].Rows[0]["Url"].ToString();
                model.description = ds.Tables[6].Rows[0]["Description"].ToString();
                model.visibleName = ds.Tables[6].Rows[0]["visibleName"].ToString();
                model.visibleid = Convert.ToInt64(ds.Tables[6].Rows[0]["visibleId"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[6].Rows[0]["visibleId"]));
            }

            model.candidaterefrencecollection = (from DataRow row in ds.Tables[7].Rows
                                                 select new CandidateModel
                                                 {
                                                     refrenceId = Convert.ToInt64(row["Id"]),
                                                     // CandidateId = Convert.ToInt64(row["CandidateId"]),
                                                     Name = Convert.ToString(row["Name"]),
                                                     Phone = Convert.ToString(row["Phone"]),
                                                     Email = Convert.ToString(row["Email"]),
                                                     Title = Convert.ToString(row["Title"]),

                                                 }).ToList();


            if (ds.Tables[8].Rows.Count > 0)
            {
                model.interviewListCollection = (from DataRow row in ds.Tables[8].Rows
                                                 select new CandidateModel
                                                 {
                                                     Id = Convert.ToInt64(row["Id"]),
                                                     Subject = Convert.ToString(row["tilte"]),
                                                     InterviewerName = Convert.ToString(row["ClientName"]),
                                                     InterviewerEmail = Convert.ToString(row["ClientEmail"]),
                                                     InterviewDate = Convert.ToString(row["Interviewdate"] + " " + row["InterviewTime"]),
                                                     location = Convert.ToString(row["Location"]),
                                                 }).ToList();
            }
            if (ds.Tables[9].Rows.Count > 0)
            {
                model.JobListCollection = (from DataRow row in ds.Tables[9].Rows
                                           select new CandidateModel
                                           {
                                               Id = Convert.ToInt64(row["Id"]),
                                               Ids = EncryptDecrypt.encrypt(row["JobId"].ToString()),
                                               jobtitle = Convert.ToString(row["JobTitle"]),
                                               JobTypeName = Convert.ToString(row["jobtypeName"]),
                                               JobStatusName = Convert.ToString(row["JobStatusName"]),
                                               UserName = Convert.ToString(row["FName"]) + Convert.ToString(row["LName"]),
                                           }).ToList();
            }

            model.candidatetagviewcollection = (from DataRow row in ds.Tables[10].Rows
                                                select new CandidateModel
                                                {
                                                    Id = Convert.ToInt64(row["Id"]),
                                                    TagId = Convert.ToInt64(row["TagId"] is DBNull ? 0 : Convert.ToInt64(row["TagId"])),
                                                    CandidateId = Convert.ToInt64(row["CId"] is DBNull ? 0 : Convert.ToInt64(row["CId"])),
                                                    CandidateTag = Convert.ToString(row["Name"] is DBNull ? "" : Convert.ToString(row["Name"]))
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



            if (ds.Tables[12].Rows.Count > 0)
            {
                model.Pipelinestage = (from DataRow row in ds.Tables[12].Rows
                                       select new CandidateModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Ids = Convert.ToString(EncryptDecrypt.encrypt(row["JobId"].ToString())),
                                           JobId = Convert.ToInt16(row["JobId"]),
                                           jobtitle = Convert.ToString(row["JobTitle"]),
                                           InterviewStausName = Convert.ToString(row["interviewstatus"]),


                                       }).ToList();
            }

            if (ds.Tables[13].Rows.Count > 0)
            {
                model.Interviewcolloction = (from DataRow row in ds.Tables[13].Rows
                                             select new CandidateModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 Ids = Convert.ToString(EncryptDecrypt.encrypt(row["JobId"].ToString())),
                                                 JobId = Convert.ToInt16(row["JobId"]),
                                                 jobtitle = Convert.ToString(row["JobTitle"]),
                                                 InterviewDate = Convert.ToString(row["Interviewdate"] + " " + row["InterviewTime"]),


                                             }).ToList();
            }
        }

        internal void interviewscedulelist(ClientModel model, DataSet ds)
        {
            model.interviewListCollection = (from DataRow row in ds.Tables[0].Rows

                                             select new ClientModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 ClientId = Convert.ToInt64(row["ClientId"]),
                                                 Title = Convert.ToString(row["tilte"]),
                                                 Jobtitle = Convert.ToString(row["JobTitle"]),
                                                 Position = Convert.ToString(row["positionlevelName"]),
                                                 CandidateId = Convert.ToInt64(row["CandidateId"]),
                                                 Ids = Convert.ToString(EncryptDecrypt.encrypt(row["CandidateId"].ToString())),
                                                 candidateTitle = Convert.ToString(row["tilte"]),
                                                 InterviewDate = Convert.ToString(row["Interviewdate"] is DBNull ? "" : row["InterviewDate"] + " "+ row["InterviewTime"]),
                                                 CandidateName = Convert.ToString(row["CandidateName"]),
                                                 Email = Convert.ToString(row["CandidateEmail"]),
                                                 ClientName = Convert.ToString(row["ClientName"]),
                                                 ClientEmail = Convert.ToString(row["ClientEmail"]),
                                                 Location = Convert.ToString(row["ClientName"]),
                                                 InterviewBcc = Convert.ToString(row["ClientName"]),
                                                 InterviewCc = Convert.ToString(row["ClientName"]),
                                                 JobId = Convert.ToInt64(row["JobId"] is DBNull ? 0 : Convert.ToInt64(row["JobId"])),
                                                 CreateBy = Convert.ToInt64(row["CreateBy"] is DBNull ? 0 : Convert.ToInt64(row["CreateBy"])),

                                             }).ToList();
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }




            model.Jobscollection = (from DataRow row in ds.Tables[1].Rows
                                    select new DropDownViewModel
                                    { 
                                        Id = Convert.ToInt64(row["Id"]),
                                        Ids = EncryptDecrypt.encrypt(row["Id"].ToString()),
                                        Name = Convert.ToString(row["JobTitle"]),
                                        Location = Convert.ToString(row["Location"])

                                    }).ToList();

            
            
            model.CompletedInterviewListCollection = (from DataRow row in ds.Tables[2].Rows

                                             select new ClientModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 ClientId = Convert.ToInt64(row["ClientId"]),
                                                 Title = Convert.ToString(row["tilte"]),
                                                 Jobtitle = Convert.ToString(row["JobTitle"]),
                                                 Position = Convert.ToString(row["positionlevelName"]),
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
                                                 JobId = Convert.ToInt64(row["JobId"] is DBNull ? 0 : Convert.ToInt64(row["JobId"])),
                                                 CreateBy = Convert.ToInt64(row["CreateBy"] is DBNull ? 0 : Convert.ToInt64(row["CreateBy"])),

                                             }).ToList();
            if (ds.Tables[2].Rows.Count > 0)
            {
                model.CompletedTotalRowCount = Convert.ToInt32(ds.Tables[2].Rows[0]["TotalRowCount"]);
                double CompletedpageCount = (double)((decimal)model.CompletedTotalRowCount / Convert.ToDecimal(model.CompletedmaxRows));
                model.CompletedPageCount = (int)Math.Ceiling(CompletedpageCount);
                model.Completedindexlegth = model.CompletedPageCount - Convert.ToInt32(model.pId);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                model.PastMonthCount = Convert.ToInt64(ds.Tables[3].Rows[0]["PastMonthCount"]);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                model.Count = Convert.ToInt64(ds.Tables[4].Rows[0]["Count"]);
            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                model.Title = Convert.ToString(ds.Tables[5].Rows[0]["JobTitle"]) + " " + ds.Tables[5].Rows[0]["Location"];
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                model.AllCount = Convert.ToInt64(ds.Tables[6].Rows[0]["Count"]);
            }
        }

        internal void interviewStatusPopup(CandidateModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            model.InterviewStaus = (from DataRow row in dt.Rows
                                    select new DropDownViewModel
                                    {

                                        Id = Convert.ToInt64(row["Id"]),
                                        Name = Convert.ToString(row["Name"])
                                    }).ToList();
            model.JobListCollection = (from DataRow row in dt1.Rows
                                       select new CandidateModel
                                       {

                                           Id = Convert.ToInt64(row["Id"]),
                                           Title = Convert.ToString(row["JobTitle"])
                                       }).ToList();
            model.Id = Convert.ToInt64(ds.Tables[2].Rows[0]["InterviewStatusId"] is DBNull ? 0 : ds.Tables[2].Rows[0]["InterviewStatusId"]);
        }

        internal void MyappliedJob(JobsModel model, DataTable dt)
        {
            model.MyappliedJobsCollection = (from DataRow row in dt.Rows
                                             select new JobsModel
                                             {

                                                 Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                 Ids = EncryptDecrypt.encrypt(row["JobId"].ToString()).ToString(),
                                                 JobId = Convert.ToInt64(row["JobId"] is DBNull ? 0 : Convert.ToInt64(row["JobId"])),
                                                 jobtitle = Convert.ToString(row["JobTitle"]),
                                                 sortdescription = Convert.ToString(row["sortdescription"]),
                                                 location = Convert.ToString(row["Location"]),
                                                 zipcode = Convert.ToString(row["zipcode"]),
                                                 Jobtype = Convert.ToString(row["jobtypeName"]),
                                                 createddate = Convert.ToDateTime(row["CreatedDate"]).ToShortDateString(),
                                             }).ToList();
            if (dt.Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
        }
        internal void Applicant(CandidateModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.CandidateCollection = (from DataRow row in ds.Tables[0].Rows
                                             select new CandidateModel
                                             {
                                                 Id = Convert.ToInt64(row["applyjobId"] is DBNull ? 0 : Convert.ToInt64(row["applyjobId"])),
                                                 Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString())),
                                                 Name = Convert.ToString(row["Name"]) + " " + Convert.ToString(row["LastName"]),
                                                 Title = Convert.ToString(row["Title"]),
                                                 Phone = Convert.ToString(row["PhoneNo"]),
                                                 Email = Convert.ToString(row["Email"]),
                                                 //CountryName = Convert.ToString(row["countryName"]),
                                                 //StateName = Convert.ToString(row["StateName"]),
                                                 //CityName = Convert.ToString(row["cityName"]),
                                                 Zipcode = Convert.ToString(row["Zipcode"]),
                                                 applyjobId = Convert.ToInt64(row["applyjobId"] is DBNull ? 0 : Convert.ToInt64(row["applyjobId"])),
                                                 GuestId = Convert.ToInt64(row["GuestId"] is DBNull ? 0 : Convert.ToInt64(row["GuestId"])),
                                                 JobId = Convert.ToInt64(row["applyjobJobId"] is DBNull ? 0 : Convert.ToInt64(row["applyjobJobId"])),
                                                 applicanttypeId = Convert.ToInt64(row["applicanttypeId"] is DBNull ? 0 : Convert.ToInt64(row["applicanttypeId"])),
                                                 InterviewSId = Convert.ToInt64(row["InterviewStatusId"] is DBNull ? 0 : Convert.ToInt64(row["InterviewStatusId"])),
                                             }).ToList();
            }

            model.JobCollection = (from DataRow row in ds.Tables[1].Rows
                                   select new DropDownViewModel
                                   {
                                       Id = Convert.ToInt64(row["Id"]),
                                       Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString())),
                                       Name = Convert.ToString(row["JobTitle"]),
                                   }).ToList();
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
            model.JobStatusCollection = (from DataRow row in ds.Tables[2].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             Name = Convert.ToString(row["Name"])
                                         }).ToList();

            model.CompanyJobCollection = (from DataRow row in ds.Tables[3].Rows
                                          select new DropDownViewModel
                                          {
                                              Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                              Name = Convert.ToString(row["name"])

                                          }).ToList();

        }

        internal void Dashboard(CandidateModel model, DataSet ds)
        {
            if ((ds.Tables[0].Rows.Count > 0))
            {
                model.percentage = Convert.ToString(ds.Tables[0].Rows[0]["percentage"]);
            }
            if ((ds.Tables[1].Rows.Count > 0))
            {
                model.Jobsavedcount = Convert.ToString(ds.Tables[1].Rows[0]["savedcount"]);
            }
            if ((ds.Tables[2].Rows.Count > 0))
            {
                model.Jobappliedcount = Convert.ToString(ds.Tables[2].Rows[0]["appliedcount"]);
            }
            if ((ds.Tables[3].Rows.Count > 0))
            {
                // model.Jobsavedcount = Convert.ToString(ds.Tables[2].Rows[0]["appliedcount"]);
            }
            if ((ds.Tables[4].Rows.Count > 0))
            {
                model.Name = Convert.ToString(ds.Tables[4].Rows[0]["Name"]);
                model.paymentPlandatecount = Convert.ToDateTime(ds.Tables[4].Rows[0]["ValidPlanDate"]).ToString("MM/dd/yyyy");
            }

        }

        internal void AutoCompleteSkills(CandidateModel model, DataTable dt)
        {
            model.SkillCollection = (from DataRow row in dt.Rows
                                     select new CandidateModel
                                     {

                                         Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                         Name = Convert.ToString(row["Name"])
                                     }).ToList();
        }

        internal void CityList(CandidateModel model, DataTable dt)
        {
            model.CityCollection = (from DataRow row in dt.Rows
                                    select new DropDownViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"]),
                                        Name = Convert.ToString(row["Name"])
                                    }).ToList();
        }
        internal void StateList(CandidateModel model, DataTable dt)
        {
            model.StateCollection = (from DataRow row in dt.Rows
                                     select new DropDownViewModel
                                     {
                                         Id = Convert.ToInt64(row["Id"]),
                                         Name = Convert.ToString(row["Name"])
                                     }).ToList();
        }
        internal void candidatedetailbyId(CandidateModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];


            if (dt.Rows.Count > 0)
            {

                model.UserId = Convert.ToInt64(dt.Rows[0]["UserId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["UserId"]));
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.location = Convert.ToString(dt.Rows[0]["location"]);
                model.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                model.PreferredEMail = Convert.ToString(dt.Rows[0]["PreferredEMail"]);
                model.DesiredTitle1 = Convert.ToString(dt.Rows[0]["DesiredTitle1"]);
                model.DesiredTitle2 = Convert.ToString(dt.Rows[0]["DesiredTitle2"]);
                model.JobTypeId = Convert.ToInt64(dt.Rows[0]["jobtype"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["jobtype"]));
                model.Industry = Convert.ToInt64(dt.Rows[0]["Industry"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["Industry"]));

                model.IndustryName = Convert.ToString(dt.Rows[0]["IndustryName"]);
                model.jobtypeName = Convert.ToString(dt.Rows[0]["jobtypeName"]);
                model.InterviewSId = Convert.ToInt64(dt.Rows[0]["InterviewStatusId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["InterviewStatusId"]));
                model.Phone = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                model.Title = Convert.ToString(dt.Rows[0]["Title"]);
                model.PorfileDescerption = Convert.ToString(dt.Rows[0]["Description"]);

                model.Address1 = Convert.ToString(dt.Rows[0]["Address1"]);
                model.Address2 = Convert.ToString(dt.Rows[0]["Address2"]);
                model.experienceName = Convert.ToString(dt.Rows[0]["experienceName"]);
                //model.JobId = Convert.ToInt64(dt.Rows[0]["JobId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["JobId"]));
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
                //model.FileName = "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["ImageFile"].ToString();

                model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["ImageFile"].ToString());


                model.InterviewSId = Convert.ToInt64(dt.Rows[0]["InterviewStatusId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["InterviewStatusId"]));
                model.InterviewStausName = Convert.ToString(dt.Rows[0]["InterviewstatusName"]);
                model.Email = Convert.ToString(dt.Rows[0]["RegisteredEmail"]);
                model.location = Convert.ToString(dt.Rows[0]["Location"]);
                model.Relocation = Convert.ToString(dt.Rows[0]["Relocation"]);

                model.CreateBy = Convert.ToInt64(dt.Rows[0]["CreatedBy"] is DBNull ? 0 : dt.Rows[0]["CreatedBy"]);
                model.CreatedByName = Convert.ToString(dt.Rows[0]["CreatedByName"]);
                model.createddate = Convert.ToDateTime(dt.Rows[0]["CreatedDate"]).ToString("MM/dd/yyyy");
                if (Convert.ToString(dt.Rows[0]["UpdateDate"]).Length > 0)
                {
                    model.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdateDate"]).ToShortDateString();
                }
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                model.EducationCollection = (from DataRow row in ds.Tables[1].Rows
                                             select new CandidateModel
                                             {
                                                 educationId = Convert.ToInt64(row["Id"]),
                                                 Education = Convert.ToString(row["education"]),



                                                 EducaStartYear = Convert.ToString(row["year"]),
                                                 EducaEndYear = Convert.ToString(row["EducationEnd"]),

                                                 univarsity = Convert.ToString(row["university"]),
                                                 description = Convert.ToString(row["description"]),
                                                 visibleName = Convert.ToString(row["visibleName"])
                                             }).ToList();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                model.workexperiencecollection = (from DataRow row in ds.Tables[2].Rows
                                                  select new CandidateModel
                                                  {
                                                      workId = Convert.ToInt64(row["Id"]),
                                                      Title = Convert.ToString(row["title"]),
                                                      Todate = Convert.ToString(row["todate"] is DBNull ? "" : Convert.ToDateTime(row["todate"]).ToString("MM/dd/yyyy")),
                                                      Fromdate = Convert.ToString(row["fromdate"] is DBNull ? "" : Convert.ToDateTime(row["fromdate"]).ToString("MM/dd/yyyy")),


                                                      description = Convert.ToString(row["description"]),
                                                      visibleName = Convert.ToString(row["visibleName"]),
                                                      Company = Convert.ToString(row["company"])
                                                  }).ToList();
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                model.Awardscecollection = (from DataRow row in ds.Tables[3].Rows
                                            select new CandidateModel
                                            {
                                                awardId = Convert.ToInt64(row["Id"]),
                                                Title = Convert.ToString(row["title"]),
                                                year = Convert.ToString(row["year"]),
                                                description = Convert.ToString(row["description"]),
                                                visibleName = Convert.ToString(row["visibleName"])

                                            }).ToList();
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                model.portfoliocecollection = (from DataRow row in ds.Tables[4].Rows
                                               select new CandidateModel
                                               {
                                                   PortfolioId = Convert.ToInt64(row["Id"]),
                                                   UserId = Convert.ToInt64(row["CreatedBy"]),
                                                   FileName = Convert.ToString(row["FileName"]),

                                                   FileUpload = "/" + "FileUpload" + "/" + "/" + "PortfolioImage" + "/" + Convert.ToInt64(row["CandidateId"]) + "/" + row["FileName"].ToString(),
                                                   Link = Convert.ToString(row["Link"]),
                                                   description = Convert.ToString(row["description"]),
                                                   visibleName = Convert.ToString(row["visibleName"])

                                               }).ToList();

            }

            if (ds.Tables[5].Rows.Count > 0)
            {
                model.SkillCollection = (from DataRow row in ds.Tables[5].Rows
                                         select new CandidateModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             skill = Convert.ToString(row["skillname"]),
                                             percentage = Convert.ToString(row["percentage"]),
                                             visibleName = Convert.ToString(row["visibleName"])
                                         }).ToList();
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                model.VideoTitle = ds.Tables[6].Rows[0]["Title"].ToString();
                model.VideoUrl = ds.Tables[6].Rows[0]["Url"].ToString();
                model.description = ds.Tables[6].Rows[0]["Description"].ToString();
                model.visibleName = ds.Tables[6].Rows[0]["visibleName"].ToString();
            }
            model.candidaterefrencecollection = (from DataRow row in ds.Tables[7].Rows
                                                 select new CandidateModel
                                                 {
                                                     refrenceId = Convert.ToInt64(row["Id"]),
                                                     // CandidateId = Convert.ToInt64(row["CandidateId"]),
                                                     Name = Convert.ToString(row["Name"]),
                                                     Phone = Convert.ToString(row["Phone"]),
                                                     Email = Convert.ToString(row["Email"]),
                                                     Title = Convert.ToString(row["Title"]),

                                                 }).ToList();

            if (model.JobId != 0)
            {

                if (ds.Tables[8].Rows.Count > 0)
                {
                    model.ClientId = Convert.ToInt64(ds.Tables[8].Rows[0]["ClientId"]);
                }
            }

            if (ds.Tables[9].Rows.Count > 0)
            {
                model.Pipelinestage = (from DataRow row in ds.Tables[9].Rows
                                       select new CandidateModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Ids = Convert.ToString(EncryptDecrypt.encrypt(row["JobId"].ToString())),
                                           JobId = Convert.ToInt16(row["JobId"]),
                                           jobtitle = Convert.ToString(row["JobTitle"]),
                                           InterviewStausName = Convert.ToString(row["interviewstatus"]),


                                       }).ToList();
            }

            if (ds.Tables[10].Rows.Count > 0)
            {
                model.Interviewcolloction = (from DataRow row in ds.Tables[10].Rows
                                             select new CandidateModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 Ids = Convert.ToString(EncryptDecrypt.encrypt(row["JobId"].ToString())),
                                                 JobId = Convert.ToInt16(row["JobId"]),
                                                 jobtitle = Convert.ToString(row["JobTitle"]),
                                                 InterviewDate = Convert.ToString(row["Interviewdate"] + " " + row["InterviewTime"]),


                                             }).ToList();
            }
            if (ds.Tables[11].Rows.Count > 0)
            {
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
            }


        }

        internal void Candidateportfoliopopup(CandidateModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.CandidateId = Convert.ToInt64(dt.Rows[0]["CandidateId"]);
                model.Link = Convert.ToString(dt.Rows[0]["Link"]);
                model.description = Convert.ToString(dt.Rows[0]["description"]);
                model.FileName = Convert.ToString(dt.Rows[0]["FileName"]);
                model.visibleid = Convert.ToInt64(dt.Rows[0]["visibleid"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["visibleid"]));
            }
            model.visibleidCollection = (from DataRow row in ds.Tables[1].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             Name = Convert.ToString(row["Name"])

                                         }).ToList();
        }

        internal void GetAllCandidateList(CandidateListModel model, DataSet ds)
        {
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    model.CountryId = Convert.ToInt64(ds.Tables[0].Rows[0]["CountryId"]);
            //    model.StateId = Convert.ToInt64(ds.Tables[0].Rows[0]["StateId"]);
            //    model.CityId = Convert.ToInt64(ds.Tables[0].Rows[0]["CityId"]);
            //    model.Zip = Convert.ToString(ds.Tables[0].Rows[0]["Zipcode"]);
            //    model.Title = Convert.ToString(ds.Tables[0].Rows[0]["Title"]);
            //}

            string groupcandidateId = "";

            if (ds.Tables[11].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[11].Rows.Count; i++)
                {
                    groupcandidateId = groupcandidateId += ds.Tables[11].Rows[i]["candidateid"].ToString() + ",";
                }
                model.groupcandidateId = groupcandidateId.Remove(groupcandidateId.Length - 1, 1);

            }


            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }


            if (ds.Tables[1].Rows.Count > 0)
            {
                model.UserIdByTitle = "";
                for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                {
                    model.UserIdByTitle = model.UserIdByTitle += ds.Tables[1].Rows[i]["UserId"].ToString() + ",";
                }
                model.UserIdByTitle = model.UserIdByTitle.Remove(model.UserIdByTitle.Length - 1, 1);
            }

            //model.StateCollection = (from DataRow row in ds.Tables[1].Rows
            //                         select new DropDownViewModel
            //                         {
            //                             Id = Convert.ToInt64(row["Id"]),
            //                             Name = Convert.ToString(row["Name"])
            //                         }).ToList();


            if (ds.Tables[3].Rows.Count > 0)
            {
                model.jobtype = "";
                for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                {
                    model.jobtype = model.jobtype += ds.Tables[3].Rows[i]["Name"].ToString() + ",";
                }
                model.jobtype = model.jobtype.Remove(model.jobtype.Length - 1, 1);
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                model.SearchCollection = (from DataRow row in ds.Tables[4].Rows
                                          select new CandidateListModel
                                          {
                                              Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                              UserId = Convert.ToInt64(row["UserId"] is DBNull ? 0 : Convert.ToInt64(row["UserId"])),
                                              Title = Convert.ToString(row["Title"]),
                                              SaleryName = Convert.ToString(row["salary"]),
                                              Location = Convert.ToString(row["Location"]),
                                              Jobtype = Convert.ToString(row["JobTypeName"]),
                                              Zip = Convert.ToString(row["Zipcode"]),
                                              Industry = Convert.ToString(row["IndustryName"]),
                                              educationlavel = Convert.ToString(row["educationlevelName"]),
                                              jobtypeId = Convert.ToInt64(row["jobtype"]),
                                              imagepath = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + row["ImageFile"].ToString()),
                                          }).ToList();
            }

            model.IndustryCollection = (from DataRow row in ds.Tables[5].Rows
                                        select new DropDownViewModel
                                        {
                                            Id = Convert.ToInt64(row["Id"]),
                                            Name = Convert.ToString(row["Name"])
                                        }).ToList();

            model.jobtypecollection = (from DataRow row in ds.Tables[6].Rows
                                       select new DropDownViewModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Name = Convert.ToString(row["Name"])
                                       }).ToList();

            model.milescollection = (from DataRow row in ds.Tables[7].Rows
                                     select new DropDownViewModel
                                     {
                                         Id = Convert.ToInt64(row["milesid"]),
                                         Name = Convert.ToString(row["Name"])
                                     }).ToList();
            model.experiencecollection = (from DataRow row in ds.Tables[8].Rows
                                          select new DropDownViewModel
                                          {
                                              Id = Convert.ToInt64(row["Id"]),
                                              Name = Convert.ToString(row["Name"])
                                          }).ToList();

            model.Educationcollection = (from DataRow row in ds.Tables[9].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             Name = Convert.ToString(row["Name"])
                                         }).ToList();
            if (ds.Tables[10].Rows.Count > 0)
            {
                model.Keyword = ds.Tables[10].Rows[0]["Name"].ToString();
            }
        }

        internal void CandidateportfolioDelete(CandidateModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.CandidateId = Convert.ToInt64(dt.Rows[0]["CandidateId"]);
            }
            model.FileName = Convert.ToString(dt.Rows[0]["FileName"]);
        }
        internal void CandidateVediopopu(CandidateModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Title = dt.Rows[0]["Title"].ToString();
                model.VideoUrl = dt.Rows[0]["Url"].ToString();
                model.description = dt.Rows[0]["Description"].ToString();
                model.visibleid = Convert.ToInt64(dt.Rows[0]["visibleid"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["visibleid"]));

            }
            model.visibleidCollection = (from DataRow row in ds.Tables[1].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             Name = Convert.ToString(row["Name"])

                                         }).ToList();
        }


        internal void candidateprofilepopup(CandidateModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                model.location = Convert.ToString(dt.Rows[0]["Location"]);
                model.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                model.PreferredEMail = Convert.ToString(dt.Rows[0]["PreferredEMail"]);
                model.DesiredTitle1 = Convert.ToString(dt.Rows[0]["DesiredTitle1"]);
                model.DesiredTitle2 = Convert.ToString(dt.Rows[0]["DesiredTitle2"]);
                model.JobTypeId = Convert.ToInt64(dt.Rows[0]["jobtype"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["jobtype"]));
                model.Industry = Convert.ToInt64(dt.Rows[0]["Industry"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["Industry"]));
                model.Address1 = Convert.ToString(dt.Rows[0]["Address1"]);
                model.Address2 = Convert.ToString(dt.Rows[0]["Address2"]);
                model.Title = Convert.ToString(dt.Rows[0]["Title"]);
                model.description = Convert.ToString(dt.Rows[0]["Description"]);
                model.Facebook = Convert.ToString(dt.Rows[0]["FacebookUrl"]);
                model.Twitter = Convert.ToString(dt.Rows[0]["twitterUrl"]);
                model.Linkedin = Convert.ToString(dt.Rows[0]["Linkedinurl"]);
                model.Phone = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                model.experience = Convert.ToString(dt.Rows[0]["Experience"]);
                model.age = Convert.ToString(dt.Rows[0]["Age"]);
                model.CurrentSalaryId = Convert.ToString(dt.Rows[0]["CurrentSalary"]);
                model.expectedSalaryId = Convert.ToString(dt.Rows[0]["expectedSalary"]);
                model.Educationlevels = Convert.ToString(dt.Rows[0]["Educationlevels"]);
                model.CityName = Convert.ToString(dt.Rows[0]["cityname"]);
                model.Relocation = Convert.ToString(dt.Rows[0]["Relocation"]);
                model.Certifications = Convert.ToString(dt.Rows[0]["Certifications"]);
                model.CountryId = "1";// Convert.ToString(dt.Rows[0]["CountryId"]);
                model.StateId = Convert.ToString(dt.Rows[0]["StateId"]);
                model.CityId = Convert.ToString(dt.Rows[0]["CityId"]);
                model.Zipcode = Convert.ToString(dt.Rows[0]["Zipcode"]);
                model.Educationlevels = Convert.ToString(dt.Rows[0]["Educationlevels"]);
                model.Featured = Convert.ToInt64(dt.Rows[0]["Featured"]);

            }
            model.experienceCollection = (from DataRow row in ds.Tables[1].Rows
                                          select new DropDownViewModel
                                          {
                                              Id = Convert.ToInt64(row["Id"]),
                                              Name = Convert.ToString(row["Name"])
                                          }).ToList();
            model.IndustryCollection = (from DataRow row in ds.Tables[2].Rows
                                        select new DropDownViewModel
                                        {
                                            Id = Convert.ToInt64(row["Id"]),
                                            Name = Convert.ToString(row["Name"])
                                        }).ToList();
            model.SalaryCollection = (from DataRow row in ds.Tables[3].Rows
                                      select new DropDownViewModel
                                      {
                                          Id = Convert.ToInt64(row["Id"]),
                                          Name = Convert.ToString(row["Name"])
                                      }).ToList();

            model.QualificationCollection = (from DataRow row in ds.Tables[4].Rows
                                             select new DropDownViewModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 Name = Convert.ToString(row["Name"])
                                             }).ToList();
            model.CountryCollection = (from DataRow row in ds.Tables[5].Rows
                                       select new DropDownViewModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Name = Convert.ToString(row["Name"])

                                       }).ToList();
            model.StateCollection = (from DataRow row in ds.Tables[6].Rows
                                     select new DropDownViewModel
                                     {
                                         Id = Convert.ToInt64(row["Id"]),
                                         Name = Convert.ToString(row["Name"])
                                     }).ToList();
            model.CityCollection = (from DataRow row in ds.Tables[7].Rows
                                    select new DropDownViewModel
                                    {
                                        Id = Convert.ToInt64(row["Id"]),
                                        Name = Convert.ToString(row["Name"])
                                    }).ToList();
            model.JobTypeCollection = (from DataRow row in ds.Tables[8].Rows
                                       select new DropDownViewModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Name = Convert.ToString(row["Name"])
                                       }).ToList();


        }
        internal void CreateCandidate(CandidateModel model, DataTable dt)
        {
            model.StatusId = Convert.ToInt64(dt.Rows[0]["StatusId"]);
            model.Id = Convert.ToInt64(dt.Rows[0]["CurrentId"]);
            if (dt.Rows[0]["StatusId"].ToString() == "2")
            {
                string Subject = "";
                model.StatusId = Convert.ToInt64(dt.Rows[0]["StatusId"]);
                model.Id = Convert.ToInt64(dt.Rows[0]["CurrentId"]);
                string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);
                if (model.AccountType == 3)
                {
                    Subject = "Welcome to MVP Talent.";
                }
                string body = string.Empty;
                using (StreamReader reader = new StreamReader(EmailTempletePath + "CandidateCreateEmail.html"))
                {
                    body = reader.ReadToEnd();
                }
                body = body.Replace("{{Name}}", model.Name + " " + model.LastName);
                body = body.Replace("{{Email}}", model.Email);
                body = body.Replace("{{Phone}}", model.Phone);
                body = body.Replace("{{Password}}", model.Password);
                body = body.Replace("{{Title}}", model.Title);
                body = body.Replace("{{id}}", Encrypt(Convert.ToString(dt.Rows[0]["CurrentId"])));
                sendEmail(Subject, body, model.Email);
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
        internal void Candidates(CandidateModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                var Password = dt.Rows[0]["Password"].ToString();
                var Salt = dt.Rows[0]["Salt"].ToString();
                var decreptPassword = Craptography.Decrypt(Password, Salt);

                //model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Phone = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                model.Title = Convert.ToString(dt.Rows[0]["Title"]);
                model.Password = decreptPassword;
            }
        }
        public void sendEmail(string Subject, string MsgBody, string ToMailAddress)
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


    }
}
