using System.Collections.Generic;
using Genetic;
using GeneticOperators.Crossovers;
using GeneticOperators.ElitistStrategies;
using GeneticOperators.Mutators;
using GeneticOperators.Selectors;
using GeneticOperators.Terminators;
using Shared.Bases;
using Shared.Functions;
using Shared.GraphRelated;
using Shared.InterfacesAndBases;
using SimulatedAnnealing;

namespace DataGatherer.Shared
{
	public static class AlgorithmStructureInitializer
	{
		public static Graph Graph = GraphInitializer();

		// TODO: GRAPH!!!!!!!!!
		public static GeneticStructure CreateGeneticStructure(int populationCount, int genomeLength, double expectedOptimalResult, double crossOverChance, double bitMutationChance)
		{
			IFitnessFunction fitnessFunction = new FitnessFunction(Graph);
			ITerminator terminator = new BestSolutionTerminator(expectedOptimalResult);
			Recombinator crossoverFunction = new OnePointCrossover(crossOverChance);
			IMutator mutatorFunction = new BitMutator(bitMutationChance);
			Selector selector = new RouletteSelector(fitnessFunction);
			IElitistStrategy elitistStrategy = new BestSolutionElitist();

			var geneticStructure = new GeneticStructure(populationCount, genomeLength, fitnessFunction, selector, mutatorFunction,
				crossoverFunction, elitistStrategy, terminator);

			return geneticStructure;
		}

		public static SimulatedAnnealer CreateSimulatedAnnealer(int solutionLength, double startingTemperature, double finalTemperature, double temperatureDrop)
		{
			var function = new FitnessFunction(Graph);
			var probabilityFunction = new BoltzmannProbabilityFunction(function);
			var temperatureFunction = new BasicTemperatureFunction(temperatureDrop);
			var neighbourFunction = new NeighbourFunction();
			var simulatedAnnealer = new SimulatedAnnealer(solutionLength, function, probabilityFunction, temperatureFunction, neighbourFunction, startingTemperature, finalTemperature);

			return simulatedAnnealer;
		}

		public static Graph GraphInitializer()
		{
			//	Please refer to Graph.jpg for visual representation of the below.

			#region Create vertices from A to M
			Vertex	vertexA = new Vertex("A"),
					vertexB = new Vertex("B"),
					vertexC = new Vertex("C"),
					vertexD = new Vertex("D"),
					vertexE = new Vertex("E"),
					vertexF = new Vertex("F"),
					vertexG = new Vertex("G"),
					vertexH = new Vertex("H"),
					vertexI = new Vertex("I"),
					vertexJ = new Vertex("J"),
					vertexK = new Vertex("K"),
					vertexL = new Vertex("L"),
					vertexM = new Vertex("M");
			#endregion
			#region Create edges from 1 to 20
			Edge edge1 = new Edge("1"),
			     edge2 = new Edge("2"),
			     edge3 = new Edge("3"),
			     edge4 = new Edge("4"),
			     edge5 = new Edge("5"),
			     edge6 = new Edge("6"),
			     edge7 = new Edge("7"),
			     edge8 = new Edge("8"),
			     edge9 = new Edge("9"),
			     edge10 = new Edge("10"),
			     edge11 = new Edge("11"),
			     edge12 = new Edge("12"),
			     edge13 = new Edge("13"),
			     edge14 = new Edge("14"),
			     edge15 = new Edge("15"),
			     edge16 = new Edge("16"),
			     edge17 = new Edge("17"),
			     edge18 = new Edge("18"),
				 edge19 = new Edge("19"),
				 edge20 = new Edge("20");
			#endregion
			#region Connect vertices with edges
			edge1.Connect(vertexC, vertexB);
			edge2.Connect(vertexD, vertexB);
			edge3.Connect(vertexF, vertexB);
			edge4.Connect(vertexC, vertexE);
			edge5.Connect(vertexA, vertexE);
			edge6.Connect(vertexE, vertexD);
			edge7.Connect(vertexD, vertexF);
			edge8.Connect(vertexF, vertexG);
			edge9.Connect(vertexA, vertexH);
			edge10.Connect(vertexE, vertexH);
			edge11.Connect(vertexE, vertexI);
			edge12.Connect(vertexD, vertexI);
			edge13.Connect(vertexF, vertexJ);
			edge14.Connect(vertexH, vertexI);
			edge15.Connect(vertexH, vertexK);
			edge16.Connect(vertexI, vertexJ);
			edge17.Connect(vertexK, vertexJ);
			edge18.Connect(vertexK, vertexM);
			edge19.Connect(vertexM, vertexJ);
			edge20.Connect(vertexL, vertexJ);
			#endregion
			#region List initialization
			var vertices = new List<Vertex>()
			               {
							   vertexA,
							   vertexB,
							   vertexC,
							   vertexD,
							   vertexE,
							   vertexF,
							   vertexG,
							   vertexH,
							   vertexI,
							   vertexJ,
							   vertexK,
							   vertexL,
							   vertexM
			               };
			var edges = new List<Edge>()
			            {
							edge1 ,
							edge2 ,
							edge3 ,
							edge4 ,
							edge5 ,
							edge6 ,
							edge7 ,
							edge8 ,
							edge9 ,
							edge10,
							edge11,
							edge12,
							edge13,
							edge14,
							edge15,
							edge16,
							edge17,
							edge18,
							edge19,
							edge20
			            }; 
			#endregion

			var graph = new Graph(vertices, edges);
			return graph;
		}

	}
}
