using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBHelper
    {
        static string conStr = @"Data Source=.;Initial Catalog=Xm;Integrated Security=True";

        //异常处理
        public static void 异常(Exception ex)
        {
           // using (StreamWriter sw = new StreamWriter("日志错误.txt", true))
           // {
            ///    sw.WriteLine("错误时间:" + DateTime.Now);
             //   sw.WriteLine("错误内容:" + ex.Message);
              //  sw.WriteLine("错误的文件:Program.cs");
              //  sw.WriteLine("--------------------------------");
          //  }
        }

        //增删改
        public static int Update(string sql, params SqlParameter[] ps)
        {
            int r = 0;

            SqlConnection cn = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand(sql, cn);
            if (ps.Length > 0)
            {
                cmd.Parameters.AddRange(ps);
            }

            try
            {
                cn.Open();
                r = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                异常(ex);
            }
            finally
            {
                cn.Close();
            }
            return r;
        }

        //单个查询
        public static object 查询单个(string sql, params SqlParameter[] ps)
        {
            object obj = null;

            SqlConnection cn = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand(sql, cn);
            if (ps.Length > 0)
            {
                cmd.Parameters.AddRange(ps);
            }


            try
            {
                cn.Open();
                obj = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                异常(ex);
            }
            finally
            {
                cn.Close();
            }
            return obj;
        }

        //查询Reader
        public static SqlDataReader 查询Reader(string sql, params SqlParameter[] ps)
        {
            SqlDataReader reader = null;

            SqlConnection cn = new SqlConnection(conStr);

            SqlCommand cmd = new SqlCommand(sql, cn);

            if (ps.Length > 0)
            {
                cmd.Parameters.AddRange(ps);
            }

            try
            {
                cn.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                异常(ex);
            }
            return reader;
        }

        //查询DataTable
        public static DataTable 查询DataTable(string sql)
        {

            SqlConnection cn = new SqlConnection(conStr);

            SqlDataAdapter ad = new SqlDataAdapter(sql, cn);

            DataTable dt = new DataTable();

            try
            {
                ad.Fill(dt);
            }
            catch (Exception ex)
            {

                异常(ex);
            }
            return dt;
        }

        //获取一张表
        public static DataTable Proc(string sql, params SqlParameter[] ps)
        {

            SqlConnection cn = new SqlConnection(conStr);

            SqlDataAdapter ad = new SqlDataAdapter(sql, cn);
            ad.SelectCommand.CommandType = CommandType.StoredProcedure;
            if (ps.Length > 0)
            {
                ad.SelectCommand.Parameters.AddRange(ps);
            }

            DataTable dt = new DataTable();

            try
            {
                ad.Fill(dt);
            }
            catch (Exception ex)
            {

                异常(ex);
            }
            return dt;
        }

    }
}
