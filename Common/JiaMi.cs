using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Common
{
    public class JiaMi
    {
        public static string PassMD5(string s)
        {
            MD5 md = MD5.Create();
            byte[] bt = Encoding.Default.GetBytes(s);
            byte[] bt5 = md.ComputeHash(bt);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bt5.Length; i++)
            {
                sb.Append(bt5[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
