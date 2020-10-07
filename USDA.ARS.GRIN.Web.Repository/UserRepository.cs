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
            GRINUser grinUser = null;

            var user = _dataContext.usp_User_Search(userName).First();
            if (user != null)
            {
                grinUser = new GRINUser();
                grinUser.ID = user.sys_user_id;
                grinUser.UserName = user.user_name;
                grinUser.Password = user.password;
            }
            return grinUser;
        }
    }
}
