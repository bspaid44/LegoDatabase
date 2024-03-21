using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDatabase.Models
{
    public class Part
    {
        public int partId { get; set; }
        public string PartNumId { get; set; }
        public string Name { get; set; }
        public string PartCatId { get; set; }

        public Part()
        {
        }

        public Part(string partNumId, string name, string partCatId)
        {
            PartNumId = partNumId;
            Name = name;
            PartCatId = partCatId;
        }

        public static List<Part> ProcessFile(string path)
        {
            return
             File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(ParseToPart)
                .ToList();

        }

        private static Part ParseToPart(string line)
        {
            var columns = line.Split(',');

            return new Part
            {
                PartNumId = columns[0],
                Name = columns[1],
                PartCatId = columns[2]
            };
        }
    }
}
