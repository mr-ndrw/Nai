using System;

namespace Shared.GraphRelated
{
	/// <summary>
	///		Represent a connection between two vertices.
	/// </summary>
	public class Edge : IEquatable<Edge>
	{
		///  <summary>
		/// 		Creates an edge using two vertices which it should connect.
		///  </summary>
		/// <param name="firstVertex"></param>
		/// <param name="secondVertex"></param>
		/// <param name="label"></param>
		public Edge(Vertex firstVertex, Vertex secondVertex, string label)
		{
			this.Label = label;
			this.Connect(firstVertex, secondVertex);
		}

		public Edge(string label)
		{
			this.Label = label;
		}

		/// <summary>
		///		Unique label of this edge.
		/// </summary>
		public string Label { get; private set; }

		/// <summary>
		///		First connected vertex.
		/// </summary>
		public Vertex FirstVertex { get; private set; }

		/// <summary>
		///		Second connected vertex.
		/// </summary>
		public Vertex SecondVertex { get; private set; }

		/// <summary>
		///		Connects two vertices using this edge.
		/// </summary>
		/// <param name="firstVertex">
		///		Vertex to connect.
		/// </param>
		/// <param name="secondVertex">
		///		Vertex to connect.
		/// </param>
		public void Connect(Vertex firstVertex, Vertex secondVertex)
		{
			this.FirstVertex = firstVertex;
			this.SecondVertex = secondVertex;

			firstVertex.Edges.Add(this);
			secondVertex.Edges.Add(this);
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
		/// </returns>
		/// <param name="other">An object to compare with this object.</param>
		public bool Equals(Edge other)
		{
			return other.Label == this.Label;
		}
	}
}
