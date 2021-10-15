using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Week4.EsFinale.Core.Models;

namespace Week4.EsFinale.EF.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CodiceCliente).IsRequired();
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Cognome).IsRequired();
        }
    }
}