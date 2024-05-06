using BusinessLogic.Interfaces.Services.Factories;
using Models.SupabaseModels.Dto.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Utilities.Factories.Payment
{
    public class PaymentFactory: IPaymentFactory
    {

        public Models.SupabaseModels.Payment CreatePayment(long orderid,long userid)
        {
            Models.SupabaseModels.Payment val = new Models.SupabaseModels.Payment
            {
                Paymenttimestamp =DateTime.UtcNow,
                Orderid = orderid,
                Userid = userid,
                Paymentstatus= "Payment Successful",
        };

            return val;
            

        }
    }
}
