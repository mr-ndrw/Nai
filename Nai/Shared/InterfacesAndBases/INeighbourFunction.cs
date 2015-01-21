using Shared.Bases;

namespace Shared.InterfacesAndBases
{
	public interface INeighbourFunction
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
		CandidateSolution SelectNeighbour(CandidateSolution candidateSolution);
	}
}
