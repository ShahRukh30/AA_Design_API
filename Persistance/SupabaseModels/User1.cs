using System;
using System.Collections.Generic;

namespace Models.SupabaseModels;

public partial class User1
{
    public long Userid { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public bool? Isactive { get; set; }

    public virtual ICollection<Deliveryadress> Deliveryadresses { get; set; } = new List<Deliveryadress>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}