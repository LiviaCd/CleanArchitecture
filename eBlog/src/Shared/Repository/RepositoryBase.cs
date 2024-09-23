using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repository
{
    public class RepositoryBase<T, U>(U context) : IRepository<T>
        where T : EntityBase.EntityBase
        where U : DbContext
    {
        public U DbContext { get; set; } = context;
        public virtual async Task<T> Add(T entity)
        {
            DbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public virtual async Task Delete(int id)
        {
            var entity = await DbContext.Set<T>().FindAsync(id);
            DbContext.Set<T>().Remove(entity);

        }

        public virtual async Task<ICollection<T>> GetAll()
        {
            return await DbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await DbContext.Set<T>().AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id);
        }

        public virtual Task Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
            return Task.CompletedTask;
        }
    }
}
