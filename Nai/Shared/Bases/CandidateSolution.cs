using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Bases
{
	/// <summary>
	///     Base class for classes representing solutions to the given problem.
	/// </summary>
	public class CandidateSolution : IEquatable<CandidateSolution>, IComparable<CandidateSolution>
	{
		/// <summary>
		///     Initializes an object with a 0's and 1's string, having previously extracted data and check for exceptions.
		/// </summary>
		/// <param name="zerosOnesString">
		///     String compromised of 0's and 1's.
		/// </param>
		public  CandidateSolution(string zerosOnesString)
		{
			var checkArray = zerosOnesString.ToCharArray();

			if (checkArray.Any(c => c.CompareTo('1') != 0 || c.CompareTo('0') != 0))
			{
				throw new Exception("Passed string is not compromised of only 1's and 0's.");
			}

			this.Solution = checkArray.Select(Convert.ToBoolean);
		}

		/// <summary>
		///     Initializes and object with a collection of bools.
		/// </summary>
		/// <param name="boolCollection">
		///     Collection of bools.
		/// </param>
		public CandidateSolution(IEnumerable<bool> boolCollection)
		{
			this.Solution = boolCollection;
		}

		/// <summary>
		///     An array of 0's and 1's represeting a solution.
		/// </summary>
		public IEnumerable<bool> Solution { get; set; }

		/// <summary>
		///     Result of the evaluation by the funtion.
		/// </summary>
		public double EvaluationResult { get; set; }

		/// <summary>
		///     Compares the current object with another object of the same type.
		/// </summary>
		/// <returns>
		///     A value that indicates the relative order of the objects being compared. The return value has the following
		///     meanings: Value Meaning Less than zero This object is less than the <paramref name="other" /> parameter.Zero This
		///     object is equal to <paramref name="other" />. Greater than zero This object is greater than
		///     <paramref name="other" />.
		/// </returns>
		/// <param name="other">
		///     An object to compare with this object.
		/// </param>
		public int CompareTo(CandidateSolution other)
		{
			return other == null
				? 1
				: this.EvaluationResult.CompareTo(other.EvaluationResult);
		}

		/// <summary>
		///     Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		///     true if the current object is equal to the <paramref name="other" /> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">
		///     An object to compare with this object.
		/// </param>
		public bool Equals(CandidateSolution other)
		{
			if (other == null)
			{
				return false;
			}

			if (this.Solution.Count() != other.Solution.Count())
			{
				return false;
			}

			return !this.Solution.Except(other.Solution)
			            .Any() && !other.Solution.Except(this.Solution)
			                            .Any();
		}
	}
}