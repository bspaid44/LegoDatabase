using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDatabase.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RGB { get; set; }
        public char IsTrans { get; set; }

        public Color() 
        {
        }

        public Color(int id, string name, string rgb, char isTrans)
        {
            Id = id;
            Name = name;
            RGB = rgb;
            IsTrans = isTrans;
        }
    }
}
