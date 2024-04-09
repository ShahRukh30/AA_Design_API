using System;
using System.Collections.Generic;

namespace Models.SupabaseModels;

public partial class City
{
    public long Cityid { get; set; }

    public string? Cityname { get; set; }

    public virtual ICollection<Deliveryadress> Deliveryadresses { get; set; } = new List<Deliveryadress>();
}
