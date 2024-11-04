using System;

namespace _09._Fruit_or_Vegeta
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            if (name == "banana"|| name=="apple"|| name=="kiwi"|| name=="cherry"||name=="lemon"|| name=="grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (name=="tomato"|| name=="cucumber"|| name=="pepper"||name=="carrot")
            {
                Console.WriteLine("vegetable");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
