using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace Genetic
{
	public class RouletteSelector : SelectionMethod
	{
		/// <summary>
		///		Initializes an object with a fitness function which will be used throughout the selection process.
		/// </summary>
		/// <param name="fitnessFunction">
		///		Fitness function.
		/// </param>
		public RouletteSelector(IEvaluationFunction fitnessFunction) : base(fitnessFunction)
		{

		}

		/// <summary>
		///		Performs the analysis of the population and modifies it according to the taken strategy.
		/// </summary>
		/// <param name="candidateSolutions">
		///		Collection of solutions on which a selection is performed.
		/// </param>
		public override void PickBestFitPopulation(IEnumerable<CandidateSolution> candidateSolutions)
		{
			//	Initialize total population count.
			var populationCount = candidateSolutions.Count();

			//	Get a random array of doubles of length equal to population count.
			var randomDoubles = RandomGenerator.GetRandomDoubles(populationCount);

			//	Produce matchings values for each genome.
			var matchingSums = GetMatchingSums();
			var distro = Math.
			throw new System.NotImplementedException();
		}


		/// <summary>
		///		Produces an array of doubles which is a representative of the matching sums for the neuron population. 
		/// </summary>
		/// <returns>
		///		An array of doubles which is a representative of the matching sums for the neuron population. 
		/// </returns>
		private IEnumerable<double> GetMatchingSums()
		{
			throw new NotImplementedException();
		}
	}

}
