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
        public int InvId { get; set; }
        public int Version { get; set; }
        public string SetNumId { get; set; }

        public Inventory()
        {
        }

        public Inventory(int id, int version, string setNumId)
        {
            InvId = id;
            Version = version;
            SetNumId = setNumId;
        }

        public static List<Inventory> ProcessFile(string path)
        {
            return
             File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(ParseToInventory)
                .ToList();

        }

        private static Inventory ParseToInventory(string line)
        {
            var columns = line.Split(',');

            return new Inventory
            {
                InvId = int.Parse(columns[0]),
                Version = int.Parse(columns[1]),
                SetNumId = columns[2]
            };
        }
    }
}
