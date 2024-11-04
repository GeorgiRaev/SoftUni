using System;

namespace _06._Vowels_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int num = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == 'a')
                {
                    num += 1;
                }
                else if (text[i] =='e')
                {
                    num += 2;
                }
                else if (text[i]=='i')
                {
                    num += 3;
                }
                else if (text[i]=='o')
                {
                    num += 4;
                }
                else if (text[i]=='u')
                {
                    num += 5;
                }
            }
            Console.WriteLine(num);
        }
    }
}
