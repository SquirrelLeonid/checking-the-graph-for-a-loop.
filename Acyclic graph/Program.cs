using System;
using System.Collections.Generic;

namespace Acyclic_graph
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> input = FileWorker.ReadFile();
            if (!Checker.CheckInputData(input))
            {
                ReportBug("Файл in.txt не найден или исходные данные некорректны");
                return;
            }

            bool[,] graph = GraphConverter.CreateGraph(input);

            string findMethod = AskFindMethod();
            if (findMethod == null)
            {
                ReportBug("Неверное название алгоритма. Попробуйте снова");
                return;
            }

            List<int> vertexesInCycle;

            if (findMethod.CompareTo("DFS") == 0)
                vertexesInCycle = DfsFinder.FindCycle(graph);
            else
                vertexesInCycle = BfsFinder.FindCycle(graph);

            string result;
            if (vertexesInCycle == null)
                result = "A";
            else
            {
                result = "N\r\n";
                vertexesInCycle.ForEach(vertex => result += vertex + " ");
                result = result.Trim();
            }

            FileWorker.WriteFile(result);
        }

        private static string AskFindMethod()
        {
            Console.WriteLine("Какой алгоритм использовать для поиска цикла? [DFS/BFS]");
            string answer = Console.ReadLine();
            if (answer != null)
            {
                answer = answer.ToUpper();
                if (answer.CompareTo("DFS") == 0 || answer.CompareTo("BFS") == 0)
                    return answer;
            }

            return null;
        }

        private static void ReportBug(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Чтобы завершить работу нажмите любую клавишу");
            Console.ReadKey();
        }
    }
}
