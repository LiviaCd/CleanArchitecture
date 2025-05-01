using AutoMapper;
using eBlog.Application.DTOs;
using eBlog.Domain.Entity;
using eBlog.Infrastructure.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Application.Tests.Commun
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly BlogDbContext Context;

        public TestCommandBase()
        {
            Context = BlogContextFactory.Create();

        }

        public void Dispose()
        {
            BlogContextFactory.Destroy(Context);
        }
    }

}
