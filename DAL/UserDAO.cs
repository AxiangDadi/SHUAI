using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAO : BaseDao<User>, UserInterface
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public int Login(User u)
        {
            string sql = string.Format(@"select Count(*) from [dbo].[User] where UserName='{0}' and UserPwd='{1}'", u.UserName, u.UserPwd);
            return (int)DBHelper.查询单个(sql);

        }
    }
}
