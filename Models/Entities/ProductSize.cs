using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class ProductSize
{
    public int ProductSizeId { get; set; }

    public int? ProductId { get; set; }

    public int? SizeId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Size? Size { get; set; }
}
