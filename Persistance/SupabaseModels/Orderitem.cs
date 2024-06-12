using System;
using System.Collections.Generic;

namespace Models.SupabaseModels;

public partial class Orderitem
{
    public long Orderitemid { get; set; }

    public long? Productid { get; set; }

    public List<string>? ProductSizes { get; set; }
    public long? Orderid { get; set; }

    public long? Quantity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
