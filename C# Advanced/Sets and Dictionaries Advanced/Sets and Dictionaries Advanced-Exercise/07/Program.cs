


Dictionary<int, int> numbersCount = new();

int count = int.Parse(Console.ReadLine());

for (int i = 0; i < count; i++)
{
    int number = int.Parse(Console.ReadLine());

	if (!numbersCount.ContainsKey(number))
	{
		numbersCount.Add(number, 0);
	}
	numbersCount[number]++;
}
int result = numbersCount.Single(n => n.Value % 2 == 0).Key;

Console.WriteLine(result);