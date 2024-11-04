using System.Text;

List<int> numbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int divider = int.Parse(Console.ReadLine());

Predicate<int> isDividetNumbers = x => x % divider == 0;
numbers.Reverse();
numbers.RemoveAll(isDividetNumbers);

foreach (int number in numbers)
{
    Console.Write($"{number} ");
}