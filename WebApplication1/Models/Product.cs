using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; }

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public int SupplierId { get; set; }

 /*   public virtual Category Category { get; set; }

    public virtual ICollection<CheckProduct> CheckProducts { get; set; } = new List<CheckProduct>();

    public virtual ICollection<ClientProduct> ClientProducts { get; set; } = new List<ClientProduct>();

    public virtual Supplier Supplier { get; set; }

    public virtual ICollection<SupplierProduct> SupplierProducts { get; set; } = new List<SupplierProduct>();*/
}
