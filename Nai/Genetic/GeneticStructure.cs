﻿using System;
using System.Collections.Generic;
using System.Linq;
using Shared;
namespace Genetic
{
	/// <summary>
	///		Main module of the genetic algorithm. Contains genetic population and performs operations on it.
	/// </summary>
	public class GeneticStructure
	{
		/// <summary>
		///		Selector method for the <see cref="Population"/>.
		/// </summary>
		private readonly SelectionMethod _selector;
		/// <summary>
		///		Mutator method.
		/// </summary>
		private readonly MutationMethod _mutator;
		/// <summary>
		///		Function which evaluates the genomes within the population.
		/// </summary>
		private readonly IEvaluationFunction _function;
		/// <summary>
		///		Performs recombination duty on the population.
		/// </summary>
		private readonly Recombinator _recombinator;
		/// <summary>
		///		Length of the individual genome.
		/// </summary>
		private readonly int _genomeLength;
		/// <summary>
		///		Total count of genomes within population.
		/// </summary>
		private readonly int _populationCount ;
		
		///   <summary>
		///  	Creates an GeneticStructure with global function evaluating given members and a selection function 
		///   </summary>
		///  <param name="populationCount">
		/// 		The total number of species within the population.	
		///  </param>
		///  <param name="function">
		///  	Shared fitness function across the genetic structure.
		///   </param>
		///   <param name="selector">
		///  	Selector for the given problem. 
		///   </param>
		/// <param name="mutator">
		///		Mutator for the given problem.
		/// </param>
		public GeneticStructure(int populationCount, IEvaluationFunction function, SelectionMethod selector, MutationMethod mutator, int genomeLength, Recombinator recombinator)
		{
			if (populationCount <= 0)
			{
				throw new ArgumentException("Population count must not be equal or less than 0.");
			}
			if (genomeLength <= 0)
			{
				throw new ArgumentException("Genome length must not be equal or less than 0.");
			}
			if (recombinator == null)
			{
				throw new ArgumentNullException("A recombinator must be specified.");
			}
			//	Assert that recombinator's crossing points do not exceed the genome length.
			if (genomeLength >= recombinator.MaximumValue)
			{
				throw new ArgumentOutOfRangeException("recombinator's crossover points cannot exceed or be equal to the length of the genome.");
			}
			if (function == null)
			{
				throw new ArgumentNullException("An evaluation function must be specified.");
			}
			if (selector == null)
			{
				throw new ArgumentNullException("A selector must be specified.");
			}
			if (mutator == null)
			{
				throw new ArgumentNullException("A mutator must be specified.");
			}
			this._function = function;
			this._selector = selector;
			this._mutator = mutator;
			this._genomeLength = genomeLength;
			this._recombinator = recombinator;
			this._populationCount = populationCount;
			this._genomeLength = genomeLength;
			this.Population = new List<CandidateSolution>(populationCount);
		}
		/// <summary>
		///		Total number of species within the population.
		/// </summary>
		public int PopulationCount
		{
			get { return _populationCount; }
		}
		/// <summary>
		///		Length of the individual genome.
		/// </summary>
		public int GenomeLength
		{
			get { return _genomeLength; }
		}
		/// <summary>
		///		Population of candidate solutions.
		/// </summary>
		public List<CandidateSolution> Population { get; private set; }
		/// <summary>
		///		
		/// </summary>
		public void Evolve()
		{
			//	Initialize the population with random values inside their Solution (bool)array.
			Population.AddRange(this.GetRandomizedCandidateSolutions(_populationCount));

			//	Loop until Termination Condition is met.
			//	DO
				//	Select the parents AND
				//	Perform an evaluation of each candidate solution in the Population.
				_selector.PickBestFitPopulation(Population);
				//	Recombine the parents - produce offsprings.
				
				//	Mutate offsprings.

				//	Evaluate new offsprings.

				//	Select individual offsprings for the next epooch	(???)
				
			//	OD	--	Rinse, repeat...

			//	CONSIDER: 
		}
		/// <summary>
		///		Returns a randomized collection(of parametrized count) of Genomes of structure-global length.
		/// </summary>
		/// <param name="populationCount">
		///		Length of the population collection.
		/// </param>
		/// <returns>
		///		Randomized collection of Genomes.
		/// </returns>
		private List<Genome> GetRandomizedCandidateSolutions(int populationCount)
		{
			var result = Enumerable.Range(0, populationCount)
								   .Select(s => new Genome(RandomGenerator.GetRandomBoolCollection(this._genomeLength)))
								   .ToList();

			return result;
		}
	}
}
