using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using en.AndrewTorski.Nai.TaskOne;
using OfficeOpenXml;

namespace ActivationFunctionMetric
{
	public class ActivationFunctionMetricProgram
	{
		public static void Main(string[] args)
		{
			//	Create a sigmoid function with default values = 1.
			var function = new SigmoidalActivationFunction();

			//	First create a network of following configuration 7-3-1
			var network = new Network(7, 3, function);
			network.SetUp();

			//	Get 20 training sets - half is true, half is false.
			var trainingSets = Program.GetTrainingSet();

			//	value below has proven to be the best choice for learning.
			const double eta = 0.35;

			const int numberOfLearningRuns = 5;

			for (var i = 0; i < numberOfLearningRuns; i++)
			{
				trainingSets.Shuffle();
				foreach (var trainingSet in trainingSets)
				{
					network.ConductClassification(trainingSet.AsciiVectors);
					network.TrainNeurons(trainingSet.ExpectedValue, eta);
				}
			}
			//	Finish learning

			//	Create a container with a 2D array which will contain the sums of error for given alpha and beta.
			var statData = new _3DStatisticalContainer(20, 20);

			//	In total to each cell(of given alpha and beta) we will add a result from below variable number of runs.
			const int numberOfFunctionEvaluationRuns = 10000;

			const double alphaStart = 0.5;
			const double betaStart = -5.0;

			var alphaStep = 0.5;
			var betaStep = -5.0;

			const double alphaIncrement = 0.5;
			const double betaIncrement = 0.5;

			for (var currentRun = 0; currentRun < numberOfFunctionEvaluationRuns; currentRun++)
			{
				//	Reset beta step to initial state
				betaStep = betaStart;
				for (var currentBetaStep = 1; currentBetaStep <= 20; currentBetaStep++)
				{
					//	Once we have dont evaluating beta, reset alpha to inital state.
					alphaStep = alphaStart;

					//	Change the beta value of the activation function.
					function.Beta = betaStep;

					for (var currentAlphaStep = 1; currentAlphaStep <= 20; currentAlphaStep++)
					{
						//	Change the alpha value of the activation function.
						function.Alpha = alphaStep;
						double error = 0.0;

						//	Classify the training set and gather the error.
						foreach (var trainingSet in trainingSets)
						{
							var calculated = network.ConductClassification(trainingSet.AsciiVectors);
							error += Math.Abs(trainingSet.ExpectedValue - calculated);
							//Console.WriteLine("error {0}", error);
							//Console.WriteLine("Alpha: {0}\tBeta:{1}", function.Alpha, function.Beta);
							//Console.WriteLine("Expected {0}\tcalculated {1}\terror {2}\n", trainingSet.ExpectedValue, calculated, Math.Abs(trainingSet.ExpectedValue - calculated));
							;
						}

						//Console.WriteLine("Alpha: {0} Beta:{1} Error: {2}", function.Alpha, function.Beta, error/20);
						//	Added the calculated error to the 2d array.
						statData[currentBetaStep - 1, currentAlphaStep - 1] += error/*/trainingSets.Count*/;

						//Console.WriteLine("error {0}", error);

						alphaStep += alphaIncrement;
					}
					betaStep += betaIncrement;
				}
			}
			
			//	Divide each value in cells in the statistical container by the total number of runs. 
			statData.CalculateAverageForEachCell(numberOfFunctionEvaluationRuns);

			//	Revert alphastep and betastep to initial values so we may reuse them in later section.
			alphaStep = alphaStart;
			betaStep = betaStart;

			using (var xlPackage = new ExcelPackage())
			{
				xlPackage.Workbook.Properties.Author = "Andrzej Torski";
				xlPackage.Workbook.Properties.Title = "Nai.TaskOne";
				xlPackage.Workbook.Properties.Company = "Andrew Torski Artifical Computing";

				xlPackage.Workbook.Worksheets.Add("Data");

				var workSheet = xlPackage.Workbook.Worksheets[1];

				workSheet.Name = "Data";
				ExcelRange cell;
				//	Parse in the first column which contains beta values starting from [2,1] and going vertically down from that point.
				for (var i = 1; i <= 20; i++)
				{
					cell = workSheet.Cells[i + 1, 1];
					cell.Value = betaStep;
					betaStep += betaIncrement;
				}

				// Parse the alpha values row starting from [1,2] and going horizontally right from that point.
				for (var i = 1; i <= 20; i++)
				{
					cell = workSheet.Cells[1, i + 1];
					cell.Value = alphaStep;
					alphaStep += alphaIncrement;
				}


				for (var currentBetaStep = 0; currentBetaStep < 20; currentBetaStep++)
				{
					for (var currentAlphaStep = 0; currentAlphaStep < 20; currentAlphaStep++)
					{
						cell = workSheet.Cells[currentBetaStep + 2, currentAlphaStep + 2];
						cell.Value = statData[currentBetaStep, currentAlphaStep];
					}
				}

				//	Save it.
				var binaryData = xlPackage.GetAsByteArray();
				File.WriteAllBytes(@"C:\Nai\Nai.functionmetric1.xlsx", binaryData);

			}

			//	Done.
			Console.WriteLine("Done;");
			Console.ReadKey();
		}

	}
}
