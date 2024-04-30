using System;
using System.Collections.Generic;

namespace API.DB;

public partial class Order
{
    public long Orderid { get; set; }

    public long? Addressid { get; set; }

    public string? Dispatchid { get; set; }

    public decimal? Totalprice { get; set; }

    public string? OrderProgress { get; set; }

    public virtual Deliveryadress? Address { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
