using System.Collections.Generic;
using MoreLinq;
using Shared.Bases;
using Shared.InterfacesAndBases;

namespace GeneticOperators.ElitistStrategies
{
	public class BestSolutionElitist : IElitistStrategy
	{
		private CandidateSolution _bestCandidateSolution;

		public BestSolutionElitist()
		{
		}

		/// <summary>
		///		Picks the best solution(s) within the space and holds them.
		/// </summary>
		/// <param name="candidateSolutions">
		///		Space to search.
		/// </param>
		public void PickBest(IEnumerable<CandidateSolution> candidateSolutions)
		{
			this._bestCandidateSolution = candidateSolutions.MaxBy(solution => solution.EvaluationResult);
		}

		/// <summary>
		///		Returns the best solution in a form of one element list.
		/// </summary>
		/// <returns>
		///		Collection of solutions containing just one element.
		/// </returns>
		public IEnumerable<CandidateSolution> ReturnBest()
		{
			return new List<CandidateSolution> {this._bestCandidateSolution};
		}
	}
}
