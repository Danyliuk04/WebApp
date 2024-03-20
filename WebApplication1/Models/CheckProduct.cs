using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class CheckProduct
{
    public int CheckProductId { get; set; }

    public int CheckId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public virtual Check Check { get; set; }

    public virtual Product Product { get; set; }
}
