using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGatherer.Shared;
using NUnit.Framework;
using Shared.GraphRelated;

namespace Tests.Shared
{
	[TestFixture]
	public class AlgorithmStructureInitializerGraphTest
	{
		private Graph graph;

		[TestFixtureSetUp]
		public void Setup()
		{
			this.graph = AlgorithmStructureInitializer.GraphInitializer();
		}

		public bool CheckIfVertexIsConnectedWithGivenEdges(Graph checkedGraph, string vertexLabel, params string[] edgesLabels)
		{
			//	Find the vertex.
			var vertex = checkedGraph.Vertices.Find(vrtx => vrtx.Label == vertexLabel);

			//	Fidn the edges.

			var vertexEdgesExpectedNumber = vertex.Edges.Count;
			var foundEdgesCount = 0;

			foreach (var edge in vertex.Edges)
			{
				for (var j = 0;  j < edgesLabels.Count(); j++)
				{
					if (edge.Label == edgesLabels[j])
					{
						foundEdgesCount++;
					}
				}
			}

			return foundEdgesCount == vertexEdgesExpectedNumber;
		}

		[Test]
		public void CheckIfCheckingMethodIsCorrect()
		{
			//	Arrange.
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

			var g1 = new Graph(vertexList, edgeList);

			//	Very simple configuration
			//		  1
			//		a - b
			//	   2|	|3
			//		c -	d
			//		  4
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(g1, "a", "1", "2"), Is.True);
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(g1, "b", "1", "3"), Is.True);
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(g1, "c", "2", "4"), Is.True);
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(g1, "d", "3", "4"), Is.True);
		}

		[Test]
		public void CheckIfVertex_A_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "A", "5", "9"));
		}
		[Test]
		public void CheckIfVertex_B_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "B", "1", "2", "3"));
		}

		[Test]
		public void CheckIfVertex_C_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "C", "1", "4"));
		}

		[Test]
		public void CheckIfVertex_D_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "D", "2", "6", "7", "12"));
		}

		[Test]
		public void CheckIfVertex_E_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "E", "4", "5", "6", "11", "10"));
		}

		[Test]
		public void CheckIfVertex_F_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "F", "3", "7", "8", "13"));
		}

		[Test]
		public void CheckIfVertex_G_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "G", "8"));
		}

		[Test]
		public void CheckIfVertex_H_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "H", "9", "15", "14", "10"));
		}

		[Test]
		public void CheckIfVertex_I_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "I", "14", "11", "12", "16"));
		}

		[Test]
		public void CheckIfVertex_J_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "J", "17", "16", "13", "20", "19"));
		}

		[Test]
		public void CheckIfVertex_K_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "K", "15", "17", "18"));
		}

		[Test]
		public void CheckIfVertex_L_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "L", "20"));
		}

		[Test]
		public void CheckIfVertex_M_IsConnectedCorrectly()
		{
			//	Arrange
			//	Act
			//	All done in fixture set up

			//	Assert.
			//	A is connected to E by edge5
			Assert.That(CheckIfVertexIsConnectedWithGivenEdges(graph, "M", "18", "19"));
		}
	}
}
