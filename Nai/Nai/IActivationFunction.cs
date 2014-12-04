/*	
 *	Project Name:	Nai Project - Neural Network.
 *	Author:			Andrzej Torski
 *	Index:			s10415
 */

namespace en.AndrewTorski.Nai.TaskOne
{
	/// <summary>
	///		Defines a contract for all inherting classes to realize.
	/// </summary>
	public interface IActivationFunction
	{
		/// <summary>
		///		Evalutaes the function for the given parameter.
		/// </summary>
		/// <returns>
		///		Result of the evaluation.
		/// </returns>
		double Evaluate(double parameterX);

		/// <summary>
		///		Evaluates the first derivative of the function for the given parameter.
		/// </summary>
		/// <returns>
		///		Result of the evaluation
		/// </returns>
		double EvaluateFirstDerivative(double parameterX);


		double Alpha { get; set; }
		double Beta { get; set; }
	}
}
