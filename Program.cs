using LegoDatabase;
using LegoDatabase.Data;
using LegoDatabase.Models;
using Microsoft.EntityFrameworkCore;

var context = new LegoDBContext();
string input;
context.Database.EnsureCreated();
Utilities.SeedDatabase();

do
{
    Console.WriteLine("\n" + "Lego Database Project" + "\n");
    Console.WriteLine("Please Select a Query");
    Console.WriteLine("*******************************" + "\n");
    Console.WriteLine("1. Part Count Grouped By Color");
    Console.WriteLine("2. Part Count Grouped By Category");
    Console.WriteLine("3. Color Name and RGB Value");
    Console.WriteLine("4. Parts by Color Name");
    Console.WriteLine("0. Exit" + "\n");

    input = Console.ReadLine();

    switch (input)
    {
        case "1":
            Utilities.PartCountByColor();
            break;
        case "2":
            Utilities.PartCountByCategory();
            break;
        case "3":
            Utilities.ColorNameRGB();
            break;
        case "4":
            Console.WriteLine("Enter a color name: ");
            string color = Console.ReadLine();
            var colors = context.Colors;
            if (!colors.Any(c => c.Name == color) || color == "")
            {
                Console.WriteLine("Color not found");
                Utilities.ColorNameRGB();
                Console.WriteLine("^^ Try one of these ^^");
                break;
            }
            Utilities.PartByColor(color);
            break;
        case "0":
            Console.WriteLine("Goodbye!");
            break;
        default:
            break;
    }
} while (input != "0");

