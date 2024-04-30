using System;
using System.Collections.Generic;
using API.DB;

namespace Models.DB.Extras;

public partial class Broadcast
{
    public long Id { get; set; }

    public long ChannelId { get; set; }

    public DateTime InsertedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Channel Channel { get; set; } = null!;
}
