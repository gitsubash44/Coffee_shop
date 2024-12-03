using System.Text.Json;
using Coffee_shop;
public class EntryClass
{
    public static void Main(string[] args)
    {
        // Create coffee objects
        Coffee coffee1 = new Coffee
        {
            Name = "Espresso",
            Size = "Small",
            Price = 500

        };

        Coffee coffee2 = new Coffee
        {
            Name = "Latte",
            Size = "Large",
            Price = 1000
        };

        // Add coffees to a centralized list and save
        AddNewCoffee(coffee1);
        AddNewCoffee(coffee2);

        Console.WriteLine("Coffee details have been saved and added to the coffee list.");
    }

    public static void SaveCoffeeData(Coffee coffee)
    {
        string json = JsonSerializer.Serialize(coffee, new JsonSerializerOptions { WriteIndented = true });

        // Determine the file path
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        filePath = Path.Combine(filePath, "CoffeeData");
        if (!Directory.Exists(filePath))
        {
            Directory.CreateDirectory(filePath);
        }

        filePath = Path.Combine(filePath, $"{coffee.ID}.json");
        Console.WriteLine("File path is: " + filePath);

        // Write individual coffee data to a file
        File.WriteAllText(filePath, json);
        Console.WriteLine($"Coffee '{coffee.Name}' details have been saved.");
    }

    public static void AddNewCoffee(Coffee coffee)
    {
        CoffeeList currentList = new CoffeeList();

        // Determine the file path
        string filePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        filePath = Path.Combine(filePath, "CoffeeData");
        string listFilePath = Path.Combine(filePath, "AllCoffees.json");

        // Load existing list if the file exists
        if (File.Exists(listFilePath))
        {
            string jsonFromFile = File.ReadAllText(listFilePath);
            currentList = JsonSerializer.Deserialize<CoffeeList>(jsonFromFile) ?? new CoffeeList();
        }

        // Add the new coffee to the list
        currentList.AllCoffees.Add(coffee);

        // Serialize the updated list back to JSON and save
        string updatedJson = JsonSerializer.Serialize(currentList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(listFilePath, updatedJson);

        Console.WriteLine($"Coffee '{coffee.Name}' added to the coffee list.");
    }
}