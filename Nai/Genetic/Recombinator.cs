using System;
using System.Linq;

namespace Genetic
{
	/// <summary>
	///		Gives acces to solution recombination methods.
	/// </summary>
	public class Recombinator
	{
		/// <summary>
		///		Points at which to perform a crossover.
		/// </summary>
		/// <remarks>
		///		If there is only one point present in the array, then the crossover will be performed only at that point.
		/// </remarks>
		private readonly int[] _crossoverPoints;

		/// <summary>
		///		Initializes the object of the Recombinator object with values at which it should peform crossovers on Genomes.
		/// </summary>
		/// <param name="crossoverPoints">
		///		Points to perform crossover.
		/// </param>
		protected Recombinator(params int[] crossoverPoints)
		{
			_crossoverPoints = crossoverPoints;
			Array.Sort(_crossoverPoints);
		}
		/// <summary>
		///		Return the maximum value present in the array. 
		/// </summary>
		/// <remarks>
		///		After it's been sorted during the initaliziation, it should be present on the last position in the array.
		/// </remarks>
		public int MaximumValue
		{
			get
			{
				if (_crossoverPoints == null || _crossoverPoints.Length == 0)
					return 0;
				return _crossoverPoints[_crossoverPoints.Length-1];
			}
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
		public void Crossover(Genome firstParent, Genome secondParent)
		{
			//	
		}

	}
}
