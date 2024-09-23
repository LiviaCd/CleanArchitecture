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
    public class UsersConfiguration : IEntityTypeConfiguration<LocalUser>
    {
        public void Configure(EntityTypeBuilder<LocalUser> entity)
        {
            entity.ToTable("LocalUsers", Constants.Data.UserDbSchemaName);
            entity.HasKey(b => b.Id);
            entity.Property(e => e.Id)
                .IsRequired();

            entity.Property(e => e.Email)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            entity.Property(e => e.Password)
                .HasColumnType("nvarchar(max)")
                .IsRequired();

            entity.Property(e => e.Role)
                .HasColumnType("nvarchar(max)")
                .IsRequired();
        }

    }
}
