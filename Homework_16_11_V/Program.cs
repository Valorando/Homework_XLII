using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_16_11_V
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1,5,4,7,1,15,2,1,16,87,32,3,2,9};
            int[] arr2 = new int[arr.Length];
            int index = 0;
            int[] arr3 = new int[index];

            Console.WriteLine("Начальный массив:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Task t1 = new Task(() =>
            {
                Console.WriteLine("Без повторений:");
                for (int  i = 0;  i < arr.Length;  i++)
                {
                    if (Array.IndexOf(arr2, arr[i]) == -1)
                    {
                        arr2[index++] = arr[i];
                    }
                }

                arr3 = new int[index];
                Array.Copy(arr2, arr3, index);

                for (int i = 0; i < arr3.Length; i++)
                {
                    Console.WriteLine(arr3[i]);
                }
            });

            Task t2 = t1.ContinueWith(t =>
            {
                Array.Sort(arr3);
                Console.WriteLine();
                Console.WriteLine("Сортированый массив:");
                for (int i = 0; i < arr3.Length; i++)
                {
                    Console.WriteLine(arr3[i]);
                }
            });

            Task t3 = t2.ContinueWith(t =>
            {
                Console.WriteLine();
                Console.Write("Введите число для поиска: ");
                int value = Convert.ToInt32(Console.ReadLine());

                int left = 0;
                int right = arr3.Length - 1;
                bool found = false;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;

                    if (arr3[mid] == value)
                    {
                        found = true;
                        break;
                    }
                    else if (arr3[mid] < value)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }

                if (found)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Элемент найден.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Элемент не найден.");
                }


            });

            t1.Start();
            t1.Wait();
            t2.Wait();
            t3.Wait();
            Console.Read();
        }
    }
}
