using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGatherer.Shared;
using Genetic;
using OfficeOpenXml;
using Shared.Utils;

namespace DataGatherer
{
	public class BitMutationChanceDataGatherer
	{
		private readonly string _path;
		private readonly string _fileName;

		public BitMutationChanceDataGatherer(string path, string fileName)
		{
			this._path = path;
			this._fileName = fileName;
		}

		public void Evaluate()
		{
			//	We will perform 500 statistical runs to gather data.
			const int numberOfEvaluations = 1000;

			GeneticStructure geneticAlgorithmStructure;
			//	We will check every 0.05 value going up from 0.05 to 1.0. therefore we will heave 20 readings for each step.
			var statContainer = new StatContainer(20);


			var startingBitMutationChance = 0.05;
			var finalBitMutationChance = 1.0;
			const int startingBitMutationChanceStep = 1; //start from 0.05
			const int finalBitMutationChanceStep = 20; //finish on 1.0
			const double bitMutationChanceIncrease = 0.05; //increase each time by 0.05;
			const int genomeLength = 13;
			const int populationSize = 80;
			const double crossOverChance = 0.35;
			const double expectedMaximumEvaluationResult = 30;	//	use this one.

			for (var i = 1; i <= finalBitMutationChanceStep; i++)
			{
				statContainer.ListOfPairValues.Add(new Pair<double>(i * 0.05, 0.0));
			}

			for (var currentEvaluationRun = 0; currentEvaluationRun < numberOfEvaluations; currentEvaluationRun++)
			{
				//Console.WriteLine("Current run: {0} out of {1}", currentEvaluationRun, numberOfEvaluations);
				//double currentBitMutationChance = startingBitMutationChance;
				for (var currentMutationStep = startingBitMutationChanceStep; currentMutationStep <= finalBitMutationChanceStep; currentMutationStep++)
				{
					var currentBitMutationChance = currentMutationStep*bitMutationChanceIncrease;
					//	Update the structure so that it will initialize the GeneticStructure with the value of the expected
					//	maximum evaluation of result, which most likely will be 30-31.
					//Console.WriteLine("Current mutation chance: {0}", currentBitMutationChance);
					geneticAlgorithmStructure = AlgorithmStructureInitializer.CreateGeneticStructure(populationSize, genomeLength,
						expectedMaximumEvaluationResult, crossOverChance, currentBitMutationChance);

					var bestSolutionResult = geneticAlgorithmStructure.Evolve().EvaluationResult;
					var numberOfEpochsWhenBestSolutionWasFound = geneticAlgorithmStructure.CurrentEpoch;

					//Console.WriteLine("Number of epcohs when best was found: {0}, it's result: {1}", numberOfEpochsWhenBestSolutionWasFound, bestSolutionResult);
					statContainer.ListOfPairValues[currentMutationStep - 1].Y += numberOfEpochsWhenBestSolutionWasFound;
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

				for (var i = 1; i <= finalBitMutationChanceStep; i++)
				{
					var pair = statContainer.ListOfPairValues[i-1];
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
