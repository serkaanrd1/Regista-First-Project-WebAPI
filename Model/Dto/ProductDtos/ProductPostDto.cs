using infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto.ProductDtos
{
    public class ProductPostDto : IDto
    {
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public string PicturePath { get; set; }
    }
}
