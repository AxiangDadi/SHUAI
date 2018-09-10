using DAL;
using DBSession;
using Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class TypeServices
    {
        DBSessionType td = new DBSessionType();

        public List<Model.Type> select() {
            TypeInterface ti = td.CreateType();
            return ti.Select();
        }

        public bool Add(Model.Type ty) {
            TypeInterface ti = td.CreateType();
            ti.Add(ty);
            return td.SaveChange();
        }

        public bool Update(Model.Type ty) {
            TypeInterface ti = td.CreateType();
            ti.Update(ty);
            return td.SaveChange();
        }
        public bool Delete(Model.Type ty) {
            TypeInterface ti = td.CreateType();
            ti.Del(ty);
            return td.SaveChange();
        }
   
        }
    }
