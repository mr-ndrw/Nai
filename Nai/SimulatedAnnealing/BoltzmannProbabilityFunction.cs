using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Bases;
using Shared.InterfacesAndBases;

namespace SimulatedAnnealing
{
	public class BoltzmannProbabilityFunction : IProbabilityFunction
	{
		/// <summary>
		///		Initializes the object with the fitness function, which will be used to determine the solution's fitness values.
		/// </summary>
		/// <param name="fitnessFunction">
		///		Fitness function of choice.
		/// </param>
		public BoltzmannProbabilityFunction(IFitnessFunction fitnessFunction)
		{
			this.FitnessFunction = fitnessFunction;
		}

		/// <summary>
		///		Calculates the fitness values.
		/// </summary>
		public IFitnessFunction FitnessFunction { get; private set; }

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
		public double CalculateProbabilityOfChoice(CandidateSolution evaluatedSolution, CandidateSolution neighgourSolutionToEvaluated,
		                                           double currentTemperature)
		{
			this.FitnessFunction.EvaluateSolution(evaluatedSolution);
			this.FitnessFunction.EvaluateSolution(neighgourSolutionToEvaluated);

			var absoluteDiffrenceOfSolutionsFitness =
				Math.Abs(evaluatedSolution.EvaluationResult - neighgourSolutionToEvaluated.EvaluationResult);

			var quotientOfAbsAndTemperature = absoluteDiffrenceOfSolutionsFitness / currentTemperature;

			return Math.Exp(-quotientOfAbsAndTemperature);
		}
	}
}
