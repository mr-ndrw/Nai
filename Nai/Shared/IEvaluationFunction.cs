namespace Shared
{
	public interface IEvaluationFunction
	{
		/// <summary>
		///		Evaluates the solution candidate and 
		/// </summary>
		/// <param name="solutionCandidate"></param>
		/// <returns></returns>
		double EvaluateGenome(CandidateSolution solutionCandidate);
	}
}
