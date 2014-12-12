using System.Collections.Generic;
using System.Linq;
using OfficeOpenXml;

namespace en.AndrewTorski.Nai.TaskOne
{
	/// <summary>
	///		Static class which exposes a function to create a binary Excel file with all the data 
	/// </summary>
	public static class NetworkPrinter
	{
		public static byte[] RetrieveNeuralData(Network network)
		{
			byte[] binaryData;
			using (var xlPackage = new ExcelPackage())
			{
				xlPackage.Workbook.Properties.Author = "Andrzej Torski";
				xlPackage.Workbook.Properties.Title = "Nai.TaskOne";
				xlPackage.Workbook.Properties.Company = "Andrew Torski Artifical Computing";

				xlPackage.Workbook.Worksheets.Add("Data");

				var workSheet = xlPackage.Workbook.Worksheets[1];

				workSheet.Name = "Data";

				var outputList = new List<Neuron> {network.OutputNeuron};

				ParseDataFromNeuronToWorksheet(workSheet, network.InputNeurons, 1);
				ParseDataFromNeuronToWorksheet(workSheet, network.HiddenNeurons, 1 + network.InputNeurons.Count);
				ParseDataFromNeuronToWorksheet(workSheet, outputList, 1 + network.InputNeurons.Count + network.HiddenNeurons.Count);


				binaryData = xlPackage.GetAsByteArray();
			}
			return binaryData;
			//	Parse this data consecutively layer by layer, neuron by neuron to Excel Sheet
		}

		public static void ParseDataFromNeuronToWorksheet(ExcelWorksheet workSheet, IEnumerable<Neuron> neurons, int startsOnColumn)
		{
			ExcelRange cell;
			foreach (var neuron in neurons)
			{
				cell = workSheet.Cells[1, startsOnColumn];
				cell.Value = neuron.Label;

				for (var i = 0; i < neuron.NumberOfInputs + 1; i++)
				{
					cell = workSheet.Cells[i + 2, startsOnColumn];
					cell.Value = neuron.InputWeights[i];
				}
				startsOnColumn++;
			}
		}

		private static List<double> RetrieveWeightsFrom(Neuron neuron)
		{
			return neuron.InputWeights.ToList();
		}
	}
}
