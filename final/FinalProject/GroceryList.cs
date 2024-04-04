using System;
using System.Collections.Generic;

public class GroceryList
{
    private List<GroceryItem> items;

    public GroceryList()
    {
        items = new List<GroceryItem>();
    }

    public void AddItem(GroceryItem item)
    {
        items.Add(item);
    }

    public void RemoveItem(string itemName)
    {
        GroceryItem itemToRemove = items.Find(item => item.Name.Equals(itemName));
        if (itemToRemove != null)
            items.Remove(itemToRemove);
        else
            Console.WriteLine($"Item '{itemName}' not found in the list.");
    }

    public void DisplayList()
    {
        foreach (var item in items)
        {
            item.Display();
        }
    }
}