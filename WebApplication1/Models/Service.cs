using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int Duration { get; set; }

    public string Materials { get; set; }

    public virtual ICollection<ClientCardService> ClientCardServices { get; set; } = new List<ClientCardService>();

    public virtual ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();
}
