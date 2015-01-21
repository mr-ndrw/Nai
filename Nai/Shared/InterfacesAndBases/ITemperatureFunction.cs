using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shared.InterfacesAndBases
{
	/// <summary>
	///		Defines a contract for classes which want to implement SA's temperature function.
	/// </summary>
	public interface ITemperatureFunction
	{
		/// <summary>
		///		Calculates the new temperature based on the current temperature.
		/// </summary>
		/// <param name="currentTemperature">
		/// 
		/// </param>
		/// <returns>
		///		Returns new temperature.
		/// </returns>
		double CalculateNewTemperature(double currentTemperature);
	}
}
