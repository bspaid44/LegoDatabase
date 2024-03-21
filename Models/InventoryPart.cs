using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDatabase.Models
{
    public class InventoryPart
    {
        public int inventoryPartId { get; set; }
        public int InventoryId { get; set; }
        public string PartNumId { get; set; }
        public string ColorNameId { get; set; }
        public int Quantity { get; set; }
        public string IsSpare { get; set; }

        public InventoryPart()
        {
        }

        public InventoryPart(int inventoryId, string partNumId, string colorId, int quantity, string isSpare)
        {
            InventoryId = inventoryId;
            PartNumId = partNumId;
            ColorNameId = colorId;
            Quantity = quantity;
            IsSpare = isSpare;
        }

        public static List<InventoryPart> ProcessFile(string path)
        {
            return
             File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(ParseToInventoryPart)
                .ToList();

        }

        private static InventoryPart ParseToInventoryPart(string line)
        {
            var columns = line.Split(',');

            return new InventoryPart
            {
                InventoryId = int.Parse(columns[0]),
                PartNumId = columns[1],
                ColorNameId = columns[2],
                Quantity = int.Parse(columns[3]),
                IsSpare = columns[4]
            };
        }
    }
}
