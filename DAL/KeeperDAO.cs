using Common;
using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KeeperDAO : BaseDao<Keeper>, KeeperInterface
    {
        public int Longin(Keeper k)
        {
            string pwd = k.KPwd;
            var password = JiaMi.PassMD5(pwd);
            string sql = string.Format(@"select COUNT(*) from [dbo].[Keeper] where KName='{0}' and KPwd = '{1}'",k.KName, password);
            int i=(int) DBHelper.查询单个(sql);
            return i;
        }

        public DataTable selesy(int id) {
            string sql = string.Format(@"select * from [dbo].[Keeper] where [KID]='{0}'",id);
            DataTable dt= DBHelper.查询DataTable(sql);
            return dt;
        }
    }
}
