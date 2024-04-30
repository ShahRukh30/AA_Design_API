using System;
using System.Collections.Generic;

namespace API.DB;

public partial class Productsize
{
    public long Productsizeid { get; set; }

    public long? Productid { get; set; }

    public long? Sizeid { get; set; }

    public long? Sizequantity { get; set; }

    public virtual Product? Product { get; set; }

    public virtual Size? Size { get; set; }
}
