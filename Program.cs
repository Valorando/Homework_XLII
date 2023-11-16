using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_16_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t1 = new Task(() => Console.WriteLine($"(Просто Task)Текущие дата и время: {DateTime.Now}"));
            t1.Start();
            Thread.Sleep(2000);

            Task t2 = Task.Factory.StartNew(() => Console.WriteLine($"(Task.Factory)Текущие дата и время: {DateTime.Now}"));
            Thread.Sleep(2000);

            Task t3 = Task.Run(() => Console.WriteLine($"(Task.Run)Текущие дата и время: {DateTime.Now}"));
        
            Console.Read();
        }
    }
}
