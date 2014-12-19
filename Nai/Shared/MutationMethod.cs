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
		///		Initializes the object with a propability value.
		/// </summary>
		/// <param name="propability"></param>
		protected MutationMethod(double propability)
		{
			Propability = propability;
		}


		/// <summary>
		///		Propability of the occurence of a mutation.
		/// </summary>
		public double Propability { get; private set; }

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
