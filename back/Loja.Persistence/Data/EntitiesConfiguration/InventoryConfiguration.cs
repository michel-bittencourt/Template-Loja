using Loja.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Loja.Persistence.Data.EntitiesConfiguration;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.Property(i => i.Name).IsRequired();
        builder.Property(i => i.Description);
    }
}