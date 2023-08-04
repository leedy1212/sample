using Sample.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.SubFolder
{
	public class Foo2Dac
	{
		private static string bar2Sql;
		private string bar3Sql;

		static Foo2Dac()
		{
			bar2Sql = ResourceLoader.GetString(new SqlResourceLookup(typeof(Foo2Dac), "Bar2"));
		}

		public Foo2Dac()
		{
			bar3Sql = ResourceLoader.GetString(new SqlResourceLookup(GetType(), "Bar3"));
		}

		public string Bar()
		{
			SqlResourceLookup sr = new SqlResourceLookup(GetType());

			string queryForThisMethod = ResourceLoader.GetString(sr);
			return queryForThisMethod;
		}

		public string Bar2()
		{
			string queryForThisMethod = bar2Sql;

			return queryForThisMethod;
		}
		public string Bar3()
		{
			string queryForThisMethod = bar3Sql;

			return queryForThisMethod;
		}
	}
}
