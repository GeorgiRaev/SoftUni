using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string barcode = Console.ReadLine();

            if (IsValidBarcode(barcode))
            {
                string productGroup = GetProductGroup(barcode);
                Console.WriteLine($"Product group: {productGroup}");
            }
            else
            {
                Console.WriteLine("Invalid barcode");
            }
        }
    }
    static bool IsValidBarcode(string barcode)
    {
        string pattern = @"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+";
        return Regex.IsMatch(barcode, pattern);
    }
    static string GetProductGroup(string barcode)
    {
        string digitsPattern = @"\d";
        string productGroup = "";
        foreach (Match match in Regex.Matches(barcode, digitsPattern))
        {
            productGroup += match.Value;
        }
        return productGroup == "" ? "00" : productGroup;
    }
}
