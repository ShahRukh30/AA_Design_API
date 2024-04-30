using Models.SupabaseModels.Dto.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.Factories
{
    public interface IPaymentFactory
    {
        Models.SupabaseModels.Payment CreatePayment(long orderid, long userid);
    }
}
