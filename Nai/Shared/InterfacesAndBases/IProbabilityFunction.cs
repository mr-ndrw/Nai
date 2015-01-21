using Shared.Bases;

namespace Shared.InterfacesAndBases
{
	/// <summary>
	///		Defines a contract for obtaining a probability of choosing a new element in SA.
	/// </summary>
	public interface IProbabilityFunction
	{
		/// <summary>
		///		Calculates the propability by taking into account the evaluatedSolution, it's chosen neighbour and the current temperature.
		/// </summary>
		/// <param name="evaluatedSolution">
		///		Currently evaluated solution.
		/// </param>
		/// <param name="neighgourSolutionToEvaluated">
		///		Solution which is a neighbour to the currently evaluated solution.
		/// </param>
		/// <param name="currentTemperature">
		///		The temperature of the algorithm.
		/// </param>
		/// <returns>
		///		Returns a double value from 0.0 to 1.0.
		/// </returns>
		double CalculateProbabilityOfChoice(CandidateSolution evaluatedSolution, CandidateSolution neighgourSolutionToEvaluated,
		                                    double currentTemperature);
	}
}
