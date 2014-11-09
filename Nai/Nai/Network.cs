using System;
using System.Collections.Generic;

namespace en.AndrewTorski.Nai.TaskOne
{
	/// <summary>
	/// </summary>
	public class Network
	{
		private readonly IActivationFunction _activationFunction;

		public Network(int numberOfInputNeruons, int numberOfHiddenNeurons, IActivationFunction activationFunction)
		{
			InputNeurons = new List<Neuron>(numberOfInputNeruons);
			HiddenNeurons = new List<Neuron>(numberOfHiddenNeurons);

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

			//	Populate input and hidden layers.
			//	Note: each neuron will have it's weighs randomized from range [0, 1]

			//	Populate input neuron list
			for (var i = 0; i < InputNeurons.Capacity; i++)
			{
				InputNeurons[i] = new Neuron("Input", 7, _activationFunction);
				InputNeurons[i].SetConstantWeights();

			}

			//	Populate hidden neuron list
			for (var i = 0; i < HiddenNeurons.Capacity; i++)
			{
				HiddenNeurons[i] = new Neuron("Hidden", 7, _activationFunction);
				HiddenNeurons[i].SetRandomWeights();;
			}

			//	Note: Output neuron was already instantiated in the Network constructor.
		}

		/// <summary>
		///     Conduct a run to train neurons.
		/// </summary>
		public void TrainNeurons(int numberOfRuns, IList<byte> expectedAsciiVector, double expectedOutput, double learningRate)
		{
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
			OutputNeuron.DeltaValue = (expectedOutput - OutputNeuron.Output)*OutputNeuron.Output*(1.0 - OutputNeuron.Output);

			//	Calculate the new weights of inputs to the Output neuron.
			//	w_i	-	weight of the input i
			//	e	-	learning rate
			//	d	-	delta value of the neuron
			//	z_i	-	signal coming from input i
			//	Formula is as follows:
			//	w_i = e * d * z_i
			for (var i = 0; i < OutputNeuron.NumberOfInputs; i++)
			{
				OutputNeuron.InputWeights[i] += learningRate*OutputNeuron.DeltaValue*OutputNeuron.Inputs[i];
			}

			//	For OutputNeuron's bias.
			OutputNeuron.InputWeights[OutputNeuron.NumberOfInputs + 1] += learningRate*OutputNeuron.DeltaValue;

			//	Calculate the delta values for the hidden layer
			//	d	-	delta value
			//	s	-	weighted arithmetic mean of wo_i	-	Output neuron's input weights and
			//									do_i	-	Output neuron's delta value
			//	f'(x) - first deriviate of the activation function
			//	
			//	d = E(wo_i*do_i) * f'(y)
			//	Above could be extended to the following form:
			//	d = E(wo_i*do_i) * (y * ( 1 - y))
			//	
			//	In other words: the hidden neuron collects the error from the neurons it is connected with.
			//	But since we only consider one output neuron we conduct no summing.

			for (var i = 0; i < HiddenNeurons.Count; i++)
			{
				var hiddenNeuron = HiddenNeurons[i];
				hiddenNeuron.DeltaValue = hiddenNeuron.Output*(1.0 - hiddenNeuron.Output)*
				                          (OutputNeuron.InputWeights[i]*OutputNeuron.DeltaValue);
			}

			//	Calculate the new weights of inputs to the Hidden neurons.
			//	w_i	-	weight of the input i
			//	e	-	learning rate
			//	d	-	delta value of the neuron
			//	z_i	-	signal coming from input i
			//	Formula is as follows:
			//	w_i = e * d * z_i
			for (var i = 0; i < HiddenNeurons.Count; i++)
			{
				var hiddenNeuron = HiddenNeurons[i];
				for (int j = 0; j < hiddenNeuron.NumberOfInputs; j++)
				{
					hiddenNeuron.InputWeights[j] += learningRate*hiddenNeuron.DeltaValue*hiddenNeuron.Inputs[i];
				}

				//	Now for hiddenNeuron's bias.
				hiddenNeuron.InputWeights[hiddenNeuron.NumberOfInputs + 1] += learningRate*hiddenNeuron.DeltaValue;
			}

		}

		/// <summary>
		///     Conduct a classification of the vector of Ascii vectors and determine whether it matches the criteria.
		/// </summary>
		public bool ConductClassification()
		{
			throw new NotImplementedException();
		}
	}
}