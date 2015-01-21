using System;
using Shared.InterfacesAndBases;

namespace SimulatedAnnealing
{
	/// <summary>
	///		Basically decreases the temperature.
	/// </summary>
	/// <remarks>
	///		For slower decrease use larger values.
	/// </remarks>
	public class BasicTemperatureFunction : ITemperatureFunction
	{
		/// <summary>
		///		Initializes the object with a real value between 0.0 and 1.0.
		/// </summary>
		/// <param name="decreaseingParameter">
		///		Double value between 0.0 and 1.0. For slower decrease use larger values.
		/// </param>
		public BasicTemperatureFunction(double decreaseingParameter)
		{
			if(decreaseingParameter < 0.0 || decreaseingParameter > 1.0) throw new ArgumentException("This value has exceeded [0.0, 1.0] range.");
			this.DecreaseingParameter = decreaseingParameter;
		}

		/// <summary>
		///		Double value expressed between 0.0 and 1.0.
		///		For slower decrease use larger values.
		/// </summary>
		public double DecreaseingParameter { get; private set; }

		/// <summary>
		///		Calculates the new temperature based on the current temperature.
		/// </summary>
		/// <param name="currentTemperature">
		///		Temperature of the algorithm.
		/// </param>
		/// <returns>
		///		Returns new temperature.
		/// </returns>
		public double CalculateNewTemperature(double currentTemperature)
		{
			//	For slower decrease use larger values.
			return currentTemperature * this.DecreaseingParameter;
		}
	}
}
