using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class FileIO
{
    public static void SaveToFile(GroceryList list, string filename)
    {
        string json = JsonSerializer.Serialize(list);
        File.WriteAllText(filename, json);
    }

    public static GroceryList LoadFromFile(string filename)
    {
        string json = File.ReadAllText(filename);
        return JsonSerializer.Deserialize<GroceryList>(json);
    }
}