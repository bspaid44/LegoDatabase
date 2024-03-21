using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDatabase.Models
{
    public class Theme
    {
        public int ThemeId { get; set; }
        public string ThemeNameId { get; set; }
        public string Name { get; set; }
        public string ParentId { get; set; }

        public Theme()
        {
        }

        public Theme(string themeId, string name, string parentId)
        {
            ThemeNameId = themeId;
            Name = name;
            ParentId = parentId;
        }

        public static List<Theme> ProcessFile(string path)
        {
            return
             File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(ParseToTheme)
                .ToList();

        }

        private static Theme ParseToTheme(string line)
        {
            var columns = line.Split(',');

            return new Theme
            {
                ThemeNameId = columns[0],
                Name = columns[1],
                ParentId = columns[2]
            };
        }
    }
}
