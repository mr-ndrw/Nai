/*	
 *	Project Name:	Nai Project - Neural Network.
 *	Author:			Andrzej Torski
 *	Index:			s10415
 */

using System;

namespace en.AndrewTorski.Nai.TaskOne
{
	public class AsciiVector
	{
		//	Bits at the beginning of the array are considered the most significant bits.
		public char[] CharArray;

		/// <summary>
		///		Initializes the object.
		/// </summary>
		/// <param name="zeroesOnesCharacters">
		///		String of zeroes and ones.
		/// </param>
		public AsciiVector(string zeroesOnesCharacters)
		{
			if (zeroesOnesCharacters.Length != 7)
			{
				throw new Exception("Length of the string must be equal to 7!");
			}
			CharArray = zeroesOnesCharacters.ToCharArray();
		}
	}
}
