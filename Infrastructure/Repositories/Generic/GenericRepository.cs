using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Generic
{
    public class GenericRepo<T> /*: IGenericRepo<T> where T : class*/ where T: class
    {
        private readonly AaDesignContext _appContext;
        public GenericRepo(AaDesignContext appcontext)
        {
            _appContext = appcontext;
        }
        public virtual async Task<T> Get(int id)
        {
            T entity = await _appContext.Set<T>().FindAsync(id);
            return entity ;
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            IEnumerable<T> all_data = await _appContext.Set<T>().ToListAsync();
            return all_data ;
        }

        public virtual async Task Post(T entity)
        {
            await _appContext.Set<T>().AddAsync(entity);
            await SaveChanges();
        }

        public virtual async Task Put(T entity)
        {
            _appContext.Set<T>().Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(T entity)
        {
            _appContext.Set<T>().Remove(entity);
            await SaveChanges();
        }
        public virtual async Task SaveChanges()
        {
            await _appContext.SaveChangesAsync();
        }
    }

}
