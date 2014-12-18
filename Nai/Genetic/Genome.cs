using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Genetic
{
	/// <summary>
	///		A singular unit in the genetic algorithm representing a candidate solution.
	/// </summary>
	public class Genome : CandidateSolution
	{
		public Genome(string chromosome) : base(chromosome)
		{
			var checkArray = chromosome.ToCharArray();

			if (checkArray.Any(c => c.CompareTo('1') != 0 || c.CompareTo('0') != 0))
			{
				throw new Exception("Passed string is not compromised of only 1's and 0's.");
			}

			Solution = checkArray.Select(Convert.ToBoolean);
		}

		public Genome(IEnumerable<bool> chromosome) : base(chromosome)
		{
			Solution = chromosome;
		}
	}
}
