using System;
using System.Collections.Generic;
using Models.SupabaseModels.Extras;

namespace Models.SupabaseModels.Extras;

public partial class Channel
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime InsertedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public bool? Check { get; set; }

    public virtual Broadcast? Broadcast { get; set; }

    public virtual Presence? Presence { get; set; }
}
