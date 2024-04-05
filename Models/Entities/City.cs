using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class City
{
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public virtual ICollection<DeliveryAdress> DeliveryAdresses { get; set; } = new List<DeliveryAdress>();
}
