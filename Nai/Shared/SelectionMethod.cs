using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	/// <summary>
	///		Defines a contract for all inherting classes to realize in order to become a selector in a genetic population.
	/// </summary>
	public abstract class SelectionMethod
	{
		private readonly IEvaluationFunction _fitnessFunction;

		protected SelectionMethod(IEvaluationFunction fitnessFunction)
		{
			_fitnessFunction = fitnessFunction;
		}

		public abstract IEnumerable<CandidateSolution> PickBestFitPopulation(IEnumerable<CandidateSolution> candidateSolutions);
	}
}
