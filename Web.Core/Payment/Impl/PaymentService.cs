
using System.Data;
using Web.Dal.Payment;
using Web.Model.Paypal;

namespace Web.Core.Payment.Impl
{
    public class PaymentService : IPayment
    {
        PaymentFactory _objPaymentFactory = new PaymentFactory();
        PaymentDel _objDelPayment = new PaymentDel();

        DataTable dt = new DataTable();
        DataSet ds = new DataSet();

        public void GetpaymentsuccessDetailById(PaymentViewModel model)
        {
            ds = _objDelPayment.GetpaymentsuccessDetailById(model);
            _objPaymentFactory.GetpaymentsuccessDetailById(model, ds);
        }

        public void GetPlanById(PaymentViewModel model)
        {
            ds = _objDelPayment.GetPlanById(model);
            _objPaymentFactory.GetPlanById(model, ds);
        }

        public void MakePayment(PaymentViewModel model)
        {
            _objDelPayment.MakePayment(model);

        }
    }
}
