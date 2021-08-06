using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Week4.EsercitazioneWebServices.Core.Models;

namespace Week4.Esercitazione.WebServices.CoreEF.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(o => o.OrderDate).IsRequired();
            builder.Property(i => i.OrderCode).IsRequired();
            builder.Property(q => q.ProductCode).IsRequired();
            builder.Property(a => a.Price).IsRequired();

            builder.HasOne(p => p.Client)
                .WithMany(a => a.Orders);

        }
    }
}
