using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Staff
{
    public object StaffID;
    public int StaffId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    //public int ContactInformationId { get; set; }

    public string Specialization { get; set; }

    public int PositionId { get; set; }

    public decimal Salary { get; set; }
/*
    public virtual ICollection<Check> Checks { get; set; } = new List<Check>();

    public virtual ContactInfomation ContactInformation { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual Position Position { get; set; }*/
}
