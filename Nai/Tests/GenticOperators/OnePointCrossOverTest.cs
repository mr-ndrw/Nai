
using System.Linq;
using NUnit.Framework;
using Shared.Bases;
using GeneticOperators.Crossovers;
using Shared.Utils;

namespace Tests.GenticOperators
{
	[TestFixture]
	public class OnePointCrossOverTest
	{
		public OnePointCrossover OnePointCrossoverFunction;

		[TestFixtureSetUp]
		public void SetUp()
		{
			//	Set the crossover chance to 1.0 so that it will always splice and slice the solutions.
			this.OnePointCrossoverFunction = new OnePointCrossover(1.0);
		}

		[Test]
		public void TestOpcOnSolutionsOfLength4BySkipping2()
		{
			//	Arrange.
			//	Crossover function prearranged in 
			var solutionA = new CandidateSolution(new bool[4] {true, true, true, true});
			var solutionB = new CandidateSolution(new bool[4] { false, false, false, false });

			//	Act.
			this.OnePointCrossoverFunction.CrossoverForTestsOnly(new Pair<CandidateSolution>(solutionA, solutionB), 2);

			//	Assert
			//	that A's last two elements are false and that B's last two elements are true.
			var solutionALastTwoElements = solutionA.Solution.Skip(2);
			var solutionBLastTwoElements = solutionB.Solution.Skip(2);

			Assert.That(solutionALastTwoElements.All(b => !b));
			Assert.That(solutionBLastTwoElements.All(b => b));
		}
	}
}
