using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Spa.Models;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpaAPI.Maps
{
    public class ServicoMap : IEntityTypeConfiguration<Serviço>
    {
        public void Configure(EntityTypeBuilder<Serviço> builder)
        {
            builder.ToTable("Serviços");

            builder.Property(s => s.Tipo)
            .IsRequired();

            builder.Property(s => s.Preco)
            .HasColumnType("decimal(18,2)");
        }
    }
}