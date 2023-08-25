using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using Web.Core.Common.Impl;
using Web.Model.Admin;
using Web.Model.Client;
using Web.Model.Common;

namespace Web.Dal.Admin
{
    public class AdminDel
    {
        //string connectstring;
        //public AdminDel()
        //{
        //    connectstring = ConfigurationManager.ConnectionStrings["mySqlCon"].ToString();
        //}
        MySqlConnection connectstring = new MySqlConnection(ConfigurationManager.ConnectionStrings["mySqlCon"].ToString());
        DataTable dt = new DataTable();
        public void unsubscribecontect(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                  new MySqlParameter("Subscribe",model.Subscribe),
                   new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call sp_unsubscribecontect(@Id,@Subscribe,@UserId)";
            connectstring.Open();
            MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet emailpopup(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                 new MySqlParameter("ClientId",model.ClientId),
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call sp_GetemailbyId(@ClientId,@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        DataSet ds = new DataSet();
        public DataTable CityList(ClientModel model)
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
        public void ClientDelete(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("Status",model.Status)
            };
            string Query = "call sp_ClientDelete(@Id,@Status)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet clientdetail(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call sp_GetclientdetailbyId(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataSet ClientList(ClientModel model)
        {
            if (model.ZipCode == null)
            {
                model.ZipCode = "0";
            }
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Name",model.Name),
                  new MySqlParameter("Zip",model.ZipCode),
                  new MySqlParameter("Location",model.Location),
                    new MySqlParameter("maxRows",model.maxRows),
                      new MySqlParameter("OffsetId",model.OffsetId),
            };
            string Query = "call SpGetClientList(@Name,@Zip,@Location,@maxRows,@OffsetId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataTable AddUpdateCompany(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("name",model.Name),
                new MySqlParameter("Website",model.Website),
                 new MySqlParameter("Location",model.Location),
                new MySqlParameter("Zip",model.Zip),
                 new MySqlParameter("Address",model.Address),
                new MySqlParameter("UserId",model.UserId),
                 new MySqlParameter("Description",model.Description),
                 new MySqlParameter("FileName",model.FileName),
            };
            string Query = "call sp_AddUpdateCompany(@Id,@name,@Website,@Location,@Zip,@Address,@UserId,@Description,@FileName)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            model.Status = 1;
            connectstring.Close();
            return dt;
        }
        public void Admin_DeleteCompanyContact(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)

            };
            string Query = "call sp_Admin_DeleteCompanyContact(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void DeleteCompanyContact(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("Status",model.Status),
            };
            string Query = "call sp_deletecompanycontact(@Id,@Status)";
            connectstring.Open();
            MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataTable emailsendDetailsById(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.ContactId),
            };
            string Query = "call emailsendDetailsById(@Id)";
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public void changePipelinestatusConfirm(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                  new MySqlParameter("StatusId",model.StatusId),
                   new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call sp_changePipelinestatusConfirm(@Id,@StatusId,@UserId)";
            connectstring.Open();
            MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet pipeline(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call sp_pipeline(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataTable MeetingActiveTab(Dashboardmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call Sp_MeetingActiveTab(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public void pipelinestatus(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("ContactIds",model.ContactIds),
                new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call sp_changepipelinestatus(@Id,@ContactIds,@UserId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet InterviewSceduleList(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("UserId",model.UserId),
                 new MySqlParameter("JobId",model.JobId),
                   new MySqlParameter("Id",model.Id),
                    new MySqlParameter("CompanyId",model.CompanyId),
            };
            string Query = "call Sp_InterviewList(@UserId,@JobId,@Id,@CompanyId)";
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

        public DataSet NewCampaign(CampaignModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)

            };
            string Query = "call Sp_NewCampaign(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataSet campaignhistory(CampaignModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("CampaignId",model.CampaignId)

            };
            string Query = "call Sp_campaignhistory(@CampaignId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataTable getTagBytypeId(CampaignModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)

            };
            string Query = "call getTagBytypeId(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public void Updatesharejobsstatus(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("JobId",model.JobId),
                new MySqlParameter("JobPostStatus",model.JobPostStatus)
            };
            string Query = "call Sp_Updatesharejobsstatus(@JobId,@JobPostStatus)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();

        }

        public DataTable AdminUsermanage(UserManagmentmodel model)
        {
            var salt = Guid.NewGuid().ToString().Replace('-', ' ');
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                   new MySqlParameter("Id", model.Id),
                      new MySqlParameter("UserId", model.UserId),
                          new MySqlParameter("RoleId", model.RoleId),
                 new MySqlParameter("FirstName", model.FirstName),
                       new MySqlParameter("LastName", model.LastName),
                            new MySqlParameter("Phoneno", model.Phoneno),
                                 new MySqlParameter("Email", model.Email),
                                      new MySqlParameter("Password",Craptography.Encrypt(model.Password.ToString(), salt)),
                                      new MySqlParameter("salt", salt),
                                        new MySqlParameter("AccounttypeId", model.AccounttypeId),
            };
            string Query = "call Sp_AdminUsermanage(@Id,@UserId,@RoleId,@FirstName,@LastName,@Phoneno,@Email,@Password,@salt,@AccounttypeId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataSet GeneralMessages(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                   new MySqlParameter("Id", model.Id),
                     new MySqlParameter("maxRows", model.maxRows),
                      new MySqlParameter("OffsetId", model.OffsetId),
                 new MySqlParameter("CreateBy", model.CreateBy),
                 new MySqlParameter("ClientName", model.Name),
            };
            string Query = "call sp_Generalmessage(@Id,@maxRows,@OffsetId,@CreateBy)";

            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }


        public DataTable AutoCompleteClient(ClientModel model)
        {

            MySqlParameter[] commandParameters = new MySqlParameter[] {
                   new MySqlParameter("ClientName", model.ClientName),

            };
            string Query = "call Sp_getAutoCompleteClient(@ClientName)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;

        }

        public DataTable ClientProfileById(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                   new MySqlParameter("Id", model.Id),

            };
            string Query = "call sp_getclientprofilebyId(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public void pipelinemessagesendbyadmin(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("Id", model.Id),
                     new MySqlParameter("FromId",model.FromId),
                     new MySqlParameter("ClientId",model.ClientId),
                     new MySqlParameter("CandidateId",model.CandidateId),
                     new MySqlParameter("description",model.description),
                     new MySqlParameter("Name",model.Name),
                     new MySqlParameter("JobId",model.JobId),
                     new MySqlParameter("ClientCandidateId",model.ClientCandidateId),

            };
            string Query = "call sp_pipelinemessagesendbyadmin(@Id,@FromId,@ClientId,@CandidateId,@description,@Name,@JobId,@ClientCandidateId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public DataTable CreateCompany(ClientModel model)
        {
            var salt = Guid.NewGuid().ToString().Replace('-', ' ');

            MySqlParameter[] commandParameters = new MySqlParameter[]{
                    new MySqlParameter("FirstName", model.FirstName),
                     new MySqlParameter("LastName", model.LastName),
                     new MySqlParameter("Email", model.Email),
                     new MySqlParameter("Company", model.Company),
                     new MySqlParameter("Address", model.Address),
                     new MySqlParameter("Website", model.Website),
                     new MySqlParameter("Location", model.Location),
                     new MySqlParameter("Zip", model.Zip),
                    new MySqlParameter("UserId", model.UserId),
                    new MySqlParameter("Password", Craptography.Encrypt(model.Password.ToString(), salt)),
                    new MySqlParameter("salt", salt),
                    new MySqlParameter("CompanyuserTypeid", model.CompanyuserTypeid),
                     new MySqlParameter("LoginAccess", model.LoginAccess),
            };
            string Query = "call sp_CreateCompany(@FirstName,@LastName,@Email,@Company,@Address,@Location,@Zip,@UserId,@Password,@salt,@Website,@CompanyuserTypeid,@LoginAccess)";
            connectstring.Open();
            DataTable dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();

            return dt;
        }
         
        public void sendAdmingeneralmessages(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("fromId", model.fromId),
                    new MySqlParameter("ToId", model.ToId),
                     new MySqlParameter("Title",model.Title),
                     new MySqlParameter("Description",model.Description),
                     new MySqlParameter("Name",model.Name)
            };
            string Query = "call sp_sendAdmingeneralmessages(@fromId,@ToId,@Title,@Description,@Name)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public void savesendgeneralmessagebyadmin(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                   new MySqlParameter("Id", model.Id),
                    new MySqlParameter("ToId", model.ToId),
                      new MySqlParameter("UserId", model.UserId),
                       new MySqlParameter("CandidateId", model.CandidateId),
                     new MySqlParameter("Name", model.Name),
                    new MySqlParameter("Description", model.Description),

            };
            string Query = "call Sp_savesendgeneralmessagebyadmin(@Id,@ToId,@UserId,@CandidateId,@Name,@Description)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public DataSet generalmessagesdetails(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                   new MySqlParameter("Id", model.Id),
                    new MySqlParameter("UserId", model.UserId),

            };
            string Query = "call sp_getmessagesdetailsbyAdmin(@Id,@UserId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataSet messagesdetail(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                   new MySqlParameter("Id", model.Id),
            };
            string Query = "call sp_adminmessagesdetailbyId(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataSet messages(Candidateconversationmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                   new MySqlParameter("Id", model.Id),
                    new MySqlParameter("maxRows", model.maxRows),
                      new MySqlParameter("OffsetId", model.OffsetId),
            };
            string Query = "call sp_adminmessageslist(@Id,@maxRows,@OffsetId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public void deleteUsers(UserManagmentmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),


            };
            string Query = "call Sp_deleteUsers(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet addnewrole(RoleViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)

            };
            string Query = "call sp_addnewrole(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public void AddUpdateRole(RoleViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("Name",model.Name),
                new MySqlParameter("PageId",model.PageId),
                new MySqlParameter("description",model.description),
                new MySqlParameter("statusId",model.statusId),
                new MySqlParameter("CreateBy",model.CreateBy),
            };

            string Query = "call sp_AddUpdateRole(@Id,@Name,@PageId,@description,@statusId,@CreateBy)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();


        }

        public DataTable getpage(RoleListModel model)
        {

            string Query = "call sp_getpage()";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable Role(RoleListModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Name",model.Name)

            };
            string Query = "call sp_RoleList(@Name)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;

        }

        public DataTable UserList(UserManagmentmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("Email",model.Email)

            };
            string Query = "call SP_UserList(@Id,@Email)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;

        }

        public DataSet Users(UserManagmentmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)

            };
            string Query = "call Sp_Users(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public DataTable sharjobIdziprecuiter(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)

            };
            string Query = "call Sp_sharjobIdziprecuiter(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public void alertunactiveJobbyId(Alertmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("StatusId",model.StatusId),

            };
            string Query = "call SP_alertunactiveJobbyId(@Id,@StatusId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();

        }

        public DataSet Alert(Alertmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("email",model.Email),
                new MySqlParameter("AlertId",model.AlertId)

            };
            string Query = "call Sp_getalertlist(@Id,@email,@AlertId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public void DeleteNewletter(EnquiresViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)

            };
            string Query = "call Sp_DeleteNewletter(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public DataTable NewLetter(EnquiresViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Name",model.Name)

            };
            string Query = "call Sp_NewLetter(@Name)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public void DeleteCampaign(CampaignModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)

            };
            string Query = "call Sp_DeleteCampaign(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }

        public DataSet Campaign(CampaignModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Name",model.Name)

            };
            string Query = "call Sp_CampaignList(@Name)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }

        public void AddUpdateCampaign(CampaignModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
            new MySqlParameter("Id",model.Id),
            new MySqlParameter("Name",model.Name),
            new MySqlParameter("Subject",model.Subject),
            new MySqlParameter("emailbody",model.emailbody),
            new MySqlParameter("CStatusId",model.CStatusId),
            new MySqlParameter("CreateBy",model.CreateBy),
            new MySqlParameter("campaigntypeid",model.campaigntypeid),
            new MySqlParameter("tagids",model.tagids),
            new MySqlParameter("tagidsforcount",model.tagids),
            };
            string Query = "call Sp_AddUpdateCampaign(@Id,@Name,@Subject,@emailbody,@CStatusId,@CreateBy,@campaigntypeid,@tagids)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
        }

        public DataSet sharedJob(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("ClientId",model.ClientId),
                  new MySqlParameter("JobStatusId",model.JobStatusId),
                  new MySqlParameter("maxRows",model.maxRows),
                      new MySqlParameter("OffsetId",model.OffsetId)
            };
            string Query = "call Sp_sharedJob(@Id,@ClientId,@JobStatusId,@maxRows,@OffsetId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataTable emailEditpopup(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call Sp_emailEditpopup(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public void Updateemailsend(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                 new MySqlParameter("CreateBy",model.CreateBy),
                  new MySqlParameter("Subject",model.Subject),
                   new MySqlParameter("Description1",model.Description1),
                    new MySqlParameter("Description2",model.Description2),
                      new MySqlParameter("Description3",model.Description3),
            };
            string Query = "call SP_Updateemailsend(@Id,@CreateBy,@Subject,@Description1,@Description2,@Description3)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void UpdatedEmaildetailById(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.email_id),
                new MySqlParameter("Description",model.Description),
            };
            string Query = "call sp_updatedemaildetailbyid(@Id,@Description)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        // kkk
        public DataSet SubmissionProfile(JobsModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("JobId",model.JobId),
               new MySqlParameter("JobStatusId",model.JobStatusId),
            };
            string Query = "call Sp_SubmissionProfile(@JobId,@JobStatusId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataSet Createuploadresumesave(JobsModel model)
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
            string Query = "call Sp_Createuploadresumesave(@Id,@FirstName,@LastName,@Phone,@Email,@FileName,@Password,@salt)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataTable AssignList(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_AssignList(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public void Createassignpay(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("UserId",model.UserId),
                       new MySqlParameter("Number",model.Number),
                              new MySqlParameter("DueDate",model.DueDate),
                                  new MySqlParameter("Amount",model.Amount),
                                      new MySqlParameter("Point",model.Point),
            };
            string Query = "call Sp_Createassignpay(@Id,@UserId,@Number,@DueDate,@Amount,@Point)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataTable getassignByEmail(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Email",model.Email),
            };
            string Query = "call Sp_getassignByEmail(@Email)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
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
        public DataSet UpdateInterviewschedule(ClientModel model)
        {
            var Date = model.InterviewDate.Substring(0, 10);
            string[] subs = Date.Split('-');

            var InterviewDate = subs[2] + "-" + subs[0] + "-" + subs[1];


            string[] settime = model.InterviewDate.Split(' ');
            var Time = settime[1] + " " + settime[2];

            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("UserId",model.UserId),
                new MySqlParameter("JobId",model.JobId),
                new MySqlParameter("ClientId",model.ClientId),
                new MySqlParameter("CandidateId",model.CandidateId),
                new MySqlParameter("CandidateName",model.CandidateName),
                new MySqlParameter("Email",model.Email),
                new MySqlParameter("ClientName",model.ClientName),
                new MySqlParameter("ClientEmail",model.ClientEmail),
                new MySqlParameter("InterviewBcc",model.InterviewBcc),
                new MySqlParameter("InterviewCc",model.InterviewCc),
                new MySqlParameter("InterviewDate",InterviewDate /*model.InterviewDate*/),
                new MySqlParameter("candidateTitle",model.candidateTitle),
                new MySqlParameter("Location",model.Location),
                new MySqlParameter("Description",model.Description),
                new MySqlParameter("Time", Time),
            };
            string Query = "call Sp_UpdateInterviewschedule(@Id,@UserId,@JobId,@ClientId,@CandidateId,@CandidateName,@Email,@ClientName,@ClientEmail,@InterviewBcc,@InterviewCc,@candidateTitle,@InterviewDate,  @Location,@Description,@Time)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Status = Convert.ToInt64(ds.Tables[0].Rows[0]["StatusId"]);

            }
            return ds;
        }
        public DataTable shortlist(ClientModel model)
        {

            string query = "call sp_Getshortlistcandidate()";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, query).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable interviewsrequestbycandidates(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Email",model.Email),
                new MySqlParameter("UserId",model.UserId),
                    new MySqlParameter("maxRows", model.maxRows),
                      new MySqlParameter("OffsetId", model.OffsetId),
            };
            string query = "call sp_interviewsrequestbycandidates(@Email,@UserId,@maxRows,@OffsetId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable ClientSendenquery(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Email",model.Email),
                new MySqlParameter("UserId",model.UserId),
                    new MySqlParameter("maxRows", model.maxRows),
                      new MySqlParameter("OffsetId", model.OffsetId),
            };
            string query = "call Sp_ClientSendenquerylist(@Email,@UserId,@maxRows,@OffsetId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable GetCompanyIdByEmail(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Email",model.Email),
            };
            string Query = "call spGetCompanyIdByEmail(@Email)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
            //if (dt.Rows.Count > 0)
            //{
            //    model.Id = Convert.ToInt64(dt.Rows[0]["clientid"].ToString());
            //}
            //else
            //{
            //    model.Id = 0;
            //}
        }
        public void companytodoactive(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call Sp_companytodoActive(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void companytodounactive(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call Sp_companytodounactive(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void CreatecompanyToDo(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("UserId",model.UserId),
                 new MySqlParameter("ClientId",model.ClientId),
                  new MySqlParameter("Subject",model.Subject),
                   new MySqlParameter("Email",model.Email),
                    new MySqlParameter("Date",model.DueDate),
                    new MySqlParameter("ZoneId",model.ZoneId),
                    new MySqlParameter("Description",model.Description),
                     new MySqlParameter("TypeId",model.TypeId)
            };
            string Query = "call Sp_CreatecompanyToDo(@Id,@UserId,@ClientId,@Subject,@Email,@Date,@ZoneId,@Description,@TypeId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet AddCompanyToDoPopUp(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call sp_AddCompanyToDoPopUp(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public void NOtesDelete(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call Sp_NOtesDelete(@Id)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void SaveNotes(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                  new MySqlParameter("UserId",model.UserId),
                   new MySqlParameter("comments",model.comments)
            };
            string Query = "call Sp_SaveNotes(@Id,@UserId,@comments)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet Dashboarddetail(Dashboardmodel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.UserId)
            };
            string Query = "call Sp_DashboardDetail(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public void enquerydelete(EnquiresViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                   new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call sp_enquerydelete(@Id,@UserId)";
            connectstring.Open();
            MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void ChanageFollowUpStatus(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                  new MySqlParameter("StatusId",model.StatusId),
                   new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call sp_ChanageFollowUpStatus(@Id,@StatusId,@UserId)";
            connectstring.Open();
            MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void inseremaildetail(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("ContactId",model.ContactId),
                new MySqlParameter("TemplateId",model.TemplateId),
                new MySqlParameter("Subject",model.Subject),
                new MySqlParameter("Description",model.Description),
                new MySqlParameter("Description1",model.Description1),
                new MySqlParameter("Description2",model.Description2),
                new MySqlParameter("Description3",model.Description3),
                new MySqlParameter("UserId",model.UserId),
                new MySqlParameter("isfollow",model.isfollow),
                new MySqlParameter("FirstFollowDate", date(model.FirstFollowDate)),
                new MySqlParameter("secondFollowDate", date(model.secondFollowDate) ),
                new MySqlParameter("thirdfollowdate", date(model.thirdfollowdate )),
                new MySqlParameter("GroupId", model.GroupId ),
            };
            string Query = "call sp_inseremaildetail(@Id,@ContactId,@TemplateId,@Subject,@Description,@Description1,@Description2,@Description3,@UserId,@isfollow,@FirstFollowDate,@secondFollowDate,@thirdfollowdate,@GroupId)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            if (dt.Rows.Count > 0)
            {
                model.email_id = Convert.ToInt64(dt.Rows[0]["emailid"]);
            }
            model.StatusId = 1;
        }


        public string date(string Fdate)
        {
            string d = null;
            if (Fdate != null)
            {
                string[] date = Fdate.Split('/');
                d = date[2] + "/" + date[0] + "/" + date[1];
            }
            return d;
        }

        public DataTable GetEmailTemplateById(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call sp_GetEmailTemplateById(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable getmessagebyId(EnquiresViewModel model)
        { 
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Email",model.Email), 
                 new MySqlParameter("Id",model.Id)
            };
            string Query = "call sp_getmessagebyId(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt; 
        }
        public DataTable replyenquire(EnquiresViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                  new MySqlParameter("UserId",model.UserId),
                    new MySqlParameter("replymessage",model.replymessage)
            };
            //string Query = "call sp_replyenquire(@Id,@UserId,@replymessage)";
            //MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            string Query = "call sp_replyenquire(@Id,@UserId,@replymessage)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable ClientContact(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
            };
            string Query = "call Sp_EditclientContact(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable AddClientContact(ClientModel model)
        {
            var salt = Guid.NewGuid().ToString().Replace('-', ' ');
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                    new MySqlParameter("Id",model.Id),
                    new MySqlParameter("CompanyId",model.CompanyId),
                    new MySqlParameter("Name",model.Name),
                    new MySqlParameter("LastName",model.LastName),
                    new MySqlParameter("Email",model.Email),
                    new MySqlParameter("Phone",model.Phone1),
                    new MySqlParameter("Position",model.Position),
                    new MySqlParameter("Linkdin",model.Linkdin),
                    new MySqlParameter("UserId",model.UserId),
                    new MySqlParameter("Password",Craptography.Encrypt(model.Password.ToString(), salt)),
                     new MySqlParameter("salt",salt),
                      new MySqlParameter("UseraccountprofileId",model.UseraccountprofileId),
                        new MySqlParameter("LoginAccess",model.LoginAccess),
                        new MySqlParameter("CompanyuserTypeid",model.CompanyuserTypeid),
            };
            string Query = "call Sp_AddClientContact(@Id,@CompanyId,@Name,@LastName,@Email,@Phone,@Position,@Linkdin,@UserId,@Password,@salt,@UseraccountprofileId,@LoginAccess,@CompanyuserTypeid)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public void updateprofile(ProfileViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.UserId),
                  new MySqlParameter("Name",model.Name),
                    new MySqlParameter("PhoneNo",model.PhoneNo),
                     new MySqlParameter("FileName",model.FileName),
                      new MySqlParameter("LastName",model.LastName),
                         new MySqlParameter("CompanyName",model.CompanyName),
                            new MySqlParameter("companywebsite",model.companywebsite),
                       new MySqlParameter("CountryId",model.CountryId),
                       new MySqlParameter("StateId",model.StateId),
                       new MySqlParameter("CityName",model.CityName),
                           new MySqlParameter("location",model.location)
            };
            string Query = "call sp_updateprofile(@Id,@Name,@PhoneNo,@FileName,@LastName,@CompanyName,@companywebsite,@CountryId,@StateId, @CityName,@location)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataSet profile(ProfileViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.UserId)
            };
            string Query = "call sp_profile(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
        }
        public DataSet enquires(EnquiresViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Email",model.Email),

                 new MySqlParameter("OffsetId",model.OffsetId),
                  new MySqlParameter("maxRows",model.maxRows),
                    new MySqlParameter("typeId",model.typeId)
            };
            string Query = "call sp_GetAllenquires(@Email,@OffsetId,@maxRows,@typeId)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds; 

        }
        public DataSet GetCompanyDetailById(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call sp_GetCompanyDetailById(@Id)";
            connectstring.Open();
            ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
            connectstring.Close();
            return ds;
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


        public DataTable getcontactbycompanyId(ClientModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call sp_getcontactbycompanyId(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }



        public void DeleteEmailTemplate(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("StatusId",model.StatusId)
            };
            string Query = "call sp_DeleteEmailTemplate(@Id,@StatusId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public void AddUpdateEmailTemplate(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id),
                new MySqlParameter("Name",model.Name),
                 new MySqlParameter("Subject",model.Subject),
                  new MySqlParameter("Description",model.Description),
                   new MySqlParameter("Description1",model.Description1),
                   new MySqlParameter("Description2",model.Description2),
                   new MySqlParameter("Description3",model.Description3),
                   new MySqlParameter("UserId",model.UserId),
            };
            string Query = "call sp_AddUpdateEmailTemplate(@Id,@name,@Subject,@Description,@Description1,@Description2,@Description3,@UserId)";
            connectstring.Open();
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
            connectstring.Close();
        }
        public DataTable GetEmailTempleteById(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Id",model.Id)
            };
            string Query = "call sp_GetEmailTempleteById(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }
        public DataTable email(EmailTempleteViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[] {
                new MySqlParameter("Name",model.Name),
                new MySqlParameter("EmailStatus",model.EmailStatus)
            };
            string Query = "call sp_getemailtempletelist(@Name,@EmailStatus)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters).Tables[0];
            connectstring.Close();
            return dt;
        }

        public DataTable ActivationEmailToContact(ClientModel model)
        {
            MySqlParameter[] mypara = new MySqlParameter[] {
            new MySqlParameter("Id",model.Id)
            };
            string Query = "Call sp_ActivationEmailToContact(@Id)";
            connectstring.Open();
            dt = MySqlHelper.ExecuteDataset(connectstring, Query, mypara).Tables[0];
            connectstring.Close();
            return dt;
        }
    }
}