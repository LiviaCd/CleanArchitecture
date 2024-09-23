using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repository
{
    public interface IRepository
    {
    }

    public interface IRepository<T> : IRepository where T : class
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<ICollection<T>> GetAll();
        Task<T> GetById(int id);
    }

}
