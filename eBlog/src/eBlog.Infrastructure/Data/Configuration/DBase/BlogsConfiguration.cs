using eBlog.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBlog.Infrastructure.Data.Configuration.DBase
{
    public class BlogsConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> entity)
        {
            entity.ToTable("Blogs", Constants.Data.BDbSchemaName);
            entity.HasKey(b => b.Id);
            entity.Property(e => e.Id)
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("NEWSEQUENTIALID()")
                .IsRequired();

            entity.Property(e => e.Name)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            entity.Property(e => e.Description)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            entity.Property(e => e.Author)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
        }
    }
}
