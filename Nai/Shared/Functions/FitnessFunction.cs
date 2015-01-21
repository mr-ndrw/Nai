using System.Linq;
using Shared.Bases;
using Shared.GraphRelated;
using Shared.InterfacesAndBases;

namespace Shared.Functions
{
	/// <summary>
	///		Provides an algorithm for evaluation of a single instance of a candidate solution.		
	/// </summary>
	public class FitnessFunction : IFitnessFunction
	{
		public FitnessFunction(Graph graph)
		{
			this.Graph = graph;
		}

		public Graph Graph { get; private set; }

		/// <summary>
		///		Evaluates the solution candidate and assigns a value to it.
		/// </summary>
		/// <param name="solutionCandidate">
		///		Solution to evaluate.
		/// </param>
		/// <returns>
		///		The value that was assigned to the candidate.
		/// </returns>
		public double EvaluateSolution(CandidateSolution solutionCandidate)
		{
			//	Basic premises and terms:
			//	Rational solution	-	Solution that meets the criteria of being a vertex cover - minimal or not.
			//	Irrational soltion	-	Solution that doesn't meet above criteria i.e. is not a vertex cover.
			//	Feasible solutions	-	A set of mixed rational and irrational solutions.	
			//	Irrational solutions are assigned a value of 0.0.
			//	Rational solutions are assigned a value of 1 divided by the number of vertices present in the solution,
			//	meaning that solutions with less vertices will be evaluated as superior to those with higher number of vertices.
			if (!this.IsRational(solutionCandidate))
			{
				solutionCandidate.EvaluationResult = 0.0;
				return 0.0;
			}

			var numberOfVerticesPresent = solutionCandidate.Solution.Count(vertex => vertex == true);

			return solutionCandidate.EvaluationResult = 1 / (double) numberOfVerticesPresent;
		}

		/// <summary>
		///		Checks whether the solution for it's rationality.
		/// </summary>
		/// <param name="candidateSolution"></param>
		/// <returns></returns>
		private bool IsRational(CandidateSolution candidateSolution)
		{
			var presentEdgesInTheSolution = new bool[this.Graph.Edges.Count];//all will be false during creation.
			//	Iterate through all vertices proposed by the candidate solution
			//	and mark true in above array edges present in the Graph.
			for (var i = 0; i < candidateSolution.Solution.Count(); i++)
			{
				if (!candidateSolution.Solution.ElementAt(i)) continue;
				var vrtx = this.Graph.Vertices[i];
				//	iterate through vertex's edges
				foreach (var edge in vrtx.Edges)
				{
					//	get the label of the edge
					var label = edge.Label;
					var index = 0;
					//	get the index in the array of this labeled edge, this 'should' always assign a value to index.
					for (var j = 0; j < this.Graph.Edges.Count; j++)
					{
						if (this.Graph.Edges[j].Label != label) continue;
						index = j;
						break;
					}
					presentEdgesInTheSolution[index] = true;
				}
				//	If at any point, it turns out that all edges are present in the solution, then return true.
				if (presentEdgesInTheSolution.All(b => b))
					return true;
			}
			//	In the end if not every edge is present in the solution - return false.
			return false;
		}
	}
}
