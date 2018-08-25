using System.Web.Script.Serialization;

namespace ExtensionLibrary
{
    public static class JsonExtensions
    {
        /// <summary>
        /// Searialize object to json string
        /// </summary>
        /// <param name="this"></param>
        /// <returns>json string</returns>
        public static string ToJson(this object @this)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(@this);
        }
        /// <summary>
        /// Searialize object to json string with depth limit
        /// </summary>
        /// <param name="this"></param>
        /// <param name="recursionDepth">Recursion limit</param>
        /// <returns></returns>
        public static string ToJson(this object @this, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(@this);
        }

        public static T FromJson<T>(this object @this)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(@this as string);
        }
    }
}
