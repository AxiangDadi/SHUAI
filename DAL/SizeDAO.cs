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
     public class SizeDAO : BaseDao<Size>, SizeInterface
    {
        public DataTable SelectAll(int GoodsId)
        {
            string sql = string.Format(@"select SUM(GoodsCount) from [dbo].[Size]  where GoodsId='{0}'", GoodsId);
            return DBHelper.查询DataTable(sql);
        }
        public DataTable SelectBySize(int GoodsId)
        {
            string sql = string.Format(@"select GoodsId,  SizeName  from  [dbo].[Size]  where GoodsId='{0}'", GoodsId);
            return DBHelper.查询DataTable(sql);
        }
        public DataTable SelectBySizeCount(Size s)
        {
            string sql = string.Format(@"select GoodsCount from [dbo].[Size]  where SizeName='{0}' and GoodsId='{1}'", s.SizeName, s.GoodsId);
            return DBHelper.查询DataTable(sql);
        }
    }
}
