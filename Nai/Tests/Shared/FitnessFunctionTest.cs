using System;
using System.Collections.Generic;
using System.Linq;
using Genetic;
using NUnit.Framework;
using Shared.Functions;
using Shared.GraphRelated;
using Shared.InterfacesAndBases;

namespace Tests.Shared
{
	[TestFixture]
	public class FitnessFunctionTest
	{
		private Graph graph;
		private IFitnessFunction function;

		[TestFixtureSetUp]
		public void SetUp()
		{
			//	Very simple configuration
			//		  1
			//		a - b
			//	   2|	|3
			//		c -	d
			//		  4

			Vertex	vertexA = new Vertex("a"),
					vertexB = new Vertex("b"),
					vertexC = new Vertex("c"),
					vertexD = new Vertex("d");

			var vertexList = new List<Vertex>()
			                 {
								 vertexA, vertexB, vertexC, vertexD
			                 };

			Edge	edge1 = new Edge(vertexA, vertexB, "1"),
					edge2 = new Edge(vertexA, vertexC, "2"),
					edge3 = new Edge(vertexD, vertexB, "3"),
					edge4 = new Edge(vertexC, vertexD, "4");

			var edgeList = new List<Edge>()
			               {
				               edge1,
				               edge2,
				               edge3,
				               edge4
			               };

			this.graph = new Graph(vertexList, edgeList);

			function = new FitnessFunction(graph);
		}

		[Test]
		public void GenomeTest()
		{
			var genome = new Genome(new bool[4]{true, true, true, true});
		}

		[Test]
		public void IrrationalSolutionsExpect0()
		{
			//	Arrange.
			//	Graph prearranged in TestFixtureSetUp.
			var irrationalSolutions = new List<Genome>()
			{
				new Genome(new bool[4]{false, false, false, false}),//	no vertices
				new Genome(new bool[4]{true, false, false, false}),	//	a only
				new Genome(new bool[4]{false, true, false, false}),	//	b only
				new Genome(new bool[4]{false, false, true, false}),	//	c only
				new Genome(new bool[4]{false, false, false, true}),	//	d only
				new Genome(new bool[4]{true, true, false, false}),	//	ab
				new Genome(new bool[4]{true, false, true, false}),	//	ac
				new Genome(new bool[4]{false, false, true, true}),	//	cd
				new Genome(new bool[4]{false, true, false, true})	//	bd
			};

			//	Act
			irrationalSolutions.ForEach(solution => function.EvaluateGenome(solution));
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
			var rationalSolutions = new List<Genome>()
			                      {
									  new Genome(new bool[4]{true, false, false, true}),	//ad
									  new Genome(new bool[4]{false, true, true, false})		//cb
			                      };

			//	Act
			rationalSolutions.ForEach(solution => function.EvaluateGenome(solution));
			rationalSolutions.ForEach(solution => System.Diagnostics.Debug.Print("{0}\n", solution.EvaluationResult));

			//	Assert
			//	Each one should have Evaluation result set to 0.5.
			Assert.That(rationalSolutions.All(solution => solution.EvaluationResult == 0.5));
		}

		[Test]
		public void RationaNonOptimalSolutionsExpectOneOverThree()
		{
			//	Arrange
			//	Graph prearranged in FixtureSetUp
			var rationalNonOptimalSolutions = new List<Genome>()
			                                  {
												  new Genome(new bool[4]{true, true, true, false}),
												  new Genome(new bool[4]{true, true, false, true}),
												  new Genome(new bool[4]{true, false, true, true}),
												  new Genome(new bool[4]{false, true, true, true}),
			                                  };

			//	Act
			rationalNonOptimalSolutions.ForEach(solution => function.EvaluateGenome(solution));
			rationalNonOptimalSolutions.ForEach(solution => System.Diagnostics.Debug.Print("{0}\n", solution.EvaluationResult));

			//	Arrange
			Assert.That(rationalNonOptimalSolutions.All(solution => solution.EvaluationResult == (double)1/(double)3));
		}
	}
}
