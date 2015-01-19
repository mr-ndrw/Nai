﻿using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using Shared;
using Shared.Bases;
using Shared.InterfacesAndBases;


namespace Genetic
{
	/// <summary>
	///     Main module of the genetic algorithm. Contains genetic population and performs operations on it.
	/// </summary>	
	public sealed class GeneticStructure
	{
		#region Private Fields

		/// <summary>
		///     Function which evaluates the genomes within the population.
		/// </summary>
		private readonly IFitnessFunction _function;

		/// <summary>
		///     Length of the individual genome.
		/// </summary>
		private readonly int _genomeLength;

		/// <summary>
		///     Mutator method.
		/// </summary>
		private readonly IMutator _mutator;

		/// <summary>
		///     Total count of genomes within population.
		/// </summary>
		private readonly int _populationCount;

		/// <summary>
		///     Performs recombination duty on the population.
		/// </summary>
		private readonly Recombinator _recombinator;

		/// <summary>
		///		Strategy for picking the best solution(s) in the space during the evaluation.
		/// </summary>
		private readonly IElitistStrategy _elitistStrategy;

		/// <summary>
		///     Selector method for the <see cref="Population" />.
		/// </summary>
		private readonly Selector _selector;

		/// <summary>
		///     Provides the answer whether the population is satisifiable.
		/// </summary>
		private readonly ITerminator _terminator;

		#endregion

		#region Constructor

		/// <summary>
		///     Initializes an object with members which will be used in the evolution process.
		/// </summary>
		/// <param name="populationCount">
		///     The total number of species within the population.
		/// </param>
		/// <param name="function">
		///     Shared fitness function across the genetic structure.
		/// </param>
		/// <param name="selector">
		///     Selector for the given problem.
		/// </param>
		/// <param name="mutator">
		///     Mutator for the given problem.
		/// </param>
		/// <param name="recombinator">
		///     Recombinator for the population.
		/// </param>
		/// <param name="terminator">
		///     Termination interface.
		/// </param>
		/// <param name="genomeLength">
		///     Length of indiviudal genome.
		/// </param>
		/// <param name="elitistStrategy"></param>
		public GeneticStructure(int populationCount, int genomeLength, IFitnessFunction function, Selector selector,
		                        IMutator mutator, Recombinator recombinator, IElitistStrategy elitistStrategy,
		                        ITerminator terminator)
		{
			if (populationCount <= 0) throw new ArgumentException(string.Format(populationCount.ToString()));
			if (genomeLength <= 0) throw new ArgumentException(genomeLength.ToString());
			if (recombinator == null) throw new ArgumentNullException("recombinator");
			if (elitistStrategy == null) throw new ArgumentNullException("elitistStrategy");
			if (function == null) throw new ArgumentNullException("function");
			if (selector == null) throw new ArgumentNullException("selector");
			if (mutator == null) throw new ArgumentNullException("mutator");
			if (terminator == null) throw new ArgumentNullException("terminator");

			this._function = function;
			this._selector = selector;
			this._mutator = mutator;
			this._genomeLength = genomeLength;
			this._recombinator = recombinator;
			this._elitistStrategy = elitistStrategy;
			this._terminator = terminator;
			this._populationCount = populationCount;
			this._genomeLength = genomeLength;
			this.Population = new List<CandidateSolution>(populationCount);
		}

		#endregion

		#region Properties

		/// <summary>
		///     Total number of species within the population.
		/// </summary>
		public int PopulationCount
		{
			get { return this._populationCount; }
		}

		/// <summary>
		///     Length of the individual genome.
		/// </summary>
		public int GenomeLength
		{
			get { return this._genomeLength; }
		}

		/// <summary>
		///     Population of candidate solutions.
		/// </summary>
		public List<CandidateSolution> Population { get; private set; }

		#endregion

		#region Methods

		/// <summary>
		///     Perfoms genetic algorithm on the population.
		/// </summary>
		public CandidateSolution Evolve()
		{
			//	Initialize the population with random values inside their Solution (bool)array.
			this.Population.AddRange(this.GetRandomizedCandidateSolutions(this._populationCount));
			//	Loop until Termination Condition is met.
			//	DO
			while (!this._terminator.IsTerminationConditionMet(this.Population))
			{
				//	Evaluate the population.
				this.Population.ForEach(solution => this._function.EvaluateGenome(solution));

				//	Select the best solutions for safekeeping, therefore not allowing it be lost amidst the evolution process.
				this._elitistStrategy.PickBest(this.Population);

				//	Select the parents AND
				//	Perform an evaluation of each candidate solution in the Population.
				this._selector.PickBestFitPopulation(this.Population);

				//	Recombine the parents - produce offsprings.
				this._recombinator.ProduceOffsprings(this.Population);

				//	Mutate offsprings.
				this._mutator.Mutate(this.Population);
			}
			//	OD	--	Rinse, repeat...

			this.Population.AddRange(this._elitistStrategy.ReturnBest());

			var result = this.Population.MaxBy(solution => solution.EvaluationResult);

			return result;
			// Return the best solution.
		}

		#region PrivateMethods

		/// <summary>
		///     Returns a randomized collection(of parametrized count) of Genomes of structure-global length.
		/// </summary>
		/// <param name="populationCount">
		///     Length of the population collection.
		/// </param>
		/// <returns>
		///     Randomized collection of Genomes.
		/// </returns>
		private IEnumerable<Genome> GetRandomizedCandidateSolutions(int populationCount)
		{
			var result = Enumerable.Range(0, populationCount)
			                                .Select(s => new Genome(RandomGenerator.GetRandomBoolCollection(this._genomeLength)))
			                                .ToList();

			return result;
		}

		#endregion

		#endregion
	}
}