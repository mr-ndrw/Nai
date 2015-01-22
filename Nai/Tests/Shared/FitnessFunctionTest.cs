using System.Collections.Generic;
using System.Linq;
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
		public void InfeasibleSolutions()
		{
			//	Arrange.
			var totallyInfeasibleSolution = new CandidateSolution(new bool[4] {false, false, false, false}); //	no vertices
			var oneVertexSolutions = new List<CandidateSolution>
			                         {
				                         new CandidateSolution(new bool[4] {true, false, false, false}), //	a only
				                         new CandidateSolution(new bool[4] {false, true, false, false}), //	b only
				                         new CandidateSolution(new bool[4] {false, false, true, false}), //	c only
				                         new CandidateSolution(new bool[4] {false, false, false, true}) //	d only
			                         };

			var twoVertexInfeasibleSolution = new List<CandidateSolution>
			                                  {
				                                  new CandidateSolution(new bool[4] {true, true, false, false}), //	ab
				                                  new CandidateSolution(new bool[4] {true, false, true, false}), //	ac
				                                  new CandidateSolution(new bool[4] {false, false, true, true}), //	cd
				                                  new CandidateSolution(new bool[4] {false, true, false, true}) //	bd
			                                  };

			//	Act.

			function.EvaluateSolution(totallyInfeasibleSolution);
			oneVertexSolutions.ForEach(solution => function.EvaluateSolution(solution));
			twoVertexInfeasibleSolution.ForEach(solution => function.EvaluateSolution(solution));

			//	Assert.

			Assert.That(totallyInfeasibleSolution.EvaluationResult, Is.EqualTo(4.0));
			Assert.That(oneVertexSolutions.All(solution => solution.EvaluationResult == 5.0), Is.True);
			Assert.That(twoVertexInfeasibleSolution.All(solution => solution.EvaluationResult == 5.0), Is.True);

		}
	}
}