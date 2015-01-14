using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Bases;
using Shared.Utils;

namespace GeneticOperators.Crossovers
{
	public class OnePointCrossover : Recombinator
	{
		/// <summary>
		///		Initializes the object of the Recombinator object with values at which it should peform crossovers on Genomes.
		/// </summary>
		/// <param name="crossoverPoint">
		///		Points to perform crossover.
		/// </param>
		public OnePointCrossover(int crossoverPoint) : base(crossoverPoint)
		{
		}

		/// <summary>
		///		Peforms a Crossover on two parent genomes and subsititutes them for their children.
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
		/// 		Peforms a Crossover on two parent genomes and subsititutes them for their children.
		///  </summary>
		/// <param name="solutionPair">
		///		Pair to perform a crossover on.
		/// </param>
		public override void Crossover(Pair<CandidateSolution> solutionPair)
		{
			throw new NotImplementedException();
		}
	}
}
