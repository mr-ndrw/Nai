/*	
 *	Project Name:	Nai Project - Neural Network.
 *	Author:			Andrzej Torski
 *	Index:			s10415
 */

using System;
using System.Collections.Generic;

namespace en.AndrewTorski.Nai.TaskOne
{
	/// <summary>
	///		A wrapper for a collection of AsciiVectors and it's associated expected output value.
	/// </summary>
	public class AsciiVectorCollectionWrapper
	{
		/// <summary>
		///		Initializes a new instance of the <see cref="T:System.Object"/> class.
		/// </summary>
		public AsciiVectorCollectionWrapper(double expectedValue, List<AsciiVector> asciiVectors, string alphaNumericValue)
		{
			AlphaNumericValue = alphaNumericValue;
			ExpectedValue = expectedValue;
			AsciiVectors = asciiVectors;
		}

		/// <summary>
		///		The value which we expect the AsciiVectors collection to yield after being processed by the network.
		/// </summary>
		public Double ExpectedValue { get; private set; }

		public List<AsciiVector> AsciiVectors { get; private set; }

		/// <summary>
		///		The alphanumeric, READABLE representation of the Collection of Ascii Vectors.
		///		Useful for debugging and general sanity check.
		/// </summary>
		public string AlphaNumericValue { get; private set; }
		
	}
}
