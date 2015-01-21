using System.Collections.Generic;
using System.Linq;
using Shared;
using Shared.Bases;
using Shared.InterfacesAndBases;

namespace SimulatedAnnealing
{
	public class SimulatedAnnealer
	{
		private readonly int _searchSpaceCardinality;
		private readonly int _solutionLength;

		public SimulatedAnnealer(List<CandidateSolution> searchSpace, IFitnessFunction fitnessFunction, IProbabilityFunction probabilityFunction, ITemperatureFunction temperatureFunction, INeighbourFunction neighbourFunction, double startingTemperature, double finalTemeprature)
		{
			this.FitnessFunction = fitnessFunction;
			this.ProbabilityFunction = probabilityFunction;
			this.TemperatureFunction = temperatureFunction;
			this.NeighbourFunction = neighbourFunction;
			this.StartingTemperature = startingTemperature;
			this.FinalTemeprature = finalTemeprature;
			this.SearchSpace = searchSpace;
		}

		public SimulatedAnnealer(int searchSpaceCardinality, int solutionLength, IFitnessFunction fitnessFunction, IProbabilityFunction probabilityFunction, ITemperatureFunction temperatureFunction, INeighbourFunction neighbourFunction, double startingTemperature, double finalTemeprature)
		{
			this._searchSpaceCardinality = searchSpaceCardinality;
			this._solutionLength = solutionLength;
			this.FitnessFunction = fitnessFunction;
			this.ProbabilityFunction = probabilityFunction;
			this.TemperatureFunction = temperatureFunction;
			this.NeighbourFunction = neighbourFunction;
			this.StartingTemperature = startingTemperature;
			this.FinalTemeprature = finalTemeprature;
			this.SearchSpace = new List<CandidateSolution>(searchSpaceCardinality);
		}

		public double StartingTemperature { get; private set; }
		public double FinalTemeprature { get; private set; }
		public List<CandidateSolution> SearchSpace { get; private set; }
		public ITemperatureFunction TemperatureFunction { get; private set; }
		public IProbabilityFunction ProbabilityFunction { get; private set; }
		public INeighbourFunction NeighbourFunction { get; private set; }
		public IFitnessFunction FitnessFunction { get; private set; }

		public CandidateSolution Simulate()
		{
			if (this.SearchSpace.Count == 0)
			{
				this.SearchSpace = (List<CandidateSolution>) this.GetRandomizedCandidateSolutions(this._solutionLength);
			}

			SearchSpace.ForEach(solution => this.FitnessFunction.EvaluateSolution(solution));


			var currentTemperature = this.StartingTemperature;

			var evaluatedSolution = this.SearchSpace[RandomGenerator.GetRandomInt(this._searchSpaceCardinality)];

			var bestSolution = evaluatedSolution;

			CandidateSolution neighbourSolution;

			while (currentTemperature > this.FinalTemeprature)
			{
				neighbourSolution = this.NeighbourFunction.SelectNeighbour(evaluatedSolution);

				this.FitnessFunction.EvaluateSolution(neighbourSolution);

				if (neighbourSolution.EvaluationResult > evaluatedSolution.EvaluationResult)
				{
					evaluatedSolution = neighbourSolution;
					if (evaluatedSolution.EvaluationResult > bestSolution.EvaluationResult)
					{
						bestSolution = evaluatedSolution;
					}
				} else if (RandomGenerator.GetRandomDouble() < this.ProbabilityFunction.CalculateProbabilityOfChoice(evaluatedSolution, neighbourSolution, currentTemperature))
				{
					evaluatedSolution = neighbourSolution;
				}

				currentTemperature = this.TemperatureFunction.CalculateNewTemperature(currentTemperature);
			}

			return bestSolution.EvaluationResult > evaluatedSolution.EvaluationResult
				? bestSolution
				: evaluatedSolution;
		}


		/// <summary>
		///     Returns a randomized collection(of parametrized count) of Genomes of structure-global length.
		/// </summary>
		/// <param name="populationCount">
		///     Length of the population collection.
		/// </param>
		/// <returns>
		///     Randomized collection of Genomes.
		/// </returns>
		private IEnumerable<CandidateSolution> GetRandomizedCandidateSolutions(int populationCount)
		{
			var result = Enumerable.Range(0, populationCount)
								   .Select(s => new CandidateSolution(RandomGenerator.GetRandomBoolCollection(this._solutionLength)))
								   .ToList();

			return result;
		}

	}
}
