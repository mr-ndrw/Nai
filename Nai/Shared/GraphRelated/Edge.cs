namespace Shared.GraphRelated
{
	/// <summary>
	///		Represent a connection between two vertices.
	/// </summary>
	public class Edge
	{
		/// <summary>
		///		Creates an edge using two vertices which it should connect.
		/// </summary>
		public Edge(Vertex firstVertex, Vertex secondVertex)
		{
			this.Connect(firstVertex, secondVertex);
		}

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
	}
}
