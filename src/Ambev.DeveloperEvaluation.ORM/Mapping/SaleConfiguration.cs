using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            // Define a tabela para a entidade Sale
            builder.ToTable("Sales");

            // Configura a chave primária
            builder.HasKey(s => s.SaleNumber);

            // Define a propriedade SaleNumber como obrigatória e com tamanho fixo
            builder.Property(s => s.SaleNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            // Configura a data da venda como obrigatória
            builder.Property(s => s.SaleDate)
                   .IsRequired();

            // Configura o CustomerId como tipo UUID
            builder.Property(s => s.CustomerId)
                   .IsRequired()
                   .HasColumnType("uuid");

            // Define o nome do cliente (denormalizado) como obrigatório
            builder.Property(s => s.CustomerName)
                   .IsRequired()
                   .HasMaxLength(100);

            // Configura o BranchId como tipo UUID
            builder.Property(s => s.BranchId)
                   .IsRequired()
                   .HasColumnType("uuid");

            // Define o nome da filial (denormalizado) como obrigatório
            builder.Property(s => s.BranchName)
                   .IsRequired()
                   .HasMaxLength(100);

            // Configura o valor total da venda como obrigatório
            builder.Property(s => s.TotalAmount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            // Configura o status de cancelamento
            builder.Property(s => s.IsCanceled)
                   .IsRequired();

            // Configura o relacionamento com os itens da venda (Products)
            builder.HasMany(s => s.Items)
                   .WithOne()
                   .HasForeignKey("SaleNumber")
                   .OnDelete(DeleteBehavior.Cascade);

            // Index para consultas rápidas com SaleDate e CustomerId
            builder.HasIndex(s => s.SaleDate);
            builder.HasIndex(s => s.CustomerId);
        }
    }
}
