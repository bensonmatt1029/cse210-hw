using System;

public class UserInterface
{
    private GroceryList groceryList;

    public UserInterface()
    {
        groceryList = new GroceryList();
    }

    public void DisplayMenu()
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Grocery Shopping List Manager!");
            Console.WriteLine("1. Add item to the list");
            Console.WriteLine("2. Remove item from the list");
            Console.WriteLine("3. Display list");
            Console.WriteLine("4. Save list to file");
            Console.WriteLine("5. Load list from file");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GetGroceryItemDetails();
                    break;
                case 2:
                    RemoveItemFromList();
                    break;
                case 3:
                    DisplayGroceryList();
                    break;
                case 4:
                    SaveListToFile();
                    break;
                case 5:
                    LoadListFromFile();
                    break;
                case 6:
                    Console.WriteLine("Exiting program...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

    public void GetGroceryItemDetails()
    {
        Console.Write("Enter item name: ");
        string name = Console.ReadLine();
        Console.Write("Enter quantity: ");
        int quantity = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter category: ");
        string category = Console.ReadLine();

        Category itemCategory = new Category(category);
        GroceryItem newItem = new GroceryItem(name, quantity, itemCategory);
        groceryList.AddItem(newItem);
    }

    public void RemoveItemFromList()
    {
        Console.Write("Enter item name to remove: ");
        string itemName = Console.ReadLine();
        groceryList.RemoveItem(itemName);
    }

    public void DisplayGroceryList()
    {
        Console.WriteLine("Grocery List:");
        groceryList.DisplayList();
    }

    public void SaveListToFile()
    {
        Console.Write("Enter file name to save: ");
        string filename = Console.ReadLine();
        FileIO.SaveToFile(groceryList, filename);
        Console.WriteLine("List saved to file.");
    }

    public void LoadListFromFile()
    {
        Console.Write("Enter file name to load: ");
        string filename = Console.ReadLine();
        groceryList = FileIO.LoadFromFile(filename);
        Console.WriteLine("List loaded from file.");
    }
}