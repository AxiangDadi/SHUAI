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
    public class KeeperServices
    {
        KeeperDAO kd = new KeeperDAO();
        DBSessionKeeper dk = new DBSessionKeeper();

        public int Longin(Keeper k) {
           return kd.Longin(k);
        }
     
        public List<Keeper> select()
        {
            KeeperInterface ti = dk.CreateKeeper();
            return ti.Select();
        }

        public bool Add(Keeper kp)
        {
            KeeperInterface ti = dk.CreateKeeper();
            ti.Add(kp);
            return dk.SaveChange();
        }

        public bool Update(Keeper kp)
        {
            KeeperInterface ti = dk.CreateKeeper();
            ti.Update(kp);
            return dk.SaveChange();
        }
        public bool Delete(Keeper kp)
        {
            KeeperInterface ti = dk.CreateKeeper();
            ti.Del(kp);
            return dk.SaveChange();
        }

        public DataTable selesy(int id)
        {
           return kd.selesy(id);
        }

        }
}
