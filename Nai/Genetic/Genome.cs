using System.Collections.Generic;
using Shared;

namespace Genetic
{
	/// <summary>
	///		A singular unit in the genetic algorithm representing a candidate solution.
	/// </summary>
	public class Genome : CandidateSolution
	{
		/// <summary>
		///		Initializes an object with a 0's and 1's string, having previously extracted data and check for exceptions.
		/// </summary>
		/// <param name="zerosOnesString">
		///		String compromised of 0's and 1's.
		/// </param>
		public Genome(string zerosOnesString) : base(zerosOnesString)
		{
		}

		/// <summary>
		///		Initializes and object with a collection of bools.
		/// </summary>
		/// <param name="boolCollection">
		///		Collection of bools.
		/// </param>
		public Genome(IEnumerable<bool> boolCollection) : base(boolCollection)
		{
		}
	}
}
