using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoDatabase.Models
{
    public class Theme
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }

        public Theme()
        {
        }

        public Theme(int id, string name, int parentId)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
        }
    }
}
