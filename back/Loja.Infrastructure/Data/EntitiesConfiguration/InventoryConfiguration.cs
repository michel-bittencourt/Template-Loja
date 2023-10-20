using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Loja.Infrastructure.Data.EntitiesConfiguration;

public class InventoryConfiguration : IEntityTypeConfiguration<InventoryEntity>
{
    public void Configure(EntityTypeBuilder<InventoryEntity> builder)
    {
        builder.Property(i => i.Name).IsRequired();
        builder.Property(i => i.Description);
    }
}