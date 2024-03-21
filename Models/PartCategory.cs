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
        public string Name { get; set; }

        public PartCategory()
        {
        }

        public PartCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
