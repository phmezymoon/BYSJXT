using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace BYSJXT.Common
{
    public static class Md5Helper
    {
        public static string GetMd5String(string msg)
        {
            StringBuilder sb = new StringBuilder();
            //创建一个md5对象
            using (MD5 md5 = MD5.Create())
            {
                //把字符串转为byte数组
                byte[] bytes = System.Text.Encoding.Default.GetBytes(msg);
                //调用该对象的方法进行md5计算
                byte[] md5Bytes = md5.ComputeHash(bytes);
                //把结果已字符串的形式返回
                for (int i = 0; i < md5Bytes.Length; i++)
                {
                    sb.Append(md5Bytes[i].ToString("x2"));//转成16进制 每个字节占2位
                }
            }
            return sb.ToString();
        }
    }
}
