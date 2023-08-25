using System;
using System.Data;
using Web.Model.Paypal;

namespace Web.Core.Payment.Impl
{
    public class PaymentFactory
    {
        internal void GetPlanById(PaymentViewModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.PlanName = ds.Tables[0].Rows[0]["Name"].ToString();

                
                model.StripePriceid = ds.Tables[0].Rows[0]["StripePriceid"].ToString();

                model.Amount = ds.Tables[0].Rows[0]["Price"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
            }
            if (ds.Tables[3].Rows.Count>0)
            {
                model.CusId = Convert.ToString(ds.Tables[3].Rows[0]["CreditCardId"]);
            }
        }


        internal void GetpaymentsuccessDetailById(PaymentViewModel model, DataSet ds)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.PlanName = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Amount = ds.Tables[0].Rows[0]["Price"].ToString();
                model.Description = ds.Tables[0].Rows[0]["Description"].ToString();
                model.StripePriceid = ds.Tables[0].Rows[0]["StripePriceid"].ToString();;
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                model.transactionno = ds.Tables[1].Rows[0]["transactionno"].ToString();
                model.PaymentId = ds.Tables[1].Rows[0]["paymentId"].ToString();
                 
            }

        }

    }
}
