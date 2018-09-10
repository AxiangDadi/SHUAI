using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBSession;
using Interface;
namespace BLL
{
    public class ShoopServices
    {
        DBSessionShoop td = new DBSessionShoop();
        public bool Add(Shoop sp)
        {
            ShoopInterface ti = td.CreateShoop();
            ti.Add(sp);
            return td.SaveChange();
        }
    }
}
