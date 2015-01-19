using System.Collections.Generic;

namespace Shared.GraphRelated
{
	/// <summary>
	///		Represents a vertex identified by string literal.
	/// </summary>
	public class Vertex
	{
		/// <summary>
		///		Initializes the object with a string label.
		/// </summary>
		/// <param name="label">
		///		Label for this vertex.
		/// </param>
		public Vertex(string label)
		{
			this.Label = label;
			this.ConnectedVertices = new List<Vertex>();
			this.Edges = new List<Edge>();
		}

		/// <summary>
		///		Unique label for this vertex.
		/// </summary>
		public string Label { get; private set; }

		/// <summary>
		///		Collection of connected vertices.
		/// </summary>
		public List<Vertex> ConnectedVertices { get; private set; }

		/// <summary>
		///		Collection of edges connected to this vertex.
		/// </summary>
		public List<Edge> Edges { get; private set; }

	}
}
