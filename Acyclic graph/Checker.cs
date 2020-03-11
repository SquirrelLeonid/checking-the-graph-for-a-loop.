using System.Collections.Generic;

namespace Acyclic_graph
{
    public static class Checker
    {
        public static bool CheckInputData(List<string> input)
        {
            if (input == null)
                return false;

            if (input.Count <= 1)
                return false;

            if (!int.TryParse(input[0], out var vertexCount))
                return false;

            if (input.Count - 1 != vertexCount)
                return false;

            for (int i = 1; i < input.Count; i++)
            {
                string[] row = input[i].Split();
                if (row.Length != vertexCount)
                    return false;
            }
            return true;
        }
    }
}
