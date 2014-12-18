using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public abstract class CandidateSolution
	{
		protected CandidateSolution(string chromosome)
		{
			var checkArray = chromosome.ToCharArray();

			if (checkArray.Any(c => c.CompareTo('1') != 0 || c.CompareTo('0') != 0))
			{
				throw new Exception("Passed string is not compromised of only 1's and 0's.");
			}

			Solution = checkArray.Select(Convert.ToBoolean);
		}

		protected CandidateSolution(IEnumerable<bool> chromosome)
		{
			Solution = chromosome;
		}

		/// <summary>
		///		An array of 0's and 1's represeting a solution.
		/// </summary>
		public IEnumerable<bool> Solution { get; set; }

		/// <summary>
		///		Result of the evaluation by the funtion.
		/// </summary>
		public double EvaluationResult { get; set; }
	}
}
