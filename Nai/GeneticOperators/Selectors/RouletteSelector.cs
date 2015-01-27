using System.Collections.Generic;
using System.Linq;
using Shared;
using Shared.Bases;
using Shared.InterfacesAndBases;

namespace GeneticOperators.Selectors
{
	/// <summary>
	///		Allows to perform roulette selection algorithm on a population.
	/// </summary>
	public class RouletteSelector : Selector
	{
		/// <summary>
		///		Initializes an object with a fitness function which will be used throughout the selection process.
		/// </summary>
		/// <param name="fitnessFunction">
		///		Fitness function.
		/// </param>
		public RouletteSelector(IFitnessFunction fitnessFunction) 
			: base(fitnessFunction)
		{
		}
		/// <summary>
		///		Performs the analysis of the population and replaces it with a new one chosen with the roulette selection strategy.
		/// </summary>
		/// <param name="candidateSolutions">
		///		Collection of solutions on which a selection is performed.
		/// </param>
		public override void PickBestFitPopulation(List<CandidateSolution> candidateSolutions)
		{
			//	Initialize total population count.
			var populationCount = candidateSolutions.Count();

			//	Evaluate each candaidate solution.
			// candidateSolutions.ForEach(solution => this._fitnessFunction.EvaluateSolution(solution));

			//	Sort the population descendingly, so that larger values will have it easier to to become selected(lower ANF!!!), and smaller values will have it harder.
			candidateSolutions = (from solution in candidateSolutions
								  orderby solution.EvaluationResult
								  select solution).ToList();

			//	Create a collection of normalized EvaluationValues.
			//	Meaning that each solution is assigned a value which is the quotient of it's own fitness 
			//	value and the total sum of fitness values.
			//	That way the new sum of fitness will be equal to 1, and all underlying and composing fitness values will be in [0, 1] range.
			var totalFitnessSum = candidateSolutions.Sum(candidateSolution => candidateSolution.EvaluationResult);
			var normalizedFitnessValuesForGivenSolution =
				candidateSolutions.Select(solution => (solution.EvaluationResult / totalFitnessSum)).ToArray();

			//	Get a random array of doubles of length equal to population count.
			var randomDoubles = RandomGenerator.GetRandomDoubles(populationCount).ToArray();

			//	Calculate the ANF - accumulated normalized fitness value for each solution.
			//	Solution's ANF is the sum of it's own normalized fitness and the ones preceeding it.
			var accumulatedNormalizedValues = new double[populationCount];

			for (var solutionIndex = 0; solutionIndex < populationCount; solutionIndex++)
			{
				accumulatedNormalizedValues[solutionIndex] = normalizedFitnessValuesForGivenSolution[solutionIndex];
				//	<= solutionIndex and then delete above line?
				for (var subArrayIndex = 0; subArrayIndex < solutionIndex; subArrayIndex++)
				{
					accumulatedNormalizedValues[solutionIndex] += normalizedFitnessValuesForGivenSolution[subArrayIndex];
				}
			}

			//	Iterate over the randomDoubles array and pick the solution that is greater than the current double.
			//	Create new population collection.
			var newPopulation = new List<CandidateSolution>(populationCount);
			for (var doubleIndex = 0; doubleIndex < populationCount; doubleIndex++)
			{
				var currentRadnom = randomDoubles[doubleIndex];
				for(var accNormalizedIndex = 0; accNormalizedIndex < populationCount; accNormalizedIndex++)
				{
					//	Once chosen, choose the solution and break;
					if (accumulatedNormalizedValues[accNormalizedIndex] > currentRadnom)
					{
						var solutionToAdd = candidateSolutions[accNormalizedIndex];
						newPopulation.Add(solutionToAdd);
						break;
					}
				}
			}
			//	When done, subsitute the old solution with the new one.
			candidateSolutions = new List<CandidateSolution>(newPopulation);
			
			//	END
		}//	/PickBestFitPopulation(List<CandidateSolution>)

	}

}
