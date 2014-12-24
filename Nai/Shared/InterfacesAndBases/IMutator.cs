using System.Collections.Generic;
using Shared.Bases;

namespace Shared.InterfacesAndBases
{
	/// <summary>
	///		Serves as a base class for all classes which want to become MutationMethods which allow the candidate solutions to mutate and change.
	/// </summary>
	public interface IMutator
	{
		/// <summary>
		///		Pefroms a mutation only on one CandidateSolution.
		/// </summary>
		/// <param name="solutionToMutate">
		///		Solution to mutate.
		/// </param>
		void Mutate(CandidateSolution solutionToMutate);

		/// <summary>
		///		Performs a mutation on the whole popluation of solutions.
		/// </summary>
		/// <param name="populationToMutate">
		///		Population to mutate within.
		/// </param>
		void Mutate(IEnumerable<CandidateSolution> populationToMutate);
	}
}
