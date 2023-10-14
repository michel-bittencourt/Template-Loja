namespace Loja.API.Model;

public class ProductModel
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public int Quantity { get; private set; }
    public DateTime Date { get; private set; } = DateTime.Now;

    public ProductModel(string name, string? description, int quantity)
    {
        Name = name;
        Description = description;
        Quantity = quantity;
    }
}
