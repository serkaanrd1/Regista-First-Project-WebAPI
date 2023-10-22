using DataAcsess.implemantations.EF.Context;
using DataAcsess.implemantations.interfaces;
using infrastructure.DataAccses.EF;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcsess.implemantations.Repositories
{
    public class AdminPanelUserRepository : BaseRepository<AdminPanelUser, RegistaContext>, IAdminPanelUserRepository
    {
        public async Task<AdminPanelUser> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList)
        {
            return await GetAsync(a => a.UserName == userName && a.Password == password && a.IsActive.Value, includeList);
        }
    }
}
