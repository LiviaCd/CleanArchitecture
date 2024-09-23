using AutoMapper;
using eBlog.Application.DTOs;
using eBlog.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Blog, BlogVm>();
            CreateMap<BlogVm, Blog>();
        }
        
        
    }
}
