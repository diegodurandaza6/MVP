using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using Web.Model.Paypal;

namespace Web.Dal.Payment
{
    public class PaymentDel
    {
        string connectstring;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();



        public PaymentDel()
        {
            connectstring = ConfigurationManager.ConnectionStrings["mySqlCon"].ToString();

        }

        public DataSet GetPlanById(PaymentViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("PlanId", model.PlanId),
                  new MySqlParameter("UserId", model.UserId)
            };
            string Query = "call Sp_PlanCreatepopup(@PlanId,@UserId)";
            return ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
        }
        public DataSet GetpaymentsuccessDetailById(PaymentViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
                  new MySqlParameter("PlanId", model.PlanId),
                   new MySqlParameter("UserId", model.UserId),
                  new MySqlParameter("PaymentId", model.PaymentId),
            };
            string Query = "call sp_GetpaymentsuccessDetailById(@PlanId,@UserId,@PaymentId)";
            return  ds = MySqlHelper.ExecuteDataset(connectstring, Query, commandParameters);
        }
        public void MakePayment(PaymentViewModel model)
        {
            MySqlParameter[] commandParameters = new MySqlParameter[]{
            new MySqlParameter("UserId", model.UserId),
            new MySqlParameter("PlanId", model.PlanId),
            new MySqlParameter("PlanName", model.PlanName),

            new MySqlParameter("Amount", model.Amount),
            new MySqlParameter("TransactionId", model.TransactionId),
            new MySqlParameter("CreditCardId", model.CreditCardId),
             new MySqlParameter("TypeId", 0),
             new MySqlParameter("PaymentId", model.PaymentId),
            };
            string Query = "call sp_MakePayment(@UserId,@PlanId,@PlanName, @Amount,@TransactionId,@CreditCardId,@TypeId,@PaymentId)";
            MySqlHelper.ExecuteNonQuery(connectstring, Query, commandParameters);
        }
    }
}



