using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.SupabaseModels;

namespace BusinessLogic.Interfaces.Services.GenericService
{
    public interface IGenericService<T> where T : class
    {
        Task<T> Get(long id);
        Task<IEnumerable<T>> Get();
        Task<T> post(T Entity);
        Task Put(T Entity);
        Task Delete(T Entity);
    }
}
