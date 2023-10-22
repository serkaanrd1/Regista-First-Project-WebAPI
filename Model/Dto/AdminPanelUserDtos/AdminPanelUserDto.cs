using infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dto.AdminPanelUserDtos
{
    public class AdminPanelUserDto : IDto
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
