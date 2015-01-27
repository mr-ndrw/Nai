using System.Collections.Generic;
using MoreLinq;
using Shared.Bases;
using Shared.InterfacesAndBases;

namespace GeneticOperators.Terminators
{
	/// <summary>
	///		Allows determination of whether the genetic algorithm should stop evaluating based on the evaluation
	///		of the best solution and the fitness that it yields.
	/// </summary>
	public class BestSolutionTerminator : ITerminator
	{
		/// <summary>
		///		Initializes the constructor with the expected value of the best solution.
		/// </summary>
		public BestSolutionTerminator(double expectedMaximumFitnessValue)
		{
			this.ExpectedMaximumFitnessValue = expectedMaximumFitnessValue;
		}

		/// <summary>
		///		The value that we expect from the best solution in order to stop the execution.
		/// </summary>
		public double ExpectedMaximumFitnessValue { get; private set; }

		///  <summary>
		/// 		Analyzes the population and determines whether the termination condition was met.
		///  </summary>
		/// <param name="candidateSolutions">
		///		Collection of solutions to analyze.
		/// </param>
		/// <returns>
		///		Has this colletion met the implemented criteria.
		/// </returns>
		public bool IsTerminationConditionMet(IEnumerable<CandidateSolution> candidateSolutions)
		{
			var foundMaximumEvaluationResult = candidateSolutions.MaxBy(solution => solution.EvaluationResult).EvaluationResult;

			return foundMaximumEvaluationResult >= this.ExpectedMaximumFitnessValue;
		}
	}
}
