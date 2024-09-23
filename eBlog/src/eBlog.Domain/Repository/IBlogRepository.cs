using eBlog.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Domain.Repository
{
    public interface IBlogRepository : IRepository<Blog>
    {
        
    }

}
