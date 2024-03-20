using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ClientProduct
{
    public int ClientProductId { get; set; }

    public int ClientId { get; set; }

    public int ProductId { get; set; }

    public virtual Client Client { get; set; }

    public virtual Product Product { get; set; }
}
