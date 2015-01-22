using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGatherer
{
	class MainProgram
	{
		static int Main()
		{
			MutationData();

			return 0;
		}


		private static void MutationData()
		{
			var gatherer = new BitMutationChanceDataGatherer("yada", "yada");
			gatherer.Evaluate();
		}
	}
}
