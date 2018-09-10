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
    public class StateServices
    {
        DBSessionState ds = new DBSessionState();

        public List<State> select()
        {
            StateInterface ti = ds.CreateState();
            return ti.Select();
        }

    }
}
