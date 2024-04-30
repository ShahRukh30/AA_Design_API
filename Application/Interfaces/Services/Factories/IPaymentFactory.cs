using Models.SupabaseModels.Dto.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.DB;
namespace BusinessLogic.Interfaces.Services.Factories
{
    public interface IPaymentFactory
    {
        Payment CreatePayment(long orderid, long userid);
    }
}
