using eBlog.Application.Common.Mappings;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eBlog.Application.DTOs
{
    public class BlogVm 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string TextOfBlog { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }
        public IBrowserFile ImageFile { get; set; }
    }
}
