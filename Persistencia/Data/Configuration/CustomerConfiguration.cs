using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class CostumerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id)
            .HasName("PRIMARY");

            builder.HasIndex(e => e.Id, "IX_Customer_IdCustomer")
            .IsUnique();

            builder.HasIndex(e => e.IdTipoPersonaFk, "IX_customer_IdPersonTypeFk");

            builder.HasIndex(e => e.IdCityFk, "IX_customer_IdcityFk");

            builder.Property(e => e.DateRegister)
            .HasColumnName("date_register");

            builder.Property(e => e.Name)
            .HasMaxLength(50)
            .HasColumnName("name");

            builder.HasOne(d => d.IdcityFkNavigation)
            .WithMany(p => p.Customers)
            .HasForeignKey(d => d.IdCityFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_customer_city_IdcityFk");

            builder.HasOne(d => d.IdTipoPersonaFkNavigation)
            .WithMany(p => p.Customers)
            .HasForeignKey(d => d.IdTipoPersonaFk)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_customer_PersonType_IdPersonTypeFk");
        }
    }
}