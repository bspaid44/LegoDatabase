using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDatabase.Models
{
    public class Set
    {
        public int setId { get; set; }
        public string SetNumId { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string ThemeNameId { get; set; }
        public string NumParts { get; set; }

        public Set()
        {
        }

        public Set(string setNumId, string name, string year, string themeId, string numParts)
        {
            SetNumId = setNumId;
            Name = name;
            Year = year;
            ThemeNameId = themeId;
            NumParts = numParts;
        }

        public static List<Set> ProcessFile(string path)
        {
            return
             File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(ParseToSet)
                .ToList();

        }

        private static Set ParseToSet(string line)
        {
            var columns = line.Split(',');

            return new Set
            {
                SetNumId = columns[0],
                Name = columns[1],
                Year = columns[2],
                ThemeNameId = columns[3],
                NumParts = columns[4]
            };
        }
    }
}
