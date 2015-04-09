using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Complex.Common.Utility
{
    public class Json
    {
        /// <summary>
        /// 序列化操作
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="obj">序列化对象</param>
        /// <returns></returns>
        public static string Serialize<T>(T obj)
        {
            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
            var ms = new MemoryStream();
            serializer.WriteObject(ms, obj);
            var retVal = Encoding.UTF8.GetString(ms.ToArray());
            ms.Dispose();
            return retVal;
        }

        /// <summary>
        /// 反序列化操作
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="json">字符传</param>
        /// <returns></returns>
        public static T Deserialize<T>(string json)
        {
            var obj = Activator.CreateInstance<T>();
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
            obj = (T)serializer.ReadObject(ms);
            ms.Close();
            ms.Dispose();
            return obj;
        }
    }
}
