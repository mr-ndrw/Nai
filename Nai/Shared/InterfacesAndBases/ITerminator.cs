using System.Collections.Generic;
using Shared.Bases;

namespace Shared.InterfacesAndBases
{
	/// <summary>
	///		Defines means of evaluating a collection and determining whether it meets given criteria.
	/// </summary>
	public interface ITerminator
	{
		///  <summary>
		/// 		Analyzes the population and determines whether the termination condition was met.
		///  </summary>
		/// <param name="candidateSolutions">
		///		Collection of solutions to analyze.
		/// </param>
		/// <returns>
		///		Has this colletion met the implemented criteria.
		/// </returns>
		bool IsTerminationConditionMet(IEnumerable<CandidateSolution> candidateSolutions);
	}
}
