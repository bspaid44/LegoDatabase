using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDatabase.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorNameId { get; set; }
        public string Name { get; set; }
        public string RGB { get; set; }
        public string IsTrans { get; set; }

        public Color() 
        {
        }

        public Color(string colorid, string name, string rgb, string isTrans)
        {
            ColorNameId = colorid;
            Name = name;
            RGB = rgb;
            IsTrans = isTrans;
        }

        public static List<Color> ProcessFile (string path)
        {
            return 
             File.ReadAllLines(path)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(ParseToColor)
                .ToList();
                
        }

        private static Color ParseToColor(string line)
        {
            var columns = line.Split(',');

            return new Color
            {
                ColorNameId = columns[0],
                Name = columns[1],
                RGB = columns[2],
                IsTrans = columns[3]
            };
        }
    }
}
