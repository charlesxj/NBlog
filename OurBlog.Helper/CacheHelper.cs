using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OurBlog.Helper
{
    public class CacheHelper
    {
        public static void set(string key, object value, DateTime exDate)
        {
            HttpRuntime.Cache.Insert(key, value, null, exDate, TimeSpan.Zero);
        }

        public static void set(string key, object obj)
        {
            HttpRuntime.Cache.Insert(key, obj, null, DateTime.MaxValue, TimeSpan.Zero);
        }

        public static T Get<T>(string key)
        {
            return (T)HttpRuntime.Cache.Get(key);
        }

        public static object Get(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }
    }
}
