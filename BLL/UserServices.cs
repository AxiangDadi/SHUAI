using DAL;
using DBSession;
using Interface;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class UserServices
    {
       DBSessionUser du = new DBSessionUser();
      
        public List<User> select()
        {
            UserInterface ti = du.CreateUser();
            return ti.Select();
        }


        public List<User> SelectBy(int id)
        {
            UserInterface ti = du.CreateUser();
            return ti.SelectBy(e=>e.UserID==id);
        }


        public bool Update(User u)
        {
            UserInterface ti = du.CreateUser();
            ti.Update(u);
            return du.SaveChange();
        }

        public bool Add(User u)
        {
            UserInterface ti = du.CreateUser();
            ti.Add(u);
            return du.SaveChange();
        }
        
        public bool Delete(User u)
        {
            UserInterface ti = du.CreateUser();
            ti.Del(u);
            return du.SaveChange();
        }

        UserDAO ud = new UserDAO();
        public object Login(User u)
        {
            return ud.Login(u);
        }
    }
}
