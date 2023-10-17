namespace Loja.Domain.Entities;

public class Inventory
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }

    public IEnumerable<Product> products { get; private set; } = new List<Product>();

    public Inventory(string name, string? description)
    {
        Name = name;
        Description = description;
    }
}
