using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Genetic;
using NUnit.Framework;
using Shared.Bases;
using Shared.Functions;
using Shared.GraphRelated;
using Shared.InterfacesAndBases;

namespace Tests.Shared
{
	[TestFixture]
	public class FitnessFunctionTest
	{
		private IFitnessFunction function;
		private Graph graph;

		[TestFixtureSetUp]
		public void SetUp()
		{
			//	Very simple configuration
			//		  1
			//		a - b
			//	   2|	|3
			//		c -	d
			//		  4

			Vertex vertexA = new Vertex("a"),
			       vertexB = new Vertex("b"),
			       vertexC = new Vertex("c"),
			       vertexD = new Vertex("d");

			var vertexList = new List<Vertex>
			                 {
				                 vertexA,
				                 vertexB,
				                 vertexC,
				                 vertexD
			                 };

			Edge edge1 = new Edge(vertexA, vertexB, "1"),
			     edge2 = new Edge(vertexA, vertexC, "2"),
			     edge3 = new Edge(vertexD, vertexB, "3"),
			     edge4 = new Edge(vertexC, vertexD, "4");

			var edgeList = new List<Edge>
			               {
				               edge1,
				               edge2,
				               edge3,
				               edge4
			               };

			this.graph = new Graph(vertexList, edgeList);

			this.function = new FitnessFunction(this.graph);
		}

		[Test]
		public void GenomeTest()
		{
			var genome = new CandidateSolution(new bool[4] {true, true, true, true});
		}

		[Test]
		public void IrrationalSolutionsExpect0()
		{
			//	Arrange.
			//	Graph prearranged in TestFixtureSetUp.
			var irrationalSolutions = new List<CandidateSolution>
			                          {
				                          new CandidateSolution(new bool[4] {false, false, false, false}), //	no vertices
				                          new CandidateSolution(new bool[4] {true, false, false, false}), //	a only
				                          new CandidateSolution(new bool[4] {false, true, false, false}), //	b only
				                          new CandidateSolution(new bool[4] {false, false, true, false}), //	c only
				                          new CandidateSolution(new bool[4] {false, false, false, true}), //	d only
				                          new CandidateSolution(new bool[4] {true, true, false, false}), //	ab
				                          new CandidateSolution(new bool[4] {true, false, true, false}), //	ac
				                          new CandidateSolution(new bool[4] {false, false, true, true}), //	cd
				                          new CandidateSolution(new bool[4] {false, true, false, true}) //	bd
			                          };

			//	Act
			irrationalSolutions.ForEach(solution => this.function.EvaluateSolution(solution));
			//irrationalSolutions.ForEach(solution => System.Diagnostics.Debug.Print("{0}\n", solution.EvaluationResult));


			//	Assert
			//	Each one should have EvaluationResult set to 0.
			Assert.That(irrationalSolutions.All(solution => solution.EvaluationResult == 0.0));
		}

		[Test]
		public void RationalSolutionsExpectOneOverTwo()
		{
			//	Arrange
			//	Graph prearranged in FixtureSetUp
			var rationalSolutions = new List<CandidateSolution>
			                        {
				                        new CandidateSolution(new bool[4] {true, false, false, true}), //ad
				                        new CandidateSolution(new bool[4] {false, true, true, false}) //cb
			                        };

			//	Act
			rationalSolutions.ForEach(solution => this.function.EvaluateSolution(solution));
			rationalSolutions.ForEach(solution => Debug.Print("{0}\n", solution.EvaluationResult));

			//	Assert
			//	Each one should have Evaluation result set to 0.5.
			Assert.That(rationalSolutions.All(solution => solution.EvaluationResult == 0.5));
		}

		[Test]
		public void RationaNonOptimalSolutionsExpectOneOverThree()
		{
			//	Arrange
			//	Graph prearranged in FixtureSetUp
			var rationalNonOptimalSolutions = new List<CandidateSolution>
			                                  {
				                                  new CandidateSolution(new bool[4] {true, true, true, false}),
				                                  new CandidateSolution(new bool[4] {true, true, false, true}),
				                                  new CandidateSolution(new bool[4] {true, false, true, true}),
				                                  new CandidateSolution(new bool[4] {false, true, true, true})
			                                  };

			//	Act
			rationalNonOptimalSolutions.ForEach(solution => this.function.EvaluateSolution(solution));
			rationalNonOptimalSolutions.ForEach(solution => Debug.Print("{0}\n", solution.EvaluationResult));

			//	Arrange
			Assert.That(rationalNonOptimalSolutions.All(solution => solution.EvaluationResult == (double) 1 / (double) 3));
		}
	}
}