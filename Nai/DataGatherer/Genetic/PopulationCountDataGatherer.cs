using System;
using System.IO;
using DataGatherer.Shared;
using Genetic;
using OfficeOpenXml;

namespace DataGatherer.Genetic
{
	public class PopulationCountDataGatherer
	{
		public void Evaluate()
		{
			//	We will perform 500 statistical runs to gather data.
			const int numberOfEvaluations = 1000;

			GeneticStructure geneticAlgorithmStructure;

			const double bitMutationChance = 0.87;
			const double crossOverChange = 0.95;
			const int genomeLength = 13;
			const double expectedMaximumEvaluationResult = 30;	//	use this one.

			const int startingPopulation = 20;
			const int finalPopulation = 2000;
			const int populationIncrease = 20;
			var statContainer = new double[(finalPopulation - startingPopulation )/populationIncrease];

			for (var currentEvaluationNumber = 0; currentEvaluationNumber < numberOfEvaluations; currentEvaluationNumber++)
			{
				Console.WriteLine("Current evaluation run: {0}", currentEvaluationNumber);
				for (var currentPopulationCountStep = 1; currentPopulationCountStep <= (finalPopulation - startingPopulation )/populationIncrease; currentPopulationCountStep++)
				{
					var currentPopulation = currentPopulationCountStep * populationIncrease;
					geneticAlgorithmStructure = AlgorithmStructureInitializer.CreateGeneticStructure(currentPopulation, genomeLength,
						expectedMaximumEvaluationResult, crossOverChange, bitMutationChance);
					geneticAlgorithmStructure.Evolve();

					statContainer[currentPopulationCountStep-1] += geneticAlgorithmStructure.CurrentEpoch;
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

				for (var currentBitMutationStep = 1; currentBitMutationStep <= (finalPopulation - startingPopulation) / populationIncrease; currentBitMutationStep++)
				{
					var cell = workSheet.Cells[currentBitMutationStep, 1];
					cell.Value = statContainer[currentBitMutationStep - 1];

				}
				var binaryData = xlPackage.GetAsByteArray();
				File.WriteAllBytes(@"C:\Nai\PopulationCountData.xlsx", binaryData);
			}
			Console.WriteLine("Done");
			Console.ReadKey();
		}
	}
}
