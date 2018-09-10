using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BaseDao<T> where T : class
    {
        DbContext st = DBContextFactory.CreateDBContext();

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public List<T> Select()
        {

            List<T> list = st.Set<T>().
                Select(e => e).
                ToList();
            return list;
        }

        /// <summary>
        /// 条件查询 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<T> SelectBy(Expression<Func<T, bool>> where)
        {

            List<T> list = st.Set<T>()
                 .Select(e => e)
                 .Where(where)
                 .ToList();
            return list;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Add(T t)
        {
            st.Set<T>().Add(t);//标记对象状态为新增
            return true;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update(T t)
        {
            //标记对象的状态为修改
            st.Entry<T>(t).State = EntityState.Modified;
            return true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Del(T t)
        {
            //标记对象的状态为删除
            st.Entry<T>(t).State = EntityState.Deleted;//标记为删除
            return true;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="K"></typeparam>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="rows"></param>
        /// <param name="where"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<T> FenYe<K>(int currentPage, int pageSize, ref int rows, Expression<Func<T, bool>> where, Expression<Func<T, K>> order) where K : struct
        {

            var data = st.Set<T>().Where(where).OrderBy(order);
            rows = data.Count();//总行数
            List<T> datas = data.Skip((currentPage - 1) * pageSize)
                 .Take(pageSize)
                 .ToList();
            return datas;
        }
    }
}
