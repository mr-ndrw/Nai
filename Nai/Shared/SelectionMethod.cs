﻿using System.Collections.Generic;

namespace Shared
{
	/// <summary>
	///		Serves as a base class for classes which want to become a selector in a genetic population.
	/// </summary>
	public abstract class SelectionMethod
	{
		private readonly IEvaluationFunction _fitnessFunction;

		/// <summary>
		///		Initializes an object with w fitness function which will be used throughout the selection process.
		/// </summary>
		/// <param name="fitnessFunction">
		///		Fitness function.
		/// </param>
		protected SelectionMethod(IEvaluationFunction fitnessFunction)
		{
			_fitnessFunction = fitnessFunction;
		}

		/// <summary>
		///		Performs the analysis of the population and modifies it according to the taken strategy.
		/// </summary>
		/// <param name="candidateSolutions">
		///		Collection of solutions on which a selection is performed.
		/// </param>
		public abstract void PickBestFitPopulation(IEnumerable<CandidateSolution> candidateSolutions);
	}
}
