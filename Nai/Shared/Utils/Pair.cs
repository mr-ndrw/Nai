using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utils
{
	/// <summary>
	///		Container for a pair of two typed objects.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Pair<T>
	{
		/// <summary>
		///		Initializes an object with a pair of two objects.
		/// </summary>
		/// <param name="x">
		///		First object in pair.
		/// </param>
		/// <param name="y">
		///		Second object in pair.
		/// </param>
		public Pair(T x, T y)
		{
			this.X = x;
			this.Y = y;
		}

		/// <summary>
		///		First object in pair.
		/// </summary>
		public T X { get; set; }

		/// <summary>
		///		Second object in pair.
		/// </summary>
		public T Y { get; set; }
	}
}
