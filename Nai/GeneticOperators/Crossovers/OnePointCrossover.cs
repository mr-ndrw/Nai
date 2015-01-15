using System;
using System.Linq;
using Shared;
using Shared.Bases;
using Shared.Utils;

namespace GeneticOperators.Crossovers
{
	/// <summary>
	///		Allows to perform a One point crossover on the population.
	/// </summary>
	public class OnePointCrossover : Recombinator
	{
		/// <summary>
		///		Occurence at which the crossing over should occur.
		/// </summary>
		private readonly double _mutationChance;

		/// <summary>
		///		Initializes the object with the mutation probability.
		/// </summary>
		/// <param name="mutationChance">
		///		Mutation chance ranging from 0.0 to 1.0.
		/// </param>
		public OnePointCrossover(double mutationChance)
		{
			this._mutationChance = mutationChance;
		}

		/// <summary>
		///		Peforms a One Point Crossover on two solutions.
		/// </summary>
		/// <param name="firstParent">
		///		First genome to perform Crossover on.
		/// </param>
		/// <param name="secondParent">
		///		Second genome to perform Crossover on.
		/// </param>
		public override void Crossover(CandidateSolution firstParent, CandidateSolution secondParent)
		{
			this.Crossover(new Pair<CandidateSolution>(firstParent, secondParent));
		}

		///  <summary>
		/// 		Peforms aOne Point Crossover on a Pair of solutions.
		///  </summary>
		/// <param name="solutionPair">
		///		Pair to perform a crossover on.
		/// </param>
		public override void Crossover(Pair<CandidateSolution> solutionPair)
		{
			//	check if crossing-over will even happen
			var randomDouble = RandomGenerator.GetRandomDouble();
			if (randomDouble > this._mutationChance)
			{
				return;
			}
			//	if it passed, carry on

			//	firstGenome:	######
			//	secondGenome:	******
			var firstGenome = solutionPair.X.Solution;
			var secondGenome = solutionPair.Y.Solution;

			//	select random crossing point solution's index range.
			var crossingPoint = RandomGenerator.GetRandomInt(0, firstGenome.Count());

			//	[Former][Latter]
			var firstGenomeFormerPart = firstGenome.Take(crossingPoint);
			var secondGenomeFormerPart = firstGenome.Take(crossingPoint);

			var firstGenomeLatterPart = firstGenome.Skip(crossingPoint);
			var secondGenomeLatterPart = secondGenome.Skip(crossingPoint);

			var firstChildGenome = firstGenomeFormerPart.Concat(secondGenomeLatterPart);
			var secondChildGenome = secondGenomeFormerPart.Concat(firstGenomeLatterPart);

			firstGenome = firstChildGenome;
			secondGenome = secondChildGenome;

			//	predicted output:	
			//	firstGenome:	###***
			//	secondGenome:	***###
		}
	}
}
