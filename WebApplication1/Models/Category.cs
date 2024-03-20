using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Category
{
    public object categoryId;

    public int CategoryId { get; set; }

    public string Name { get; set; }

    public decimal Discount { get; set; }

    //public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
