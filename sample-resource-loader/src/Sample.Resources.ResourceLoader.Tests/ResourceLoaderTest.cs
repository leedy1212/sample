using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.Resources;
using System.Resources;
using System.Reflection;
using System.Collections;
using System.Globalization;
using System.IO;

namespace Sample.Resources
{
	[TestClass]
	public class ResourceLoaderTest
	{
		[TestMethod]
		public void TestGetStringResource()
		{
			string resource = ResourceLoader.GetString(new SqlResourceLookup(GetType()));
			Assert.AreEqual("select * from string_resources", resource);
		}		
	}
}
