﻿using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Loja.Domain.Entities;

public sealed class ProductEntity : Entity
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public decimal PurchasePrice { get; private set; }
    public decimal SellingPrice { get; private set; }
    public int Quantity { get; private set; }
    public string? Weight { get; private set; }
    public string? Dimensions { get; private set; }
    public string? ImageUrl { get; private set; }
    public string? AdditionalNotes { get; private set; }
    public string? Barcode { get; set; }
    public float AlertLevel { get; private set; }
    public float CriticalLevel { get; private set; }
    public bool Available { get; private set; }

    public int InventoryId { get; private set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public InventoryEntity Inventory { get; private set; }
}