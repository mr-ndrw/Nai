

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace en.AndrewTorski.Nai.TaskOne
{

	public class Program
	{
		/// <summary>
		///		Returns a collection of AsciiVectors representing the given string.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		/// <example>
		///		For instance: 
		///			By passing string = "Andrew" to the method,
		///			a collection of following Vectors will be returned:
		///			[0] = 100 0001	'A'
		///			[1] = 110 1110	'n'
		///			[2] = 110 0100	'd'
		/// 		[3] = 111 0010	'r'
		/// 		[5] = 111 1010	'e'
		/// 		[6] = 110 1010	'w'
		/// </example>
		public static List<AsciiVector> GetInputSet (string name)
		{
			return name.ToCharArray().
				Select(letter => Convert.ToString(letter, 2)).
				Select(zerosOnesString => new AsciiVector(zerosOnesString)).
				ToList();
		}
		
		static void Main(string[] args)
		{
			//a = 1, b = 1;
			var defaultSigmoidActivationFunction = new SigmoidalActivationFunction();
			var network = new Network(7, 7, defaultSigmoidActivationFunction);
			network.SetUp();

			var firsSet = GetInputSet("Andrzej");
			var secondWrongSet = GetInputSet("MaxMaxM");

			for (var i = 0; i < 100; i++)
			{
				Console.WriteLine(network.ConductClassification(firsSet));
				
			}
			for (int i = 0; i < 10; i++)
			{
				network.TrainNeurons(0, null, 1.0, 0.5);
			}
			Console.WriteLine("AFTER TRAINING");

			Console.WriteLine(network.ConductClassification(firsSet));

			Console.WriteLine("NEW SET");

			for (var i = 0; i < 100; i++)
			{
				Console.WriteLine(network.ConductClassification(secondWrongSet));
				//network.TrainNeurons(0, null, 0.5, 1.0);
			}
			for (int i = 0; i < 10; i++)
			{
				network.TrainNeurons(0, null, 0.0, 0.5);
			}
			Console.WriteLine("AFTER TRAINING");

			Console.WriteLine(network.ConductClassification(secondWrongSet));

			Console.WriteLine("Done");
			Console.ReadKey();
		}
	}
}
