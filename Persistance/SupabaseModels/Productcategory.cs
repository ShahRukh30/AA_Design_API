﻿using System;
using System.Collections.Generic;

namespace Models.SupabaseModels;

public partial class Productcategory
{
    public long Productcategoryid { get; set; }

    public string Productcategory1 { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
