using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class State
{
    public int StateId { get; set; }

    public string? StateName { get; set; }

    public virtual ICollection<DeliveryAdress> DeliveryAdresses { get; set; } = new List<DeliveryAdress>();

    public virtual DeliveryCharge? DeliveryCharge { get; set; }
}
