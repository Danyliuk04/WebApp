using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string Name1 { get; set; }

    public int ContactInformationId { get; set; }

    public virtual ContactInfomation ContactInformation { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<SupplierProduct> SupplierProducts { get; set; } = new List<SupplierProduct>();
}
