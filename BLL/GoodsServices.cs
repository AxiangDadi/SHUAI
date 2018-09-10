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
    public class GoodsServices
    {
        DBSessionGoods dg = new DBSessionGoods();
        GoodsDAO gd = new GoodsDAO();
        public List<Goods> select()
        {
            GoodsInterface ti = dg.CreateGoods();
            return ti.Select();
        }

        public List<Goods> SelectBy(int id)
        {
            GoodsInterface ti = dg.CreateGoods();
            return ti.SelectBy(e => e.GoodsID == id);
        }

        public bool Update(Goods g)
        {
            GoodsInterface ti = dg.CreateGoods();
            ti.Update(g);
            return dg.SaveChange();
        }


        public bool Add(Goods g)
        {
            GoodsInterface ti = dg.CreateGoods();
            ti.Add(g);
            return dg.SaveChange();
        }

        public bool Delete(Goods g)
        {
            GoodsInterface ti = dg.CreateGoods();
            ti.Del(g);
            return dg.SaveChange();
        }


        public bool SelectAll()
        {
            GoodsInterface gf = dg.CreateGoods();
            gf.Select();
            return dg.SaveChange();
        }


        public List<Goods> SelectBys(int id)
        {
            GoodsInterface gf = dg.CreateGoods();
            return gf.SelectBy(e => e.TypeID == id);
        }

 
        //根据最新上架时间，查询相应商品信息
        public DataTable SelectByTime()
        {
            return gd.SelectByTime();
        }
        //根据销售数量多少查询商品信息
        public DataTable SelectByNum()
        {
            return gd.SelectByNum();
        }
        //根据价格，由高到低查询商品信息
        public DataTable SelectByPrice()
        {
            return gd.SelectByPrice();
        }
        //时装
        public DataTable SelectByShow()
        {
            return gd.SelectByShow();
        }
        //特色系列
        public DataTable SelectShoes()
        {
            return gd.SelectShoes();
        }
        //点击Shop查看这个商品的详细信息
        public List<Goods> SelectByDescripy(int id)
        {
            GoodsInterface gf = dg.CreateGoods();
            return gf.SelectBy(e => e.GoodsID == id);
        }
    }
}
