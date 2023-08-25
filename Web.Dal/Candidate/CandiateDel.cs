using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using Web.Core.Common.Impl;
using Web.Model.Admin;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;
using Web.Model.Paypal;
namespace Web.Dal.Candidate
{
    public class CandiateDel
    {
        //string connectstring;
        //public CandiateDel()
        //{
        //    connectstring = ConfigurationManager.ConnectionStrings["mySqlCon"].ToString();
        //}
        MySqlConnection connectstring = new MySqlConnection(ConfigurationManager.ConnectionStrings["mySqlCon"].ToString());
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public DataSet CadidateList(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                  new MySqlParameter("Email",model.Email),
                  new MySqlParameter("Zipcode",model.Zipcode),
                    new MySqlParameter("OffsetId",model.OffsetId),
                      new MySqlParameter("maxRows",model.maxRows)
            };
            string Query = "call Sp_getCadidateList(@Email,@Zipcode,@OffsetId,@maxRows)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public void CandidateawardsDelete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_CandidateawardsDelete(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void Deleteskill(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call sp_Deleteskill(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet CandidateAwardspopup(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_getCandidateAwardspopup(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataTable CandidateDelete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_getCandidateDeletebyId(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public void Candidateportfoliosave(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("CreateBy",model.CreateBy),
                new MySqlParameter("FileName",model.FileName),
                new MySqlParameter("CandidateId",model.CandidateId),
                 new MySqlParameter("description",model.description),
                   new MySqlParameter("visibleid",model.visibleid),
                  new MySqlParameter("Link",model.Link),
            };
            string Query = "call Sp_CandidatePortfolio(@Id,@CreateBy,@FileName,@CandidateId,@description,@visibleid,@Link)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void CandidateEducationDelete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_CandidateEducationDelete(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void CandidateworkexperienceDelete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_CandidateworkexperienceDelete(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet Candidateworkexperiencepopup(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call Sp_GetCandidateworkexperiencepopup(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public void createawardscandidate(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("CreateBy",model.CreateBy),
                 new MySqlParameter("Title",model.Title),
                  new MySqlParameter("year",model.year),
                    new MySqlParameter("description",model.description),
                      new MySqlParameter("visibleid",model.visibleid),
                       new MySqlParameter("CandidateId",model.CandidateId)
            };
            string Query = "call Sp_createawardscandidate(@Id,@CreateBy,@Title,@year,@description,@visibleid,@CandidateId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataTable CandidateportfolioDelete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_CandidateportfolioDelete(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public void CandidateResumeUpload(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.UserId),
                  new MySqlParameter("Resumefile",model.Resumefile)
            };
            string Query = "call Sp_CandidateResumeUpload(@Id,@Resumefile)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataTable Candidaterefrencespopup(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("CandidateId",model.CandidateId),
            };
            string Query = "call Sp_Candidaterefrencespopup(@Id,@CandidateId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        } 

        public DataSet LicensesCertificationspopup(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("CandidateId",model.CandidateId),
            };
            string Query = "call sp_licensescertificationspopup(@Id,@CandidateId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        } 
        public DataTable AutoCompleteSkills(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                 new MySqlParameter("skill",model.skill),
            };
            string Query = "call Sp_AutoCompleteSkills(@skill)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable MyappliedJob(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                 new MySqlParameter("UserId",model.UserId),
                  new MySqlParameter("OffsetId",model.OffsetId),
                      new MySqlParameter("maxRows",model.maxRows)
            };
            string Query = "call Sp_Appliedjoblist(@UserId,@OffsetId,@maxRows)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public void JobSavedDeletebyId(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                 new MySqlParameter("UserId",model.Id),
            };
            string Query = "call Sp_JobSavedDeletebyId(@UserId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataTable MySavedJobList(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                 new MySqlParameter("UserId",model.UserId),
                   new MySqlParameter("OffsetId",model.OffsetId),
                      new MySqlParameter("maxRows",model.maxRows)
            };
            string Query = "call SP_SavedJobList(@UserId,@OffsetId,@maxRows)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataSet interviewscedulelist(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Title",model.Title),
                new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call Sp_InterviewList(@Title,@UserId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataSet InterviewSchedulepopup(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                       new MySqlParameter("ClientId",model.ClientId),
                              new MySqlParameter("CandidateId",model.CandidateId),
            };
            string Query = "call Sp_InterviewSchedulepopup(@Id,@ClientId,@CandidateId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataSet stoppayment(CandidateModel obj)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",obj.UserId),
                   new MySqlParameter("Id",obj.Id),
                     new MySqlParameter("p_Id",obj.p_Id),
            };
            string Query = "call sp_stoppayment(@UserId,@Id,@p_Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);

            connectstring.Close();
            return ds;
        }
        public DataSet Renewpayment(CandidateModel obj)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",obj.UserId),
                   new MySqlParameter("Id",obj.Id),
                     new MySqlParameter("p_Id",obj.p_Id),
            };
            string Query = "call sp_Renewpayment(@UserId,@Id,@p_Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);

            connectstring.Close();
            return ds;
        }
        public DataSet refundpayment(CandidateModel obj)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",obj.Id),
                 new MySqlParameter("UserId",obj.UserId),
                new MySqlParameter("subscription_Id",obj.p_Id),
            };
            string Query = "call sp_refundpayment(@Id,@UserId,@subscription_Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);

            connectstring.Close();
            return ds;
        }

        public DataSet Plan(PlanModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("PlanStatusId",model.PlanStatusId),
                   new MySqlParameter("PlanTypeId",model.PlanTypeId),
            };
            string Query = "call Sp_PlanList(@Id,@PlanStatusId,@PlanTypeId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataTable Candidatedefaultimage(CandidateModel model)
        {
            string Query = "call Sp_Candidatedefaultimage()";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable AutoCompleteCandidatetags(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("CandidateTag",model.CandidateTag),
                   new MySqlParameter("AccountType",model.AccountType),
            };
            string Query = "call AutoCompleteCandidatetags(@CandidateTag,@AccountType)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable interviewlistbycandidate(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call sp_interviewlistbycandidate(@UserId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataSet messageslist(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",model.UserId),
                            new MySqlParameter("maxRows", model.maxRows),
                      new MySqlParameter("OffsetId", model.OffsetId),
            };
            string Query = "call sp_getallcandidatemessages(@UserId,@maxRows,@OffsetId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataSet generalmessagelist(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",model.UserId),

                    new MySqlParameter("maxRows", model.maxRows),
                      new MySqlParameter("OffsetId", model.OffsetId),
            };
            string Query = "call Sp_generalmessagelist(@UserId,@maxRows,@OffsetId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public void generalmessageconversationsaved(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("UserId", model.UserId),

                     new MySqlParameter("description",model.description),
                     new MySqlParameter("Name",model.Name),
                      new MySqlParameter("Id",model.Id)
            };
            string Query = "call SP_generalmessageconversationsaved(@UserId,@description,@Name,@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }


        public void LicensesCertificationsDelete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call sp_licensescertificationsdelete(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet CandidateDetailsbyId(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("UserId",model.UserId),
                 new MySqlParameter("JobTypeId",model.JobTypeId),
                  new MySqlParameter("location",model.location),
                    new MySqlParameter("Client",0)

            };
            string Query = "call Sp_CandidateDetailsbyId(@Id,@UserId,@JobTypeId,@location,@Client)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public string convertdate(string date)
        {
            var date1 = "";
            // 01/24/2023
            string[] arrDate = date.Split('/');
            string month = arrDate[0].ToString();
            string day = arrDate[1].ToString();
            string year = arrDate[2].ToString();
            date1 = year + "-" + month + "-" + day;
            return date1; // 2023-01-30
        }


        public DataSet getAllPaymentHistory(PlansListModel model)
        {
            string FromDate = "";
            string ToDate = "";
            if (model.FromDate != null && model.Todate != null)
            {
                FromDate = convertdate(model.FromDate);
                ToDate = convertdate(model.Todate);
            }
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                  new MySqlParameter("FromDate", FromDate ),
                    new MySqlParameter("Todate", ToDate),

            };
            string Query = "call sp_getAllPaymentHistory(@Id,@FromDate,@Todate)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataSet getallzipcodeinradius(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("CityName",model.CityName),
                  new MySqlParameter("MileId",model.MileId),
                  new MySqlParameter("gid",model.gid),
                  new MySqlParameter("Title",model.Title),
            };
            string Query = "call FindZCTAbyRadius(@CityName,@MileId,@gid,@Title)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public void submitedMessageprofile(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("UserId", model.UserId),
                     new MySqlParameter("Id", model.Id),
                     new MySqlParameter("description",model.description),
                      new MySqlParameter("FromId",model.FromId),
                       new MySqlParameter("ToId",model.ToId),
            };
            string Query = "call sp_submitedMessageprofile(@UserId,@Id,@description,@FromId,@ToId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public DataSet submitedprofiledetail(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("ClientId",model.ClientId),
                new MySqlParameter("AccountTypeId",model.AccountTypeId),
            };
            string Query = "call sp_submitedprofiledetail(@Id,@ClientId,@AccountTypeId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataSet submitedprofile(Candidateconversationmodel model)
        {
            if (model.Name == null)
            {
                model.Name = "null";
            }
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("Name",model.Name),
                new MySqlParameter("AccountTypeId",model.AccountTypeId),
            };
            string Query = "call sp_submitedprofile(@Id,@Name,@AccountTypeId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();

            if (model.Name == "null")
            {
                model.Name = null;
            }
            return ds;
        }

        public DataTable getallFavoritescandidatelistByClient(CandidateListModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.ClientId),
                new MySqlParameter("CandidateIds",model.CandidateIds),
            };
            string Query = "call sp_getallFavoritescandidatelistByClient(@Id,@CandidateIds)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();

            return dt;
        }

        public void CheckAndInsertZipCode(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Zipcode", model.Zipcode.Trim()),
                     new MySqlParameter("Latitude", model.Latitude),
                     new MySqlParameter("Longitude",model.Longitude),

            };
            string Query = "call sp_CheckAndInsertZipCode(@Zipcode,@Latitude,@Longitude)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public DataTable CoreUpdate()
        {

            string Query = "call sp_CandidateCoreUpdate()";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query).Tables[0];
            connectstring.Close();
            return dt;
        }

        public void GetJobOnwerDetailById(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call sp_GetJobOnwerDetailById(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            if (dt.Rows.Count > 0)
            {
                model.Name = dt.Rows[0]["Name"].ToString() + " " + dt.Rows[0]["LastName"].ToString();
                model.Email = dt.Rows[0]["Email"].ToString();
            }
        }

        public void Error(long id, string error)
        {
            connectstring.Close();
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                     new MySqlParameter("id",id),
                      new MySqlParameter("error",error),
            };
            string Query = "call sp_Error(@id,@error)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public DataSet UpdateCandidateOnsolr(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call sp_UpdateCandidateOnsolr(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataSet AdminNotification(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("CreatedBy",model.CreatedBy),
            };
            string Query = "call sp_AdminNotification(@CreatedBy)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataSet CandidateNnotification(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("CreatedBy",model.CreatedBy),
            };
            string Query = "call sp_candidatennotification(@CreatedBy)";
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

        public DataSet generalmessagedetail(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",model.UserId),
                 new MySqlParameter("Id",model.Id),
            };
            string Query = "call SP_generalmessagedetail(@UserId,@Id)";
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
                      new MySqlParameter("jId", model.jId),
                     new MySqlParameter("description",model.description),
                     new MySqlParameter("Name",model.Name),
                      new MySqlParameter("Id",model.Id)

            };
            string Query = "call sp_conversationByCandidate(@UserId,@CId,@jId,@description,@Name,@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public DataSet conversation(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call sp_getCandidateconversationlist(@Id,@UserId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataTable getinterviewschedulelist(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("CreatedBy",model.CreatedBy),
            };
            string Query = "call sp_getinterviewschedulelist(@CreatedBy)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataSet getallunreadmessage(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("CreatedBy",model.CreatedBy),
            };
            string Query = "call sp_getallunreadmessage(@CreatedBy)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataTable InterviewSchedulecalenderlist(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.UserId),
            };
            string Query = "call Sp_calenderinterviewschedulelist(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public void deletecandidatetag(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_deletecandidatetag(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();

        }

        public DataSet Candidatetagvalue(Tagsmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("CId",model.CId),

                   new MySqlParameter("CandidateTag",model.CandidateTag),
                   new MySqlParameter("CreateBy",model.CreateBy),
                   new MySqlParameter("TagtypeId",model.TagtypeId),
            };
            string Query = "call Sp_Candidatetagvalue(@Id,@CId,@CandidateTag,@CreateBy,@TagtypeId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataSet paymenthistory(PlansListModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",model.UserId),
                  new MySqlParameter("OffsetId",model.OffsetId),
                      new MySqlParameter("maxRows",model.maxRows)
            };
            string Query = "call sp_paymenthistory(@UserId,@OffsetId,@maxRows)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataSet CandidatesharedJobpopup(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call CandidatesharedJobpopup(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        } 
        public DataSet Clientinterviewscedulelist(ClientModel model)
        {
             
            if (model.todate == "" && model.todate == " ")
            {
                model.todate = null;
            }
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                    new MySqlParameter("Title",model.Title),
                    new MySqlParameter("UserId",model.UserId),
                    new MySqlParameter("JobId",model.JobId),
                    new MySqlParameter("fromdate",model.fromdate),
                    new MySqlParameter("todate",model.todate),
                    new MySqlParameter("OffsetId",model.OffsetId),
                    new MySqlParameter("maxRows",model.maxRows),
                    new MySqlParameter("ClientId",model.ClientId),
                    new MySqlParameter("Id",model.Id),
                    new MySqlParameter("CompletedOffsetId",model.CompletedOffsetId),
                    new MySqlParameter("CompletedmaxRows",model.CompletedmaxRows),
            };

            string Query = "call sp_Clientinterviewscedulelist(@Title,@UserId,@JobId,@fromdate,@todate,@OffsetId,@maxRows,@ClientId,@Id,@CompletedOffsetId,@CompletedmaxRows)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataTable getsharedjobbyclientid(CandidateModel model)
        {
            if (model.Ids == null)
            {
                model.Ids = "0";
            }
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("@Id",model.Id),
                    new MySqlParameter("@Ids",model.Ids),
                     new MySqlParameter("@CompanyId",model.CompanyId),
            };
            string Query = "call sp_getsharedjobbyclientid(@Id,@Ids,@CompanyId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }


        public void AddSharedJobcandidatebyId(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",model.UserId),
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("sharedJobCheckId",model.sharedJobCheckId),

                  new MySqlParameter("Typeid",model.Typeid),
                new MySqlParameter("ClientId",model.ClientId),
                new MySqlParameter("description",model.description),
                };
            // candidate submit 
            string Query = "call Sp_AddSharedJobcandidatebyId(@UserId,@Id,@sharedJobCheckId,@Typeid,@ClientId,@description)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            if (dt.Rows.Count > 0)
            {
                model.StatusId = Convert.ToInt64(dt.Rows[0]["Status"]);
            }
        }

        public void SubmitCandidateProfile(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",model.UserId),
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("sharedJobCheckId",model.sharedJobCheckId),
                };

            string Query = "call Sp_AddSharedJobcandidatebyId(@UserId,@Id,@sharedJobCheckId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            if (dt.Rows.Count > 0)
            {
                model.StatusId = Convert.ToInt64(dt.Rows[0]["Status"]);
            }
        }
        public void SaveTransaction(PlansViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",model.UserId),
                new MySqlParameter("PlanId",model.PlanId),
                new MySqlParameter("transactionno",model.transactionno),
                new MySqlParameter("Amount",model.Amount)
            };
            string Query = "call sp_savetransaction(@UserId,@PlanId,@transactionno,@Amount)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
        }
        public void PlanDelete(PlanModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_PlanDelete(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void CreatePlan(PlanModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("UserId",model.UserId),
                new MySqlParameter("Name",model.Name),
                new MySqlParameter("Price",model.Price),
                new MySqlParameter("noofjob",model.noofjob),
                new MySqlParameter("noofinterview",model.noofinterview),
                new MySqlParameter("noofsubmission",model.noofsubmission),
                new MySqlParameter("Description",model.Description),
                new MySqlParameter("PlanStatusId",model.PlanStatusId),
                new MySqlParameter("PlanTypeId",model.PlanTypeId),
                new MySqlParameter("Subscription",model.Subscription),
                new MySqlParameter("StripePriceid",model.StripePriceid),
                new MySqlParameter("StripeProductId",model.StripeProductId),
            };
            string Query = "call Sp_CreatePlan(@Id,@UserId,@Name,@Price,@noofjob,@noofinterview,@noofsubmission,@Description,@PlanStatusId,@PlanTypeId,@Subscription,@StripePriceid,@StripeProductId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet PlanCreatepopup(PlanModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                   new MySqlParameter("UserId", model.UserId)
            };
            string Query = "call Sp_PlanCreatepopup(@Id,@UserId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataSet CDetail(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call Sp_getCDetail(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public void InterViewdelete(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call Sp_InterViewdelete(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet interviewStatusPopup(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                 new MySqlParameter("CandidateId",model.CandidateId),
                  new MySqlParameter("UserId",model.UserId),
                   new MySqlParameter("CompanyId",model.CompanyId),
                   new MySqlParameter("JobId",model.JobId),
            };
            string Query = "call Sp_interviewStatusPopup(@CandidateId,@UserId,@CompanyId,@JobId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public void Interviewstatus(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("InterviewSId",model.ContactIs),
                  new MySqlParameter("JobId",model.JobId),
                new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call Sp_Interviewstatus(@Id,@InterviewSId,@JobId,@UserId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void JobAppliedDeletebyId(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                 new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_JobAppliedDeletebyId(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
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
                  new MySqlParameter("typeid",model.tid),
                   new MySqlParameter("CompanyId",model.CompanyId)
                };
            string Query = "call sp_GetApplicant(@Email,@OffsetId,@maxRows,@UserId,@JobId,@jobStatus,@typeid,@CompanyId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public void ApplicantDelete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
             };
            string Query = "call sp_ApplicantDelete(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet Dashboard(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                 new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call sp_CandidateDashboard(@UserId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public void Candidateskillsvaluesave(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("CandidateId",model.CandidateId),
                  new MySqlParameter("skill",model.skill)
            };
            string Query = "call Sp_Candidateskillsvaluesave(@Id,@CandidateId,@skill)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void candidaterefrenceDelete(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call Sp_candidaterefrenceDelete(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void Candididaterefencessave(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                  new MySqlParameter("CandidateId",model.CandidateId),
                    new MySqlParameter("Name",model.Name),
                      new MySqlParameter("Phone",model.Phone),
                        new MySqlParameter("Email",model.PreferredEMail),
                         new MySqlParameter("Title",model.Title)
            };
            string Query = "call Sp_Candididaterefencessave(@Id,@CandidateId,@Name,@Phone,@Email,@Title)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet Candidateportfoliopopup(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("CandidateId",model.CandidateId)
            };
            string Query = "call Sp_Candidateportfoliopopup(@Id,@CandidateId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataSet GetAllCandidateList(CandidateListModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
            new MySqlParameter("StateId",model.StateId),
            new MySqlParameter("City",model.City),
            new MySqlParameter("Zip",model.Zip),
            new MySqlParameter("Title",model.Title),
            new MySqlParameter("maxRows",model.maxRows),
            new MySqlParameter("OffsetId",model.OffsetId),
            new MySqlParameter("gid",model.gid),
            new MySqlParameter("Keyword",model.Keyword),
            new MySqlParameter("checkId", model.checkId),
            new MySqlParameter("SearchId", model.SearchId),
            new MySqlParameter("Id", model.Id),
            };
            string Query = "call sp_GetAllCandidateList(@StateId,@City,@Zip,@Title,@maxRows,@OffsetId,@gid,@Keyword,@checkId,@SearchId,@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataSet CandidateVediopopu(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call sp_getCandidateVediopopup(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public void UploadVideo(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
               new MySqlParameter("p_Id",model.Id),
                new MySqlParameter("p_Userid",model.UserId),
                new MySqlParameter("p_Title",model.Title),
                new MySqlParameter("p_Videourl",model.VideoUrl),
                new MySqlParameter("p_description",model.description)
            };
            string Query = "call sp_UploadVideo(@p_Id,@p_Userid,@p_Title,@p_Videourl,@p_description)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet CandidateEducationpopup(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call Sp_CandidateEducationpopup(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public void createworkexperiencecandidate(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                   new MySqlParameter("CreateBy",model.CreateBy),
                    new MySqlParameter("Company",model.Company),
                 new MySqlParameter("Title",model.Title),
                  new MySqlParameter("Todate",model.Todate),
                   new MySqlParameter("Fromdate",model.Fromdate),
                    new MySqlParameter("description",model.description),
                       new MySqlParameter("visibleid",model.visibleid),
                      new MySqlParameter("CandidateId",model.CandidateId),
            };
            string Query = "call sp_createworkexperiencecandidate(@Id,@CreateBy,@Company,@Title,@Todate,@Fromdate,@description,@visibleid,@CandidateId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void SkillAddUpdate(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                   new MySqlParameter("CreateBy",model.CreateBy),
                 new MySqlParameter("skill",model.skill),
                    new MySqlParameter("CandidateId",model.CandidateId),
            };
            string Query = "call sp_SkillAddUpdate(@Id,@CreateBy,@skill,@CandidateId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataTable CityList(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("StateId",model.Id)
            };
            string Query = "call sp_GetCityByStateId(@StateId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable CandidateDetail(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call sp_CandidateDetail(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable StateList(CandidateModel model)
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
        public void createeducationcandidate(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("CreateBy",model.CreateBy),
                new MySqlParameter("Education",model.Education),
                new MySqlParameter("univarsity",model.univarsity),
                new MySqlParameter("year",model.EducaStartYear),
                 new MySqlParameter("EndYear",model.EducaEndYear),
                new MySqlParameter("description",model.description),
                 new MySqlParameter("visibleid",model.visibleid),
                new MySqlParameter("CandidateId",model.CandidateId),
            };
            string Query = "call Sp_createeducationcandidate(@Id,@CreateBy,@Education,@univarsity,@year,@EndYear,@description,@visibleid,@CandidateId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }



        public void addupdatelicensescertification(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("CreateBy",model.CreateBy),
                new MySqlParameter("Education",model.Education),
                new MySqlParameter("univarsity",model.univarsity),
                new MySqlParameter("year",model.year),
                 new MySqlParameter("EndYear",model.EndYear),
                new MySqlParameter("description",model.description),
                 new MySqlParameter("visibleid",model.visibleid),
                new MySqlParameter("CandidateId",model.CandidateId),
            };
            string Query = "call sp_addupdatelicensescertification(@Id,@CreateBy,@Education,@univarsity,@year,@EndYear,@description,@visibleid,@CandidateId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet candidatedetailbyId(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id) ,
                new MySqlParameter("JobId",model.JobId),
                 new MySqlParameter("UserId",model.UserId),
                 new MySqlParameter("CompanyId",model.CompanyId)
            };

            if (model.JobId != 0)
            {
                string Query = "call Sp_getcandidateprofile(@Id,@JobId,@UserId,@CompanyId)";
                connectstring.Open();
                ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
                connectstring.Close();
            }
            else
            {
                string Query = "call Sp_getmyfavouritedetail(@Id)";
                connectstring.Open();
                ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
                connectstring.Close();
            }
            //connectstring.Open();
            //ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            //connectstring.Close();
            return ds;
        }
        public DataTable UpdateCandidate(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("Name",model.Name),
              new MySqlParameter("LastName",model.LastName),
              new MySqlParameter("Phone",model.Phone),
                new MySqlParameter("PreferredEMail",model.PreferredEMail),
               new MySqlParameter("DesiredTitle1",model.DesiredTitle1),
               new MySqlParameter("DesiredTitle2",model.DesiredTitle2),
                 new MySqlParameter("Industry",model.Industry),
                new MySqlParameter("Title",model.Title),
                new MySqlParameter("CountryId",model.CountryId),
                new MySqlParameter("StateId", 0),
                new MySqlParameter("CityName",model.CityName),
                new MySqlParameter("Address1",model.Address1),
                new MySqlParameter("experience",model.experience),
                new MySqlParameter("JobTypeId",model.JobTypeId),
                new MySqlParameter("CurrentSalaryId",model.CurrentSalaryId),
                new MySqlParameter("expectedSalaryId",model.expectedSalaryId),
                new MySqlParameter("Educationlevels",model.Educationlevels),
                new MySqlParameter("Facebook",model.Facebook),
                new MySqlParameter("Twitter",model.Twitter),
                new MySqlParameter("Linkedin",model.Linkedin),
                new MySqlParameter("Description",model.description),
                new MySqlParameter("Zipcode",model.Zipcode),
                  new MySqlParameter("CreateBy",model.CreateBy),
                    new MySqlParameter("location",model.location),
                     new MySqlParameter("Certifications",model.Certifications),
                    new MySqlParameter("Relocation",model.Relocation),
                     new MySqlParameter("Featured",model.Featured),
            };
            string Query = "call Sp_UpdateCandidate(@Id,@Name,@LastName,@Phone,@PreferredEMail,@DesiredTitle1,@DesiredTitle2,@Industry,@Title,@CountryId,@StateId,@CityName,@Address1,@experience,@JobTypeId," +
                "@CurrentSalaryId,@expectedSalaryId,@Educationlevels,@Facebook,@Twitter,@Linkedin,@Description,@Zipcode,@CreateBy,@location,@Certifications,@Relocation,@Featured)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataSet candidateprofilepopup(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_UpdateCandidateprofile(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataTable Candidates(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_getCandidatedatabyId(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable CreateCandidate(CandidateModel model)
        {
            var salt = Guid.NewGuid().ToString().Replace('-', ' ');
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("Name",model.Name),
                 new MySqlParameter("LastName",model.LastName),
                new MySqlParameter("Email",model.Email.Trim()),
                new MySqlParameter("Phone",model.Phone),
                new MySqlParameter("Password",Craptography.Encrypt(model.Password.ToString(), salt)),
                new MySqlParameter("Title",model.Title),
                new MySqlParameter("UserId",model.UserId),
                new MySqlParameter("AccountType",model.AccountType),
                new MySqlParameter("Resumefile",model.Resumefile),
                  new MySqlParameter("salt",salt),
                  new MySqlParameter("CompanyId",0),
                   new MySqlParameter("CompanyuserTypeid",0),
            };
            string Query = "call Sp_CreateCandidate(@Id,@Name,@LastName,@Email,@Phone,@Password,@Title,@UserId,@AccountType,@Resumefile,@salt,@CompanyId,@CompanyuserTypeid)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable ResumeImageUpload(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("Resumefile",model.Resumefile),
                new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call sp_ResumeImageUpload(@Id,@Resumefile,@UserId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable ProfileImageUpload(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("Resumefile",model.FileName),
                new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call sp_ProfileImageUpload(@Id,@Resumefile,@UserId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataSet AddUpdateSkillsPopup(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call sp_GetcandidateSkillsbyId(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public void PlanActiveInactive(PlanModel model)
        {
            MySqlParameter[] Para = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("PlanStatusId",model.PlanStatusId),
            };
            string Query = "sp_PlanActiveInactive(@Id,@PlanStatusId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, Para);
            connectstring.Close();
        }
    }
}