using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class Size
{
    public int SizeId { get; set; }

    public string? Size1 { get; set; }

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
}
