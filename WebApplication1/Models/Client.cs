using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string Name { get; set; }

    public int ContactInformationId { get; set; }

    public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

    public virtual ICollection<ClientProduct> ClientProducts { get; set; } = new List<ClientProduct>();

    public virtual ICollection<ClientService> ClientServices { get; set; } = new List<ClientService>();

    public virtual ContactInfomation ContactInformation { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
