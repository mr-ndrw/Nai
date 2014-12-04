/*	
 *	Project Name:	Nai Project - Neural Network.
 *	Author:			Andrzej Torski
 *	Index:			s10415
 */


using System;
using System.Collections.Generic;
using System.Linq;


namespace Excel
{
	/// <summary>
	///		Simple container for a 2-D Array.
	/// </summary>
	public class AveragePerEtaPerRunContainer
	{
		private readonly int _numberOfRuns;

		public double[,] AverageErrors { get; set; }

		public AveragePerEtaPerRunContainer(int numberOfRuns)
		{
			_numberOfRuns = numberOfRuns;
			AverageErrors = new double[20, numberOfRuns];
		}

		public List<Double> CalculateAveragePerEta()
		{
			var result = new List<Double>();
			var d = 0.0;

			for (var i = 0; i < 20; i++)
			{
				for (var j = 0; j < _numberOfRuns; j++)
				{
					d += (double) AverageErrors.GetValue(i, j);
				}

				result.Add(d/(double)_numberOfRuns);
				d = 0.0;
			}

			return result;
		}





	}
}
