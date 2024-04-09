using System;
using System.Collections.Generic;

namespace API.Modellsss;

public partial class Orderitem
{
    public long Orderitemid { get; set; }

    public long? Productid { get; set; }

    public long? Orderid { get; set; }

    public long? Quantity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
