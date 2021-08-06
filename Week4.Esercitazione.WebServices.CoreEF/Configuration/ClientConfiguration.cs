using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Week4.EsercitazioneWebServices.Core.Models;

namespace Week4.Esercitazione.WebServices.CoreEF.Configuration
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(e => e.FirstName).IsRequired();
            builder.Property(r => r.LastName).IsRequired();
            builder.Property(t => t.ClientCode).IsRequired();

            builder.HasMany(e => e.Orders)
                .WithOne(w => w.Client);
        }
    }
}
