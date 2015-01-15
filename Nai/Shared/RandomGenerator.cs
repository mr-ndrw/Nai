using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared
{
	public static class RandomGenerator
	{
		private static readonly Random Random;


		static RandomGenerator()
		{
			Random = new Random();
		}

		/// <summary>
		///		Generates a random collection of bools of specified count.
		/// </summary>
		/// <param name="length">
		///		Count of the collection.
		/// </param>
		public static IEnumerable<bool> GetRandomBoolCollection(int length)
		{
			var randomTrueFalseCollection = Enumerable.Range(0, length).Select(r =>Random.NextDouble() > 0.5);

			return randomTrueFalseCollection;
		}

		/// <summary>
		///		Returns an arbitrarily-sized collection of random doubles.
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public static IEnumerable<double> GetRandomDoubles(int length)
		{
			return Enumerable.Range(0, length).Select(rand => Random.NextDouble());
		}

		/// <summary>
		///		Returns a nonnegative number.
		/// </summary>
		/// <returns>
		///		Nonnegative number.
		/// </returns>
		public static int GetRandomInt()
		{
			return Random.Next();
		}

		/// <summary>
		///		Returns a nonnegative number less than the specified value.
		/// </summary>
		/// <param name="maxValue">
		///		Upper bound for the randomized value.
		/// </param>
		/// <returns>
		///		Nonnegative number.
		/// </returns>
		public static int GetRandomInt(int maxValue)
		{
			return Random.Next(maxValue);
		}

		/// <summary>
		///		Returns a random number from the specified range.
		/// </summary>
		/// <param name="minValue">
		///		Lower, inclusive bound.
		/// </param>
		/// <param name="maxValue">
		///		Upper, exclusive bound.
		/// </param>
		/// <returns>
		///		Random number.
		/// </returns>
		public static int GetRandomInt(int minValue, int maxValue)
		{
			return Random.Next(minValue, maxValue);
		}

		/// <summary>
		///		Returns a random number between 0.0 and 1.0.
		/// </summary>
		/// <returns></returns>
		public static double GetRandomDouble()
		{
			return Random.NextDouble();
		}
	}
}
