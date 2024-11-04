using System;

namespace _04._Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double holidayPrice = double.Parse(Console.ReadLine());
            int numberPuzzle = int.Parse(Console.ReadLine());
            int numberTalkingDolls = int.Parse(Console.ReadLine());
            int numberTeddyBears = int.Parse(Console.ReadLine());
            int numberMinions = int.Parse(Console.ReadLine());
            int numberTrucks = int.Parse(Console.ReadLine());
            double puzzle = 2.60;
            double talkingDolls = 3;
            double teddyBear = 4.10;
            double minion = 8.20;
            double truck = 2;
            int numberToy = numberPuzzle + numberTalkingDolls + numberTeddyBears + numberMinions + numberTrucks;
            double symOfToys = (numberPuzzle * puzzle) + (numberTalkingDolls * talkingDolls) + (numberTeddyBears * teddyBear) + (numberMinions * minion) + (numberTrucks * truck);
            if (numberToy>=50)
            {

            }
        }
    }
}
