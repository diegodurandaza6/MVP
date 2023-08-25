using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;
using Web.Core.Common.Impl;


namespace Web.Core.Client.Impl
{

    public class ClientFactory
    {
        internal void ClientSendenquery(ClientModel model, DataTable dt)
        {
            

            if (dt.Rows.Count > 0)
            {
                model.Status = Convert.ToInt64(dt.Rows[0]["IsQueryExecute"]);

                if (model.Status == 1)
                {
                    string Subject = "";

                    string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);
                    string AdminEmail = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"]);

                    Subject = "REQUEST TO INTERVIEW";
                    string body = string.Empty;
                    using (StreamReader reader = new StreamReader(EmailTempletePath + "Clientenquiry.html"))
                    {
                        body = reader.ReadToEnd();
                    }
                    body = body.Replace("{{Name}}", model.Name);
                    body = body.Replace("{{Email}}", model.Email);
                    body = body.Replace("{{Phone}}", model.Phone1);

                    body = body.Replace("{{Message}}", model.Description);

                    sendEmail(Subject, body, AdminEmail);
                }

            } 
        }

        internal void AddSkills(JobsModel model, DataTable dt)
        {
            model.SkillCollection = (from DataRow row in dt.Rows
                                     select new DropDownViewModel
                                     {
                                         Id = Convert.ToInt64(row["Id"]),
                                         Name = Convert.ToString(row["Name"]),
                                     }).ToList();
        }

        internal void favoritecandidate(ClientModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Status = Convert.ToInt64(dt.Rows[0]["StatusId"]);
                if (model.Status == 2)
                {
                    model.Ids = Convert.ToString(ds.Tables[1].Rows[0]["guidid"]);
                }
            }
            
        }
        internal void AddTofavoritecandidate(ClientModel model, DataTable dt)
        {            
            if (dt.Rows.Count > 0)
            {
                model.Status = Convert.ToInt64(dt.Rows[0]["IsExist"]);               
            }

        }

        internal void conversation(Candidateconversationmodel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {

                model.Title = Convert.ToString(dt.Rows[0]["Title"]);
                model.location = Convert.ToString(dt.Rows[0]["Location"]);
                model.IndustryName = Convert.ToString(dt.Rows[0]["industryName"]);
                model.JobTypeName = Convert.ToString(dt.Rows[0]["TypeName"]);
                model.imageFile = Convert.ToString(dt.Rows[0]["ImageFile"]);

                model.DesiredTitle1 = Convert.ToString(dt.Rows[0]["DesiredTitle1"]);
                model.DesiredTitle2 = Convert.ToString(dt.Rows[0]["DesiredTitle2"]);
                model.MaxSalary = Convert.ToString(dt.Rows[0]["Salery"]);

                model.zipcode = Convert.ToString(dt.Rows[0]["zipcode"]);
                model.FirstName = Convert.ToString(dt.Rows[0]["Name"] + " " + Convert.ToString(dt.Rows[0]["LastName"]));
                model.FileUpload = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["ImageFile"].ToString());
            }

            model.candidateconversationcollection = (from DataRow row in ds.Tables[1].Rows
                                                     select new CandidateConversationEditModel
                                                     {
                                                         Description = Convert.ToString(row["Massege"]),
                                                         Name = Convert.ToString(row["FirstName"]) + " "+ Convert.ToString(row["LastName"]),
                                                         createddate = Convert.ToString(row["Createddate"]),
                                                         CreateBy = Convert.ToInt64(row["CreatedBy"] is DBNull ? 0 : Convert.ToInt64(row["CreatedBy"])),
                                                         ClientCandidateId = Convert.ToInt64(row["ClientCandidateId"] is DBNull ? 0 : Convert.ToInt64(row["ClientCandidateId"])),
                                                         imageFile = Convert.ToString(row["ImageFile"]),
                                                         FileName = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + row["ImageFile"].ToString())
                                                     }).ToList();


            if (ds.Tables[2].Rows.Count > 0)
            {
                model.JobTitle = ds.Tables[2].Rows[0]["JobTitle"].ToString();
                model.qualificationName = ds.Tables[2].Rows[0]["qualificationName"].ToString();
                model.JobTypeName = ds.Tables[2].Rows[0]["typeName"].ToString();
                model.DesignationName = ds.Tables[2].Rows[0]["DesignationName"].ToString();
                model.location = ds.Tables[2].Rows[0]["Location"].ToString();
                model.MinSalary = ds.Tables[2].Rows[0]["MinSalary"].ToString();
                model.MaxSalary = ds.Tables[2].Rows[0]["MaxSalary"].ToString();
                model.jobcategory = ds.Tables[2].Rows[0]["jobcategoryName"].ToString();
            }
        }

        internal void Pipelinemessageslist(ClientModel model, DataTable dt)
        {
            model.interviewListCollection = (from DataRow row in dt.Rows
                                             select new ClientModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 Ids = EncryptDecrypt.encrypt(Convert.ToString(row["Id"])),
                                                 CandidateId = Convert.ToInt64(row["CandidateId"]),
                                                 cids = EncryptDecrypt.encrypt(Convert.ToString(row["CandidateId"])),
                                                 JobId = Convert.ToInt64(row["JobId"]),
                                                 CreateBy = Convert.ToInt64(row["CreatedBy"]),
                                                 Name = Convert.ToString(row["Name"]) + " " + Convert.ToString(row["Lastname"]),
                                                 CreatedDate = Convert.ToDateTime(row["Updateddate"]).ToShortDateString(),
                                                 Title = Convert.ToString(row["JobTitle"]),
                                                 Unreadcount = Convert.ToInt64(row["Unreadcount"]),
                                             }).ToList();
            if (dt.Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
        }

        internal void CandidateNameAutoComplete(CandidateModel model, DataTable dt)
        {
            model.candidatelistcollection = (from DataRow row in dt.Rows
                                             select new DropDownViewModel
                                             {
                                                 Id = Convert.ToInt32(row["UserId"]),
                                                 Name = Convert.ToString(row["Name"]) + " (" + (Convert.ToString(row["Email"])) + ")"  ,
                                             }).ToList();
        }

        internal void ClientNameAutoComplete(CandidateModel model, DataTable dt)
        {
            model.CityCollection = (from DataRow row in dt.Rows
                                    select new DropDownViewModel
                                    {
                                        Id = Convert.ToInt32(row["UserId"]),
                                        Name = Convert.ToString(row["Name"]) + " (" + (Convert.ToString(row["Email"])) + ")" + " (" + (Convert.ToString(row["CompanyName"])) + ")",
                                    }).ToList();
        }

        internal void messagesdetails(ClientModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[2];
            if (dt.Rows.Count > 0)
            {
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
                                                         clientLogo = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + Convert.ToInt32(row["CreatedBy"]) + "/" + row["ImageFile"]),
                                                         //itle = Convert.ToString(row["sendquerytitle"]),
                                                     }).ToList();


            }
            if (dt1.Rows.Count > 0)
            {
                model.Title = Convert.ToString(dt1.Rows[0]["Title"]);
            }

            if (ds.Tables[3].Rows.Count > 0)
            {
                model.Name = ds.Tables[3].Rows[0]["Name"] is DBNull ? "" : ds.Tables[3].Rows[0]["Name"].ToString();
                model.LastName = ds.Tables[3].Rows[0]["LastName"] is DBNull ? "" : ds.Tables[3].Rows[0]["LastName"].ToString();
                model.Email = ds.Tables[3].Rows[0]["Email"] is DBNull ? "" : ds.Tables[3].Rows[0]["Email"].ToString();
                model.ClientPhone = ds.Tables[3].Rows[0]["PhoneNo"] is DBNull ? "" : ds.Tables[3].Rows[0]["PhoneNo"].ToString();
                model.Address = ds.Tables[3].Rows[0]["Address1"] is DBNull ? "" : ds.Tables[3].Rows[0]["Address1"].ToString();
                model.Location = ds.Tables[3].Rows[0]["Location"] is DBNull ? "" : ds.Tables[3].Rows[0]["Location"].ToString();
                model.Role = ds.Tables[3].Rows[0]["RoleName"] is DBNull ? "" : ds.Tables[3].Rows[0]["RoleName"].ToString();
            }


        }

        internal void getCandidateTitleList(CandidateModel model, DataSet ds)
        {


            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    ds.Tables[0].Merge(ds.Tables[1]);
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    ds.Tables[0].Merge(ds.Tables[2]);
                }
                 
                model.candidatetagvaluecollection = (from DataRow row in ds.Tables[0].Rows
                                                     select new DropDownViewModel
                                                     {
                                                         Id = Convert.ToInt64(row["UserId"] is DBNull ? 0 : row["UserId"]),
                                                         Name = Convert.ToString(row["Title"])
                                                     }).ToList();
            }




        }


        internal void jobtitleautocomplate(CandidateModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {                 
                model.candidatetagvaluecollection = (from DataRow row in dt.Rows
                                                     select new DropDownViewModel
                                                     {
                                                         Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : row["Id"]),
                                                         Name = Convert.ToString(row["Title"])
                                                     }).ToList();
            }

        }



        internal void messages(ClientModel model, DataTable dt)
        {
            model.clientsendenuerycollection = (from DataRow row in dt.Rows
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



                                                }).ToList();
            if (dt.Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
        }

        internal void ClientenquireyList(ClientModel model, DataTable dt)
        {
            model.clientsendenuerycollection = (from DataRow row in dt.Rows
                                                select new ClientModel
                                                {
                                                    Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                    Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString())),
                                                    ClientId = Convert.ToInt64(row["ClientId"]),
                                                    Name = Convert.ToString(row["Name"]),
                                                    Email = Convert.ToString(row["Email"]),
                                                    Jobtitle = Convert.ToString(row["JobTitle"]),
                                                    JobTypeId = Convert.ToString(row["jobtype"]),
                                                    cids = Convert.ToString(EncryptDecrypt.encrypt(row["UserId"].ToString())),
                                                    Industry = Convert.ToString(row["industryName"]),
                                                    JobType = Convert.ToString(row["jobtypeName"]),
                                                    Phone1 = Convert.ToString(row["Phone"]),
                                                    Description = Convert.ToString(row["Description"]),
                                                    FileName = Convert.ToString(row["fileName"]),
                                                    CandidateName = Convert.ToString(row["CandidateName"]) + " " + Convert.ToString(row["LastName"]),
                                                    FilePath = "/" + "FileUpload/Interviewrequest" + "/" + Convert.ToInt64(row["ClientId"]) + "/" + Convert.ToString(row["fileName"]),
                                                    conversationcount = Convert.ToInt64(row["viewcount"] is DBNull ? 0 : Convert.ToInt64(row["viewcount"])),
                                                    Unreadcount = Convert.ToInt64(row["Unreadcount"] is DBNull ? 0 : Convert.ToInt64(row["Unreadcount"])),
                                                    Title = Convert.ToString(row["CandidateTitle"]),
                                                    Location = Convert.ToString(row["Location"]),
                                                }).ToList();
            if (dt.Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }

        }

        internal void JobDetailById(JobsModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.ClientId = Convert.ToInt64(dt.Rows[0]["ClientId"]);
                model.jobtitle = Convert.ToString(dt.Rows[0]["JobTitle"]);
                model.location = Convert.ToString(dt.Rows[0]["Location"]);
                model.JobTypeId = Convert.ToInt64(dt.Rows[0]["JobTypeId"]);
                model.JobCategoryId = Convert.ToInt64(dt.Rows[0]["CategoryId"]);
                model.JobStatusId = Convert.ToInt64(dt.Rows[0]["JobStatusId"]);
                model.CountryId = Convert.ToInt64(dt.Rows[0]["CountryId"]);
                model.StateId = Convert.ToInt64(dt.Rows[0]["StateId"]);
                model.City = Convert.ToString(dt.Rows[0]["City"]);
                model.MinSalary = Convert.ToString(dt.Rows[0]["MinSalary"]);
                model.MaxSalary = Convert.ToString(dt.Rows[0]["MaxSalary"]);
                model.JobDescription = Convert.ToString(dt.Rows[0]["Desription"]);
                model.WorkExperienceMin = Convert.ToString(dt.Rows[0]["MinExeperience"]);
                model.WorkExperienceMax = Convert.ToString(dt.Rows[0]["MaxExeperience"]);
                model.QualificationId = Convert.ToInt64(dt.Rows[0]["Qualification"]);
                model.qualificationName = Convert.ToString(dt.Rows[0]["qualificationName"]);
                model.JobTypeName = Convert.ToString(dt.Rows[0]["typeName"]);
                model.KeySkills = Convert.ToString(dt.Rows[0]["Keyskills"]);
                model.Designation = Convert.ToString(dt.Rows[0]["Designation"]);
                model.sortdescription = Convert.ToString(dt.Rows[0]["sortdescription"]);

                model.DesignationName = Convert.ToString(dt.Rows[0]["Designation"]);
                model.CompanyName = Convert.ToString(dt.Rows[0]["CompanyName1"]);
                model.JobCategoryName = Convert.ToString(dt.Rows[0]["jobcategoryName"]);
                model.website = Convert.ToString(dt.Rows[0]["Website"]);
               
                model.createddate = Convert.ToString(dt.Rows[0]["CreatedDate"] is DBNull ? "" : Convert.ToDateTime(dt.Rows[0]["CreatedDate"]).ToString("MMM , dd yyyy"));
                model.Address = Convert.ToString(dt.Rows[0]["Address1"]);
                 model.zipcode= Convert.ToString(dt.Rows[0]["zipcode"]);
                model.Mobile = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                model.JobStatusName = Convert.ToString(dt.Rows[0]["StatusName"]);
                model.ClientId = Convert.ToInt64(dt.Rows[0]["ClientId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["ClientId"]));
                //model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + Convert.ToInt32(dt.Rows[0]["ClientId"]) + "/" + dt.Rows[0]["ImageFile"]);
                
                //model.applyedStatus = Convert.ToInt64(dt.Rows[0]["applyedStatusId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["applyedStatusId"]));
                model.SavedStatus = Convert.ToInt64(dt.Rows[0]["SavedJobStatusId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["SavedJobStatusId"]));
                model.viewcount = Convert.ToInt64(dt.Rows[0]["ViewCount"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["ViewCount"]));
                model.SubCategoryName = Convert.ToString(dt.Rows[0]["SubCategoryName"] is DBNull ? "" : dt.Rows[0]["SubCategoryName"]);
                model.PositionLevelName = Convert.ToString(dt.Rows[0]["PositionLevelName"] is DBNull ? "" : dt.Rows[0]["PositionLevelName"]);
                model.ClientName = Convert.ToString(dt.Rows[0]["NameOfClient"]);


                if (model.ClientId > 0)
                {
                    model.FileName = Convert.ToString(dt.Rows[0]["CompanyImage"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/" + "FileUpload" + "/" + "/" + "CompanyImage" + "/" + Convert.ToInt64(dt.Rows[0]["CompanyId"]) + "/" + dt.Rows[0]["CompanyImage"].ToString());

                }
                else
                {
                    model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/" + "FileUpload" + "/" + "/" + "CandidateImage" + "/" + 1 + "/" + dt.Rows[0]["ImageFile"].ToString());

                } 

                TimeSpan difference = Convert.ToDateTime(DateTime.Now) - Convert.ToDateTime(dt.Rows[0]["CreatedDate"]);
                if (difference.Days == 0)
                {
                    model.Dayscount = "Today";
                }
                else
                {
                    model.Dayscount = difference.Days + " Days Ago";
                }



                model.SkillCollection = (from DataRow row in ds.Tables[1].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             Name = Convert.ToString(row["Name"]),
                                         }).ToList();

                model.applyedCount = Convert.ToString(ds.Tables[2].Rows[0]["applicantcount"]);

                model.SimilarJobscollection = (from DataRow row in ds.Tables[3].Rows
                                               select new JobsModel
                                               {
                                                   Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                   ClientId = Convert.ToInt64(row["ClientId"] is DBNull ? 0 : Convert.ToInt64(row["ClientId"])),
                                                   jobtitle = Convert.ToString(row["JobTitle"]),
                                                   MaxSalary = Convert.ToString(row["MaxSalary"]),
                                                   MinSalary = Convert.ToString(row["MinSalary"]),
                                                   location = Convert.ToString(row["Location"]),
                                                   Designation = Convert.ToString(row["Designation"]),
                                                   Jobtype = Convert.ToString(row["typeName"]),
                                                   FilePath = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + Convert.ToInt32(row["ClientId"]) + "/" + row["ImageFile"])
                                               }).ToList();
            }

            model.tagcollection = (from DataRow row in ds.Tables[4].Rows
                                   select new DropDownViewModel
                                   {
                                       Id = Convert.ToInt64(row["Id"]),
                                       Name = Convert.ToString(row["Name"]),
                                   }).ToList();


            if (ds.Tables[5].Rows.Count > 0)
            {
                model.applyedStatus = 1;
            }
            else
            {

                if (ds.Tables[7].Rows.Count > 0)
                {
                    model.applyedStatus = 1;
                }
                else
                {
                    model.applyedStatus = 0;
                }

                
            }

            if (ds.Tables[6].Rows.Count > 0)
            {
                model.requestmoreinfo = 1;
            }
            else
            {
                model.requestmoreinfo = 0;
            }
        }

        internal void Clientnotepopup(CandidateModel model, DataTable dt)
        {
            model.Clientnotecollection = (from DataRow row in dt.Rows
                                          select new CandidateModel
                                          {

                                              Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                              CandidateId = Convert.ToInt64(row["CandidateId"] is DBNull ? 0 : Convert.ToInt64(row["CandidateId"])),
                                              ClientName = Convert.ToString(row["Note"]),
                                              createddate = Convert.ToDateTime(row["Createdate"]).ToShortDateString(),
                                              Name = Convert.ToString(row["Name"]) + ' ' + Convert.ToString(row["LastName"]),
                                              ClientFName = Convert.ToString(row["clientFName"]) + ' ' + Convert.ToString(row["clientLName"]),
                                              jobtitle = Convert.ToString(row["JobTitle"]),
                                              JobId = Convert.ToInt64(row["JobId"] is DBNull ? 0 : Convert.ToInt64(row["JobId"])),
                                          }).ToList();
        }

        internal void mycandidate(CandidateModel model, DataTable dt)
        {
            model.mycandidatecollection = (from DataRow row in dt.Rows
                                           select new CandidateModel


                                           {
                                               Id = Convert.ToInt64(row["applyjobId"] is DBNull ? 0 : Convert.ToInt64(row["applyjobId"])),
                                               JobId = Convert.ToInt64(row["applyjobJobId"] is DBNull ? 0 : Convert.ToInt64(row["applyjobJobId"])),

                                               Name = Convert.ToString(row["Name"] + " " + Convert.ToString(row["LastName"])),
                                               DesiredTitle1 = Convert.ToString(row["DesiredTitle1"]),
                                               DesiredTitle2 = Convert.ToString(row["DesiredTitle2"]),
                                               JobType = Convert.ToString(row["typeName"]),
                                               experience = Convert.ToString(row["experienceName"]),
                                               Education = Convert.ToString(row["educationName"]),
                                               IndustryName = Convert.ToString(row["IndustryName"]),
                                               location = Convert.ToString(row["Location"]),
                                               Zipcode = Convert.ToString(row["Zipcode"]),
                                               InterviewSId = Convert.ToInt64(row["InterviewStatusId"] is DBNull ? 0 : Convert.ToInt64(row["InterviewStatusId"])),
                                               salaryname = Convert.ToString(row["salaryName"]),
                                               CandidateId = Convert.ToInt64(row["CandidateId"] is DBNull ? 0 : Convert.ToInt64(row["CandidateId"])),
                                               UserId = Convert.ToInt64(row["UserId"] is DBNull ? 0 : Convert.ToInt64(row["UserId"])),
                                               Ids = Convert.ToString(EncryptDecrypt.encrypt(row["UserId"].ToString())),
                                               FileName = Convert.ToString(row["ImageFile"]),
                                               FileUpload = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + row["ImageFile"].ToString()),
                                           }).ToList();

            if (dt.Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(dt.Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
        }

        internal void deleteJobtags(JobsModel model, DataTable dt)
        {
            throw new NotImplementedException();
        }

        internal void AddTags(JobsModel model, DataTable dt)
        {
            model.tagcollection = (from DataRow row in dt.Rows
                                   select new DropDownViewModel
                                   {
                                       Id = Convert.ToInt64(row["Id"]),
                                       Name = Convert.ToString(row["Name"]),

                                   }).ToList();
        }

        internal void Tagsautocomplete(CandidateModel model, DataTable dt)
        {
            model.tagscollection = (from DataRow row in dt.Rows
                                    select new CandidateModel
                                    {
                                        //Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                        tags = Convert.ToString(row["Name"]),
                                    }).ToList();
        }

        internal void JobDetail(JobsModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(dt.Rows[0]["Id"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["Id"]));
                model.ClientId = Convert.ToInt64(dt.Rows[0]["ClientId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["ClientId"]));
                model.jobtitle = Convert.ToString(dt.Rows[0]["JobTitle"]);
                model.zipcode = Convert.ToString(dt.Rows[0]["zipcode"]);
                model.location = Convert.ToString(dt.Rows[0]["AddressOfCompany"]);
                model.JobTypeId = Convert.ToInt64(dt.Rows[0]["JobTypeId"]);
                model.JobCategoryId = Convert.ToInt64(dt.Rows[0]["CategoryId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["CategoryId"]));
                model.JobStatusId = Convert.ToInt64(dt.Rows[0]["JobStatusId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["JobStatusId"]));
                model.CountryId = Convert.ToInt64(dt.Rows[0]["CountryId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["CountryId"]));
                model.StateId = Convert.ToInt64(dt.Rows[0]["StateId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["StateId"]));
                
                model.ClientName = Convert.ToString(dt.Rows[0]["ClientName"]) + ' ' + Convert.ToString(dt.Rows[0]["ClientLastName"]);
                model.MinSalary = Convert.ToString(dt.Rows[0]["MinSalary"]);
                model.MaxSalary = Convert.ToString(dt.Rows[0]["MaxSalary"]);
                model.JobDescription = Convert.ToString(dt.Rows[0]["Desription"]);
                model.WorkExperienceMin = Convert.ToString(dt.Rows[0]["MinExeperience"]);
                model.WorkExperienceMax = Convert.ToString(dt.Rows[0]["MaxExeperience"]);
                model.QualificationId = Convert.ToInt64(dt.Rows[0]["Qualification"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["Qualification"]));
                model.qualificationName = Convert.ToString(dt.Rows[0]["qualificationName"]);
                model.JobTypeName = Convert.ToString(dt.Rows[0]["typeName"]);
                model.KeySkills = Convert.ToString(dt.Rows[0]["Keyskills"]);
                model.createddate = Convert.ToString(dt.Rows[0]["CreatedDate"]);
                model.Designation = Convert.ToString(dt.Rows[0]["Designation"]);
               
                model.DesignationName = Convert.ToString(dt.Rows[0]["Designation"]);
                model.CompanyName = Convert.ToString(dt.Rows[0]["NameOfCompany"]);
                model.JobCategoryName = Convert.ToString(dt.Rows[0]["jobcategoryName"]);
                model.website = Convert.ToString(dt.Rows[0]["WebOfCompany"]);
                
                model.createddate = Convert.ToString(dt.Rows[0]["CreatedDate"] is DBNull ? "" : Convert.ToDateTime(dt.Rows[0]["CreatedDate"]).ToString("MMM , dd yyyy"));
                model.Address = Convert.ToString(dt.Rows[0]["Address1"]);
                
                model.Mobile = Convert.ToString(dt.Rows[0]["PhoneNo"]);
                model.JobStatusName = Convert.ToString(dt.Rows[0]["StatusName"]);
                model.FileName = Convert.ToString(dt.Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + Convert.ToInt32(dt.Rows[0]["ClientId"]) + "/" + dt.Rows[0]["ImageFile"]);
                model.applyedStatus = Convert.ToInt64(dt.Rows[0]["applyedStatusId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["applyedStatusId"]));
                model.SavedStatus = Convert.ToInt64(dt.Rows[0]["SavedJobStatusId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["SavedJobStatusId"]));
                model.viewcount = Convert.ToInt64(dt.Rows[0]["ViewCount"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["ViewCount"]));
                model.JobPostStatus = Convert.ToInt64(dt.Rows[0]["JobPostStatus"]);
                model.SubCategoryName = Convert.ToString(dt.Rows[0]["SubCategoryName"] is DBNull ? "" : Convert.ToString(dt.Rows[0]["SubCategoryName"]));
                model.sortdescription = Convert.ToString(dt.Rows[0]["sortdescription"] is DBNull ? "" : Convert.ToString(dt.Rows[0]["sortdescription"]));
                model.JobLocation = Convert.ToString(dt.Rows[0]["Location"]);
                model.PositionLevelName = Convert.ToString(dt.Rows[0]["PositionLevelName"] is DBNull ? "" : dt.Rows[0]["PositionLevelName"]);



                model.PostedBy = Convert.ToString(dt.Rows[0]["PostedBy"] is DBNull ? "" : Convert.ToString(dt.Rows[0]["PostedBy"]));
                model.SkillCollection = (from DataRow row in ds.Tables[1].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"]),
                                             Name = Convert.ToString(row["Name"]),
                                         }).ToList();


                model.tagcollection = (from DataRow row in ds.Tables[6].Rows
                                       select new DropDownViewModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Name = Convert.ToString(row["Name"]),
                                       }).ToList();

                model.applyedCount = Convert.ToString(ds.Tables[2].Rows[0]["applicantcount"]);

                model.Jobsuploadresumecollection = (from DataRow row in ds.Tables[3].Rows
                                                    select new JobsModel
                                                    {
                                                        Id = Convert.ToInt64(row["Id"]),
                                                        UserId = Convert.ToInt64(row["UserId"]),
                                                        Ids = Convert.ToString(EncryptDecrypt.encrypt(row["UserId"].ToString())),
                                                        JobId = Convert.ToInt64(row["JobId"]),
                                                        Name = Convert.ToString(row["Name"] + " " + Convert.ToString(row["LastName"])),
                                                        Phone = Convert.ToString(row["PhoneNo"]),
                                                        createddate = Convert.ToDateTime(row["jobcreated"]).ToShortDateString(),
                                                        FileName = Convert.ToString(row["ResumeFile"]),
                                                        FilePath = "/" + "FileUpload/CandidateResume" + "/" + Convert.ToString(row["UserId"]) + "/" + Convert.ToString(row["ResumeFile"]),
                                                        Email = Convert.ToString(row["Email"]),
                                                        qualificationName = Convert.ToString(row["qulificationname"]),
                                                        jobtitle = Convert.ToString(row["JobTitle"]),
                                                    }).ToList();



            }
            model.applicantlistcollection = (from DataRow row in ds.Tables[4].Rows
                                             select new JobsModel
                                             {

                                                 Name = Convert.ToString(row["Name"] + " " + Convert.ToString(row["LastName"])),
                                                 Email = Convert.ToString(row["Email"]),
                                                 ClientName = Convert.ToString(row["clientName"] + " " + Convert.ToString(row["clientLastname"])),
                                                 StateName = Convert.ToString(row["statusname"]),
                                                 CandidateId = Convert.ToInt64(row["candidateId"] is DBNull ? 0 : Convert.ToInt64(row["candidateId"])),
                                                 Ids = Convert.ToString(EncryptDecrypt.encrypt(row["CandidateId"].ToString())),
                                                 JobId = Convert.ToInt64(row["JobId"] is DBNull ? 0 : Convert.ToInt64(row["JobId"])),
                                             }).ToList();

            model.interviewlistcollection = (from DataRow row in ds.Tables[5].Rows
                                             select new JobsModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                 Name = Convert.ToString(row["CandidateName"]),
                                                 Email = Convert.ToString(row["CandidateEmail"]),
                                                 ClientName = Convert.ToString(row["ClientName"]),
                                                 StateName = Convert.ToString(row["ClientEmail"]),
                                                 createddate = Convert.ToString(row["Interviewdate"] is DBNull ? "" : row["Interviewdate"] + " " + row["InterviewTime"]),
                                                 location = Convert.ToString(row["Location"]),
                                                 CandidateId = Convert.ToInt64(row["candidateId"] is DBNull ? 0 : Convert.ToInt64(row["candidateId"])),
                                                 ClientId = Convert.ToInt64(row["ClientId"] is DBNull ? 0 : Convert.ToInt64(row["ClientId"])),
                                                 JobId = Convert.ToInt64(row["JobId"] is DBNull ? 0 : Convert.ToInt64(row["JobId"])),
                                             }).ToList();
            model.applicantlistviewcollection = (from DataRow row in ds.Tables[7].Rows
                                                 select new JobsModel
                                                 {
                                                     Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                     UserId = Convert.ToInt64(row["UserId"] is DBNull ? 0 : Convert.ToInt64(row["UserId"])),
                                                     Ids = Convert.ToString(EncryptDecrypt.encrypt(row["UserId"].ToString())),
                                                     InterviewStatusId = Convert.ToInt64(row["InterviewStatusId"] is DBNull ? 0 : Convert.ToInt64(row["InterviewStatusId"])),
                                                     CandidateId = Convert.ToInt64(row["CandidateId"] is DBNull ? 0 : Convert.ToInt64(row["CandidateId"])),

                                                     JobId = Convert.ToInt64(row["JobId"] is DBNull ? 0 : Convert.ToInt64(row["JobId"])),


                                                     Name = Convert.ToString(row["Name"] + " " + Convert.ToString(row["LastName"])),
                                                     Phone = Convert.ToString(row["PhoneNo"]),
                                                     //createddate = Convert.ToDateTime(row["jobcreated"]).ToShortDateString(),
                                                     accounttype = Convert.ToInt64(row["AccountTypeId"] is DBNull ? 0 : Convert.ToInt64(row["AccountTypeId"])),
                                                     Email = Convert.ToString(row["Email"]),
                                                     interviewStatus = Convert.ToString(row["interviewstatusname"]),

                                                 }).ToList();


            if (ds.Tables[8].Rows.Count > 0)
            { 
                model.CompanyName = ds.Tables[8].Rows[0]["name"].ToString();
                model.location = ds.Tables[8].Rows[0]["Location"].ToString();
                model.website = ds.Tables[8].Rows[0]["Website"].ToString();
            }


        }

        internal void SharedJobCount(JobsModel model, DataTable dt)
        {
            model.Jobsuploadresumecollection = (from DataRow row in dt.Rows
                                                select new JobsModel
                                                {
                                                    Id = Convert.ToInt64(row["Id"]),
                                                    UserId = Convert.ToInt64(row["UserId"]),
                                                    Ids = Convert.ToString(EncryptDecrypt.encrypt(row["UserId"].ToString())),
                                                    JobId = Convert.ToInt64(row["JobId"]),
                                                    Name = Convert.ToString(row["Name"] + " " + Convert.ToString(row["LastName"])),
                                                    Phone = Convert.ToString(row["PhoneNo"]),
                                                    createddate = Convert.ToDateTime(row["jobcreated"]).ToShortDateString(),
                                                    FileName = Convert.ToString(row["ResumeFile"]),
                                                    FilePath = "/" + "FileUpload/CandidateResume" + "/" + Convert.ToString(row["JobId"]) + "/" + Convert.ToString(row["ResumeFile"]),
                                                    Email = Convert.ToString(row["Email"]),
                                                    qualificationName = Convert.ToString(row["qulificationname"]),
                                                    jobtitle = Convert.ToString(row["JobTitle"]),
                                                }).ToList();
        }

        internal void dashboard(ClientModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.jobCount = Convert.ToInt64(ds.Tables[0].Rows.Count);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.applyjobCount = Convert.ToInt64(ds.Tables[1].Rows.Count);
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                model.favoritecandidateCount = Convert.ToInt64(ds.Tables[2].Rows.Count);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                model.sendenqueryCount = Convert.ToInt64(ds.Tables[3].Rows.Count);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                model.noofjob = Convert.ToInt64(ds.Tables[4].Rows[0]["noofjob"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[4].Rows[0]["noofjob"]));
                //model.noofinterview = Convert.ToInt64(ds.Tables[4].Rows[0]["noofinterview"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[4].Rows[0]["noofinterview"]));
                model.jobleft = Convert.ToInt64(ds.Tables[4].Rows[0]["leftjob"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[4].Rows[0]["leftjob"]));
                model.leftinterview = Convert.ToInt64(ds.Tables[4].Rows[0]["leftinterview"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[4].Rows[0]["leftinterview"]));
                model.noofsubmission = Convert.ToInt64(ds.Tables[4].Rows[0]["leftsubmission"] is DBNull ? 0 : Convert.ToInt64(ds.Tables[4].Rows[0]["leftsubmission"]));
                model.ValidPlanDate = Convert.ToDateTime(ds.Tables[4].Rows[0]["ValidPlanDate"]).ToShortDateString();
            }
            if (ds.Tables[6].Rows.Count > 0)
            {
                model.noofinterview = ds.Tables[6].Rows.Count;
            }
            model.joblistcollection = (from DataRow row in ds.Tables[5].Rows
                                       select new ClientModel
                                       {
                                           Id = Convert.ToInt64(row["Id"]),
                                           Ids = EncryptDecrypt.encrypt(row["Id"].ToString()),
                                           Title = Convert.ToString(row["JobTitle"]),
                                           Description = Convert.ToString(row["Desription"]),
                                           sortdescription = Convert.ToString(row["sortdescription"]),

                                           jobStatus = Convert.ToInt64(row["JobStatusId"]),
                                           JSs = EncryptDecrypt.encrypt(row["JobStatusId"].ToString()),
                                           JobType = Convert.ToString(row["typeName"]),

                                           Location = Convert.ToString(row["Location"]),
                                           CreatedDate = Convert.ToDateTime(row["CreatedDate"]).ToShortDateString(),
                                           MinSalary = Convert.ToString(row["MinSalary"]),
                                           MaxSalary = Convert.ToString(row["MaxSalary"]),
                                           viewcount = Convert.ToInt64(row["ViewCount"] is DBNull ? 0 : Convert.ToInt64(row["ViewCount"])),
                                           applicantcount = Convert.ToInt64(row["applicantcount"] is DBNull ? 0 : Convert.ToInt64(row["applicantcount"])),
                                           NewCandidatecount = Convert.ToInt64(row["NewCandidatecount"] is DBNull ? 0 : Convert.ToInt64(row["NewCandidatecount"])),
                                           Notecount = Convert.ToInt64(row["Notecount"] is DBNull ? 0 : Convert.ToInt64(row["Notecount"])),
                                           Interviewcount = Convert.ToInt64(row["Interviewcount"] is DBNull ? 0 : Convert.ToInt64(row["Interviewcount"])),
                                           pipelinemessagecount = Convert.ToInt64(row["Cmessagescount"])
                                       }).ToList();

            model.interviewListCollection = (from DataRow row in ds.Tables[7].Rows

                                             select new ClientModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 ClientId = Convert.ToInt64(row["ClientId"]),
                                                 Title = Convert.ToString(row["tilte"]),
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
                                                 CreateBy = Convert.ToInt64(row["CreateBy"] is DBNull ? 0 : Convert.ToInt64(row["CreateBy"]))
                                             }).ToList();
        }

        internal void Applicant(CandidateModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.CandidateCollection = (from DataRow row in ds.Tables[0].Rows
                                             select new CandidateModel
                                             {
                                                 Id = Convert.ToInt64(row["applyjobId"]),
                                                 SubmitedByAdmin = Convert.ToInt64(row["SubmitedByAdmin"]),
                                                 CandidateId = Convert.ToInt64(row["CandidateId"]),
                                                 JobId = Convert.ToInt64(row["applyjobJobId"]),
                                                 JIds = Convert.ToString(EncryptDecrypt.encrypt(row["applyjobJobId"].ToString())),
                                                 Ids = Convert.ToString(EncryptDecrypt.encrypt(row["Id"].ToString())),
                                                 UserId = Convert.ToInt64(row["Id"]),
                                                 Name = Convert.ToString(row["Name"]) + " " + Convert.ToString(row["LastName"]),
                                                 //CandidateId = Convert.ToInt64(row["Id"]),
                                                 Title = Convert.ToString(row["Title"]),
                                                 Phone = Convert.ToString(row["PhoneNo"]),
                                                 Email = Convert.ToString(row["Email"]),

                                                 educationlevel = Convert.ToString(row["educationlevelsName"]),
                                                 experience = Convert.ToString(row["CandidateExperience"]),

                                                 //CountryName = Convert.ToString(row["countryName"]),
                                                 //StateName = Convert.ToString(row["StateName"]),
                                                 //CityName = Convert.ToString(row["cityName"]),

                                                 JobType = Convert.ToString(row["CandidateJobType"]),
                                                 CurrentSalary = Convert.ToString(row["CurrentSalery"]),
                                                 IndustryName = Convert.ToString(row["Candidateindustry"]),
                                                 location = Convert.ToString(row["Location"]),
                                                 Zipcode = Convert.ToString(row["Zipcode"]),
                                                 applyjobId = Convert.ToInt64(row["applyjobId"]),
                                                 applicanttypeId = Convert.ToInt64(row["applicanttypeId"] is DBNull ? 0 : Convert.ToInt64(row["applicanttypeId"])),
                                                 //GuestId = Convert.ToInt64(row["GuestId"]),
                                                 InterviewSId = Convert.ToInt64(row["InterviewStatusId"] is DBNull ? 0 : Convert.ToInt64(row["InterviewStatusId"])),
                                                 sharedjobapplyId = Convert.ToInt64(row["sharedjobapplyId"] is DBNull ? 0 : Convert.ToInt64(row["sharedjobapplyId"])),
                                                 FileName = Convert.ToString(row["ImageFile"]),


                                                 imageFile = Convert.ToString(row["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + row["ImageFile"].ToString()),

                                             }).ToList();
            }
            model.JobCollection = (from DataRow row in ds.Tables[1].Rows
                                   select new DropDownViewModel
                                   {
                                       Id = Convert.ToInt64(row["Id"]),
                                       Ids = EncryptDecrypt.encrypt(row["Id"].ToString()),
                                       Name = Convert.ToString(row["JobTitle"]),
                                       Location = Convert.ToString(row["Location"])

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
                                             Ids = EncryptDecrypt.encrypt(row["Id"].ToString()),
                                             Name = Convert.ToString(row["Name"])
                                         }).ToList();
            if (ds.Tables[3].Rows.Count > 0)
            {
                model.pipelinemessagecount = Convert.ToInt64(ds.Tables[3].Rows.Count);
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                model.Title = model.Title = Convert.ToString(ds.Tables[4].Rows[0]["JobTitle"]) + " " + ds.Tables[4].Rows[0]["Location"];
            }
        }

        public string sharedapplyId(string sharedJob)
        {
            string name = "";
            if (sharedJob == "1")
            {
                name = "(Shared)";
            }
            return name;
        }

        internal void JobList(JobsModel model, DataSet ds)
        {
            model.JobListCollection = (from DataRow row in ds.Tables[0].Rows
                                       select new JobsModel
                                       {

                                           Id = Convert.ToInt64(row["Id"]),
                                           Ids = EncryptDecrypt.encrypt(row["Id"].ToString()),

                                           jobtitle = Convert.ToString(row["JobTitle"]),
                                           description = Convert.ToString(row["Desription"]),
                                           sortdescription = Convert.ToString(row["sortdescription"]),
                                           JobStatusId = Convert.ToInt64(row["JobStatusId"]),
                                           JSs = EncryptDecrypt.encrypt(row["JobStatusId"].ToString()),

                                           JobTypeName = Convert.ToString(row["typeName"]),
                                           JobStatusName = Convert.ToString(row["StatusName"]),
                                           City = Convert.ToString(row["StatusName"]),
                                           WorkExperienceMax = Convert.ToString(row["MaxExeperience"]),
                                           qualificationName = Convert.ToString(row["qualificationName"]),
                                           JobCategoryName = Convert.ToString(row["categoryName"]),
                                           createddate = Convert.ToDateTime(row["CreatedDate"]).ToShortDateString(),
                                           JobPostStatus = Convert.ToInt64(row["JobPostStatus"]),
                                           location = Convert.ToString(row["Location"]),
                                           MinSalary = Convert.ToString(row["MinSalary"]),
                                           MaxSalary = Convert.ToString(row["MaxSalary"]),
                                           viewcount = Convert.ToInt64(row["ViewCount"] is DBNull ? 0 : Convert.ToInt64(row["ViewCount"])),

                                           ClientName = Convert.ToString(row["ClientName"] is DBNull ? "" : Convert.ToString(row["ClientName"])),
                                           applicantcount = Convert.ToInt64(row["applicantcount"] is DBNull ? 0 : Convert.ToInt64(row["applicantcount"])),
                                           NewCandidatecount = Convert.ToInt64(row["NewCandidatecount"] is DBNull ? 0 : Convert.ToInt64(row["NewCandidatecount"])),
                                           Interviewcount = Convert.ToInt64(row["Interviewcount"] is DBNull ? 0 : Convert.ToInt64(row["Interviewcount"])),
                                           pipelinemessagecount = Convert.ToInt64(row["Cmessagescount"]),
                                           ClientId = Convert.ToInt64(row["ClientId"]),
                                           ClientName_Admin = Convert.ToString(row["ClientName_Admin"]),
                                           zipcode = Convert.ToString(row["zipcode"]),

                                       }).ToList();
            model.JobStatusCollection = (from DataRow row in ds.Tables[1].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                             Name = Convert.ToString(row["Name"])

                                         }).ToList();

            model.JobTypeCollection = (from DataRow row in ds.Tables[2].Rows
                                       select new DropDownViewModel
                                       {
                                           Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                           Name = Convert.ToString(row["Name"])

                                       }).ToList();

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.TotalRowCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRowCount"]);
                double pageCount = (double)((decimal)model.TotalRowCount / Convert.ToDecimal(model.maxRows));
                model.PageCount = (int)Math.Ceiling(pageCount);
                model.indexlegth = model.PageCount - Convert.ToInt32(model.CurrentPageIndex);
            }
        }

        internal void Jobs(JobsModel model, DataSet ds)
        {
            model.JobTypeCollection = (from DataRow row in ds.Tables[0].Rows
                                       select new DropDownViewModel
                                       {
                                           Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                           Name = Convert.ToString(row["Name"])

                                       }).ToList();
            model.JobCategoryCollection = (from DataRow row in ds.Tables[1].Rows
                                           select new DropDownViewModel
                                           {
                                               Id = Convert.ToInt64(row["Jid"] is DBNull ? 0 : Convert.ToInt64(row["Jid"])),
                                               Name = Convert.ToString(row["Name"])

                                           }).ToList();
            model.JobDeginationCollection = (from DataRow row in ds.Tables[2].Rows
                                             select new DropDownViewModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                 Name = Convert.ToString(row["Name"])

                                             }).ToList();
            model.JobStatusCollection = (from DataRow row in ds.Tables[3].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                             Name = Convert.ToString(row["Name"])

                                         }).ToList();
            model.JobQualficationCollection = (from DataRow row in ds.Tables[4].Rows
                                               select new JobsModel
                                               {
                                                   Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                   Name = Convert.ToString(row["Name"]),
                                                   //ParentId = Convert.ToInt64(row["ParentId"] is DBNull ? 0 : Convert.ToInt64(row["ParentId"]))

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


            model.SkillCollection = (from DataRow row in ds.Tables[11].Rows
                                     select new DropDownViewModel
                                     {
                                         Id = Convert.ToInt64(row["Id"]),
                                         Name = Convert.ToString(row["Name"])
                                     }).ToList();

            model.tagcollection = (from DataRow row in ds.Tables[13].Rows
                                   select new DropDownViewModel
                                   {
                                       Id = Convert.ToInt64(row["Id"]),
                                       Name = Convert.ToString(row["Name"])
                                   }).ToList();

            DataTable dt = ds.Tables[8];
            if (dt.Rows.Count > 0)
            {

                model.Id = Convert.ToInt64(dt.Rows[0]["Id"]);
                model.jobtitle = Convert.ToString(dt.Rows[0]["JobTitle"]);
                model.sortdescription = Convert.ToString(dt.Rows[0]["sortdescription"]);
                model.zipcode = Convert.ToString(dt.Rows[0]["zipcode"]);
                model.location = Convert.ToString(dt.Rows[0]["Location"]);
                model.JobTypeId = Convert.ToInt64(dt.Rows[0]["JobTypeId"]);
                model.JobCategoryId = Convert.ToInt64(dt.Rows[0]["CategoryId"]);
                model.JobStatusId = Convert.ToInt64(dt.Rows[0]["JobStatusId"]);
                model.CountryId = 1;// Convert.ToInt64(dt.Rows[0]["CountryId"]);
                model.StateId = Convert.ToInt64(dt.Rows[0]["StateId"]);
                model.City = Convert.ToString(dt.Rows[0]["CityName"]);
                model.MinSalary = Convert.ToString(dt.Rows[0]["MinSalary"]);
                model.MaxSalary = Convert.ToString(dt.Rows[0]["MaxSalary"]);
                model.JobDescription = Convert.ToString(dt.Rows[0]["Desription"]);
                model.WorkExperienceMin = Convert.ToString(dt.Rows[0]["MinExeperience"]);
                model.WorkExperienceMax = Convert.ToString(dt.Rows[0]["MaxExeperience"]);
                model.QualificationId = Convert.ToInt64(dt.Rows[0]["Qualification"]);
                model.KeySkills = Convert.ToString(dt.Rows[0]["Keyskills"]);
                model.Designation = Convert.ToString(dt.Rows[0]["Designation"]);
                model.ClientId = Convert.ToInt64(dt.Rows[0]["ClientId"]);
                model.SharedJob = Convert.ToInt64(dt.Rows[0]["AdminSharedJob"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["AdminSharedJob"]));
                model.Featured = Convert.ToInt64(dt.Rows[0]["FeaturedId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["FeaturedId"]));
                model.SubCategoryId = Convert.ToInt64(dt.Rows[0]["SubCategoryId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["SubCategoryId"]));
                model.PositionLevelId = Convert.ToInt64(dt.Rows[0]["PositionLevelId"] is DBNull ? 0 : dt.Rows[0]["PositionLevelId"]);

            }
            model.CountryId = 1;
            model.ClientCollection = (from DataRow row in ds.Tables[9].Rows
                                      select new DropDownViewModel
                                      {
                                          Id = Convert.ToInt64(row["Id"]),
                                          Name = Convert.ToString(row["Name"] is DBNull ? " " : row["Name"]),


                                      }).ToList();
            if (ds.Tables[10].Rows.Count > 0)
            {

                model.ValidPlandate = Convert.ToDateTime(ds.Tables[10].Rows[0]["ValidPlanDate"]).ToShortDateString();

                model.Validdate = Convert.ToDateTime(ds.Tables[10].Rows[0]["ValidPlanDate"]);

                model.LeftJobs = Convert.ToInt64(ds.Tables[10].Rows[0]["leftjob"]);
                model.noofjob = Convert.ToInt64(ds.Tables[10].Rows[0]["noofjob"]);
                model.Name = Convert.ToString(ds.Tables[10].Rows[0]["Name"]);

            }

            if (ds.Tables[15].Rows.Count > 0)
            {
                model.SubCategoryCollection = (from DataRow row in ds.Tables[15].Rows
                                               select new JobsModel
                                               {
                                                   SubCategoryId = Convert.ToInt64(row["Id"] is DBNull ? 0 : row["Id"]),
                                                   SubCategoryName = Convert.ToString(row["Name"] is DBNull ? 0 : row["Name"]),
                                               }).ToList();
            }
            if (ds.Tables[16].Rows.Count > 0)
            {
                model.PositionLevelCollection = (from DataRow row in ds.Tables[16].Rows
                                                 select new JobsModel { 
                                                     PositionLevelId = Convert.ToInt64(row["Id"] is DBNull ? 0 : row["Id"]),
                                                     PositionLevelName = Convert.ToString(row["Name"] is DBNull ? 0 : row["Name"]),
                                                 }).ToList();
            }
        }

        internal void sendClientconversationsaved(ClientModel model)
        {
            string Subject = "";

            string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);
            string AdminEmail = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"]);

            Subject = "REQUEST TO INTERVIEW";
            var ToEmail = model.Email;
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(EmailTempletePath + "Clientconversationhtml.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{Name}}", model.Name);

            body = body.Replace("{{Message}}", model.Description);

            sendEmail(Subject, body, ToEmail);
        }

        internal void enquireydetails(ClientModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            if (dt.Rows.Count > 0)
            {
                model.ClientId = Convert.ToInt64(dt.Rows[0]["ClientId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["ClientId"]));

                model.JobId = Convert.ToInt64(dt.Rows[0]["JobId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["JobId"]));


                model.CandidateId = Convert.ToInt64(dt.Rows[0]["CandidateId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["CandidateId"]));
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                model.Phone1 = Convert.ToString(dt.Rows[0]["Phone"]);
                model.Description = Convert.ToString(dt.Rows[0]["Description"]); 
                model.ClientName = Convert.ToString(dt.Rows[0]["FirstName"]) + ' ' + Convert.ToString(dt.Rows[0]["LastName"]);



                model.CandidateId = Convert.ToInt64(dt.Rows[0]["CandidateId"]);
                model.cids = EncryptDecrypt.encrypt(dt.Rows[0]["CandidateId"].ToString()).ToString();
                model.candidateEmail = Convert.ToString(dt.Rows[0]["CandidateEmail"]);
                model.CandidateName = Convert.ToString(dt.Rows[0]["CandidateName"]) + " " + Convert.ToString(dt.Rows[0]["CandidateLastName"]);
                model.CandidatePhone = Convert.ToString(dt.Rows[0]["CandidatePhone"]);
                model.candidateTitle = Convert.ToString(dt.Rows[0]["candidateTitle"]);
                model.candidatedescription = Convert.ToString(dt.Rows[0]["candidatedescription"]);
                model.candidateaddress = Convert.ToString(dt.Rows[0]["candidateaddress"]);
                model.candidatefacebook = Convert.ToString(dt.Rows[0]["candidatefacebook"]);
                model.candidatetwitter = Convert.ToString(dt.Rows[0]["candidatetwitter"]);
                model.candidatelinkedin = Convert.ToString(dt.Rows[0]["candidatelinkedin"]);
                model.candidateexp = Convert.ToString(dt.Rows[0]["candidateexp"]);
                model.Candidateage = Convert.ToString(dt.Rows[0]["candidateage"]);

                model.candidateimage = Convert.ToString(dt.Rows[0]["candidateimage"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["candidateimage"].ToString());

                model.candidateresume = Convert.ToString(dt.Rows[0]["candidateresume"]);
                model.candidatezipcode = Convert.ToString(dt.Rows[0]["candidatezipcode"]);
              
                model.Website = Convert.ToString(dt.Rows[0]["Website"]);
                model.JobType = Convert.ToString(dt.Rows[0]["jobtypeName"]);
                model.Industry = Convert.ToString(dt.Rows[0]["industryName"]);
                model.Candidateloction = Convert.ToString(dt.Rows[0]["Location"]);
                model.CreatedDate = Convert.ToDateTime(dt.Rows[0]["Createddate"]).ToString("dd MMMM yyyy");
                model.Jobtitle = Convert.ToString(dt.Rows[0]["JobTitle"]);

                model.DesiredTitle1 = Convert.ToString(dt.Rows[0]["DesiredTitle1"]);
                model.DesiredTitle2 = Convert.ToString(dt.Rows[0]["DesiredTitle2"]);

            }

            if (ds.Tables[2].Rows.Count > 0)
            {

                model.CompanyName = Convert.ToString(ds.Tables[2].Rows[0]["name"]);
                model.Website = Convert.ToString(ds.Tables[2].Rows[0]["Website"]);
                model.Location = Convert.ToString(ds.Tables[2].Rows[0]["Location"]);

                model.clientLogo = Convert.ToString(ds.Tables[2].Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CompanyImage/" + Convert.ToInt32(ds.Tables[2].Rows[0]["Id"]) + "/" + ds.Tables[2].Rows[0]["ImageFile"]);

            }
            else
            {
                model.CompanyName = "";
                model.clientLogo = "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG";

            }




            model.ClienConversationcollection = (from DataRow row in dt1.Rows
                                                 select new ClientModel
                                                 {
                                                     Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                     EnquireyId = Convert.ToInt64(row["sendenuireyId"] is DBNull ? 0 : Convert.ToInt64(row["sendenuireyId"])),
                                                     fromId = Convert.ToInt64(row["fromId"] is DBNull ? 0 : Convert.ToInt64(row["fromId"])),
                                                     ToId = Convert.ToInt64(row["ToId"] is DBNull ? 0 : Convert.ToInt64(row["ToId"])),
                                                     FileName = Convert.ToString(row["FileName"]),
                                                     adminName = Convert.ToString(row["adminName"]),
                                                     FilePath = "/" + "FileUpload/Conversation" + "/" + Convert.ToString(row["Id"]) + "/" + Convert.ToString(row["FileName"]),
                                                     Description = Convert.ToString(row["Massege"]).Replace("_Ids", row["Id"].ToString()),
                                                     StateId = Convert.ToInt64(row["StatusId"] is DBNull ? 0 : Convert.ToInt64(row["sendenuireyId"])),
                                                     CreatedDate = Convert.ToString(row["CreatedDate"].ToString()),
                                                     CreatedBy = Convert.ToInt64(row["CreatedBy"] is DBNull ? 0 : Convert.ToInt64(row["CreatedBy"])),
                                                     ClientName = Convert.ToString(row["Name"]),
                                                     clientLogo = Convert.ToString(row["clientLogo"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + Convert.ToInt32(row["CreatedBy"]) + "/" + row["clientLogo"]),
                                                 }).ToList();
        }

        internal void interviewsrequestbycandidatesdetail(ClientModel model, DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            if (dt.Rows.Count > 0)
            {
                model.ClientId = Convert.ToInt64(dt.Rows[0]["ClientId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["ClientId"]));

                model.JobId = Convert.ToInt64(dt.Rows[0]["JobId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["JobId"]));


                model.requestmoreinfo = Convert.ToInt64(dt.Rows[0]["requestmoreinfo"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["requestmoreinfo"]));

                model.CandidateId = Convert.ToInt64(dt.Rows[0]["CandidateId"] is DBNull ? 0 : Convert.ToInt64(dt.Rows[0]["CandidateId"]));
                model.Name = Convert.ToString(dt.Rows[0]["Name"]);
                model.Email = Convert.ToString(dt.Rows[0]["Email"]);
                model.Phone1 = Convert.ToString(dt.Rows[0]["Phone"]);
                model.Description = Convert.ToString(dt.Rows[0]["Description"]);

                model.ClientName = Convert.ToString(dt.Rows[0]["FirstName"]) + ' ' + Convert.ToString(dt.Rows[0]["LastName"]);

                model.CandidateId = Convert.ToInt64(dt.Rows[0]["CandidateId"]);
                model.cids = EncryptDecrypt.encrypt(dt.Rows[0]["CandidateId"].ToString()).ToString();
                model.candidateEmail = Convert.ToString(dt.Rows[0]["CandidateEmail"]);
                model.CandidateName = Convert.ToString(dt.Rows[0]["CandidateName"]) + " " + Convert.ToString(dt.Rows[0]["CandidateLastName"]);
                model.CandidatePhone = Convert.ToString(dt.Rows[0]["CandidatePhone"]);
                model.candidateTitle = Convert.ToString(dt.Rows[0]["candidateTitle"]);
                model.candidatedescription = Convert.ToString(dt.Rows[0]["candidatedescription"]);
                model.candidateaddress = Convert.ToString(dt.Rows[0]["candidateaddress"]);
                model.candidatefacebook = Convert.ToString(dt.Rows[0]["candidatefacebook"]);
                model.candidatetwitter = Convert.ToString(dt.Rows[0]["candidatetwitter"]);
                model.candidatelinkedin = Convert.ToString(dt.Rows[0]["candidatelinkedin"]);
                model.candidateexp = Convert.ToString(dt.Rows[0]["candidateexp"]);
                model.Candidateage = Convert.ToString(dt.Rows[0]["candidateage"]);

                model.candidateimage = Convert.ToString(dt.Rows[0]["candidateimage"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/candidatedefaultImage/" + dt.Rows[0]["candidateimage"].ToString());

                model.candidateresume = Convert.ToString(dt.Rows[0]["candidateresume"]);
                model.candidatezipcode = Convert.ToString(dt.Rows[0]["candidatezipcode"]);
            
                model.Website = Convert.ToString(dt.Rows[0]["Website"]);
                model.JobType = Convert.ToString(dt.Rows[0]["jobtypeName"]);
                model.Industry = Convert.ToString(dt.Rows[0]["industryName"]);
                model.Candidateloction = Convert.ToString(dt.Rows[0]["Location"]);
                model.CreatedDate = Convert.ToDateTime(dt.Rows[0]["Createddate"]).ToString("dd MMMM yyyy");
                model.Jobtitle = Convert.ToString(dt.Rows[0]["JobTitle"]);

            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                
                model.CompanyName = Convert.ToString(ds.Tables[2].Rows[0]["name"]);
                model.Website = Convert.ToString(ds.Tables[2].Rows[0]["Website"]);
                model.Location = Convert.ToString(ds.Tables[2].Rows[0]["Location"]);

                model.clientLogo = Convert.ToString(ds.Tables[2].Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CompanyImage/" + Convert.ToInt32(ds.Tables[2].Rows[0]["Id"]) + "/" + ds.Tables[2].Rows[0]["ImageFile"]);

            }
            else
            {
                model.CompanyName = "";
                model.clientLogo = "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG";

            }




            model.ClienConversationcollection = (from DataRow row in dt1.Rows
                                                 select new ClientModel
                                                 {
                                                     Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                     EnquireyId = Convert.ToInt64(row["sendenuireyId"] is DBNull ? 0 : Convert.ToInt64(row["sendenuireyId"])),
                                                     fromId = Convert.ToInt64(row["fromId"] is DBNull ? 0 : Convert.ToInt64(row["fromId"])),
                                                     ToId = Convert.ToInt64(row["ToId"] is DBNull ? 0 : Convert.ToInt64(row["ToId"])),
                                                     FileName = Convert.ToString(row["FileName"]),
                                                     adminName = Convert.ToString(row["adminName"]),
                                                     FilePath = "/" + "FileUpload/Conversation" + "/" + Convert.ToString(row["Id"]) + "/" + Convert.ToString(row["FileName"]),
                                                     Description = Convert.ToString(row["Massege"]).Replace("_Ids", row["Id"].ToString()),
                                                     StateId = Convert.ToInt64(row["StatusId"] is DBNull ? 0 : Convert.ToInt64(row["sendenuireyId"])),
                                                     CreatedDate = Convert.ToString(row["CreatedDate"].ToString()),
                                                     CreatedBy = Convert.ToInt64(row["CreatedBy"] is DBNull ? 0 : Convert.ToInt64(row["CreatedBy"])),
                                                     ClientName = Convert.ToString(row["Name"]),
                                                     clientLogo = Convert.ToString(row["clientLogo"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + Convert.ToInt32(row["CreatedBy"]) + "/" + row["clientLogo"]),
                                                 }).ToList();
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

        internal void shortlist(ClientModel model, DataTable dt)
        {
            model.GetShortList = (from DataRow row in dt.Rows
                                  select new ClientModel
                                  {
                                      Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                      Ids = EncryptDecrypt.encrypt(row["CandidateId"].ToString()).ToString(),
                                      ClientId = Convert.ToInt64(row["ClientId"] is DBNull ? 0 : Convert.ToInt64(row["ClientId"])),
                                      CandidateName = Convert.ToString(row["Name"]),
                                      Phone1 = Convert.ToString(row["PhoneNo"]),
                                      Email = Convert.ToString(row["PreferredEMail"]),
                                      ClientName = Convert.ToString(row["clientName"])
                                  }).ToList();
        }

        internal void skillautocomplete(CandidateModel model, DataTable dt)
        {
            model.SkillCollection = (from DataRow row in dt.Rows
                                     select new CandidateModel
                                     {
                                         //Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                         skill = Convert.ToString(row["Name"]),
                                     }).ToList();
        }

        internal void sendconversationsavedpopup(ClientModel model, DataTable dt)
        {
            model.ClienConversationcollection = (from DataRow row in dt.Rows
                                                 select new ClientModel
                                                 {
                                                     Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : Convert.ToInt64(row["Id"])),
                                                     EnquireyId = Convert.ToInt64(row["sendenuireyId"] is DBNull ? 0 : Convert.ToInt64(row["sendenuireyId"])),
                                                     fromId = Convert.ToInt64(row["fromId"] is DBNull ? 0 : Convert.ToInt64(row["fromId"])),
                                                     ToId = Convert.ToInt64(row["ToId"] is DBNull ? 0 : Convert.ToInt64(row["ToId"])),
                                                     Description = Convert.ToString(row["Massege"]),

                                                     FileName = Convert.ToString(row["FileName"]),
                                                     FilePath = "/" + "FileUpload/Conversation" + "/" + Convert.ToString(row["Id"]) + "/" + Convert.ToString(row["FileName"]),
                                                     StateId = Convert.ToInt64(row["StatusId"] is DBNull ? 0 : Convert.ToInt64(row["sendenuireyId"])),
                                                     CreatedDate = Convert.ToString(row["CreatedDate"] is DBNull ? "" : Convert.ToDateTime(row["CreatedDate"]).ToString("dd MMM yyyy")),
                                                     CreatedBy = Convert.ToInt64(row["CreatedBy"] is DBNull ? 0 : Convert.ToInt64(row["CreatedBy"])),
                                                     ClientName = Convert.ToString(row["clientName"]),
                                                     clientLogo = Convert.ToString(row["clientLogo"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + Convert.ToInt32(row["CreatedBy"]) + "/" + row["clientLogo"]),

                                                 }).ToList();
        }

        internal void sendconversationsaved(ClientModel model, DataTable dt)
        {
            //if (dt.Rows.Count > 0)
            //{
            //    model.StateId = Convert.ToInt64(dt.Rows[0]["StatusId"]);
            //}
            //string Subject = "";

            //string EmailTempletePath = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["EmailTemplate"]);
            //string AdminEmail = Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["AdminEmail"]);

            //Subject = "REQUEST TO INTERVIEW";
            //string body = string.Empty;
            //using (StreamReader reader = new StreamReader(EmailTempletePath + "Clientconversationhtml.html"))
            //{
            //    body = reader.ReadToEnd();
            //}
            //body = body.Replace("{{Name}}", model.Name);

            //body = body.Replace("{{Message}}", model.Description);

            //sendEmail(Subject, body, AdminEmail);
        }

        internal void myfavourite(CandidateModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.MilesCollection = (from DataRow row in ds.Tables[0].Rows
                                         select new DropDownViewModel
                                         {
                                             Id = Convert.ToInt64(row["milesid"]),
                                             Name = Convert.ToString(row["Name"])
                                         }).ToList();
            }


            if (ds.Tables[1].Rows.Count > 0)
            {
                model.JobTypeCollection = (from DataRow row in ds.Tables[1].Rows
                                           select new DropDownViewModel
                                           {
                                               Id = Convert.ToInt64(row["Id"]),
                                               Name = Convert.ToString(row["Name"])
                                           }).ToList();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                model.IndustryCollection = (from DataRow row in ds.Tables[2].Rows
                                            select new DropDownViewModel
                                            {
                                                Id = Convert.ToInt64(row["Id"]),
                                                Name = Convert.ToString(row["Name"])
                                            }).ToList();
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                model.experienceCollection = (from DataRow row in ds.Tables[3].Rows
                                              select new DropDownViewModel
                                              {
                                                  Id = Convert.ToInt64(row["Id"]),
                                                  Name = Convert.ToString(row["Name"])
                                              }).ToList();
            }
            if (ds.Tables[4].Rows.Count > 0)
            {
                model.EducationCollection = (from DataRow row in ds.Tables[4].Rows
                                             select new CandidateModel
                                             {
                                                 Id = Convert.ToInt64(row["Id"]),
                                                 Name = Convert.ToString(row["Name"])
                                             }).ToList();
            }

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

        internal void CompanyProfile(ClientModel model, DataSet ds)
        {


            model.CompanyName = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
            model.Website = Convert.ToString(ds.Tables[0].Rows[0]["Website"]);
            model.Location = Convert.ToString(ds.Tables[0].Rows[0]["Location"]);
            model.Zip = Convert.ToString(ds.Tables[0].Rows[0]["zipcode"]);
            model.Address = Convert.ToString(ds.Tables[0].Rows[0]["Address"]);
            model.Description = Convert.ToString(ds.Tables[0].Rows[0]["Description"]);
            model.FileName = Convert.ToString(ds.Tables[0].Rows[0]["ImageFile"]); 

            model.FilePath = Convert.ToString(ds.Tables[0].Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/" + "FileUpload" + "/" + "/" + "CompanyImage" + "/" + model.CompanyId + "/" + ds.Tables[0].Rows[0]["ImageFile"].ToString());



            if (ds.Tables[1].Rows.Count > 0)
            {
                model.clientContactForm = (from DataRow row in ds.Tables[1].Rows
                                           select new ClientModel
                                           {
                                               Id = Convert.ToInt64(row["Id"]),
                                               Status = Convert.ToInt64(row["Status"]),
                                               UseraccountprofileId = Convert.ToInt64(row["UseraccountprofileId"]),
                                               Name = Convert.ToString(row["Name"]),
                                               LastName = Convert.ToString(row["LastName"]),
                                               Title = Convert.ToString(row["Title"]),
                                               Email = Convert.ToString(row["Email"]),
                                               Linkdin = Convert.ToString(row["Linkedinurl"]),
                                               Phone1 = Convert.ToString(row["PhoneNo"]),
                                               
                                           }).ToList();
            }

        }

        internal void GetSubJobByJId(JobsModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.SubCategoryCollection = (from DataRow row in dt.Rows
                                               select new JobsModel
                                               {
                                                   SubCategoryId = Convert.ToInt64(row["Id"] is DBNull ? 0 : row["Id"]),
                                                   SubCategoryName = Convert.ToString(row["Name"] is DBNull ? "" : row["Name"])
                                               }).ToList();
            }
        }

        internal void GetjobByCompanyIdId(JobsModel model, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                model.SubCategoryCollection = (from DataRow row in dt.Rows
                                               select new JobsModel
                                               {
                                                   Id = Convert.ToInt64(row["Id"] is DBNull ? 0 : row["Id"]),
                                                   Title = Convert.ToString(row["JobTitle"] is DBNull ? "" : row["JobTitle"])
                                               }).ToList();
            }
        }



        internal void ResendActivationEmail( ClientModel model, DataTable dt)
        {
            if(dt.Rows.Count>0)
            {
                model.Password = Craptography.Decrypt(dt.Rows[0]["Password"].ToString(), dt.Rows[0]["Salt"].ToString());
                string Subject = "Account activation email ";                
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
