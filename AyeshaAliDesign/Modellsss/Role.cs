using System;
using System.Collections.Generic;

namespace API.Modellsss;

public partial class Role
{
    public long Roleid { get; set; }

    public string? Rolename { get; set; }

    public virtual ICollection<User1> User1s { get; set; } = new List<User1>();
}
