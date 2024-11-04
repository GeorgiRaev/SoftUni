using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            int startIndex = input.IndexOf('>') + 1;
            int endIndex = input.LastIndexOf('<');

            if (IsValidPassword(input, startIndex, endIndex))
            {
                string password = input.Substring(startIndex, endIndex - startIndex);
                password = password.Replace("|", "");
                Console.WriteLine($"Password: " + password);
            }
            else
            {
                Console.WriteLine("Try another password!");
            }
        }
    }

    static bool IsValidPassword(string input, int startIdx, int endIdx)
    {
        if (startIdx <= 0 || endIdx <= 0 || endIdx <= startIdx)
            return false;

        string startSymbols = input.Substring(0, startIdx - 1);
        string endSymbols = input.Substring(endIdx + 1);

        if (startSymbols.Length != endSymbols.Length)
            return false;

        for (int i = 0; i < startSymbols.Length; i++)
        {
            if (startSymbols[i] != endSymbols[i])
                return false;
        }

        string password = input.Substring(startIdx, endIdx - startIdx);
        string[] groups = password.Split('|');

        if (groups.Length != 4)
            return false;

        foreach (string group in groups)
        {
            if (group.Length != 3)
                return false;
        }
        
        return true;
    }
}
