using System.Linq;
using Shared;
using Shared.Bases;
using Shared.InterfacesAndBases;

namespace SimulatedAnnealing
{
	public class NeighbourFunction : INeighbourFunction
	{
		/// <summary>
		///		Chooses and returns the neighbour of the parametrized solution.
		/// </summary>
		/// <param name="candidateSolution">
		///		Solution for which we find a neigbour.
		/// </param>
		/// <returns>
		///		Neigbour solution.
		/// </returns>
		public CandidateSolution SelectNeighbour(CandidateSolution candidateSolution)
		{
			var solutionToChange = candidateSolution.Solution.ToArray();

			var numberOfBits = solutionToChange.Count();

			var bitToChangeIndex = RandomGenerator.GetRandomInt(numberOfBits);

			solutionToChange[bitToChangeIndex] = !solutionToChange[bitToChangeIndex];

			var neigbhourSolution = new CandidateSolution(solutionToChange);

			return neigbhourSolution;
		}
	}
}
