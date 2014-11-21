using System;
using System.Collections.Generic;
using System.Linq;

namespace en.AndrewTorski.Nai.TaskOne
{
	/// <summary>
	/// </summary>
	public class Network
	{
		private readonly IActivationFunction _activationFunction;
		private readonly int _numberOfInputNeurons;
		private readonly int _numberOfHiddenNeurons;

		public Network(int numberOfInputNeruons, int numberOfHiddenNeurons, IActivationFunction activationFunction)
		{
			InputNeurons = new List<Neuron>(numberOfInputNeruons);
			HiddenNeurons = new List<Neuron>(numberOfHiddenNeurons);

			_numberOfInputNeurons = numberOfInputNeruons;
			_numberOfHiddenNeurons = numberOfHiddenNeurons;

			_activationFunction = activationFunction;

			OutputNeuron = new Neuron("Output", 7, _activationFunction);
			OutputNeuron.SetRandomWeights();
		}

		public List<Neuron> InputNeurons { get; set; }

		public List<Neuron> HiddenNeurons { get; set; }

		public Neuron OutputNeuron { get; set; }

		/// <summary>
		///     Creates necessary connections between input, hidden and output neurons.
		/// </summary>
		public void SetUp()
		{
			/****************************************************************************************************************************************
			 *	The network structure is most primarily dictated by the following elements:
			 *		-	for each letter in the name: Andrzej, one seperate neuron is dedicated - length of the name Andrzej is 7, hence the number of
			 *			input neurons is also 7,
			 *		-	each input neuron accepts a single Ascii character/vector, which length is 7.(For instance letter 'A' is 100 0001) Therefore
			 *			each input neuron will have 7 inputs,
			 *		-	the number of neurons in hidden layer will be identical to that of input layer - 7,
			 *		-	each hiden neuron will have 7 inputs,
			 *		-	each input neuron will have it's output collected by each of the hidden neurons, which constitutes the following:
			 *			7 input neurons and 7 hidden neurons gives us a total of 49(7 * 7) connectiong between input layer and hidden layer.
			 *		-	since we expect a yes/no answer, there will be only one output neuron.
			 *		-	each hidden neuron will have it's output collected by the output layer.
			 *		
			 *	In short:
			 *		-	7 input neurons,(one layer)
			 *		-	7 hidden neurons,(one layer)
			 *		-	1 output neuron.(one layer)
			 ***************************************************************************************************************************************/

			//	First dispose of old neurons if such exist.
			InputNeurons.Clear();
			HiddenNeurons.Clear();
			OutputNeuron = new Neuron("Output", 7, _activationFunction);

			//	Populate input and hidden layers.
			//	Note: each neuron will have it's weighs randomized from range [0, 1]

			//	Populate input neuron list
			Neuron newInputNeuron;
			for (var i = 0; i < _numberOfInputNeurons; i++)
			{
				newInputNeuron = new Neuron("Input", 7, _activationFunction);
				newInputNeuron.SetRandomWeights();
				InputNeurons.Add(newInputNeuron);
				Console.WriteLine("NEWS");
			}

			//	Populate hidden neuron list
			Neuron newHiddenNeuron;
			for (var i = 0; i < _numberOfHiddenNeurons; i++)
			{
				newHiddenNeuron = new Neuron("Hidden", 7, _activationFunction);
				newHiddenNeuron.SetRandomWeights();
				HiddenNeurons.Add(newHiddenNeuron);
			}

			//	Note: Output neuron was already instantiated in the Network constructor.
		}

		/// <summary>
		///		Randomizes the input weights in neurons
		/// </summary>
		public void RandomizeWeights()
		{
			foreach (var inputNeuron in InputNeurons)
			{
				inputNeuron.SetRandomWeights();
			}

			foreach (var hiddenNeuron in HiddenNeurons)
			{
				hiddenNeuron.SetRandomWeights();
			}

			OutputNeuron.SetRandomWeights();
		}

		/// <summary>
		///     Conduct a run to train neurons.
		/// </summary>

		public void TrainNeurons(double expectedOutput, double learningRate)
		{
			#region Comment
			//	READTHIS READTHIS READTHIS
			//	Before a TrainNeurons run is conducted, a standard classification run(ConductClassification() method) should be run. 

			//	Calculate the delta value for the output neuron.
			//	d - delta value
			//	t - expected value
			//	y - neural response
			//	f'(x) - first deriviate of the activation function
			//	
			//	d = (t - y) * f'(y)
			//	Above could be extended to the following form:
			//	d = (t - y) * (y * ( 1 - y)) 
			#endregion
			OutputNeuron.DeltaValue = (expectedOutput - OutputNeuron.Output) * OutputNeuron.Output * (1.0 - OutputNeuron.Output);

			#region Comment
			//	Calculate the new weights of inputs to the Output neuron.
			//	w_i	-	weight of the input i
			//	e	-	learning rate
			//	d	-	delta value of the neuron
			//	z_i	-	signal coming from input i
			//	Formula is as follows:
			//	w_i = e * d * z_i 
			#endregion
			for (var i = 0; i < OutputNeuron.NumberOfInputs; i++)
			{
				OutputNeuron.InputWeights[i] += learningRate * OutputNeuron.DeltaValue * OutputNeuron.Inputs[i];
			}

			//	For OutputNeuron's bias.
			OutputNeuron.InputWeights[OutputNeuron.NumberOfInputs] += learningRate * OutputNeuron.DeltaValue;

			#region Comment
			//	Calculate the delta values for the hidden layer
			//	d	-	delta value
			//	s	-	weighted arithmetic mean of wo_i	-	Output neuron's input weights and
			//										do_i	-	Output neuron's delta value
			//	f'(x) - first deriviate of the activation function
			//	
			//	d = E(wo_i*do_i) * f'(y)
			//	Above could be extended to the following form:
			//	d = E(wo_i*do_i) * (y * ( 1 - y))
			//	
			//	Where E should be sigma...	
			//
			//	In other words: the hidden neuron collects the error from the neurons it is connected with.
			//	But since we only consider one output neuron we conduct no summing. 
			#endregion
			for (var i = 0; i < HiddenNeurons.Count; i++)
			{
				var hiddenNeuron = HiddenNeurons[i];
				hiddenNeuron.DeltaValue = hiddenNeuron.Output * (1.0 - hiddenNeuron.Output) *  (OutputNeuron.InputWeights[i] * OutputNeuron.DeltaValue);
			}

			#region Comment
			/*
			 * Calculate the new weights of inputs to the Hidden neurons.
			 * w_i	-	weight of the input i
			 * e	-	learning rate
			 * d	-	delta value of the neuron
			 * z_i	-	signal coming from input i
			 * Formula is as follows:
			 * w_i = e * d * z_i
			 */
			#endregion
			foreach (var hiddenNeuron in HiddenNeurons)
			{
				for (var j = 0; j < hiddenNeuron.NumberOfInputs; j++)
				{
					hiddenNeuron.InputWeights[j] += learningRate * hiddenNeuron.DeltaValue * hiddenNeuron.Inputs[j];
				}

				//	Now for hiddenNeuron's bias.
				hiddenNeuron.InputWeights[hiddenNeuron.NumberOfInputs] += learningRate * hiddenNeuron.DeltaValue;
			}

			#region Comment
			//	Calculate the delta values for input neurons
			//	d	-	delta value
			//	s	-	weighted arithmetic mean of wh_i	-	hidden neuron's input weights and
			//										dh_i	-	hidden neuron's delta value
			//	f'(x) - first deriviate of the activation function
			//	
			//	
			//	Where E should be sigma...	
			//
			//	d = E(wh_i*dh_i) * f'(y)
			//	Above could be extended to the following form:
			//	d = E(wh_i*dh_i) * (y * ( 1 - y))
			//
			//	For each input neuron, we have to iterate over the hidden neurons it is connected with. 
			#endregion
			double error = 0.0;
			for (var i = 0; i < InputNeurons.Count; i++)
			{
				var inputNeuron = InputNeurons[i];

				//	LINQ function which for each hiddenNeuron in HiddenNeurons Collection caluclates and returns associated error
				//	LINQ rocks!
				error += HiddenNeurons.Sum(hiddenNeuron => hiddenNeuron.InputWeights[i] * hiddenNeuron.DeltaValue);

				inputNeuron.DeltaValue = inputNeuron.Output * (1.0 - inputNeuron.Output) * error;

				error = 0.0;
			}

			//	Calculate the new weights of inputs to Input neuron

			foreach (var inputNeuron in InputNeurons)
			{
				for (var j = 0; j < inputNeuron.NumberOfInputs; j++)
				{
					inputNeuron.InputWeights[j] += learningRate * inputNeuron.DeltaValue * inputNeuron.Inputs[j];
				}
				//	Now for inputNeuron's bias.
				inputNeuron.InputWeights[inputNeuron.NumberOfInputs] += learningRate * inputNeuron.DeltaValue;
			}

			//	FINISH
		}

		/// <summary>
		///     Conduct a classification of the collection of Ascii vectors and returns the calculated output value.
		/// </summary>
		/// <returns>
		///		Returns the calculated output value.
		/// </returns>
		public double ConductClassification(List<AsciiVector> asciiVectorsList)
		{
			//	Assign each vector to respective input neuron.
			for (var i = 0; i < InputNeurons.Count; i++)
			{
				InputNeurons[i].PutAsciiVectorToInput(asciiVectorsList[i]);
			}

			//	Calculate the Output values(calculated by the provided activation function) for each InputNeuron
			foreach (var inputNeuron in InputNeurons)
			{
				inputNeuron.GetNeuralResponse();
			}

			//	Assign InputNeurons' Output values to HiddenNeurons' Input values.
			foreach (var hiddenNeuron in HiddenNeurons)
			{
				for (var j = 0; j < InputNeurons.Count; j++)
				{
					var inputNeurons = InputNeurons[j];
					hiddenNeuron.Inputs[j] = inputNeurons.Output;
				}
			}

			//Calculate the Output values for each HiddenNeuron
			foreach (var hiddenNeuron in HiddenNeurons)
			{
				hiddenNeuron.GetNeuralResponse();
			}

			//	Assign HiddenNeuron's Output values to OutputNeuron's Input values.
			for (var j = 0; j < HiddenNeurons.Count; j++)
			{
				var hiddenNeuron = HiddenNeurons[j];
				OutputNeuron.Inputs[j] = hiddenNeuron.Output;
			}

			//	Return the final neuron response.
			return OutputNeuron.GetNeuralResponse();
		}
	}
}