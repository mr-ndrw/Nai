using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel
{
	public class StatisticalDataContainer
	{
		public StatisticalDataContainer(double [,] dataContainer, int row, int rowLength)
		{
			var list = ExtractListFromArray(dataContainer, row, rowLength);

			Median = ExtractMedian(list);

			Max = list.Max();
			Min = list.Min();

			StandardDeviation = CalculateStandardDeviation(list);

		}

		public double Max { get; set; }
		public double Min { get; set; }
		public double Median { get; set; }
		public double StandardDeviation { get; set; }


		private static List<Double> ExtractListFromArray(double[,] dataContainer, int row, int rowLength)
		{
			var listOfDoubles = new List<Double>();

			for (var i = 0; i < rowLength; i++)
			{
				listOfDoubles.Add(dataContainer[row, i]);
			}

			return listOfDoubles;
		}

		private static double ExtractMedian(List<Double> listOfDoubles)
		{
			listOfDoubles.Sort();

			var listSize = listOfDoubles.Count;
			var mid = listSize / 2;

			if (listSize % 2 == 0)
			{
				return (listOfDoubles[mid] + listOfDoubles[mid - 1]) / (double) 2;
			}

			return listOfDoubles[mid];
		}

		private static double CalculateStandardDeviation(List<Double> listOfDoubles)
		{
			var average = listOfDoubles.Average();

			var variance = listOfDoubles.Sum(t => Math.Pow((t - average), 2));

			variance /= listOfDoubles.Count;

			return Math.Sqrt(variance);
		}
	}
}
