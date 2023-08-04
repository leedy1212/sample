using Sample.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
	public class FooDac
	{
		public string Bar()
		{
			SqlResourceLookup sr = new SqlResourceLookup(GetType());			
			string queryForThisMethod = ResourceLoader.GetString(sr);
			return queryForThisMethod;
		}

		public string Bar2()
		{
			string queryForThisMethod = ResourceLoader.GetString(new SqlResourceLookup(GetType()));
			return queryForThisMethod;
		}
	}
}
