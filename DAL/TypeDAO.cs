using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class TypeDAO : BaseDao<Model.Type>, TypeInterface
    {
        public DataTable selectBytop() {
            string sql = string.Format(@"select top(8)* from Type");
            DataTable dt = DBHelper.查询DataTable(sql);
            return dt;
        }
    }
}
