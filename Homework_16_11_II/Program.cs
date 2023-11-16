using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_16_11_II
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(() =>
            {
                for (int i = 2; i < 1001; i++)
                {
                    int count = 0;

                    for (int j = 1; j <= i; j++)
                    {
                        if (i % j == 0)
                        {
                            count++;
                        }

                        if (count > 2)
                        {
                            break;
                        }
                    }

                    if (count == 2)
                    {
                        Console.WriteLine(i);
                    }
                }
                
            });

            t1.Start();
            t1.Wait();
            Console.Read();
        }
    }
}
