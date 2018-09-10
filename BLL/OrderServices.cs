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
    public class OrderServices
    {

        OrderDAO od = new OrderDAO();
        DBSessionOrder so = new DBSessionOrder();
        public DataTable Cha()
        {
           return od.Cha();
        }

        public int Update(int sid, string oid)
        {
          return  od.Update(sid,oid);
        }


        public bool Del(Order o) {
            OrderInterface ti = so.CreateOrder();
            ti.Del(o);
            return so.SaveChange();
        }

        }
}
