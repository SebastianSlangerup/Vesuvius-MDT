﻿namespace Vesuvius_MDT.Models;

public class OrderStatus
{
    public int OrderId { get; set; }
    
    public string Status { get; set; }
    
    public List<Order> Orders { get; set; }
}