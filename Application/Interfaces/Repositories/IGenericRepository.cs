using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(long id);
        Task<IEnumerable<T>> Get();
        Task<T> Post(T entity);
        Task<T> Put(T entity);
        Task Delete(T entity);
    }
}
