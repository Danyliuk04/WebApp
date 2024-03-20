using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Check
{
    public int CheckId { get; set; }

    public DateOnly Date { get; set; }

    public TimeOnly Time { get; set; }

    public int StaffId { get; set; }

    public int? CardId { get; set; }

    //public virtual Card Card { get; set; }

    //public virtual ICollection<CheckProduct> CheckProducts { get; set; } = new List<CheckProduct>();

    //public virtual Staff Staff { get; set; }
}
