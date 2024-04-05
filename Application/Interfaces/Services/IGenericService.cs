using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services
{
    public interface IGenericService<T> where T: class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> Get();
        Task post(T Entity);
        Task Put(T Entity);
        Task Delete(T Entity);
    }
}
