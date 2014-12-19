using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public class RandomGenerator
	{
		private static Random _random;


		static RandomGenerator()
		{
			_random = new Random();
		}

		/// <summary>
		///		Generates a random collection of bools of specified count.
		/// </summary>
		/// <param name="length">
		///		Count of the collection.
		/// </param>
		public IEnumerable<bool> GetRandomBoolCollection(int length)
		{
			var randomTrueFalseCollection = Enumerable.Range(0, length).Select(r =>_random.NextDouble() > 0.5);

			return randomTrueFalseCollection;
		}
	}
}
