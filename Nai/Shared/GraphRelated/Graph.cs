using System.Collections.Generic;
using System.Linq;

namespace Shared.GraphRelated
{
	/// <summary>
	///		Contains vertices and exposes method to operate on them.
	/// </summary>
	public class Graph
	{
		/// <summary>
		///		Initializes the object with a collection of vertices.
		/// </summary>
		/// <param name="vertices">
		///		List to be included in the Graph.
		/// </param>
		public Graph(List<Vertex> vertices)
		{
			this.Vertices = vertices;
		}

		/// <summary>
		///		Collection of vertices.
		/// </summary>
		public List<Vertex> Vertices { get; private set; }

		/// <summary>
		///		Returns the vertex from the list by the specified number.
		/// </summary>
		/// <param name="i">
		///		Index within the list.
		/// </param>
		/// <returns>
		///		Found vertex.
		/// </returns>
		public Vertex this[int i]
		{
			get { return this.Vertices[i]; }
		}

		/// <summary>
		///		Returns the vertex from the list by the specified label.
		/// </summary>
		/// <param name="label">
		///		Label of the vertex that is searched for..
		/// </param>
		/// <returns>
		///		Found vertex.
		/// </returns>
		public Vertex this[string label]
		{
			get { return this.Vertices.First(vertex => vertex.Label.CompareTo(label) == 0); }
		}
	}
}
