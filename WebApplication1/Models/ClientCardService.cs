using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ClientCardService
{
    public int ClientCardServiceId { get; set; }

    public int CardId { get; set; }

    public int ServiceId { get; set; }

    public virtual Card Card { get; set; }

    public virtual Service Service { get; set; }
}
