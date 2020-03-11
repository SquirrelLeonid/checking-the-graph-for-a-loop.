using System;
using System.Collections.Generic;
using System.IO;

namespace Acyclic_graph
{
    public static class FileWorker
    {
        
        private static string CWD = Directory.GetCurrentDirectory();
        private const string InputFileName = "/in.txt";

        public static void WriteFile(string result)
        {
            using (var fsStream = new FileStream(Path.Combine(CWD, "out.txt"), FileMode.OpenOrCreate))
            {
                byte[] output = System.Text.Encoding.Default.GetBytes(result);
                fsStream.Write(output,0,output.Length);
            }

            Console.WriteLine("Результат сохранен в файл out.txt");
        }

        public static List<string> ReadFile()
        {
            string line;
            List<string> input = new List<string>();
            try
            {
                using (var streamReader = new StreamReader(CWD + InputFileName, System.Text.Encoding.Default))
                {
                    while ((line = streamReader.ReadLine()) != null)
                        input.Add(line);
                }
            }
            catch (FileNotFoundException exception)
            {
                return null;
            }
            return input;
        }
    }
}
