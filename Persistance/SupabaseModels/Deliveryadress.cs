using System;
using System.Collections.Generic;

namespace Models.SupabaseModels;


public partial class Deliveryadress
{
    public long Adressid { get; set; }

    public string? Deliveryaddress { get; set; }

    public long? Zipcode { get; set; }

    public long? Userid { get; set; }

    public long? Stateid { get; set; }

    public long? Cityid { get; set; }

    public virtual City? City { get; set; }
    public virtual State? State { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual User1? User { get; set; }

}
