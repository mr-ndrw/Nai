using System;
using System.IO;
using DataGatherer.Shared;
using Genetic;
using OfficeOpenXml;
using Shared.Utils;

namespace DataGatherer
{
	public class CrossOverChanceDataGatherer
	{
		public void Evaluate()
		{
			//	We will perform 500 statistical runs to gather data.
			const int numberOfEvaluations = 100;

			GeneticStructure geneticAlgorithmStructure;
			//	We will check every 0.05 value going up from 0.05 to 1.0. therefore we will heave 20 readings for each step.
			var statContainer = new StatContainer(20);

			const int startingCrossOverChanceStep = 1; //start from 0.05
			const int finalCrossOverChanceStep = 20; //finish on 1.0
			const double crossOverChanceIncrease = 0.05; //increase each time by 0.05;
			const int genomeLength = 13;
			const int populationSize = 80;
			const int numberOfEpochs = 500;
			const double bitMutationChance = 0.35;
			const double expectedMaximumEvaluationResult = 30;	//	use this one.

			for (var i = 1; i <= finalCrossOverChanceStep; i++)
			{
				statContainer.ListOfPairValues.Add(new Pair<double>(i * 0.05, 0.0));
			}

			for (var currentEvaluationRun = 0; currentEvaluationRun < numberOfEvaluations; currentEvaluationRun++)
			{
				Console.WriteLine("Current run: {0} out of {1}", currentEvaluationRun, numberOfEvaluations);
				//double currentBitMutationChance = startingBitMutationChance;
				for (var currentCrossOverChanceStep = startingCrossOverChanceStep; currentCrossOverChanceStep <= finalCrossOverChanceStep; currentCrossOverChanceStep++)
				{
					var currentCrossOverChance = currentCrossOverChanceStep * crossOverChanceIncrease;
					//	Update the structure so that it will initialize the GeneticStructure with the value of the expected
					//	maximum evaluation of result, which most likely will be 30-31.
					geneticAlgorithmStructure = AlgorithmStructureInitializer.CreateGeneticStructure(populationSize, genomeLength,
						numberOfEpochs, bitMutationChance, currentCrossOverChance);

					geneticAlgorithmStructure.Evolve();
					var numberOfEpochsWhenBestSolutionWasFound = geneticAlgorithmStructure.CurrentEpoch;

					Console.WriteLine("Result: {0}", numberOfEpochsWhenBestSolutionWasFound);
					statContainer.ListOfPairValues[currentCrossOverChanceStep - 1].Y += numberOfEpochsWhenBestSolutionWasFound;
				}
			}

			//			foreach (var pair in statContainer.ListOfPairValues)
			//			{
			//				pair.Y /= numberOfEpochs;
			//			}

			using (var xlPackage = new ExcelPackage())
			{
				xlPackage.Workbook.Properties.Author = "Andrzej Torski";
				xlPackage.Workbook.Properties.Title = "Nai.TaskOne";
				xlPackage.Workbook.Properties.Company = "Andrew Torski Artifical Computing";

				xlPackage.Workbook.Worksheets.Add("Data");

				var workSheet = xlPackage.Workbook.Worksheets[1];

				workSheet.Name = "Data";

				for (var i = 1; i <= finalCrossOverChanceStep; i++)
				{
					var pair = statContainer.ListOfPairValues[i - 1];
					var bitMutationCell = workSheet.Cells[i, 1];
					var resultCell = workSheet.Cells[i, 2];

					bitMutationCell.Value = pair.X;
					resultCell.Value = pair.Y;
				}

				var binaryData = xlPackage.GetAsByteArray();
				File.WriteAllBytes(@"C:\Nai\BitMutationChance.xlsx", binaryData);
			}
			Console.WriteLine("Done");
			Console.ReadKey();
		}
	}
}
