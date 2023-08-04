using System.Linq;
using System.Reflection;

namespace Demo.Api.Common.Utils
{
    public class PropertiesUtil
    {
        /// <summary>
        /// source 오브젝트에서 result 오브젝트로 Property의 값을 복사해준다.
        /// </summary>
        /// <param name="source">원본</param>
        /// <param name="result">대상</param>
        /// <param name="ignorePropertyFilter">제외할 Property 목록</param>
        public static void CopyProperties(object source, object result, string[] ignorePropertyFilter)
        {
            PropertyInfo[] sourceProperties = source.GetType().GetProperties();
            PropertyInfo[] resultProperties = result.GetType().GetProperties();
            foreach (var sp in sourceProperties)
            {
                if (ignorePropertyFilter != null && ignorePropertyFilter.Contains(sp.Name)) continue;

                var rp = resultProperties.FirstOrDefault(o => o.Name == sp.Name && o.PropertyType == sp.PropertyType && o.GetSetMethod() != null);
                if (rp == null) continue;

                rp.SetValue(result, sp.GetValue(source, null), null);
            }
        }    
    }
}