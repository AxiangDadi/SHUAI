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
   public class GoodsDAO : BaseDao<Goods>, GoodsInterface
    {
        public DataTable SelectByTime()
        {
            string sql = string.Format(@"select top 3 * from [dbo].[Goods] Order By [GoodsTime] Desc");
            return DBHelper.查询DataTable(sql);
        }
        public DataTable SelectByNum()
        {
            string sql = string.Format(@"select top 3 * from [dbo].[Goods] Order By [GoodsNum]  Desc");
            return DBHelper.查询DataTable(sql);
        }
        public DataTable SelectByPrice()
        {
            string sql = string.Format(@"select top 3 * from [dbo].[Goods] Order By [GoodsPrice]  Desc");
            return DBHelper.查询DataTable(sql);
        }
        public DataTable SelectByShow()
        {
            string sql = string.Format(@"select top 3 * from [dbo].[Goods] ");
            return DBHelper.查询DataTable(sql);
        }
        public DataTable SelectShoes()
        {
            string sql = string.Format(@"select top 3 * from [dbo].[Goods] where TypeID=7 Order By GoodsTime desc ");
            return DBHelper.查询DataTable(sql);
        }
    }
}
