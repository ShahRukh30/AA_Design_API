using System;
using System.Collections.Generic;

namespace API.DB;

public partial class State
{
    public long Stateid { get; set; }

    public string? Statename { get; set; }

    public virtual Deliverycharge? Deliverycharge { get; set; }
}
