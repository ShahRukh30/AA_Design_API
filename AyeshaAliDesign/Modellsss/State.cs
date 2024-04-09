using System;
using System.Collections.Generic;

namespace API.Modellsss;

public partial class State
{
    public long Stateid { get; set; }

    public string? Statename { get; set; }

    public virtual ICollection<Deliveryadress> Deliveryadresses { get; set; } = new List<Deliveryadress>();

    public virtual Deliverycharge? Deliverycharge { get; set; }
}
