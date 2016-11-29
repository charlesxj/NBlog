using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OurBlog.Helper
{
    public class SerializeHelper
    {
        public static string SerializeObjectToJson<T>(T value)
        {
            //System.Web.Script.Serialization.JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            //return scriptSerializer.Serialize(value);

            //Json.Net:
            //return Newtonsoft.Json.JsonConvert.SerializeObject(value);            

            return JsonConvert.SerializeObject(value, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

        public static T DeSerializeStringToObject<T>(string json)
        {
            //System.Web.Script.Serialization.JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            //return scriptSerializer.Deserialize<T>(json);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);

        }
    }
}
