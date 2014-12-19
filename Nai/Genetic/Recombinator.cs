namespace Genetic
{
	/// <summary>
	///		Gives acces to solution recombination methods.
	/// </summary>
	public class Recombinator
	{
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
