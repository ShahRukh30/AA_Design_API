using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? PasswordHash { get; set; }

    public int? RoleId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<DeliveryAdress> DeliveryAdresses { get; set; } = new List<DeliveryAdress>();

    public virtual Role? Role { get; set; }
}
