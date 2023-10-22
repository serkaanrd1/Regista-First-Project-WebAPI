using infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Product : IEntity
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public short? UnitsInStock { get; set; }
        public bool? IsActive { get; set; }
        public string? PicturePath { get; set; }
    }
}
