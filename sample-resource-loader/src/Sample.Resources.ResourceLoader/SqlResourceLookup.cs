using System;
using System.Runtime.CompilerServices;

namespace Sample.Resources
{
	/// <summary>
	/// 일정 규칙으로 작성한 리소스의 경로를 반환합니다.
	/// </summary>
	public class SqlResourceLookup : IResourceLookup
	{
		private Type callerType;
		private string callerMethodName;

		/// <summary>
		/// 이 클래스의 새 인스턴스를 초기화합니다.
		/// </summary>
		/// <param name="callerType">이 클래스를 호출하는 클래스의 형식</param>
		/// <param name="methodName">이 클래스를 호출하는 메서드의 이름 (인라인으로 호출하지 않을 경우 별도 입력 필요)</param>
		public SqlResourceLookup(Type callerType, [CallerMemberName] string methodName = "")
		{
			if (callerType == null) throw new ArgumentNullException("callerType");

			this.callerType = callerType;
			this.callerMethodName = methodName;
		}

		/// <summary>
		/// 리소스 이름을 반환합니다.
		/// </summary>
		/// <returns>리소스 이름</returns>
		public string GetResourceFileName()
		{
			string ret =
				callerType.Namespace +
				".Resources" +
				"." + callerType.Name +
				"." + callerMethodName +
				".sql";

			return ret;
		}
	}
}
