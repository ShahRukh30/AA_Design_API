using Models.Entities;
using System;
using System.Collections.Generic;

namespace Models.Entitiess;

public partial class ProductImage
{
    public int ProductImageId { get; set; }

    public int? ProductId { get; set; }

    public string? ImageUrl { get; set; }

    public string? ImageName { get; set; }

    public bool? IsMainImage { get; set; }

    public virtual Product? Product { get; set; }
}
