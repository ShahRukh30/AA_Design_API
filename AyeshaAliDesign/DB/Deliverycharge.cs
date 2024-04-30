using System;
using System.Collections.Generic;

namespace API.DB;

public partial class Deliverycharge
{
    public long Deliverychargeid { get; set; }

    public long? Stateid { get; set; }

    public decimal? Deliverycharge1 { get; set; }

    public virtual State? State { get; set; }
}
