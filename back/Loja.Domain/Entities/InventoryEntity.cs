namespace Loja.Domain.Entities;

public sealed class InventoryEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public IEnumerable<ProductEntity> products { get; private set; } = new List<ProductEntity>();

    public InventoryEntity(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}
