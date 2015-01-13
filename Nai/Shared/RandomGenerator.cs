using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public static class RandomGenerator
	{
		private static Random _random;


		static RandomGenerator()
		{
			_random = new Random();
		}

		/// <summary>
		///		Generates a random collection of bools of specified count.
		/// </summary>
		/// <param name="length">
		///		Count of the collection.
		/// </param>
		public static IEnumerable<bool> GetRandomBoolCollection(int length)
		{
			var randomTrueFalseCollection = Enumerable.Range(0, length).Select(r =>_random.NextDouble() > 0.5);

			return randomTrueFalseCollection;
		}

		/// <summary>
		///		Returns an arbitrarily-sized collection of random doubles.
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public static IEnumerable<double> GetRandomDoubles(int length)
		{
			return Enumerable.Range(0, length).Select(rand => _random.NextDouble());
		}

		/// <summary>
		///		Returns a nonnegative number.
		/// </summary>
		/// <returns>
		///		Nonnegative number.
		/// </returns>
		public static int GetRandomInt()
		{
			return _random.Next();
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
			return _random.Next(maxValue);
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
			return _random.Next(minValue, maxValue);
		}
	}
}
