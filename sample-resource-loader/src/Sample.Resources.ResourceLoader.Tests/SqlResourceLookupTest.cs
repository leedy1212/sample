using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sample.Resources
{
	[TestClass]
	public class SqlResourceLookupTest
	{
		[TestMethod]
		public void GetResourceFileName()
		{
			string expected = "Sample.Resources.Resources.SQLResourceLookupTest.GetResourceFileName.sql";
			string actual = new SqlResourceLookup(GetType()).GetResourceFileName();
			Assert.AreEqual(expected, actual);
		}
	}
}
