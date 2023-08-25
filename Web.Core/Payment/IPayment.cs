using Web.Model.Paypal;

namespace Web.Core.Payment
{
    public interface IPayment
    {
        void GetPlanById(PaymentViewModel model);
        void GetpaymentsuccessDetailById(PaymentViewModel model);
        void MakePayment(PaymentViewModel model);
    }
}
