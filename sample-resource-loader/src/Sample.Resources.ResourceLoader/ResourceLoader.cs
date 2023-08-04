using System;
using System.IO;
using System.Reflection;

namespace Sample.Resources
{
	/// <summary>
	/// 이 클래스를 사용하면 리소스를 간편하게 읽을 수 있습니다.
	/// </summary>
	public static class ResourceLoader
	{
		/// <summary>
		/// 지정된 string 리소스의 값을 반환합니다.
		/// </summary>
		/// <param name="resource">리소스 파일의 경로를 가리키는 인터페이스를 구현한 클래스</param>
		/// <returns>리소스의 값입니다.</returns>
		/// <exception cref="InvalidOperationException">읽고자 하는 리소스 파일이 없을 경우</exception>
		public static string GetString(IResourceLookup resource)
		{
			if (resource == null) throw new ArgumentNullException("resource");

			Assembly caller = Assembly.GetCallingAssembly();
			string resourceName = resource.GetResourceFileName();
			Stream s = null;
			try
			{				
				s = caller.GetManifestResourceStream(resourceName);
				if (s == null) throw new InvalidOperationException("Could not find embedded resource file. (assemblyName=" + caller.GetName() + ",resourceName=" + resourceName + ")");

				using (StreamReader r = new StreamReader(s))
				{
					string ret = r.ReadToEnd();
					return ret;
				}
			}
			finally
			{
				if (s != null) s.Dispose();
			}
		}
	}
}
