using System;
using System.Collections.Generic;
using API.DB;

namespace Models.DB.Extras;

public partial class Bucket
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    /// <summary>
    /// Field is deprecated, use owner_id instead
    /// </summary>
    public Guid? Owner { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? Public { get; set; }

    public bool? AvifAutodetection { get; set; }

    public long? FileSizeLimit { get; set; }

    public List<string>? AllowedMimeTypes { get; set; }

    public string? OwnerId { get; set; }

    public virtual ICollection<Models.SupabaseModels.Extras.Object> Objects { get; set; } = new List<Models.SupabaseModels.Extras.Object>();

    public virtual ICollection<S3MultipartUpload> S3MultipartUploads { get; set; } = new List<S3MultipartUpload>();

    public virtual ICollection<S3MultipartUploadsPart> S3MultipartUploadsParts { get; set; } = new List<S3MultipartUploadsPart>();
}
