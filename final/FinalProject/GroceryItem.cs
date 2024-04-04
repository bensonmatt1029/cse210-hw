public class GroceryItem
{
    public string Name { get; }
    public int Quantity { get; }
    public Category Category { get; }

    public GroceryItem(string name, int quantity, Category category)
    {
        Name = name;
        Quantity = quantity;
        Category = category;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {Name}, Quantity: {Quantity}, Category: {Category.Name}");
    }
}