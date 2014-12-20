using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	/// <summary>
	///		Serves as a base class for all classes which want to become MutationMethods which allow the candidate solutions to mutate and change.
	/// </summary>
	public abstract class MutationMethod
	{
		/// <summary>
		///		Initializes the object with a Probability value.
		/// </summary>
		/// <param name="probability">
		/// </param>
		protected MutationMethod(double probability)
		{
			this.Probability = probability;
		}


		/// <summary>
		///		Probability of the occurence of a mutation.
		/// </summary>
		public double Probability { get; private set; }

		/// <summary>
		///		Pefroms a mutation only on one CandidateSolution.
		/// </summary>
		/// <param name="solutionToMutate">
		///		Solution to mutate.
		/// </param>
		public abstract void Mutate(CandidateSolution solutionToMutate);

		/// <summary>
		///		Performs a mutation on the whole popluation of solutions.
		/// </summary>
		/// <param name="populationToMutate">
		///		Population to mutate within.
		/// </param>
		public abstract void Mutate(IEnumerable<CandidateSolution> populationToMutate);
	}
}
