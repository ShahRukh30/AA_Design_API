using System;
using System.Collections.Generic;

namespace Models.SupabaseModels;

public partial class Product
{
    public long Productid { get; set; }

    public string? Productname { get; set; }

    public long? Quantity { get; set; }

    public string? Productdescription { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual ICollection<Productimage> Productimages { get; set; } = new List<Productimage>();

    public virtual ICollection<Productsize> Productsizes { get; set; } = new List<Productsize>();
}
