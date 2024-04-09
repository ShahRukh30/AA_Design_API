using System;
using System.Collections.Generic;

namespace Models.SupabaseModels;

public partial class Productimage
{
    public long Productimageid { get; set; }

    public long? Productid { get; set; }

    public string? Imageurl { get; set; }

    public string? Imagename { get; set; }

    public bool? Ismainimage { get; set; }

    public virtual Product? Product { get; set; }
}
