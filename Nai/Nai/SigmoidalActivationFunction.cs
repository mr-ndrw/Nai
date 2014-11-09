using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace en.AndrewTorski.Nai.TaskOne
{
	/// <summary>
	///		Represents a function of the following form. f(s) = 1 / (1 + e^(-s))
	/// </summary>
	public class SigmoidalActivationFunction : IActivationFunction
	{
		/// <summary>
		///		Alpha parameter.
		/// </summary>
		public double Alpha { get; set; }

		/// <summary>
		///		Beta parameter.
		/// </summary>
		public double Beta { get; set; }

		/// <summary>
		///		Initializes an object of function with default(equal to 1) parameters.
		/// </summary>
		public SigmoidalActivationFunction()
			:this(1.0, 1.0)
		{
			
		}

		/// <summary>
		///		Initializes an object of function with given parameters.
		/// </summary>
		/// <param name="alpha">
		///		Value of alpha.
		/// </param>
		/// <param name="beta">
		///		Value of beta.
		/// </param>
		public SigmoidalActivationFunction(double alpha, double beta)
		{
			Alpha = alpha;
			Beta = beta;
		}

		/***************************************************************
		 * Function has the following form:
		 *			1
		 * f(s) = ---------
		 *			     -a(s + b)
		 *			1 + e
		 *	
		 *	Or if the indentation has nulled our attempt above.
		 *	
		 *		f(s) = 1 / (1 + e^(-a(s + b))
		 *		
		 * Where a is alpha and b is beta respectievly.
		 **************************************************************/

		/// <summary>
		///		Takes the weighted arithmetic mean and calculates the response based on the underlying function.
		/// </summary>
		/// <returns>
		///		Calculated response.
		/// </returns>
		public double Evaluate(double weightedArithmeticMean)
		{
			//	Math.Exp returns e raised to the specified power.
			return 1/(1 + Math.Exp(-Alpha*(weightedArithmeticMean + Beta)));
		}

		/// <summary>
		///		Evaluates the first derivative of the function for the given parameter.
		/// </summary>
		/// <returns>
		///		Result of the evaluation
		/// </returns>
		/// TODO: Explain in comment why the derivative has taken on the following(more simplified though) form.
		public double EvaluateFirstDerivative(double parameterX)
		{
			return Evaluate(parameterX)*(1 - Evaluate(parameterX));
		}
	}
}
