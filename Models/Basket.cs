using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BasketApi.Models;

public class Basket
{
    [Key]
    public Guid Id { get; set; }
    public string userEmail { get; set; }
    public double totalAmount { get; set; }

    // Navigation property for the OrderLines
    public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
}