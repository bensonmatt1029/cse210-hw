using System;
using System.Collections.Generic;

public class ShoppingCart
{
    private List<GroceryItem> items;

    public ShoppingCart()
    {
        items = new List<GroceryItem>();
    }

    public void AddToCart(GroceryItem item)
    {
        items.Add(item);
    }

    public void RemoveFromCart(GroceryItem item)
    {
        items.Remove(item);
    }

    public void DisplayCart()
    {
        Console.WriteLine("Shopping Cart:");
        foreach (var item in items)
        {
            item.Display();
        }
    }
}