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
        public int Id { get; set; }
        public int SetNumId { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }
        public int NumParts { get; set; }

        public Set()
        {
        }

        public Set(int setNumId, string name, int year, int themeId, int numParts)
        {
            SetNumId = setNumId;
            Name = name;
            Year = year;
            ThemeId = themeId;
            NumParts = numParts;
        }
    }
}
