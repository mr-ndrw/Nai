using System;

namespace en.AndrewTorski.Nai.TaskOne
{
	public class AsciiVector
	{
		//	Bits at the beginning of the array are considered the most significant bits.
		public char[] CharArray;

		/// <summary>
		///		Expected value of the evaluation of the given Vector.
		/// </summary>
		public double ExpectedValue { get; set; }

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

		/// <summary>
		///		Initializes the object.
		/// </summary>
		/// <param name="zeroesOnesCharacters">
		///		String of zeroes and ones.
		/// </param>
		/// <param name="expected">
		///		Expected value for instantiated vector.
		/// </param>
		public AsciiVector(string zeroesOnesCharacters, double expected)
		{
			if (zeroesOnesCharacters.Length != 7)
			{
				throw new Exception("Length of the string must be equal to 7!");
			}
			CharArray = zeroesOnesCharacters.ToCharArray();
			ExpectedValue = expected;
		}



	}
}
