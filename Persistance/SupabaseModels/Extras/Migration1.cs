﻿using System;
using System.Collections.Generic;

namespace Models.SupabaseModels.Extras;

public partial class Migration1
{
    public string Version { get; set; } = null!;

    public DateTime InsertedAt { get; set; }
}
