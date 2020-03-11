using System.Collections.Generic;

namespace Acyclic_graph
{
    public static class DfsFinder
    {
        private static int Length;

        public static List<int> FindCycle(bool[,] graph)
        {
            Length = graph.GetLength(0);
            List<int> cycle;
            bool[] isVertexVisited = new bool[graph.GetLength(0)];
            while (true)
            {
                bool hasMoreComponents = false;
                for (int vertex = 0; vertex < Length; vertex++)
                {
                    if (!isVertexVisited[vertex])
                    {
                        hasMoreComponents = true;
                        cycle = FindRoot(graph, vertex, isVertexVisited);
                        if (cycle != null)
                            return cycle;
                    }
                }

                if (!hasMoreComponents)
                    return null;
            }
        }

        private static List<int> FindRoot(bool[,] graph, int startVertex, bool[] isVertexVisited)
        {
            List<int> stack = new List<int>() { startVertex };
            while (stack.Count != 0)
            {
                int currentVertex = stack[stack.Count - 1];
                isVertexVisited[currentVertex ] = true;
                bool hasFreeNeighbor = false;

                for (int neighbor = 0; neighbor < Length; neighbor++)
                {
                    if (ShouldSkipVertex(stack, currentVertex, neighbor))
                        continue;
                    if (graph[currentVertex, neighbor])
                    {
                        if (stack.Contains(neighbor))
                            return WriteCycle(neighbor, stack);
                        if (!isVertexVisited[neighbor])
                        {
                            stack.Add(neighbor);
                            hasFreeNeighbor = true;
                            break;
                        }
                    }
                }
                if (hasFreeNeighbor)
                    continue;
                stack.RemoveAt(stack.Count - 1);
            }
            return null;
        }

        private static List<int> WriteCycle(int cycleRoot, List<int> stack)
        {
            List<int> cycle = new List<int>();
            stack.Reverse();
            foreach (int vertex in stack)
            {
                cycle.Add(vertex + 1);
                if (vertex == cycleRoot)
                    break;
            }
            cycle.Reverse();
            return cycle;
        }

        private static bool ShouldSkipVertex(List<int> stack, int currentVertex, int neighbor)
        {
            return neighbor == currentVertex || stack.Count > 1 && stack[stack.Count - 2] == neighbor;
        }
    }
}