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
   public class OrderDAO : BaseDao<Order>, OrderInterface
    {
        public DataTable Cha() {
            string sql = "select * from [dbo].[Dingdan]";
            DataTable dt= DBHelper.查询DataTable(sql);
            return dt;
        }

        public int Update(int sid,string oid) {
            string sql = string.Format(@"update [dbo].[Order] set[StateId]='{0}' where [OrderNumber]='{1}'",sid,oid);
           int i=  DBHelper.Update(sql);
            return i;
        }
    }
}
