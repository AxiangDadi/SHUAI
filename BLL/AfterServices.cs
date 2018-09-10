using DBSession;
using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class AfterServices
    {
        DBSessionAfter db = new DBSessionAfter();

        public List<After> Select()
        {
            AfterInterface ist = db.CreateAfter();
            return ist.Select();
        }

        public bool Dele(After s)
        {
            AfterInterface ist = db.CreateAfter();
            return ist.Del(s);
        }
    }
}
