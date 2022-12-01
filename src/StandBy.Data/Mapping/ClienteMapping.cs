using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StandBy.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StandBy.Data.Mapping
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(x=> x.CLIENTE_ID);
            
            builder.Property(x=> x.RAZAO_SOCIAL).HasColumnName("RAZAO_SOCIAL").HasColumnName("varchar(60)").IsRequired();
            builder.Property(x=> x.DATA_FUNDACAO).HasColumnName("DATA_FUNDACAO").HasColumnType("DATE").IsRequired();
            builder.Property(x=> x.CNPJ).HasColumnName("CNPJ").HasColumnName("DATE").IsRequired();
            builder.Property(x=> x.CAPITAL).HasColumnName("CAPITAL").HasColumnName("DECIMAL(18,2)").IsRequired();
            builder.Property(x=> x.QUARENTENA).HasColumnName("QUARENTENA");
            builder.Property(x=> x.STATUS_CLIENTE).HasColumnName("STATUS_CLIENTE");
            builder.Property(x=> x.CLASSIFICACAO).HasColumnName("CLASSIFICACAO").HasColumnType("CHAR(1)");


        }
    }
}
