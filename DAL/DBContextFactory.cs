using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBContextFactory
    {
            /// <summary>
            /// 一次请求中，数据上下文唯一
            /// </summary>
            /// <returns></returns>
            public static DbContext CreateDBContext()
            {
                DbContext db = (DbContext)CallContext.GetData("context");
                if (db == null)
                {
                    db = new XmEntities();
                    CallContext.SetData("context", db);
                }
                return db;
        }
    }
}
