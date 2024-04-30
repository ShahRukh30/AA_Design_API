using System;
using System.Collections.Generic;

namespace API.DB;

public partial class Size
{
    public long Sizeid { get; set; }

    public string? Size1 { get; set; }

    public virtual ICollection<Productsize> Productsizes { get; set; } = new List<Productsize>();
}
