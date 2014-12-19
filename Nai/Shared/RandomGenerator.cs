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
		///		Generates a random CandidateSolution of given length. (Randomizes it's true-false collection).
		/// </summary>
		/// <param name="length">
		///		Length of the solution.
		/// </param>
		public CandidateSolution GetRandomCandidateSolution(int length)
		{
			var randomTrueFalseCollection = Enumerable.Range(0, length).Select(r =>_random.NextDouble() > 0.5);

			var result = new

		}
	}
}
