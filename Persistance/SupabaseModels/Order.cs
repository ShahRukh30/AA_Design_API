using System;
using System.Collections.Generic;

namespace Models.SupabaseModels;

public partial class Order
{
    public long Orderid { get; set; }

    public long? Addressid { get; set; }

    public string? Dispatchid { get; set; }

    public decimal? Totalprice { get; set; }

    public string? OrderProgress { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime? DeliveryDate {  get; set; }
    public virtual Deliveryadress? Address { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
