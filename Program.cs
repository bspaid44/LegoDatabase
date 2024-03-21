using LegoDatabase.Data;
using LegoDatabase.Models;
using Microsoft.EntityFrameworkCore;

var context = new LegoDBContext();
context.Database.EnsureCreated();

if (context.Inventories.Count() == 0)
{
    var colors = Color.ProcessFile("Data/colors.csv");
    var inventories = Inventory.ProcessFile("Data/inventories.csv");
    var inventoryParts = InventoryPart.ProcessFile("Data/inventory_parts.csv");
    var parts = Part.ProcessFile("Data/parts.csv");
    var partCategories = PartCategory.ProcessFile("Data/part_categories.csv");
    var sets = Set.ProcessFile("Data/sets.csv");
    var themes = Theme.ProcessFile("Data/themes.csv");

    foreach (var color in colors)
    {
        context.Colors.Add(color);
        Console.WriteLine("Color row added");
    }

    foreach (var inventory in inventories)
    {
        context.Inventories.Add(inventory);
        Console.WriteLine("Inventory row added");
    }

    foreach (var inventory in inventoryParts)
    {
        context.InventoryParts.Add(inventory);
        Console.WriteLine("InventoryPart row added");
    }

    foreach (var part in parts)
    {
        context.Parts.Add(part);
        Console.WriteLine("Part row added");
    }

    foreach (var part in partCategories)
    {
        context.PartCategories.Add(part);
        Console.WriteLine("PartCategory row added");
    }

    foreach (var part in parts)
    {
        context.Parts.Add(part);
        Console.WriteLine("Part row added");
    }

    foreach (var set in sets)
    {
        context.Sets.Add(set);
        Console.WriteLine("Set row added");
    }

    foreach (var theme in themes)
    {
        context.Themes.Add(theme);
        Console.WriteLine("Theme row added");
    }

    context.SaveChanges();
    Console.WriteLine("Data has been seeded");
}

