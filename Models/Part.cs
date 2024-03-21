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
        public int Id { get; set; }
        public int PartNumId { get; set; }
        public string Name { get; set; }
        public int PartCategoryId { get; set; }
        public PartCategory PartCategory { get; set; }

        public Part()
        {
        }

        public Part(int partNumId, string name, int partCategoryId)
        {
            PartNumId = partNumId;
            Name = name;
            PartCategoryId = partCategoryId;
        }
    }
}
