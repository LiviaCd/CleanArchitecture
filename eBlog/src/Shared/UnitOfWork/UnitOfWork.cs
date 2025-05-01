using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.UnitOfWork
{
    public class UnitOfWork<U>(U context) : IUnitOfWork 
        where U : DbContext
    {
        
        public U DbContext { get; set; } = context;

        
        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return DbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
