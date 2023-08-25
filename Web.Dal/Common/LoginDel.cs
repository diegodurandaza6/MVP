using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Web.Core.Common.Impl;
using Web.Model.Candidate;
using Web.Model.Client;
using Web.Model.Common;
using Web.Model.Paypal;

namespace Web.Dal.Common
{
    public class LoginDel
    {
        MySqlConnection myConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["mySqlCon"].ToString());

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public DataSet CandidateLogin(LoginModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                    new MySqlParameter("Email",model.Email.ToLower()),
                    new MySqlParameter("UserTypeId",model.UsertypeId)
            };
            string Query = "call SpCandidateLogin(@Email,@UserTypeId)";
            myConnection.Open();
            ds = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters);
            myConnection.Close();
            return ds;
        }
        public void emailread(string ids)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", ids),
            };
            string Query = "call sp_emailread(@Id) ";
            myConnection.Open();
            MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters);
            myConnection.Close();
        }

        public DataSet unsubscribe(LoginModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                    new MySqlParameter("Id" ,model.ids),
            };
            string Query = "call sp_unsubscribe(@Id)";
            myConnection.Open();
            ds = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters);
            myConnection.Close();
            return ds;
        }
        public void ClientsendqueryDelete(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_ClientsendqueryDelete(@Id)";
            myConnection.Open();
            MySqlHelper.ExecuteNonQuery(myConnection, Query, commandParameters);
            myConnection.Close();
        }
        public void CreateContactUs(ContactUs model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                    new MySqlParameter("Name" ,model.Name),
                     new MySqlParameter("Email" ,model.Email),
                      new MySqlParameter("SubJect" ,model.SubJect),
                       new MySqlParameter("Message" ,model.Message),
                         new MySqlParameter("Phone" ,model.Phone),
                          new MySqlParameter("typeId" ,model.typeId),
                          new MySqlParameter("LastName" ,model.LastName),

            };
            string Query = "call Sp_CreateContactUs(@Name,@Email,@SubJect,@Message,@Phone,@typeId,@LastName)";
            myConnection.Open();
            dt = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters).Tables[0];
            myConnection.Close();
            if (dt.Rows.Count > 0)
            {
                model.typeId = Convert.ToInt64(dt.Rows[0]["typeid"]);
            }
        }

        public DataSet AppliedJob(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                  new MySqlParameter("UserId", model.UserId),


            };
            string Query = "call Sp_CandidateAppliedJobs(@Id,@UserId)";
            myConnection.Open();

            ds = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters);
            myConnection.Close();
            return ds;
        }

        public DataSet creategustcandidate(JobsModel model)
        {
            var salt = Guid.NewGuid().ToString().Replace('-', ' ');
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.JobId),
                  new MySqlParameter("FirstName", model.FirstName),
                       new MySqlParameter("LastName", model.LastName),
                            new MySqlParameter("Phone", model.Phone),
                                 new MySqlParameter("Email", model.Email),
                                      new MySqlParameter("FileName", model.FileName),
                                      new MySqlParameter("Password",Craptography.Encrypt(model.Password.ToString(), salt)),
                                      new MySqlParameter("salt", salt),

            };
            string Query = "call Sp_creategustcandidate(@Id,@FirstName,@LastName,@Phone,@Email,@FileName,@Password,@salt)";
            myConnection.Open();
            ds = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters);
            myConnection.Close();
            return ds;
        }



        public void sendemail(JobsModel model)
        {

            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                  new MySqlParameter("CretedBy", model.CretedBy),
                  new MySqlParameter("Email", model.Email),
                   new MySqlParameter("subject", model.subject),
                    new MySqlParameter("description", model.description),
            };
            string Query = "call Sp_sendemail(@Id,@CretedBy,@Email,@subject,@description)";
            myConnection.Open();
            MySqlHelper.ExecuteNonQuery(myConnection, Query, commandParameters);
            myConnection.Close();
        }

        public void MakeFreePayment(PaymentViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("UserId", model.UserId),
                  new MySqlParameter("PlanId", model.PlanId),
            };
            string Query = "call sp_MakeFreePayment(@UserId,@PlanId)";
            myConnection.Open();
            MySqlHelper.ExecuteNonQuery(myConnection, Query, commandParameters);
            myConnection.Close();
            model.result = 1;
        }

        public string getzipcodeforzipcodesizedecrease(string zip)
        {
            string zipcodes = "";
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                    new MySqlParameter("p_Id",zip),
            };
            string Query = "call getzipcodeforzipcodesizedecrease(@p_Id)";
            myConnection.Open();
            dt = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters).Tables[0];
            myConnection.Close();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    zipcodes += dt.Rows[i]["Zipcode"].ToString() + ",";
                } 
            }
            return zipcodes;
        }

        public DataSet requestmoreinfo(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                  new MySqlParameter("UserId", model.UserId),
            };
            string Query = "call Sp_requestmoreinfo(@Id,@UserId)";
            myConnection.Open();

            ds = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters);
            myConnection.Close();
            return ds;
        }

        public void getIds(JobsModel model)
        {
            string jobIds = "0";
            myConnection.Open();

            string[] multiArray = model.Tags.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            foreach (string tag in multiArray)
            {

                MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Tags",tag)
                 };
                string Query = "call getjobIdbyTagName(@Tags)";

                dt = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters).Tables[0];

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        jobIds += dt.Rows[i]["JobId"] is DBNull ? "0" : dt.Rows[i]["JobId"].ToString() + ",";
                    }

                    model.jobIds = jobIds.Remove(jobIds.Length - 1, 1);

                }
            }
            myConnection.Close();

        }

        public DataTable getemailbyId(JobsModel model)
        {
            string email = "";
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                    new MySqlParameter("Ids",model.Ids),
            };
            string Query = "call sp_getcandidateemailbyId(@Ids)";
            myConnection.Open();
            dt = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters).Tables[0];
            myConnection.Close();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    email += dt.Rows[i]["Email"].ToString() + ",";
                }
                model.Email = email.Remove(email.Length - 1, 1);
            }

            return dt;
        }

        public DataSet ZipRecruiter()
        {
            string Query = "call Sp_ZipRecruiter()";
            myConnection.Open();
            ds = MySqlHelper.ExecuteDataset(myConnection, Query);
            myConnection.Close();

            if (ds.Tables[0].Rows.Count > 0)
            {
                myConnection.Open();
                string jobid = "";
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    jobid = jobid + ds.Tables[0].Rows[i]["Id"].ToString() + ',';
                }
                MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("_jobid", jobid)
                };
                string Query1 = "call sp_insertjobpostonZipRecruiterhistory(@_jobid)";

                MySqlHelper.ExecuteNonQuery(myConnection, Query1, commandParameters);
                myConnection.Close();
            }


            return ds;
        }

        public void alertunsubscribe(string alertid, string alerttypeId)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("_id", alertid),
                     new MySqlParameter("alerttypeid", alerttypeId),
            };
            string Query = "call sp_alertunsubscribe(@_id,@alerttypeid)";
            myConnection.Open();
            MySqlHelper.ExecuteNonQuery(myConnection, Query, commandParameters);
            myConnection.Close();
        }

        public void savejobalert(jobalertviewmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("JobTitle", model.JobTitle),
                  new MySqlParameter("location", model.location),
                  new MySqlParameter("AlertName", model.AlertName),
                  new MySqlParameter("Name", model.Name),
                  new MySqlParameter("Email", model.Email),
                  new MySqlParameter("alertid", model.alertid),
            };
            string Query = "call sp_savejobalert(@JobTitle,@location,@AlertName,@Name,@Email,@alertid)";
            myConnection.Open();
            MySqlHelper.ExecuteNonQuery(myConnection, Query, commandParameters);
            myConnection.Close();
        }

        public void NewletterCreate(LoginModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Name",model.Name),
                new MySqlParameter("Email",model.Email),
            };
            string Query = "call Sp_NewletterCreate(@Name,@Email)";
            myConnection.Open();
            MySqlHelper.ExecuteNonQuery(myConnection, Query, commandParameters);
            myConnection.Close();
        }

        public void Campaignread(string campiganId, string contactId)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("campiganId",campiganId),
                new MySqlParameter("contactId",contactId),
            };
            string Query = "call campaignloghistory(@campiganId,@contactId)";
            myConnection.Open();
            MySqlHelper.ExecuteNonQuery(myConnection, Query, commandParameters);
            myConnection.Close();
        }

        public DataTable GetLocation(LoginModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                  new MySqlParameter("location",model.location),
            };
            string Query = "call spGetLocation_1(@location)";
            myConnection.Open();
            dt = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters).Tables[0];
            myConnection.Close();
            return dt;
        }

        public DataTable plandetails(PlanModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call sp_plandetailsById(@Id)";
            myConnection.Open();
            dt = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters).Tables[0];
            myConnection.Close();
            return dt;
        }

        public DataTable plan(PlanModel model)
        {
            string Query = "call Sp_PlanHomelist()";
            myConnection.Open();
            dt = MySqlHelper.ExecuteDataset(myConnection, Query).Tables[0];
            myConnection.Close();
            return dt;
        }

        public DataTable Jobsautocomplete(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Name",model.Name),
            };
            string Query = "call Sp_Jobsautocomplete(@Name)";
            myConnection.Open();
            dt = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters).Tables[0];
            myConnection.Close();
            return dt;
        }

        public DataTable CandidateJobapplyLogin(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                    new MySqlParameter("Email",model.Email.ToLower()),
                    new MySqlParameter("UserTypeId",3)
            };
            string Query = "call Sp_CandidateJobapplyLogin(@Email,@UserTypeId)";
            myConnection.Open();
            dt = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters).Tables[0];
            myConnection.Close();
            return dt;
        }

        public void JobSave(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                  new MySqlParameter("UserId", model.UserId),
            };
            string Query = "call Sp_JobSave(@Id,@UserId)";
            myConnection.Open();
            MySqlHelper.ExecuteNonQuery(myConnection, Query, commandParameters);
            myConnection.Close();
        }

        public DataSet GetHomeIndex(JobsModel model)
        {
            try
            {
                MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.UserId),
                };
                string Query = "call Sp_GetHomeIndex(@Id)";
                myConnection.Open();
                ds = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters);
                myConnection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                myConnection.Close();
                throw;
            }
        }

        public DataSet job(JobsModel model)
        {

            MySqlParameter[] commandParameters = new MySqlParameter[]{
                new MySqlParameter("jobtitle", model.jobtitle),
                new MySqlParameter("StateId", model.StateId),
                new MySqlParameter("City", model.City),
                new MySqlParameter("JobCategoryId", model.Jobcatagory),
                new MySqlParameter("JobStatusId", model.JobStatusId),
                new MySqlParameter("JobTypeId", model.Jobtype),
                new MySqlParameter("maxRows", model.maxRows),
                new MySqlParameter("OffsetId", model.OffsetId),
                new MySqlParameter("days", model.days),
                new MySqlParameter("checkId", model.checkId),
                new MySqlParameter("searchId", model.searchId),
                new MySqlParameter("Tags", model.Tags),
            };
            string Query = "call Sp_SearchJob(@jobtitle,@StateId,@City,@JobCategoryId,@JobStatusId,@JobTypeId,@maxRows,@OffsetId,@days,@checkId,@searchId,@Tags)";
            myConnection.Open();
            ds = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters);
            myConnection.Close();
            return ds;
        }
        public void ClientSendenquery(ClientModel model)
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
            string Query = "call Sp_ClientSendenquery(@Id,@CandidateId,@Name,@Email,@Phone1,@JobId,@Description)";
            myConnection.Open();
            dt = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters).Tables[0];
            myConnection.Close();



        }
        public DataSet CandidateDetailsbyId(CandidateModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("UserId",model.UserId),
                 new MySqlParameter("JobTypeId",model.JobTypeId),
                  new MySqlParameter("location",model.location) ,
                  new MySqlParameter("ClientId",model.ClientId) ,

            };
            string Query = "call Sp_CandidateDetailsbyId(@Id,@UserId,@JobTypeId,@location,@ClientId)";
            myConnection.Open();
            ds = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters);
            myConnection.Close();
            return ds;
        }

        public void confirmation(LoginModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                    new MySqlParameter("UserId" ,model.UserId),

            };
            string Query = "call sp_confirmation(@UserId)";
            myConnection.Open();
            MySqlHelper.ExecuteNonQuery(myConnection, Query, commandParameters);
            myConnection.Close();
        }

        public void unsubscribeClick(LoginModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                    new MySqlParameter("Id",model.ids),
                    new MySqlParameter("IsSubscribed",model.IsSubscribed)

            };
            string Query = "call sp_Updateunsubscribe(@Id,@IsSubscribed)";
            myConnection.Open();
            MySqlHelper.ExecuteNonQuery(myConnection, Query, commandParameters);
            myConnection.Close();
        }

        public DataTable CreateCandidate(LoginModel model)
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
                  new MySqlParameter("Company",model.Company),
                new MySqlParameter("CompanyuserTypeid",model.CompanyuserTypeid),
            };
            string Query = "call Sp_CreateCandidate(@Id,@Name,@LastName,@Email,@Phone,@Password,@Title,@UserId,@AccountType,@Resumefile,@salt,@Company,@CompanyuserTypeid)";
            myConnection.Open();
            dt = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters).Tables[0];
            myConnection.Close();
            return dt;
        }


        public void updateforgotPassword(LoginModel model)
        {
            var salt = Guid.NewGuid().ToString().Replace('-', ' ');
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                    new MySqlParameter("Password",Craptography.Encrypt(model.Password.ToString(), salt)),
                     new MySqlParameter("salt",salt),
            };
            string Query = "call sp_updateforgotPassword(@Id,@Password,@salt) ";
            myConnection.Open();
            MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters);
            myConnection.Close();
        }

        public void ChangePasswordEmail(LoginModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                    new MySqlParameter("Id",model.Id),
            };
            string Query = "call spGetPasswordById(@Id)";
            myConnection.Open();
            DataTable dt = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters).Tables[0];
            if (dt.Rows.Count > 0)
            {
                var decryptPassword = Craptography.Decrypt(dt.Rows[0]["Password"].ToString(), dt.Rows[0]["Salt"].ToString());
                if (model.oldPassword == decryptPassword)
                {
                    var salt = Guid.NewGuid().ToString().Replace('-', ' ');
                    MySqlParameter[] commandParameters1 = new MySqlParameter[]{
                        new MySqlParameter("Id",model.Id),
                        new MySqlParameter("Password",Craptography.Encrypt(model.NewPassword.ToString(), salt)),
                        new MySqlParameter("Salt",salt),
                     };
                    string Query1 = "call sp_Updatepassword(@Id,@Password,@Salt)";
                    ds = MySqlHelper.ExecuteDataset(myConnection, Query1, commandParameters1);
                    model.Status = 1;
                }
                else
                {
                    model.Status = 2;
                }
            }
            else
            {
                model.Status = 3;
            }
            myConnection.Close();
        }
        public DataSet ForgotPasswordEmail(LoginModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                    new MySqlParameter("Email",model.Email.ToLower())
            };
            string Query = "call Sp_ForgotPasswordEmail(@Email)";
            myConnection.Open();
            ds = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters);
            myConnection.Close();
            return ds;
        }


        public DataSet GetAllMenuSubmenu()
        {

            string Query = "call sp_GetAllMenuSubmenu()";
            myConnection.Open();
            ds = MySqlHelper.ExecuteDataset(myConnection, Query);
            myConnection.Close();
            return ds;
        }



        public int CheckPermission(string area, string Controller, string Action, int RoleId)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                    new MySqlParameter("Area", area),
                    new MySqlParameter("Controller", Controller),
                    new MySqlParameter("Action", Action),
                    new MySqlParameter("RoleId", RoleId)
            };
            string Query = "call sp_GetAllMenuSubmenu(@Area, @Controller,@Action,@RoleId)";


            myConnection.Open();
            dt = MySqlHelper.ExecuteDataset(myConnection, Query, commandParameters).Tables[0];
            myConnection.Close();
            return Convert.ToInt32(dt.Rows[0]["valid"]);
        }


        public DataTable GetAllZipCodewithlatlong()
        {

            string Query = "call sp_GetAllZipCodewithlatlong()";
            myConnection.Open();
            dt = MySqlHelper.ExecuteDataset(myConnection, Query).Tables[0];
            myConnection.Close();
            return dt;
        }



    }
}
