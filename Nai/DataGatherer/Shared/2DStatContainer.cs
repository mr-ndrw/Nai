/*	
 *	Project Name:	Nai Project - GA vs SA.
 *	Author:			Andrzej Torski
 *	Index:			s10415
 */

namespace DataGatherer.Shared
{
	/// <summary>
	///		Container for a 2D array and a method to calculate an average for each cell.
	/// </summary>
	public class TwoDimensionalStatContainer
	{
		private double[,] _errorContainer;

		public TwoDimensionalStatContainer(int numberOfRows, int numberOfColumns)
		{
			this.NumberOfRows = numberOfRows;
			this.NumberOfColumns = numberOfColumns;

			this._errorContainer = new double[numberOfColumns, numberOfRows];
		}


		public int NumberOfRows { get; set; }

		public int NumberOfColumns { get; set; }

		/// <summary>
		///		Hello
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		public double this[int x, int y]
		{
			get { return this._errorContainer[x, y]; }
			set { this._errorContainer[x, y] = value; }
		}

		public void CalculateAverageForEachCell(int numberToDivideBy)
		{
			for (var i = 0; i < this.NumberOfColumns; i++)
			{
				for (var j = 0; j < this.NumberOfRows; j++)
				{
					this._errorContainer[i, j] = this._errorContainer[i, j] / (double)numberToDivideBy;
				}
			}
		}

	}
}
