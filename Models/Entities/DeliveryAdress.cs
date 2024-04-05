using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class DeliveryAdress
{
    public int AdressId { get; set; }

    public string? DeliveryAddress { get; set; }

    public int? Zipcode { get; set; }

    public int? UserId { get; set; }

    public int? StateId { get; set; }

    public int? CityId { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual State? State { get; set; }

    public virtual User? User { get; set; }
}
