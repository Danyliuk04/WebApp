using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class ContactInfomation
{
    public int ContactInformationId { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    //public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
