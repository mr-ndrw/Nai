using System.Collections.Generic;
using Shared.Bases;
using Shared.InterfacesAndBases;

namespace GeneticOperators.Terminators
{
	/// <summary>
	///     Exposes a method for epoch number based termination.
	/// </summary>
	public class EpochCountTerminator : ITerminator
	{
		/// <summary>
		///     Number of generations this algorithm
		/// </summary>
		private readonly int _maxNumberOfEpochs;

		/// <summary>
		///     Current epoch number.
		/// </summary>
		private int _currentEpoch;

		/// <summary>
		///     Initializes the object with the value of maximum number of epochs, the termination algorithm should take into
		///     criteria.
		/// </summary>
		/// <param name="maxNumberOfEpochs"></param>
		public EpochCountTerminator(int maxNumberOfEpochs)
		{
			this._maxNumberOfEpochs = maxNumberOfEpochs;
			this._currentEpoch = 1;
		}

		/// <summary>
		///     Returns false if the current epoch has exceeded the parametrized maximum number of epoochs.
		/// </summary>
		/// <param name="candidateSolutions">
		///     Collection of solutions to analyze.
		/// </param>
		/// <returns>
		///     Has this colletion met the implemented criteria.
		/// </returns>
		public bool IsTerminationConditionMet(IEnumerable<CandidateSolution> candidateSolutions)
		{
			if (this._currentEpoch > this._maxNumberOfEpochs) return false;
			this._currentEpoch++;
			return true;
		}
	}
}