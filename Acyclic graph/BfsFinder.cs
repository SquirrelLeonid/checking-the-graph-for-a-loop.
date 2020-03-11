using System.Collections.Generic;

namespace Acyclic_graph
{
    public static class BfsFinder
    {
        private static int Length;
        private static int[] Trace;
        private static bool[,] Graph;
        private static Queue<int> Queue;
        private static bool[] IsVertexesVisited;

        private static void InitializeData(bool[,] graph)
        {
            Graph = graph;
            Length = Graph.GetLength(0);
            Trace = new int[Length];
            Queue = new Queue<int>();
            IsVertexesVisited = new bool[Length];

            Queue.Enqueue(0);
        }

        public static List<int> FindCycle(bool[,] graph)
        {
            InitializeData(graph);
            Length = graph.GetLength(0);
            while (true)
            {
                Queue<int> cycleRoots = FindRoots();
                if (cycleRoots != null)
                    return WriteCycle(cycleRoots);

                bool hasMoreComponents = false;
                for (int vertex = 0; vertex < IsVertexesVisited.Length; vertex++)
                {
                    if (!IsVertexesVisited[vertex])
                    {
                        hasMoreComponents = true;
                        Queue = new Queue<int>();
                        Queue.Enqueue(vertex);
                    }
                }

                if (!hasMoreComponents)
                    return null;
            }
        }

        private static Queue<int> FindRoots()
        { ;

            MarkFirstComponentVertex();

            while (Queue.Count != 0)
            {
                int currentVertex = Queue.Dequeue();
                int lastVertex = Trace[currentVertex];

                for (int neighbor = 0; neighbor < Length; neighbor++)
                {
                    if (neighbor == lastVertex || neighbor == currentVertex)
                        continue;
                    if (Graph[currentVertex,neighbor])
                    {
                        if (!IsVertexesVisited[neighbor])
                            MarkNextVertex(neighbor, currentVertex);
                        else if (Queue.Contains(neighbor))
                            return WriteCycleRoots(neighbor, currentVertex);
                    }
                }
            }
            return null;
        }

        private static void MarkFirstComponentVertex()
        {
            int lastVertex = -1;
            int currentVertex = Queue.Peek();
            IsVertexesVisited[currentVertex] = true;
            Trace[currentVertex] = lastVertex;
        }

        private static void MarkNextVertex(int neighbor, int currentVertex)
        {
            Queue.Enqueue(neighbor);
            IsVertexesVisited[neighbor] = true;
            Trace[neighbor] = currentVertex;
        }

        private static Queue<int> WriteCycleRoots(int neighbor, int currentVertex)
        {
            Queue<int> cycleRoots = new Queue<int>();
            cycleRoots.Enqueue(neighbor);
            cycleRoots.Enqueue(currentVertex);
            return cycleRoots;
        }

        private static List<int> WriteCycle(Queue<int> cycleRoots)
        {
            List<int> vertexesInCycle = new List<int>();
            while (true)
            {
                int vertex = cycleRoots.Dequeue();
                if (!vertexesInCycle.Contains(vertex+1))
                {
                    vertexesInCycle.Add(vertex+1);
                    cycleRoots.Enqueue(Trace[vertex]);
                }
                else
                {
                    vertexesInCycle.Sort();
                    return vertexesInCycle;
                }
            }
        }
    }
}