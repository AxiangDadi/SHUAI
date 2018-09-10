using DAL;
using DBSession;
using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class SizeServices
    {
        DBSessionSize si = new DBSessionSize();

        public List<Size> select()
        {
            SizeInterface ti = si.CreateSize();
            return ti.Select();
        }

        SizeDAO sd = new SizeDAO();
      

        
        //根据商品类型ID查询该类型下的库存
        public DataTable SelectAll(int GoodsId)
        {
            return sd.SelectAll(GoodsId);
        }
        //根据商品ID查询该商品下的尺码
        public DataTable SelectBySize(int GoodsId)
        {
            return sd.SelectBySize(GoodsId);
        }

        public DataTable SelectBySizeCount(Size s)
        {
            return sd.SelectBySizeCount(s);
        }
    }
}
