using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Position
{
    public int PositionId { get; set; }

    public string Name { get; set; }

    //public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
