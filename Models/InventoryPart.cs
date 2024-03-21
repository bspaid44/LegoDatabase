using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDatabase.Models
{
    public class InventoryPart
    {
        public int Id { get; set; }
        public int InventoryId { get; set; }
        public Inventory Inventory { get; set; }
        public int PartNumId { get; set; }
        public Part Part { get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int Quantity { get; set; }
        public char IsSpare { get; set; }

        public InventoryPart()
        {
        }

        public InventoryPart(int inventoryId, int partNumId, int colorId, int quantity, char isSpare)
        {
            InventoryId = inventoryId;
            PartNumId = partNumId;
            ColorId = colorId;
            Quantity = quantity;
            IsSpare = isSpare;
        }
    }
}
