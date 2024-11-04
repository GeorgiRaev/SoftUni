using System.Collections.Generic;
using System.Text;

namespace BoxOfInteger;

public class Box<T>
{
    private List<T> items = new List<T>();

    public int Add(T item)
    {
        items.Add(item);
        return items.Count();
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        foreach (var item in items)
        {
            sb.AppendLine($"{typeof(T)}: {item}");
        }

        return sb.ToString().TrimEnd();
    }
}