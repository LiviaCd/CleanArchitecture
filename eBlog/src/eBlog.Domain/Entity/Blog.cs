using Shared.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Domain.Entity
{
    public class Blog : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string TextOfBlog { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
