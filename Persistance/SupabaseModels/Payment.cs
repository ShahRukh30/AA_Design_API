using System;
using System.Collections.Generic;

namespace Models.SupabaseModels;
public partial class Payment
{
    public long Paymentid { get; set; }

    public long? Userid { get; set; }

    public long? Orderid { get; set; }

    public string? Paymentstatus { get; set; }

    public DateTime? Paymenttimestamp { get; set; }

    public virtual Order? Order { get; set; }

    public virtual User1? User { get; set; }
}
