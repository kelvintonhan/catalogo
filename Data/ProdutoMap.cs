using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tab_produtos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar(150)");

            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnType("money");

            builder.Property(x => x.Quantidade)
                .IsRequired();

            builder.Property(x => x.Criacao)
                .IsRequired();

            builder.Property(x => x.Alteracao)
                .IsRequired();
        }
    }
}
