using Shared.Bases;

namespace Shared.InterfacesAndBases
{
	/// <summary>
	///		Provides means of evaluating units in the solution space.
	/// </summary>
	public interface IEvaluationFunction
	{
		/// <summary>
		///		Evaluates the solution candidate and assigns a value to it.
		/// </summary>
		/// <param name="solutionCandidate">
		///		Solution to evaluate.
		/// </param>
		/// <returns>
		///		The value that was assigned to the candidate.
		/// </returns>
		double EvaluateGenome(CandidateSolution solutionCandidate);
	}
}
