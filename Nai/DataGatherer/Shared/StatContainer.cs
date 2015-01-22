using System.Collections.Generic;
using Shared.Utils;

namespace DataGatherer.Shared
{
	public class StatContainer
	{
		private readonly int _numberOfElements;

		public List<Pair<double>> ListOfPairValues { get; set; }

		public StatContainer(int numberOfElements)
		{
			this._numberOfElements = numberOfElements;
			ListOfPairValues = new List<Pair<double>>();
		}

	}
}
