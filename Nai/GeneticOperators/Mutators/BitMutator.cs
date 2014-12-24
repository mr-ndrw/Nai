using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Bases;
using Shared.InterfacesAndBases;

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
		///		Pefroms a mutation only on one CandidateSolution.
		/// </summary>
		/// <param name="solutionToMutate">
		///		Solution to mutate.
		/// </param>
		public void Mutate(CandidateSolution solutionToMutate)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///		Performs a mutation on the whole popluation of solutions.
		/// </summary>
		/// <param name="populationToMutate">
		///		Population to mutate within.
		/// </param>
		public void Mutate(IEnumerable<CandidateSolution> populationToMutate)
		{
			throw new NotImplementedException();
		}
	}
}
