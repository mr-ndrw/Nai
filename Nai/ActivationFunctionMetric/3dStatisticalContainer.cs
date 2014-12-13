/*	
 *	Project Name:	Nai Project - Neural Network.
 *	Author:			Andrzej Torski
 *	Index:			s10415
 */

namespace ActivationFunctionMetric
{
	/// <summary>
	///		Container for a 2D array and a method calculate an average for each cell.
	/// </summary>
	//	TODO:	Change the name of the class for something more sensible and readable.
	public class _3DStatisticalContainer
	{
		private double[,] _errorContainer;

		public _3DStatisticalContainer(int numberOfAlphaSteps, int numberOfBetaSteps)
		{
			NumberOfAlphaRows = numberOfAlphaSteps;
			NumberOfBetaColumns = numberOfBetaSteps;

			_errorContainer = new double[numberOfBetaSteps, numberOfAlphaSteps];
		}


		public int NumberOfAlphaRows { get; set; }

		public int NumberOfBetaColumns { get; set; }

		public double this[int beta,int alpha]
		{
			get { return _errorContainer[beta, alpha]; }
			set { _errorContainer[beta, alpha] = value; }
		}

		public void CalculateAverageForEachCell(int numberOfRuns)
		{
			for (var i = 0; i < NumberOfBetaColumns; i++)
			{
				for (var j = 0; j < NumberOfAlphaRows; j++)
				{
					_errorContainer[i, j] = _errorContainer[i, j] / (double) numberOfRuns;
				}
			}
		}

	}
}
