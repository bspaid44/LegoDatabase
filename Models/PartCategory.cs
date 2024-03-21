using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDatabase.Models
{
    public class PartCategory
    {
        public int Id { get; set; }
        public int partCategoryId { get; set; }
        public string PartCatId { get; set; }
        public string Name { get; set; }

        public PartCategory()
        {
        }

        public PartCategory(string partCatId, string name)
        {
            PartCatId = partCatId;
            Name = name;
        }

        public static List<PartCategory> ProcessFile(string path)
        {
            return
             File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(ParseToPartCategory)
                .ToList();

        }

        private static PartCategory ParseToPartCategory(string line)
        {
            var columns = line.Split(',');

            return new PartCategory
            {
                PartCatId = columns[0],
                Name = columns[1]
            };
        }
    }
}
