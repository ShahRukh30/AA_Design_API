using System;
using System.Collections.Generic;

namespace API.Modellsss;

public partial class City
{
    public long Cityid { get; set; }

    public string? Cityname { get; set; }

    public virtual ICollection<Deliveryadress> Deliveryadresses { get; set; } = new List<Deliveryadress>();
}
