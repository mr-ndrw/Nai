using System.Collections.Generic;
using Shared.Utils;

namespace Shared.Bases
{
	/// <summary>
	///		Serves as a base class for crossover classes.
	/// </summary>
	public abstract class Recombinator
	{
		/// <summary>
		///		Peforms a Crossover on two parent genomes and subsititutes them for their children.
		/// </summary>
		/// <param name="firstParent">
		///		First genome to perform Crossover on.
		/// </param>
		/// <param name="secondParent">
		///		Second genome to perform Crossover on.
		/// </param>
		public abstract void Crossover(CandidateSolution firstParent, CandidateSolution secondParent);

		///  <summary>
		/// 		Peforms a Crossover on two parent genomes and subsititutes them for their children.
		///  </summary>
		/// <param name="solutionPair">
		///		Pair to perform a crossover on.
		/// </param>
		public abstract void Crossover(Pair<CandidateSolution> solutionPair);

		/// <summary>
		///		Takes the the population and performs a crossover opereration on the solutions.
		/// </summary>
		/// <param name="population">
		///		Solutions to recombine.
		/// </param>
		/// <remarks>
		///		This procedure will only take into consideration an even number of genomes, 
		///		subsequently leaving the odd one with no mutation, as such are the rules of nature.
		/// </remarks>
		public void ProduceOffsprings(List<CandidateSolution> population)
		{
			//	Generate a list of random integers ranging from 0 to populationCount if it is even, if not then generate up to populationCount - 1.
			//	Next we are going to scramble the elements inside the list.
			var indexList = new List<int>();
			for (var i = 0; i < population.Count - population.Count%2; i++)
			{
				indexList.Add(i);
			}
			indexList.Shuffle();
			
			//	With list shuffled, we will now take each next 2 elements, create a pair out of them and insert them into a list containging these pairs.
			var pairList = new List<Pair<CandidateSolution>>();
			for (var i = 1; i < indexList.Count; i = i + 2)
			{
				var firstSolution = population[indexList[i - 1]];
				var secondSolution = population[indexList[i]];

				var pair = new Pair<CandidateSolution>(firstSolution, secondSolution);
				pairList.Add(pair);
			}

			//	Iterate over the pair list and perform on each pair an operation of recombination
			//	CrossOver method invoked for each of the pair has to implemented by the inheriting classes.
			pairList.ForEach(this.Crossover);
		}


	}
}
