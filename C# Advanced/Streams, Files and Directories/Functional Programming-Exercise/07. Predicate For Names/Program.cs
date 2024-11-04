int n = int.Parse(Console.ReadLine());

List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Predicate<string> filterNames = name => name.Length <= n;

foreach (string name in names.Where(name => filterNames(name)))
{
    Console.WriteLine(name);
}