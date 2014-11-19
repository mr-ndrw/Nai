using System;


namespace en.AndrewTorski.Nai.TaskOne
{
	public class Neuron
	{

		#region PrivateFields
		
		private readonly IActivationFunction _activationFunction;

		#endregion

		/// <summary>
		///		Initializes a random-input-weighted Neuron object with parametrized label, number of inputs and activation function reference.
		/// </summary>
		/// <param name="label">
		///		Description of the instantiated neuron.
		/// </param>
		/// <param name="numberOfInputs">
		///		Number of inputs instantiated neruon accepts.
		/// </param>
		/// <param name="activationFunction">
		///		Activation function which will be used to evaluate neural response.
		/// </param>
		public Neuron(string label, int numberOfInputs, IActivationFunction activationFunction)
		{
			Label = label;

			NumberOfInputs = numberOfInputs;
			Inputs = new double[NumberOfInputs];

			_activationFunction = activationFunction;

			//	Additional space in the InputWeights array is reserved for the bias. Hence '+ 1'.
			InputWeights = new double[NumberOfInputs + 1];

		}

		#region Properties

		/// <summary>
		///		Simple text label describing what kind of neuron this is(input, hidden or output).
		/// </summary>
		public string Label { get; private set; }

		/// <summary>
		///		Number of total inputs inside this neuron. This number excludes bias.
		/// </summary>
		public int NumberOfInputs { get; private set; }

		/// <summary>
		///		Collection of inputs provided to this neuron.
		/// </summary>
		public double [] Inputs { get; private set; }

		/// <summary>
		///		Array of weights prescribed to each respective Input.
		/// </summary>
		/// <remarks>
		///		This array's length will be equal to NumberOfInputs + 1. Additional space in the array is reserved for the Bias.
		/// </remarks>
		public double[] InputWeights { get; set; }

		/// <summary>
		///		Product of sum of all inputs mulitplied by their respective weights.
		/// </summary>
		public double WeightedArithmeticMean { get; set; }

		/// <summary>
		///		WeightedArithmeticMean after being evaluated by the activation function.
		/// </summary>
		public double Output { get; set; }

		/// <summary>
		///		Value used when calculating the backwards propagation.//TODO: Be more specific.
		/// </summary>
		public double DeltaValue { get; set; }

		#endregion

		#region Methods

		/// <summary>
		///		Calculated the weighted arithmethic mean based on the inputs and their respective weights.
		/// </summary>
		public double GetWeightedArithmeticMean()
		{
			var temp = 0.0;

			for (var i = 0; i < NumberOfInputs; i++)
			{
				temp += InputWeights[i]*Inputs[i];
			}

			WeightedArithmeticMean = temp;

			return WeightedArithmeticMean;
		}

		/// <summary>
		///		Calculates, sets and returns the neural response calculated by the activation function.
		/// </summary>
		public double GetNeuralResponse()
		{
			Output = _activationFunction.Evaluate(GetWeightedArithmeticMean());

			return Output;
		}

		/// <summary>
		///		Randomizes the weights of inputs.
		/// </summary>
		/// <remarks>
		///		This includes the bias.
		/// </remarks>
		public void SetRandomWeights()
		{
			var random = new Random();

			for (var i = 0; i < NumberOfInputs + 1; i++)
			{
				//InputWeights[i] = (random.NextDouble() * 4) - 2.0;
				InputWeights[i] = random.NextDouble();
			}
		}

		/// <summary>
		///		Sets all the weights to be equal to 1.0.
		/// </summary>
		/// <remarks>
		///		This includes the bias.
		/// </remarks>
		public void SetConstantWeights()
		{
			for (var i = 0; i < NumberOfInputs + 1; i++)
			{
				InputWeights[i] = 1.0;
			}
		}

		/// <summary>
		///		
		/// </summary>
		/// <param name="asciiVector"></param>
		public void PutAsciiVectorToInput(AsciiVector asciiVector)
		{
			//	Bits at the beginning of the array are considered the most significant bits.
			for (var i = 0; i < NumberOfInputs; i++)
			{
				Inputs[i] = asciiVector.CharArray[i] == '1' ? 1.0 : 0.0;
			}
		}
 
		#endregion

	}
}
