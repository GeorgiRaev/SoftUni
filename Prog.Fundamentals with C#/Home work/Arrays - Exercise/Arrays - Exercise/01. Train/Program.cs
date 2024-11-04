using System;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] passengers = new int[n];
            int sumOfPassenger = 0;

            for (int i = 0; i < passengers.Length; i++)
            {
                passengers[i] = int.Parse(Console.ReadLine());
                sumOfPassenger += passengers[i];
            }
            for (int i = 0; i < passengers.Length; i++)
            {
                Console.Write(passengers[i] + " ");
                
            }
            Console.WriteLine();
            Console.WriteLine(sumOfPassenger);
        }
    }
}
