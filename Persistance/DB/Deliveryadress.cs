using System;
using System.Collections.Generic;

namespace API.DB;

public partial class Deliveryadress
{
    public long Adressid { get; set; }

    public string? Deliveryaddress { get; set; }

    public long? Zipcode { get; set; }

    public long? Userid { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User1? User { get; set; }
}
