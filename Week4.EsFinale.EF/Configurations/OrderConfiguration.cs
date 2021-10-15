using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Week4.EsFinale.Core.Models;

namespace Week4.EsFinale.EF.Configurations
{
   public class OrderConfiguration  : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.OrderId);

            builder.Property(o => o.DataOrdine).IsRequired();
            builder.Property(o => o.CodiceOrdine).IsRequired();
            builder.Property(o => o.CodiceProdotto).IsRequired();
            builder.Property(o => o.Importo).IsRequired();
            builder.HasOne(o => o.Cliente).WithMany(c => c.Ordine).HasForeignKey(o => o.IdCliente);
        }
    }
}
