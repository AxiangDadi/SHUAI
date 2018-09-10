using Common;
using DAL;
using Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSession
{
   public class DBSessionEvaluation
    {
        //1 获得数据访问层对象的创建
        public EvaluationInterface CreateEvaluation()
        {
            return new EvaluationDAO();
        }
        DbContext st = DBContextFactory.CreateDBContext();
        //2 实现数据的事物操作
        public bool SaveChange()
        {
            bool result = false;
            try
            {
                result = st.SaveChanges() > 0;
            }
            catch (Exception ex)
            {

                LogHelper.WriteLog(typeof(DBSessionEvaluation), ex);
            }
            return result;
        }
    }
}
