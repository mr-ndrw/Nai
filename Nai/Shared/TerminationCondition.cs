using System.Collections.Generic;

namespace Shared
{
	/// <summary>
	///		Defines means of evaluating a collection and determining whether it meets given criteria.
	/// </summary>
	public interface ITerminationCondition
	{
		///  <summary>
		/// 		Analyzes the population and determines whether the termination condition was met.
		///  </summary>
		/// <param name="candidateSolutions">
		///		Collection of solutions to analyze.
		/// </param>
		/// <returns>
		///		Has this colletion met the criteria.
		/// </returns>
		bool IsTerminationConditionMet(IEnumerable<CandidateSolution> candidateSolutions);
	}
}
