using System;
using System.IO;
using OfficeOpenXml;
using en.AndrewTorski.Nai.TaskOne;

namespace Excel
{
	class MainProgram
	{

		static Random random = new Random();

		private static double GetRandomNumber(double minimum, double maximum)
		{
			return random.NextDouble() * (maximum - minimum) + minimum;
		}

		static void Main(string[] args)
		{
			using (var xlPackage = new ExcelPackage())
			{
				xlPackage.Workbook.Properties.Author = "Andrzej Torski";
				xlPackage.Workbook.Properties.Title = "Nai.TaskOne";
				xlPackage.Workbook.Properties.Company = "Andrew Torski Artifical Computing";

				xlPackage.Workbook.Worksheets.Add("Data");

				var workSheet = xlPackage.Workbook.Worksheets[1];

				workSheet.Name = "Data";

				const int numberOfRuns = 1;
				const int numberOfRunsPerEtaStep = 5000;


				var network = new Network(7, 7, new SigmoidalActivationFunction());
				var trainingSets = Program.GetTrainingSet();

				ExcelRange etaCell, errorCell;


				for (var i = 0; i < numberOfRuns; i++)
				{
					var eta = 0.0;

					for (var j = 1; j <= 20; j++)
					{
						//Console.WriteLine("Setting up");
						network.RandomizeWeights();
						for (var k = 0; k < numberOfRunsPerEtaStep; k++)
						{
							trainingSets.Shuffle();
							foreach (var trainingSet in trainingSets)
							{
								network.ConductClassification(trainingSet.AsciiVectors);
								network.TrainNeurons(trainingSet.ExpectedValue, eta);
							}
						}

						var error = 0.0;

						foreach (var trainingSet in trainingSets)
						{
							var calculated = network.ConductClassification(trainingSet.AsciiVectors);
							error += trainingSet.ExpectedValue - calculated;
							//Console.WriteLine("E: {0} C: {1}", trainingSet.ExpectedValue, calculated);
						}

						var averageError = error / (double) trainingSets.Count;

						etaCell = workSheet.Cells[j, 1];
						errorCell = workSheet.Cells[j, 2];

						Console.WriteLine("{0} {1}", eta, averageError);
						etaCell.Value = eta;

						errorCell.Value = averageError;

						eta += 0.05;
					}

				}
				

				var binaryData = xlPackage.GetAsByteArray();
				File.WriteAllBytes(@"C:\Nai\Nai.TaskOne.xlsx", binaryData);
			}
			Console.WriteLine("Done;");
			Console.ReadKey();
		}
	}
}
