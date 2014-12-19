using System.Collections.Generic;
using Shared;

namespace Genetic
{
	/// <summary>
	///		Main module of the genetic algorithm. Contains genetic population and performs operations on it.
	/// </summary>
	public class GeneticStructure
	{
		/// <summary>
		///		Performs selection on the <see cref="Population"/>.
		/// </summary>
		private readonly SelectionMethod _selector;

		///  <summary>
		/// 	Creates an GeneticStructure with global function evaluating given members and a selection function 
		///  </summary>
		/// <param name="populationCardinality">
		///		The total number of species within the population.	
		/// </param>
		/// <param name="function">
		/// 	Shared fitness function across the genetic structure.
		///  </param>\
		///  <param name="selector">
		/// 	Selector for the given population. 
		///  </param>
		public GeneticStructure(int populationCardinality, IEvaluationFunction function, SelectionMethod selector)
		{
			Function = function;
			_selector = selector;

			PopulationCardinality = populationCardinality;
			Population = new List<Genome>(populationCardinality);
		}

		/// <summary>
		///		Total number of species within the population.
		/// </summary>
		public int PopulationCardinality { get; private set; } 

		/// <summary>
		///		Function which evaluates the genomes within the population.
		/// </summary>
		public IEvaluationFunction Function { get; set; }

		/// <summary>
		///		Population of candidate solutions.
		/// </summary>
		public IEnumerable<Genome> Population { get; set; }


		public void Evolve()
		{
			//	Initialize the population with random values inside their Solution (bool)array.
 
			//	Perform an evaluation of each candidate solution in the Population.

			//	Loop until Termination Condition is met.
			//	DO
					//	Select the parents.

					//	Recombine the parents - produce offsprings.

					//	Mutate offsprings.

					//	Evaluate new offsprings.

					//	Select individual for the next epooch

			//	OD	--	Rinse, repeat...

			//	CONSIDER: 
		}
	}
}
