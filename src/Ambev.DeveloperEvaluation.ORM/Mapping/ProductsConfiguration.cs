using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ProductsConfiguration : IEntityTypeConfiguration<Products>
{
    public void Configure(EntityTypeBuilder<Products> builder)
    {
        
        builder.ToTable("Products");
        
        builder.HasKey(p => p.ProductId);        
        builder.Property(p => p.ProductId).IsRequired().
               HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");
        
        builder.Property(p => p.ProductName).IsRequired().HasMaxLength(100);        
        builder.Property(p => p.Quantity).IsRequired();        
        builder.Property(p => p.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");        
        builder.Property(p => p.Discount).HasColumnType("decimal(18,2)");        
        builder.Property(p => p.TotalValue).IsRequired().HasColumnType("decimal(18,2)");
    }
}