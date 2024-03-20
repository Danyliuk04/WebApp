using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Card
{
    public object cardID;
    public int CardId { get; set; }

    public DateOnly CreationDate { get; set; }

    public int ClientId { get; set; }

    public decimal DiscountRate { get; set; }

    public decimal TotalAmountPurchase { get; set; }

   /* public virtual ICollection<Check> Checks { get; set; } = new List<Check>();

    public virtual Client Customer { get; set; }

    public virtual ICollection<ClientCardService> ClientCardServices { get; set; } = new List<ClientCardService>();*/
}
