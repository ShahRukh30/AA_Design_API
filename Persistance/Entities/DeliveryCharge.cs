using System;
using System.Collections.Generic;

namespace Models.Entities;  

public partial class DeliveryCharge
{
    public int DeliveryChargeId { get; set; }

    public int? StateId { get; set; }

    public decimal? DeliveryCharge1 { get; set; }

    public virtual State? State { get; set; }
}
