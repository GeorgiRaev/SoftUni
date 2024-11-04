using System.Diagnostics;

int n = 10000;//int.Parse(Console.ReadLine());
Stopwatch watch = Stopwatch.StartNew();
List<int> list = new List<int>();
for (int i = 0; i < n; i++)
{
    list.Insert(0, i);
}
watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds);

watch = Stopwatch.StartNew();
LinkedList<int> linkedList = new LinkedList<int>();
for (int i = 0;i < n; i++)
{
    linkedList.AddFirst(i);
}
watch.Stop();
Console.WriteLine(watch.ElapsedMilliseconds);