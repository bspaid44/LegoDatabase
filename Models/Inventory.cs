using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDatabase.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int Version { get; set; }
        public int SetNumId { get; set; }
        public Set Set { get; set; }

        public Inventory()
        {
        }

        public Inventory(int id, int version, int setNumId)
        {
            InventoryId = id;
            Version = version;
            SetNumId = setNumId;
        }
    }
}
