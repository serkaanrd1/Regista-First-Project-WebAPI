using infrastructure.Utilities;
using Model.Dto.AdminPanelUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.interfaces
{
    public interface IAdminPanelUserBs
    {
        Task<ApiResponse<AdminPanelUserDto>> LogInAsync(string userName, string password, params string[] includeList);

    }
}
