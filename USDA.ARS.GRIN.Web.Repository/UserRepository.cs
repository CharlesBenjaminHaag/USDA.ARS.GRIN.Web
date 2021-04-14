using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USDA.ARS.GRIN.Web.Models;

namespace USDA.ARS.GRIN.Web.Repository
{
    public class UserRepository : BaseRepository
    {
        public GRINUser Find(string userName)
        {
            GRINUser grinUser = new GRINUser();

            var users = _dataContext.usp_User_Search(userName).ToList();
            if (users.Count() > 0)
            {
                var user = users.First();
                grinUser = new GRINUser();
                grinUser.ID = user.sys_user_id;
                grinUser.UserName = user.user_name;
                grinUser.Password = user.password;
            }
            return grinUser;
        }
    }
}
