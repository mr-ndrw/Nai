using System.Collections.Generic;
using Shared.InterfacesAndBases;

namespace Shared.Bases
{
	/// <summary>
	///		Serves as a base class for classes which want to become a selector in a genetic population.
	/// </summary>
	public abstract class Selector
	{
		protected readonly IFitnessFunction _fitnessFunction;

		/// <summary>
		///		Initializes an object with w fitness function which will be used throughout the selection process.
		/// </summary>
		/// <param name="fitnessFunction">
		///		Fitness function.
		/// </param>
		protected Selector(IFitnessFunction fitnessFunction)
		{
			this._fitnessFunction = fitnessFunction;
		}

		///  <summary>
		/// 		Performs the analysis of the population and modifies it according to the taken strategy.
		///  </summary>
		///  <param name="candidateSolutions">
		/// 		Collection of solutions on which a selection is performed.
		///  </param>
		public abstract void PickBestFitPopulation(List<CandidateSolution> candidateSolutions);
	}
}
