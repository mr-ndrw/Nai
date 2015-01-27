using System;
using System.IO;
using DataGatherer.Shared;
using Genetic;
using OfficeOpenXml;

namespace DataGatherer.Genetic
{
	public partial class BitAndCrossOverChanceAnalyticalDataGather
	{
		public void Evaluate()
		{
			//	We will perform 500 statistical runs to gather data.
			const int numberOfEvaluations = 500;

			GeneticStructure geneticAlgorithmStructure;

			var statContainer = new TwoDimensionalStatContainer(20, 20);

			const int startingBitMutationChanceStep = 1; //start from 0.05
			const int finalBitMutationChanceStep = 20; //finish on 1.0
			const double bitMutationChanceIncrease = 0.05; //increase each time by 0.05;

			const int startingCrossOverChanceStep = 1; //start from 0.05
			const int finalCrossOverChanceStep = 20; //finish on 1.0
			const double crossOverChanceIncrease = 0.05; //increase each time by 0.05;

			const int genomeLength = 13;
			const int populationSize = 40;
			const double expectedMaximumEvaluationResult = 30;	//	use this one.

			for (var currentEvaluationNumber = 0; currentEvaluationNumber < numberOfEvaluations; currentEvaluationNumber++)
			{
				Console.WriteLine("Current evaluation run: {0}", currentEvaluationNumber);
				for (var currentBitMutationStep = 1; currentBitMutationStep <= finalBitMutationChanceStep; currentBitMutationStep++)
				{
					var currentBitMutationChance = currentBitMutationStep * bitMutationChanceIncrease;
					for (var currentCrossOverChanceStep = 1; currentCrossOverChanceStep <= finalCrossOverChanceStep; currentCrossOverChanceStep++)
					{
						var currentCrossOverChance = currentCrossOverChanceStep * crossOverChanceIncrease;

						geneticAlgorithmStructure = AlgorithmStructureInitializer.CreateGeneticStructure(populationSize, genomeLength,
							expectedMaximumEvaluationResult, currentCrossOverChance, currentBitMutationChance);

						geneticAlgorithmStructure.Evolve();

						statContainer[currentBitMutationStep - 1, currentCrossOverChanceStep - 1] += geneticAlgorithmStructure.CurrentEpoch;

					}
				}
			}

			using (var xlPackage = new ExcelPackage())
			{
				xlPackage.Workbook.Properties.Author = "Andrzej Torski";
				xlPackage.Workbook.Properties.Title = "Nai.TaskOne";
				xlPackage.Workbook.Properties.Company = "Andrew Torski Artifical Computing";

				xlPackage.Workbook.Worksheets.Add("Data");

				var workSheet = xlPackage.Workbook.Worksheets[1];

				workSheet.Name = "Data";

				for (var currentBitMutationStep = 1; currentBitMutationStep <= finalBitMutationChanceStep; currentBitMutationStep++)
				{
					for (var currentCrossOverChanceStep = 1; currentCrossOverChanceStep <= finalCrossOverChanceStep; currentCrossOverChanceStep++)
					{
						var cell = workSheet.Cells[currentBitMutationStep, currentCrossOverChanceStep];
						cell.Value = statContainer[currentBitMutationStep - 1, currentCrossOverChanceStep - 1];
					}
				}
				var binaryData = xlPackage.GetAsByteArray();
				File.WriteAllBytes(@"C:\Nai\BitAndCrossoverData.xlsx", binaryData);
			}
			Console.WriteLine("Done");
			Console.ReadKey();
		}
	}
}
