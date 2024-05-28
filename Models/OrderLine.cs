using System.Collections;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BasketApi.Models;

public class OrderLine
{
    [Key]
    public int Id { get; set; } // Primary Key
    public int productId { get; set; }
    public string? productName { get; set; }
    public double productUnitPrice { get; set; }
    public int productSize { get; set; }
    public int quantity { get; set; }
    public double totalPrice => productUnitPrice * quantity;
}