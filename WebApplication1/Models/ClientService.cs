using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ClientService
{
    public int ClientServiceId { get; set; }

    public int ClientId { get; set; }

    public int ServiceId { get; set; }

    public virtual Client Client { get; set; }

    public virtual Service Service { get; set; }
}
