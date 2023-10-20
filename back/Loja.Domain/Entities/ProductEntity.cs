namespace Loja.Domain.Entities;

public sealed class ProductEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public string? Dimension { get; private set; }
    public string? Material { get; private set; }
    public bool Available { get; private set; } = false;
    public string? UrlImages { get; private set; }

    public int InventoryId { get; private set; }
    public InventoryEntity Inventory { get; private set; } = new InventoryEntity("none", "none");

    public ProductEntity(
        string name,
        string? description,
        string? dimension,
        string? material,
        bool available,
        string? urlImages
        )
    {
        Name = name;
        Description = description;
        Dimension = dimension;
        Material = material;
        Available = available;
        UrlImages = urlImages;
    }
}