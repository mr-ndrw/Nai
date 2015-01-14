using System.Collections.Generic;
using Shared.Utils;

namespace Shared.Bases
{
	/// <summary>
	///		Gives acces to solution recombination methods.
	/// </summary>
	public abstract class Recombinator
	{
		/// <summary>
		///		Points at which to perform a crossover.
		/// </summary>
		/// <remarks>
		///		If there is only one point present in the array, then the crossover will be performed only at that point.
		/// </remarks>
		private readonly int  _crossoverPoint;

		/// <summary>
		///		Initializes the object of the Recombinator object with values at which it should peform crossovers on Genomes.
		/// </summary>
		/// <param name="crossoverPoint">
		///		Points to perform crossover.
		/// </param>
		protected Recombinator(int crossoverPoint)
		{
			this._crossoverPoint = crossoverPoint;
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
		public abstract void Crossover(CandidateSolution firstParent, CandidateSolution secondParent);

		///  <summary>
		/// 		Peforms a Crossover on two parent genomes and subsititutes them for their children.
		///  </summary>
		/// <param name="solutionPair">
		///		Pair to perform a crossover on.
		/// </param>
		public abstract void Crossover(Pair<CandidateSolution> solutionPair);

		/// <summary>
		///		Analyzes 
		/// </summary>
		/// <param name="population">
		///		
		/// </param>
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
			for (int i = 1; i < indexList.Count; i = i + 2)
			{
				var firstSolution = population[indexList[i - 1]];
				var secondSolution = population[indexList[i]];

				var pair = new Pair<CandidateSolution>(firstSolution, secondSolution);
				pairList.Add(pair);
			}
			//	Iterate over the pair list and perform on each pair an operation of recombination
			pairList.ForEach(this.Crossover);
		}


	}
}
