using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public DateTime DateTime { get; set; }

    public int ClientId { get; set; }

    public string Device { get; set; }

    public int StaffId { get; set; }

    public virtual Client Client { get; set; }

    public virtual Staff Staff { get; set; }
}
