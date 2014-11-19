using System;
using System.Collections.Generic;
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
		///			By passing string = "Andrzej" to the method,
		///			a collection of following Vectors will be returned:
		///			[0] = 100 0001	'A'
		///			[1] = 110 1110	'n'
		///			[2] = 110 0100	'd'
		/// 		[3] = 111 0010	'r'
		/// 		[4] = 111 1010	'z'
		/// 		[5] = 110 0101	'e'
		///			[6] = 110 1010	'j'
		/// </example>
		public static List<AsciiVector> GetInputSet (string name)
		{
			return name.ToCharArray().
				Select(letter => Convert.ToString(letter, 2)).
				Select(zerosOnesString => new AsciiVector(zerosOnesString)).
				ToList();
		}

		/// <summary>
		/// 	Returns a collection of AsciiVectors representing the given string.
		/// </summary>
		/// <param name="name">
		///		String for which we obtain the List of AsciiVectors
		/// </param>
		/// <param name="expected">
		///		The value of this List.
		/// </param>
		/// <returns>
		/// 
		///	</returns>
		public static List<AsciiVector> GetInputSet(string name, double expected)
		{
			return name.ToCharArray().
				Select(letter => Convert.ToString(letter, 2)).
				Select(zerosOnesString => new AsciiVector(zerosOnesString, expected)).
				ToList();
		}

		/// <summary>
		///		
		/// </summary>
		/// <returns></returns>
		public static List<List<AsciiVector>> GetTrainingSet()
		{
			string[] correctSamples = 
			{		
				"Andrzej", "ANDrzej", "ANDrzEj", "anDRzej", "AndRZEJ", 
				"andRZEJ", "ANDRZEJ", "andrzej", "AndrzeJ", "andrzEJ"
			};

			string[] incorrectSamples =
			{
				"MaxPowr", "PowerMx", "Sevennn", "NiceOne", "MopsKlo",
				"NieAndr", "MaxKolo", "SixSeve", "Correct", "NCorrec"
			};

			var result = correctSamples.Select(correctSample => GetInputSet(correctSample, 1.0)).ToList();

			result.AddRange(incorrectSamples.Select(incorrectSample => GetInputSet(incorrectSample, 0.0)));


			//	Shuffle the list using the ListHelper.cs method.
			result.Shuffle();

			return result;
		}

		
		static void Main(string[] args)
		{
			//a = 1, b = 1;
			var defaultSigmoidActivationFunction = new SigmoidalActivationFunction();
			var network = new Network(7, 7, defaultSigmoidActivationFunction);
			network.SetUp();

			var learningRate = 0.0;
			var expectedOutputValue = 1.0;
			var asciiVectorList = new List<AsciiVector>();

			var query = string.Empty;
			var messageLoopCondition = true;

			while (messageLoopCondition)
			{
				//Console.WriteLine("---------------\nProvide a new command:\n---------------");
				var readLine = Console.ReadLine();
				if (readLine != null) 
					query = readLine.ToLower();

				var tokenizedString = query.Split(' ');

				var command = tokenizedString[0];

				switch (command)
				{
					case "newset":
					{
						if (tokenizedString.Length < 3)
						{
							Console.WriteLine("You must provide a set! and it's expected value!");
							break;
						}
						var secondToken = tokenizedString[1];
						asciiVectorList = GetInputSet(secondToken);

						expectedOutputValue = Double.Parse(tokenizedString[2]);

						break;
					}
					case "train":
					{
						if (tokenizedString.Length < 2)
						{
							Console.WriteLine("You must provide an integer number argument.");
							break;
						}
						var numberOfTrains = Int32.Parse(tokenizedString[1]);

						for (var i = 0; i < numberOfTrains; i++)
						{
							network.TrainNeurons(expectedOutputValue, learningRate);
						}

						Console.WriteLine("Evauluating after training. \n Output = {0}", network.ConductClassification(asciiVectorList));
						break;
					}
					case "classify":
					{
						Console.WriteLine("Result of the evaluation. \n Output = {0}", network.ConductClassification(asciiVectorList));
						break;
					}
					//	Set learning rate;
					case "setlr":
					{
						if (tokenizedString.Length < 2)
						{
							Console.WriteLine("You must provide a real number argument.");
							break;
						}
						learningRate = Double.Parse(tokenizedString[1]);
						break;
					}
					case "setalpha":
					{
						if (tokenizedString.Length < 2)
						{
							Console.WriteLine("You must provide a real number argument.");
							break;
						}
						var newAlphaValue = Double.Parse(tokenizedString[1]);
						defaultSigmoidActivationFunction.Alpha = newAlphaValue;
						break;
					}
					case "config":
					{
						Console.WriteLine("Learning rate: {0}", learningRate);
						Console.WriteLine("Function Alpha parameter: {0}", defaultSigmoidActivationFunction.Alpha);
						
						printNeuronInfo(network.OutputNeuron);

						foreach (var hiddenNeuron in network.HiddenNeurons)
						{
							printNeuronInfo(hiddenNeuron);
						}

						foreach (var inputNeuron in network.InputNeurons)
						{
							printNeuronInfo(inputNeuron);
						}

						break;
					}
					case "quit":
					{
						messageLoopCondition = false;
						break;
					}
				}
			
			}

			Console.WriteLine("Done");
			Console.ReadKey();
		}

		public static void  printNeuronInfo(Neuron neuron)
		{
			Console.WriteLine(neuron.Label);

			Console.WriteLine("\tDelta value: {0}", neuron.DeltaValue);
			Console.WriteLine("\tOutput: {0}", neuron.Output);

			Console.Write("\tInputWeights:");

			foreach (var inputWeight in neuron.InputWeights)
			{
				Console.Write("{0} ", inputWeight);
			}
			Console.WriteLine();
			Console.Write("\tInputs:");

			foreach (var input in neuron.Inputs)
			{
				Console.Write("{0} ", input);
			}

			Console.WriteLine();
		}
	}
}
