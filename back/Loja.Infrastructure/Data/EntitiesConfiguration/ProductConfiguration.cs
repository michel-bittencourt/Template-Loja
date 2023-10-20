using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Data.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Description);
        builder.Property(p => p.Dimension);
        builder.Property(p => p.Material);
        builder.Property(p => p.Available).IsRequired();
        builder.Property(p => p.UrlImages);
    }
}