using System.Collections.Generic;
using Shared.Bases;
using Shared.InterfacesAndBases;

namespace GeneticOperators.ElitistStrategies
{
	/// <summary>
	///		Elitist strategy which doesn't perform any search for best solutions.
	/// </summary>
	public class NoElitist : IElitistStrategy
	{
		/// <summary>
		///		Does nothing.
		/// </summary>
		/// <param name="candidateSolutions">
		///		Space to search.
		/// </param>
		public void PickBest(IEnumerable<CandidateSolution> candidateSolutions)
		{

		}

		/// <summary>
		///		Returns an empty collection.
		/// </summary>
		/// <returns>
		///		Empty collection.
		/// </returns>
		public IEnumerable<CandidateSolution> ReturnBest()
		{
			return new List<CandidateSolution>();
		}
	}
}
