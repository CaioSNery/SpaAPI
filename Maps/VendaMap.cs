using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Spa.Models;

namespace SpaAPI.Maps
{
    public class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.ToTable("Vendas");

            builder.Property(v => v.ValorUnitario)
            .HasColumnType("decimal(18,2)");

            builder.HasOne(v => v.Cliente)
            .WithMany()
            .HasForeignKey(v => v.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(v => v.Servico)
            .WithMany()
            .HasForeignKey(v => v.ServicoId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}