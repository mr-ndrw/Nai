/*	
 *	Project Name:	Nai Project - Neural Network.
 *	Author:			Andrzej Torski
 *	Index:			s10415
 */


using System;
using System.Collections.Generic;
using System.IO;
using en.AndrewTorski.Nai.TaskOne;
using OfficeOpenXml;

namespace EtaMetricCalculation
{
	/// <summary>
	///		This class servers as an entry point to the program, which gathers statistical data from neural network learning process.
	/// </summary>
	class MainProgram
	{

		static Random random = new Random();

		private static double GetRandomNumber(double minimum, double maximum)
		{
			return random.NextDouble() * (maximum - minimum) + minimum;
		}


		/// <summary>
		///		Main entry point for the program.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			//	Create excel package to which we will parse statistical data.
			using (var xlPackage = new ExcelPackage())
			{
				xlPackage.Workbook.Properties.Author = "Andrzej Torski";
				xlPackage.Workbook.Properties.Title = "Nai.TaskOne";
				xlPackage.Workbook.Properties.Company = "Andrew Torski Artifical Computing";

				xlPackage.Workbook.Worksheets.Add("Data");

				var workSheet = xlPackage.Workbook.Worksheets[1];

				workSheet.Name = "Data";

				//	numberOfRuns is a number of how many full Eta cycles we will complete and gather data from.
				//	The larger this value is, the more accurate our final data will be.
				const int numberOfRuns = 100;

				//	etaCycles is a value which is used to determine how many cycles of learning process on each training set
				//	will be completed per each step of Eta
				//	By Eta Step what is meant is the value by which we increment Eta during statistical data collection.
				//	Example:	we begin with eta = 0.05 <- perform etaCycles number of learning process on a trainingset
				//				increase eta by 0.05 <- eta step
				//				eta = 0.1 <- perform etaCycles etc.. etc..
				//				increase eta by 0.05
				//				eta = 0.15 <- etc etc

				const int totalEtaCycles = 2000;

				//	In total we have 20[0.05, 1] eta steps, for which individually we perform 2000 iterations of learning on
				//	a training set of 20 training examples(half is expected to be false, half is expected to true).
				//	The number of how many times we are suppoused to do such a run is regulated by the value numberOfRuns.


				//	Create a Network with	-7 input/hidden neurons - they server as input neurons and hidden neurons at the same time
				//							-3 hidden neurons
				//							-1 output neuron
				//							-with sigmoid functions serving as it's activation functions with default parameters.
				var network = new Network(7, 3, new SigmoidalActivationFunction());

				//	Get 20 training sets - half is true, half is false.
				var trainingSets = NetworkUtils.GetTrainingSet();

				//	Cells for excel usage.
				ExcelRange etaCell, errorCell, minCell, maxCell, medianCell, sdCell;

				//	Statistical data structure which in essence is a 2D matrix, 
				//	which size is defined by following properties:
				//		-	number of total etaSteps = 20 determines the number of rows:
				//				-	we start on eta = 0.05 and then increase by 0.05(once etaCycles has completed) untill we reach eta = 1
				//					therefore we consider 20 such steps(1 / 0.05 = 20)
				//		-	numberOfRuns determines the number of columns
				var statContainer = new AveragePerEtaPerRunContainer(numberOfRuns);

				for (var currentGlobalRun = 0; currentGlobalRun < numberOfRuns; currentGlobalRun++)
				{
					var eta = 0.0;

					if(currentGlobalRun % 10 == 0) Console.WriteLine(currentGlobalRun);

					
					for (var etaStep = 1; etaStep <= 20; etaStep++)
					{
						eta += 0.05;
						//	With each new value of eta, we clear the data in network and randomize it's weights.
						network.SetUp();
						
						//	Perform training on shuffled training sets etaCyles number of times.
						for (var etaCycle = 0; etaCycle < totalEtaCycles; etaCycle++)
						{
							//	Shuffle training sets to obtain better results and avoid over-training of the network.
							trainingSets.Shuffle();
							foreach (var trainingSet in trainingSets)
							{
								network.ConductClassification(trainingSet.AsciiVectors);
								network.TrainNeurons(trainingSet.ExpectedValue, eta);
							}
						}
						
						var error = 0.0;
						
						//	After training for the given step of eta has been performed,
						//	conduct a final classification run on each of the training sets,
						//	calculate the error between what has network obtained from this 
						//	example and what do we expect from this set and the take the
						//	absolute value out of it and add it too cumulated error.
						foreach (var trainingSet in trainingSets)
						{
							var calculated = network.ConductClassification(trainingSet.AsciiVectors);
							error += Math.Abs(trainingSet.ExpectedValue - calculated);
						}
						
						//	Once we have performed all the final classification runs, we divide obtained sum of errors
						//	by the number of training sets, therefore obtaining an averageError. Next we put that error in
						//	it's designated place in the 2D array in the statistical container.

						var averageError = error / (double)trainingSets.Count;
						//	Little clarification: for eta = 0.05, the etaStep is equal to 1(because 0.05 / 0.05 = 1 and 
						//	so on for next values.
						statContainer.AverageErrors[etaStep - 1, currentGlobalRun] = averageError;
					}

				}

				/*	Finally we obtain a statistical container which looks like this:
				 * 
				*								Global run number starting with 
				 *		step = 0.05				0 and ending whereever we set
				 *								the value numberOfRuns initially minus one.
				 *							|	0|	1|	2|	3|	4|	5|	6|	7|	8|	9| ... ... numberOfRuns - 1
				 *	ETA		Step Multiplier	|xxxx|xxx|xxx|xxx|xxx|xxx|xxx|xxx|xxx|xxx|
				 *	0.05		1			|	 |	 |	 |	 |	 |	 |	 |	 |	 |	 |
				 *	--------------------------------------------------------------------
				 *	0.1			2			|	 |	 |	 |	 |	 |	 |	 |	 |	 |	 |
				 *	--------------------------------------------------------------------
				 *	0.15		3			|	 |	 |	 |	 |	 |	 |	 |	 |	 |	 |
				 *	--------------------------------------------------------------------
				 *	0.2			4			|	 |	 |	 |	 |	 |	 |	 |	 |	 |	 |
				 *	--------------------------------------------------------------------
				 *	0.25		5			|	 |	 |	 |	 |	 |	 |	 |	 |	 |	 |
				 *	--------------------------------------------------------------------
				 *	0.3			6			|	 |	 |	 |	 |	 |	 |	 |	 |	 |	 |
				 *	--------------------------------------------------------------------
					...			...			...		...		...		...		...		...
				 *	1			20	
				*/

				//	Each cell the above matrix corresponds to the average error the network has made classifying trainings sets
				//	while eta was equal = StepMultipler - row number
				//	and the number of global run which is the column number.

				//	This way we are able to obtain a large data set of values which is next used to calculate
				//	the AverageError per Eta, by just summing the column values for each row and then dividing it by the numberOfRuns
				//	and storing it away in a data structure such as statData below which contains that information.

				//	Calculate the average error per eta
				var resultList = statContainer.CalculateAveragePerEta();
				var statData = new List<StatisticalDataContainer>();

				for (var i = 0; i < 20; i++)
				{
					statData.Add(new StatisticalDataContainer(statContainer.AverageErrors, i, numberOfRuns));
				}

				double d = 0.05;

				//	Write the data to excel cells.
				for (var i = 1; i <= 20; i++)
				{
					var statsForGivenRow = statData[i - 1];
					var average = resultList[i - 1];

					etaCell = workSheet.Cells[i, 1];
					errorCell = workSheet.Cells[i, 2];
					minCell = workSheet.Cells[i, 3];
					maxCell = workSheet.Cells[i, 4];
					medianCell = workSheet.Cells[i, 5];
					sdCell = workSheet.Cells[i, 6];

					etaCell.Value = d;
					errorCell.Value = average;
					minCell.Value = statsForGivenRow.Min;
					maxCell.Value = statsForGivenRow.Max;
					medianCell.Value = statsForGivenRow.Median;
					sdCell.Value = statsForGivenRow.StandardDeviation;

					d += 0.05;
				}

				//	Save it.
				var binaryData = xlPackage.GetAsByteArray();
				File.WriteAllBytes(@"C:\Nai\Nai.TaskOne100runs3hiddenneruons.xlsx", binaryData);
			}

			//	Done.
			Console.WriteLine("Done;");
			Console.ReadKey();
		}
	}
}
