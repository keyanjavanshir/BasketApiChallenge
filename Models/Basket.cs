using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace BasketApi.Models;

public class Basket
{
    public Guid Id { get; set; }
    public string userEmail { get; set; }
    public double totalAmount { get; set; }
}