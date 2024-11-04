using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = string.Empty;
            string inputPassword = string.Empty;
            for (int i = userName.Length - 1; i >= 0; i--)
            {
                password += userName[i];
            }
            for (int j = 0; j <= 4; j++)
            {
                inputPassword = Console.ReadLine();
                if (password == inputPassword)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    break;
                }
                if (j == 3 && password != inputPassword)
                {
                    Console.WriteLine($"User {userName} blocked!");
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }
                
            }
        }
    }
}
