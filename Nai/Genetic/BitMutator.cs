using System;
using System.Collections.Generic;
using Shared;

namespace Genetic
{
	/// <summary>
	///		Perfoms a bit mutation(changes the selected bit to it's oposite value) on the population.
	/// </summary>
	public class BitMutator : IMutator
	{
		/// <summary>
		///		Expressed in a range [0.0, 1.0] determines the probabiklit
		/// </summary>
		private readonly double _bitMutationChance;

		/// <summary>
		///		Initializes the mutator with the mutation chance.
		/// </summary>
		/// <param name="bitMutationChance">
		///		Value from range [0.0, 1.0].
		/// </param>
		public BitMutator(double bitMutationChance)
		{
			this._bitMutationChance = bitMutationChance;
		}

		/// <summary>
		///		Initializes the mutator with the quotient of chosen number of bits and product of genome length and total population count.
		/// </summary>
		/// <param name="numberOfBitsToMutate">
		/// 
		/// </param>
		/// <param name="genomeLength">
		/// 
		/// </param>
		///	<param name="genomeCount">
		///	
		/// </param>
		public BitMutator(int numberOfBitsToMutate, int genomeLength, int genomeCount)
		{

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
