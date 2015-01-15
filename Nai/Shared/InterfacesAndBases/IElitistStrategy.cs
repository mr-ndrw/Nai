using System.Collections.Generic;
using Shared.Bases;

namespace Shared.InterfacesAndBases
{
	/// <summary>
	///		Exposes a method for 
	/// </summary>
	///	<remarks>
	///		The implementing class should be able to store the best solutions somehow.
	/// </remarks>
	public interface IElitistStrategy
	{
		/// <summary>
		///		Picks the best solution(s) within the space and holds.
		/// </summary>
		/// <param name="candidateSolutions">
		///		Space to search.
		/// </param>
		void PickBest(IEnumerable<CandidateSolution> candidateSolutions);

		/// <summary>
		///		Returns the best solutions, which were previously found.
		/// </summary>
		/// <returns>
		///		Collection of solutions.
		/// </returns>
		IEnumerable<CandidateSolution> ReturnBest();
	}
}
