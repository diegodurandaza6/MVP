using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;

namespace Web.Dal.Client
{
    public class ClientDel
    {
        MySqlConnection connectstring = new MySqlConnection(ConfigurationManager.ConnectionStrings["mySqlCon"].ToString());

        //public ClientDel()
        //{
        //    connectstring = ConfigurationManager.ConnectionStrings["mySqlCon"].ToString();            
        //}

        DataTable dt = new DataTable();

        public DataTable AddSkills(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                     new MySqlParameter("KeySkills", model.KeySkills),
                      new MySqlParameter("UserId", model.UserId),
                      new MySqlParameter("SId", model.SId),
            };
            string Query = "call sp_AddJobSkill(@Id,@KeySkills,@UserId,@SId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable deleteskill(JobsModel model)
        {

            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                     new MySqlParameter("Ids", model.Ids),
                     new MySqlParameter("SId", model.SId),
            };
            string Query = "call spDeleteJobskill(@Id,@Ids,@SId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        } 
        DataSet ds = new DataSet();
        public void candidateshortlist(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                     new MySqlParameter("ClientId", model.ClientId),

            };
            string Query = "call sp_candidateshortlist(@Id,@ClientId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            if (dt.Rows.Count > 0)
            {
                model.Status = Convert.ToInt64(dt.Rows[0]["status"]);
            }
        }

        public DataTable ClientenquireyList(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.UserId),
                    new MySqlParameter("maxRows", model.maxRows),
                      new MySqlParameter("OffsetId", model.OffsetId),

            };
            string Query = "call Sp_ClientenquireyList(@Id,@maxRows,@OffsetId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public void CreateJobs(JobsModel model)
        {
            string tag = "";

            MySqlParameter[] commandParameters = new MySqlParameter[]{
                new MySqlParameter("UserId", model.UserId),
                new MySqlParameter("Id", model.Id),
                new MySqlParameter("jobtitle", model.jobtitle),
                new MySqlParameter("JobTypeId", model.JobTypeId),
                new MySqlParameter("JobCategoryId", model.JobCategoryId),
                new MySqlParameter("SId", model.SId),
                new MySqlParameter("Designation", model.Designation),
                new MySqlParameter("JobDescription", model.JobDescription),
                new MySqlParameter("WorkExperienceMin", model.WorkExperienceMin),
                new MySqlParameter("WorkExperienceMax", model.WorkExperienceMax),
                new MySqlParameter("MinSalary", model.MinSalary),
                new MySqlParameter("MaxSalary", model.MaxSalary),
                new MySqlParameter("QualificationId", model.QualificationId),
                new MySqlParameter("JobStatusId", model.JobStatusId),
                new MySqlParameter("CountryId", model.CountryId),
                new MySqlParameter("StateId", model.StateId),
                new MySqlParameter("City", model.City),
                new MySqlParameter("ClientId",model.ClientId),
                new MySqlParameter("SharedJob",model.SharedJob),
                new MySqlParameter("zipcode",model.zipcode),
                new MySqlParameter("location",model.location),
                new MySqlParameter("TId",model.TId),
                 new MySqlParameter("sortdescription",model.sortdescription),
                new MySqlParameter("accounttype",model.accounttype),
                   new MySqlParameter("Featured",model.Featured),
                    new MySqlParameter("SubCategoryId",model.SubCategoryId),
                    new MySqlParameter("PositionLevelId",model.PositionLevelId),

            };
            string Query = "call Sp_CreateJobs(@UserId,@Id,@jobtitle,@JobTypeId,@JobCategoryId,@SId,@Designation,@JobDescription,@WorkExperienceMin,@WorkExperienceMax,@MinSalary,@MaxSalary," +
                "@QualificationId,@JobStatusId,@CountryId,@StateId,@City,@ClientId,@SharedJob,@zipcode,@location,@TId,@sortdescription,@accounttype,@Featured,@SubCategoryId,@PositionLevelId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["JobId"]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.UserId = Convert.ToInt64(ds.Tables[1].Rows[0]["Id"]);
                model.Image = Convert.ToString(ds.Tables[1].Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/" + "FileUpload" + "/" + "/" + "CompanyImage" + "/" + Convert.ToInt64(ds.Tables[1].Rows[0]["Id"]) + "/" + ds.Tables[1].Rows[0]["ImageFile"].ToString());
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    tag += ds.Tables[2].Rows[i]["Name"].ToString() + ", ";
                }
                model.Tags = tag.Remove(tag.Length - 2, 2);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                model.CreDate = Convert.ToDateTime(ds.Tables[3].Rows[0]["CreatedDate"]);
            }
        }

        public void Admin_CreateJobs(JobsModel model)
        {
            string tag = "";

            MySqlParameter[] commandParameters = new MySqlParameter[]{
                new MySqlParameter("UserId", model.UserId),
                new MySqlParameter("Id", model.Id),
                new MySqlParameter("jobtitle", model.jobtitle),
                new MySqlParameter("JobTypeId", model.JobTypeId),
                new MySqlParameter("JobCategoryId", model.JobCategoryId),
                new MySqlParameter("SId", model.SId),
                new MySqlParameter("Designation", model.Designation),
                new MySqlParameter("JobDescription", model.JobDescription),
                new MySqlParameter("WorkExperienceMin", model.WorkExperienceMin),
                new MySqlParameter("WorkExperienceMax", model.WorkExperienceMax),
                new MySqlParameter("MinSalary", model.MinSalary),
                new MySqlParameter("MaxSalary", model.MaxSalary),
                new MySqlParameter("QualificationId", model.QualificationId),
                new MySqlParameter("JobStatusId", model.JobStatusId),
                new MySqlParameter("CountryId", model.CountryId),
                new MySqlParameter("StateId", model.StateId),
                new MySqlParameter("City", model.City),
                new MySqlParameter("ClientId",model.ClientId),
                new MySqlParameter("SharedJob",model.SharedJob),
                new MySqlParameter("zipcode",model.zipcode),
                new MySqlParameter("location",model.location),
                new MySqlParameter("TId",model.TId),
                 new MySqlParameter("sortdescription",model.sortdescription),
                new MySqlParameter("accounttype",model.accounttype),
                   new MySqlParameter("Featured",model.Featured),
                    new MySqlParameter("SubCategoryId",model.SubCategoryId),
                    new MySqlParameter("PositionLevelId",model.PositionLevelId),

            };
            string Query = "call Sp_AdminCreateJobs(@UserId,@Id,@jobtitle,@JobTypeId,@JobCategoryId,@SId,@Designation,@JobDescription,@WorkExperienceMin,@WorkExperienceMax,@MinSalary,@MaxSalary," +
                "@QualificationId,@JobStatusId,@CountryId,@StateId,@City,@ClientId,@SharedJob,@zipcode,@location,@TId,@sortdescription,@accounttype,@Featured,@SubCategoryId,@PositionLevelId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Id = Convert.ToInt64(ds.Tables[0].Rows[0]["JobId"]);
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.UserId = Convert.ToInt64(ds.Tables[1].Rows[0]["UserId"]);
                model.Image = Convert.ToString(ds.Tables[1].Rows[0]["ImageFile"] is DBNull ? "/FileUpload/candidatedefaultImage/" + "No_image_available.PNG" : "/FileUpload/CandidateImage/" + Convert.ToInt32(ds.Tables[1].Rows[0]["UserId"]) + "/" + ds.Tables[1].Rows[0]["ImageFile"].ToString());
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                {
                    tag += ds.Tables[2].Rows[i]["Name"].ToString() + ", ";
                }
                model.Tags = tag.Remove(tag.Length - 2, 2);
            }
            if (ds.Tables[3].Rows.Count > 0)
            {
                model.CreDate = Convert.ToDateTime(ds.Tables[3].Rows[0]["CreatedDate"]);
            }
        }

        public DataTable jobtitleautocomplate(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Title",model.Title)
            };
            string Query = "call sp_jobtitleautocomplate(@Title)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataSet getCandidateTitleList(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Title",model.Title) 
            };
            string Query = "call sp_getCandidateTitleList(@Title)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataSet getFavoriteCandidateTitleList(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Title",model.Title),
                 new MySqlParameter("UserId",model.UserId)
            };
            string Query = "call sp_getFavoriteCandidateTitleList(@Title,@UserId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }



        public void Candidateconversationsaved(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("UserId", model.UserId),
                     new MySqlParameter("CId", model.CId),
                     new MySqlParameter("description",model.description),
                     new MySqlParameter("Name",model.Name),
                     new MySqlParameter("JobId",model.jId)

            };
            // pipeline message save by client
            string Query = "call Sp_Candidateconversationsaved(@UserId,@CId,@description,@Name,@JobId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public void savesendgeneralmessage(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                     new MySqlParameter("fromId", model.fromId),
                     new MySqlParameter("ToId",model.ToId),
                     new MySqlParameter("Description",model.Description),
                      new MySqlParameter("Name",model.Name),
            };
            string Query = "call sp_savesendgeneralmessage(@Id,@fromId,@ToId,@Description,@Name)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public DataTable Pipelinemessageslist(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",model.UserId),
                   new MySqlParameter("maxRows", model.maxRows),
                      new MySqlParameter("OffsetId", model.OffsetId),
            };
            string Query = "call SP_Pipelinemessageslist(@UserId,@maxRows,@offsetId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable ClientCandidateNameAutoComplete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Name",model.Name),
            };
            string Query = "call sp_ClientCandidateNameAutoComplete(@Name)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable CandidateNameAutoComplete(CandidateModel model)
        {

            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Name",model.Name),


            };
            string Query = "call Sp_AutoCompleteCandidate(@Name)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable ClientNameAutoComplete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Name",model.Name),


            };
            string Query = "call Sp_AutoCompleteClient(@Name)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }


        public DataSet messagesdetails(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("UserId",model.UserId)
            };
            string Query = "call sp_getmessagesdetails(@Id,@UserId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public void sendgeneralmessages(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("fromId", model.fromId),
                     new MySqlParameter("Title",model.Title),
                     new MySqlParameter("Description",model.Description),
                     new MySqlParameter("Name",model.Name),
                     new MySqlParameter("Email",model.Email),
                        new MySqlParameter("ToId",model.ToId)

            };
            string Query = "call sp_sendgeneralmessages(@fromId,@Title,@Description,@Name,@Email,@ToId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public DataTable messages(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.UserId),
                    new MySqlParameter("maxRows", model.maxRows),
                      new MySqlParameter("OffsetId", model.OffsetId),

            };
            string Query = "call sp_generalmessagebyclientid(@Id,@maxRows,@OffsetId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataSet conversation(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("UserId", model.UserId),
                     new MySqlParameter("Id", model.Id),
                     new MySqlParameter("jId", model.jId)

            };
            // read by client pipeline message
            string Query = "call Sp_conversation(@UserId,@Id,@jId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataTable Clientnotepopup(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("UserId", model.UserId),
                     new MySqlParameter("Id", model.Id),
                       new MySqlParameter("JobId", model.JobId),

            };
            string Query = "call Sp_Clientnotepopup(@UserId,@Id,@JobId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public void clientNotesDelete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id",model.Id),



            };
            string Query = "call Sp_clientnotedelete(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
        }

        public void clientNotesave(CandidateModel Model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id",Model.Id),
                   new MySqlParameter("UserId",Model.UserId),
                    new MySqlParameter("JobId",Model.JobId),
                    new MySqlParameter("ClientNote",Model.ClientNote)


            };
            string Query = "call Sp_clientNotesave(@Id,@UserId,@JobId,@ClientNote)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();

        }

        public DataTable mycandidate(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("UserId", model.UserId),
                   new MySqlParameter("CandidateName", model.CandidateName),
                    new MySqlParameter("location", model.location),
                      new MySqlParameter("OffsetId",model.OffsetId),
                      new MySqlParameter("maxRows",model.maxRows),

            };
            string Query = "call Sp_getmycandidatelist(@UserId,@CandidateName,@location,@OffsetId,@maxRows)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable deleteJobtags(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                     new MySqlParameter("Ids", model.Ids),
                     new MySqlParameter("TId", model.TId),
            };
            string Query = "call Sp_deleteJobtags(@Id,@Ids,@TId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }



        public DataTable AddTags(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                     new MySqlParameter("Tags", model.Tags),
                      new MySqlParameter("UserId", model.UserId),
                      new MySqlParameter("TId", model.TId),
            };
            string Query = "call sp_AddTags(@Id,@Tags,@UserId,@TId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable Tagsautocomplete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Name",model.Name)


            };
            string Query = "call Sp_AutoCompleteTags(@Name)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataSet dashboard(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                  new MySqlParameter("UserId",model.UserId),
                  new MySqlParameter("ClientId",model.ClientId)
            };
            string Query = "call sp_clientdashboard(@UserId,@ClientId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataTable SharedJobCount(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                  new MySqlParameter("JobId",model.JobId)
            };
            string Query = "call Sp_SharedJobCount(@JobId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public void viewCandidate(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                  new MySqlParameter("Id",model.Id)
            };
            string Query = "call viewCandidate(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0]; connectstring.Close();
            connectstring.Close();
            if (dt.Rows.Count > 0)
            {
                model.Ids = dt.Rows[0]["CandidateId"].ToString();
                model.CreatedDate = dt.Rows[0]["CreatedDate"].ToString();
            }
        }

        public DataSet Applicant(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                  new MySqlParameter("Email",model.Email),
                    new MySqlParameter("OffsetId",model.OffsetId),
                      new MySqlParameter("maxRows",model.maxRows),
                      new MySqlParameter("UserId",model.UserId),
                      new MySqlParameter("JobId",model.JobId),
                      new MySqlParameter("jobStatus",model.jobStatus),
                      new MySqlParameter("ClientId",model.ClientId)
            };
            string Query = "call sp_GetClientApplicant(@Email,@OffsetId,@maxRows,@UserId,@JobId,@jobStatus,@ClientId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }


        public void JobDetailDeletebyId(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id)
            };
            string Query = "call Sp_JobDetailDeletebyId(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet JobDetail(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                  new MySqlParameter("UserId", model.UserId),
            };
            string Query = "call Sp_JobDetail(@Id,@UserId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataSet JobDetailById(JobsModel model)
        {

            if (model.Jobtype == null)
            {
                model.Jobtype = "0";
            } 

            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                  new MySqlParameter("UserId", model.UserId),
                     new MySqlParameter("JobTypeId", model.Jobtype),
                        new MySqlParameter("location", model.location),
            };
            string Query = "call sp_JobDetailById(@Id,@UserId,@JobTypeId,@location)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }


        public DataSet JobList(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                new MySqlParameter("jobtitle", model.jobtitle),
                new MySqlParameter("JobStatusId", model.JobStatusId),
                new MySqlParameter("SharedJob", model.SharedJob),
                new MySqlParameter("JobTypeId", model.JobTypeId),
                new MySqlParameter("UserId", model.UserId),
                new MySqlParameter("OffsetId",model.OffsetId),
                new MySqlParameter("maxRows",model.maxRows),
                new MySqlParameter("ClientId",model.ClientId),
            };
            if (model.accounttype == 1)
            {
                string Query = "call Sp_AdminJobsList(@jobtitle,@JobStatusId,@SharedJob,@JobTypeId,@UserId,@OffsetId,@maxRows)";
                connectstring.Open();
                ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
                connectstring.Close();
                return ds;
            }
            else
            {
                string Query = "call Sp_JobsList(@jobtitle,@JobStatusId,@SharedJob,@JobTypeId,@UserId,@OffsetId,@maxRows,@ClientId)";
                connectstring.Open();
                ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
                connectstring.Close();
                return ds;
            }
             
        }

        public void Clientlogoupdate(ClientModel model)
        {

            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                     new MySqlParameter("clientLogo", model.clientLogo),

            };
            string Query = "call Sp_Clientlogoupdate(@Id,@clientLogo)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public DataSet Jobs(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                  new MySqlParameter("SId", model.SId),
                        new MySqlParameter("UserId", model.UserId),
                          new MySqlParameter("TId", model.TId),
            };

            string Query = "call Sp_JobsbyId(@Id,@SId,@UserId,@TId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public void ClientProfileupdate(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                  new MySqlParameter("CompanyName", model.CompanyName),
                  new MySqlParameter("Website", model.Website),
                  new MySqlParameter("Address", model.Address),
                  new MySqlParameter("FaceBook", model.FaceBook),
                  new MySqlParameter("Twitter", model.Twitter),
                  new MySqlParameter("Linkdin", model.Linkdin),

                  new MySqlParameter("CityName", model.CityName),
                   new MySqlParameter("Zip", model.Zip),
                  new MySqlParameter("Description", model.Description),
                   new MySqlParameter("clientLogo", model.clientLogo),
                       new MySqlParameter("Location", model.Location),
                         new MySqlParameter("Name", model.Name),
                         new MySqlParameter("LastName", model.LastName),

                         new MySqlParameter("ClientPhone", model.ClientPhone),

            };
            string Query = "call Sp_ClientProfileupdate(@Id,@CompanyName,@Website,@Address,@FaceBook,@Twitter,@Linkdin,@CityName,@Zip,@Description,@clientLogo,@Location,@Name,@LastName,@ClientPhone)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public DataTable shortlist(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",model.UserId),
            };
            string query = "call sp_GetshortlistClient(@UserId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable skillautocomplete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Name",model.Name),


            };
            string Query = "call Sp_AutoCompleteSkills(@Name)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public void sendClientconversationsaved(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                   new MySqlParameter("ClientId",model.ClientId),
                      new MySqlParameter("UserId",model.UserId),
                        new MySqlParameter("Description",model.Description),
                        new MySqlParameter("Ids",model.Ids),
                        new MySqlParameter("FileName",model.FileName),
                         new MySqlParameter("Name",model.Name)
            };
            string Query = "call Sp_sendClientconversationsaved(@Id,@ClientId,@UserId,@Description,@Ids,@FileName,@Name)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            if (dt.Rows.Count > 0)
            {
                model.RowsId = Convert.ToInt64(dt.Rows[0]["v_CurrentId"]);
            }
        }

        public DataTable sendconversationsavedpopup(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),


            };
            string Query = "call sp_sendconversationsavedpopup(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable sendconversationsaved(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                   new MySqlParameter("ClientId",model.ClientId),
                      new MySqlParameter("UserId",model.UserId),
                        new MySqlParameter("Description",model.Description),
                         new MySqlParameter("FileName",model.FileName),
                          new MySqlParameter("Name",model.Name)
            };
            string Query = "call sp_sendconversationsaved(@Id,@ClientId,@UserId,@Description,@FileName,@Name)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.RowsId = Convert.ToInt64(ds.Tables[1].Rows[0]["v_CurrentId"]);
            }
            connectstring.Close();
            return ds.Tables[0];
        }


        public DataSet enquireydetails(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("UserId",model.UserId),
                  new MySqlParameter("AccountTypeId",model.AccountTypeId)
            };
            string Query = "call Sp_enquirey_details(@Id,@UserId,@AccountTypeId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataSet interviewsrequestbycandidatesdetail(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("UserId",model.UserId)
            };
            string Query = "call sp_interviewsrequestbycandidatesdetail(@Id,@UserId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataTable ClientSendenquery(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.UserId),
                   new MySqlParameter("CandidateId", model.CandidateId),
                  new MySqlParameter("Name", model.Name),
                  new MySqlParameter("Email", model.Email),
                  new MySqlParameter("Phone1", model.Phone1),
                  new MySqlParameter("JobId", model.JobId),
                  new MySqlParameter("Description", model.Description),
                   new MySqlParameter("FileName", model.FileName)
            };
            string Query = "call Sp_ClientSendenquery(@Id,@CandidateId,@Name,@Email,@Phone1,@JobId,@Description,@FileName)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;

          
        }

        public DataTable StateList(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("CountryId",model.Id)
            };
            string Query = "call sp_GetStateByCountryId(@CountryId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataSet CompanyProfile(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.UserId),
                  new MySqlParameter("CompanyId", model.CompanyId),
            };
            string Query = "call Sp_ClientCompanyProfile(@Id,@CompanyId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataSet myfavourite(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                   new MySqlParameter("maxRows", model.maxRows),
                    new MySqlParameter("OffsetId", model.OffsetId),
                     new MySqlParameter("CandidateName", model.CandidateName),
                      new MySqlParameter("location", model.location),
                      new MySqlParameter("ClientId", model.ClientId),
            };
            string Query = "call sp_myfavourite(@Id,@maxRows,@OffsetId,@CandidateName,@location,@ClientId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataSet favoritecandidate(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                  new MySqlParameter("ClientId", model.ClientId),
                    new MySqlParameter("Status", model.Status),
                    new MySqlParameter("Ids", model.Ids),

            };
            string Query = "call Sp_favoritecandidate(@Id,@ClientId,@Status,@Ids)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataTable AddTofavoritecandidate(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                  new MySqlParameter("ClientId", model.ClientId),
                    new MySqlParameter("Status", model.Status),
                    new MySqlParameter("Ids", model.Ids),

            };
            string Query = "call Sp_AddTofavoritecandidate(@Id,@ClientId,@Status,@Ids)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable GetSubJobByJId(JobsModel model)
        {
            MySqlParameter[] myPara = new MySqlParameter[] {
            new MySqlParameter("JobCategoryId",model.Id)
            };
            string Query = "Call sp_GetSubJobByJId(@JobCategoryId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, myPara).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable GetjobByCompanyIdId(JobsModel model)
        {
            MySqlParameter[] myPara = new MySqlParameter[] { 
            new MySqlParameter("Id",model.Id)
            };
            string Query = "Call sp_GetjobByCompanyIdId(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, myPara).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable ResendActivationEmail(ClientModel model)
        {
            MySqlParameter[] mypara = new MySqlParameter[] { 
            new MySqlParameter("Id",model.Id)
            };
            string Query = "Call sp_ResendActivationEmail(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, mypara).Tables[0];
            connectstring.Close();
            return dt;
        }
    }
}



