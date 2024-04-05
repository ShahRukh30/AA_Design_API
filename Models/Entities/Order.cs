using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int? AddressId { get; set; }

    public string? DispatchId { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual DeliveryAdress? Address { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
