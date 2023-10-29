using Loja.Domain.Entities;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Loja.Application.DTO;

public class InventoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime EntryDate { get; set; }
    public DateTime? ExitDate { get; set; }
    public string? ExitReason { get; set; }
    public string? StorageLocation { get; set; }
    public string? AdditionalNotes { get; set; }

    public ICollection<ProductEntity> Products { get; set; }
}
