using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PlatformerFileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            int m;
            int n;
            int k;
            int lines;
            string file;

            Console.Out.Write("Enter input width: ");
            input = Console.In.ReadLine();
            m = Convert.ToInt32(input);

            Console.Out.WriteLine();
            Console.Out.Write("Enter input height: ");
            input = Console.In.ReadLine();
            n = Convert.ToInt32(input);

            Console.Out.WriteLine();
            Console.Out.Write("Enter number of hidden nodes: ");
            input = Console.In.ReadLine();
            k = Convert.ToInt32(input);

            Console.Out.WriteLine();
            Console.Out.Write("Enter number of generations: ");
            input = Console.In.ReadLine();
            lines = Convert.ToInt32(input);

            Console.Out.WriteLine();
            Console.Out.Write("Enter file destination: ");
            file = Console.In.ReadLine();
            Console.Out.WriteLine();

            StreamWriter sw = new StreamWriter(new FileStream(file, FileMode.Create));
            
            sw.Write(GenerateString(m, n, k, lines));

            sw.Close();

            Console.Out.WriteLine("File has been written to " + file);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }

        public static string GenerateString(int m, int n, int k, int l)
        {
            string output = "";
            Random r = new Random();
            double w;
            int p;

            //header
            output += m + "\n";
            output += n + "\n";
            output += k + "\n";
            output += l + "\n";

            int numWeights = (m * n * k) + (3 * k);

            for (int i = 0; i < l; i++)
            {
                //each of k nodes gets m * n weights
                //then each of 3 output nodes gets k weights
                //all weights are between -1 and 1
                //GO

                for (int j = 0; j < numWeights; j++)
                {
                    w = r.NextDouble();
                    p = r.Next(2);
                    if (p == 0) w = -w;

                    output += w;

                    if (j < numWeights - 1) output += ',';
                    
                }
                output += "\n";
            }

            return output;
        }
    }
}
