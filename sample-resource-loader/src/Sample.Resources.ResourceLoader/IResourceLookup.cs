namespace Sample.Resources
{
	/// <summary>
	/// 리소스 파일의 이름을 가리키는 기능을 제공합니다.
	/// </summary>
	public interface IResourceLookup
	{
		/// <summary>
		/// 리소스 파일의 이름을 반환합니다.
		/// </summary>
		/// <returns>리소스 파일 이름</returns>
		string GetResourceFileName();
	}
}
