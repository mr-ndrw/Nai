/*	
 *	Project Name:	Nai Project - Genetic and SA Algorithms comparison.
 *	Author:			Andrzej Torski
 *	Index:			s10415
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Shared.Utils
{
	/// <summary>
	///		Contains usefull methods that help operate and manipulate the List class.
	/// </summary>
	public static class ListHelper
	{
		/// <summary>
		///		Shuffles the elements contained in the list using effective cryptographic random seed.
		/// </summary>
		/// <param name="list">
		///		List which elements' are to be shuffled.
		/// </param>
		public static void Shuffle<T>(this IList<T> list)
		{
			Random rnd = new Random();
			list = list.OrderBy<T, int>((item) => rnd.Next()).ToList();
/*			var provider = new RNGCryptoServiceProvider();
			var n = list.Count;
			while (n > 1)
			{
				var box = new byte[1];
				do provider.GetBytes(box);
				while (!(box[0] < n * (Byte.MaxValue / n)));
				var k = (box[0] % n);
				n--;
				var value = list[k];
				list[k] = list[n];
				list[n] = value;
			}*/
		}
	}
}
