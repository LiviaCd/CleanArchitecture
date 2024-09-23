using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UnitOfWork
{
    public class UnitOfWork<U>(U context) : IUnitOfWork //, IDisposable
        where U : DbContext
    {
        /*private bool _disposed;

        private readonly Dictionary<Type, object> _repositories;

        private IDbContextTransaction _transaction;
*/
        //  _repositories = new Dictionary<Type, object>();


        public U DbContext { get; set; } = context;

        /*public async Task BeginTransactionAsync()
        {
            _transaction = await DbContext.Database.BeginTransactionAsync();
        }
*/
        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
