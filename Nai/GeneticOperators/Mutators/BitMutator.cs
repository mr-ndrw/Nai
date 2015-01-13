using System;
using System.Collections.Generic;
using System.Linq;
using Shared;
using Shared.Bases;
using Shared.InterfacesAndBases;
using Shared.Utils;

namespace GeneticOperators.Mutators
{
	public class BitMutator : IMutator
	{
		/// <summary>
		///		
		/// </summary>
		private readonly double _bitMutationChance;

		/// <summary>
		///		Initalizes the bit mutator with a real value.
		/// </summary>
		/// <param name="bitMutationChance">
		///		Double value ranging in [0.0, 1.0].
		/// </param>
		public BitMutator(double bitMutationChance)
		{
			this._bitMutationChance = bitMutationChance;
		}

		/// <summary>
		///		Initializes the bit mutator with the quotient of bits to mutate and the product of genome length and the total population count. 
		/// </summary>
		/// <param name="bitsToMutate">
		///		How many bits to mutate totally per population.
		/// </param>
		/// <param name="genomeLength">
		///		Length of a genome.
		/// </param>
		/// <param name="populationCount">
		///		Total population count.
		/// </param>
		public BitMutator(int bitsToMutate, int genomeLength, int populationCount)
		{
			this._bitMutationChance = bitsToMutate / (double) (genomeLength * populationCount);
		}

		///  <summary>
		/// 		Initializes the bit mutator with the quotient of bits to mutate and the product of genome length and the total population count. 
		///  </summary>
		///  <param name="bitsToMutate">
		/// 		How many bits to mutate totally per population.
		///  </param>
		/// <param name="totalBitsInPopulation">
		///			Total bits present within the population.
		/// </param>
		public BitMutator(int bitsToMutate, int totalBitsInPopulation)
		{
			this._bitMutationChance = bitsToMutate / (double) totalBitsInPopulation;
		}

		/// <summary>
		///		Performs a mutation on the whole popluation of solutions.
		/// </summary>
		/// <param name="populationToMutate">
		///		Population to mutate within.
		/// </param>
		public void Mutate(IEnumerable<CandidateSolution> populationToMutate)
		{
			//	calculate the number of bits to mutate
			var countOfBitsToMutate = (int) Math.Floor(this._bitMutationChance * populationToMutate.Count());

			//	get countOfBitsToMutate pairs of random numbers with the first number in pair being constrained by the population count
			//	and the second one by the genome length.
			var randomPairs = Enumerable.Range(0, countOfBitsToMutate)
			                            .Select(
				                            pair => new Pair<int>(RandomGenerator.GetRandomInt(), RandomGenerator.GetRandomInt()));

			//	iterate over the generated pairs and mutate(change the value to the opposite one) the bits based on the current pair's indices.
			foreach (var pair in randomPairs)
			{
				var bit = populationToMutate.ElementAt(pair.X)
				                            .Solution.ElementAt(pair.Y);
				bit = !bit;

			}
		}
	}
}
