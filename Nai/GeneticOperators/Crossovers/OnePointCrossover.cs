using System;
using System.Linq;
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
		///		Number of bits at the beginning to skip.
		/// </summary>
		/// <remarks>
		///		The bits at the beginning will not be taken into the exchanging genetic material.
		/// </remarks>
		private readonly int _bitsToSkip;

		/// <summary>
		///		Initializes the object of the Recombinator object with the number of bits in the beginning
		///		it should skip during material exchange.
		/// </summary>
		/// <param name="bitsToSkip">
		///		Bits to skip during the one point crossover operation
		/// </param>
		public OnePointCrossover(int bitsToSkip) 
		{
			this._bitsToSkip = bitsToSkip;
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
			throw new NotImplementedException();
		}

		///  <summary>
		/// 		Peforms aOne Point Crossover on a Pair of solutions.
		///  </summary>
		/// <param name="solutionPair">
		///		Pair to perform a crossover on.
		/// </param>
		public override void Crossover(Pair<CandidateSolution> solutionPair)
		{
			//	firstGenome:	######
			//	secondGenome:	******
			var firstGenome = solutionPair.X.Solution;
			var secondGenome = solutionPair.Y.Solution;

			var firstGenomeLatterPart = firstGenome.Skip(_bitsToSkip);
			var secondGenomeLatterPart = secondGenome.Skip(_bitsToSkip);

			var secondGenomeLatterPartTemp = secondGenome.Select(bit => bit); 
			//	predicted output:	
			//	firstGenome:	###***
			//	secondGenome:	***###
		}
	}
}
