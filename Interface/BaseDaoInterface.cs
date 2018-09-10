using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface BaseDaoInterface<T> where T:class
    {
        bool Add(T st);
        bool Del(T st);
        bool Update(T st);
        List<T> Select();
        List<T> SelectBy(Expression<Func<T, bool>> where);
    }
}
