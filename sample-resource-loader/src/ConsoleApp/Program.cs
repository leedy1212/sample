using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample;
using Sample.SubFolder;

namespace ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			FooDac foo = new FooDac();
			Console.WriteLine("FooDac.Bar=" + foo.Bar());
			Console.WriteLine("FooDac.Bar2=" + foo.Bar2());

			Foo2Dac foo2 = new Foo2Dac();
			Console.WriteLine("Foo2Dac.Bar=" + foo2.Bar());
			Console.WriteLine("Foo2Dac.Bar2=" + foo2.Bar2());
			Console.WriteLine("Foo2Dac.Bar3=" + foo2.Bar3());

			Console.Read();
		}
	}
}
