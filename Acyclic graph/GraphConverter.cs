using System.Collections.Generic;

namespace Acyclic_graph
{
    public static class GraphConverter
    {
        public static bool[,] CreateGraph(List<string> input)
        {
            int length = input.Count - 1;
            bool[,] graph = new bool[length, length];
            for (int i = 1; i <= length; i++)
            {
                string[] row = input[i].Split();
                for (int j = 0; j < row.Length; j++)
                    if (row[j].CompareTo("1") == 0)
                        graph[i-1, j] = true;
            }
            return graph;
        }
    }
}
