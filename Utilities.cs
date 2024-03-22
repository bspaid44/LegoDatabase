using LegoDatabase.Data;
using LegoDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDatabase
{
    public class Utilities
    {
        public static void SeedDatabase()
        {
            var context = new LegoDBContext();
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
        }

        public static void PartCountByColor() 
        {
            var context = new LegoDBContext();
            var ip = context.InventoryParts;
            var colors = context.Colors;

            var colorNamePartCount = ip
                .Join(colors, ip => ip.ColorNameId, c => c.ColorNameId, (ip, c) => new { ip, c })
                .GroupBy(x => x.c.Name)
                .Select(g => new { ColorName = g.Key, PartCount = g.Count() })
                .OrderByDescending(x => x.PartCount);

            foreach (var item in colorNamePartCount)
            {
                Console.WriteLine($"{item.ColorName} - {item.PartCount}");
            }
        }

        public static void PartCountByCategory()
        {
            var context = new LegoDBContext();
            var ip = context.InventoryParts;
            var parts = context.Parts;
            var partCategories = context.PartCategories;

            var partCategoryPartCount = ip
                .Join(parts, ip => ip.PartNumId, p => p.PartNumId, (ip, p) => new { ip, p })
                .Join(partCategories, x => x.p.PartCatId, pc => pc.PartCatId, (x, pc) => new { x, pc })
                .GroupBy(x => x.pc.Name)
                .Select(g => new { PartCategory = g.Key, PartCount = g.Count() })
                .OrderByDescending(x => x.PartCount);

            foreach (var item in partCategoryPartCount)
            {
                Console.WriteLine($"{item.PartCategory} - {item.PartCount}");
            }
        }

        public static void ColorNameRGB()
        {
            var context = new LegoDBContext();
            var colors = context.Colors;

            foreach (var color in colors)
            {
                Console.WriteLine($"{color.Name} - {color.RGB}");
            }
        }
    }
}
