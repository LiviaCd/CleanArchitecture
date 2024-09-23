using Shared.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Domain.Entity
{
    public class LocalUser : EntityBase
    {
        public string Email { get; set; } 
        public string Password { get; set; } 
        public string Role { get; set; } 
    }
}
