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
			this.Connections = new List<Vertex>();
			this.Label = label;
		}

		public string Label { get; private set; }

		public List<Vertex> Connections { get; private set; }

		/// <summary>
		///		Connects a Vertex to this.
		/// </summary>
		/// <param name="vertex">
		///		Vertex to connect.
		/// </param>
		public void ConnectTo(Vertex vertex)
		{
			this.Connections.Add(vertex);
			vertex.Connections.Add(this);
		}
	}
}
