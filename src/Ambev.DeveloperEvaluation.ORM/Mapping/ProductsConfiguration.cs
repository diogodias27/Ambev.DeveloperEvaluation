using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductsConfiguration : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        // Define a tabela para a entidade Products
        builder.ToTable("Products");

        // Configura a chave primária como ProductId
        builder.HasKey(p => p.ProductId);

        // Configura ProductId como obrigatório e tipo UUID
        builder.Property(p => p.ProductId)
               .IsRequired()
               .HasColumnType("uuid");

        // Define ProductName como obrigatório e com tamanho máximo
        builder.Property(p => p.ProductName)
               .IsRequired()
               .HasMaxLength(100);

        // Configura Quantity como obrigatório
        builder.Property(p => p.Quantity)
               .IsRequired();

        // Configura UnitPrice com precisão decimal
        builder.Property(p => p.UnitPrice)
               .IsRequired()
               .HasColumnType("decimal(18,2)");

        // Configura Discount com precisão decimal
        builder.Property(p => p.Discount)
               .HasColumnType("decimal(18,2)");

        // Configura TotalValue com precisão decimal
        builder.Property(p => p.TotalValue)
               .IsRequired()
               .HasColumnType("decimal(18,2)");
    }
}