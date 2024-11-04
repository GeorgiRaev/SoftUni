using System;

namespace _06._The_Most_Powerful_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string mostPowerfulWord = string.Empty;
            int wordCounter = 0;
            bool firstLetterIsVowell = false;
            double sumOfMostPowerWord = int.MinValue;
            while (word != "End of words")
            {
                double currentScoreWord = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (i == 0)
                    {
                        if (word[i] == 'a' || word[i] == 'e' || word[i] == 'i' || word[i] == 'o' || word[i] == 'u' || word[i] == 'y' ||
                        word[i] == 'A' || word[i] == 'E' || word[i] == 'I' || word[i] == 'O' || word[i] == 'U' || word[i] == 'Y')
                        {
                            firstLetterIsVowell = true;
                        }
                    }
                    wordCounter++;
                    currentScoreWord += word[i];
                }
                if (firstLetterIsVowell == true)
                {
                    currentScoreWord *= wordCounter;
                }
                else
                {
                    currentScoreWord = Math.Floor(currentScoreWord /= wordCounter);
                }
                if (currentScoreWord >= sumOfMostPowerWord)
                {
                    sumOfMostPowerWord = currentScoreWord;
                    mostPowerfulWord = word;
                }
                word = Console.ReadLine();
                wordCounter = 0;
            }
            Console.WriteLine($"The most powerful word is {mostPowerfulWord} - {sumOfMostPowerWord}");
        }
    }
}
