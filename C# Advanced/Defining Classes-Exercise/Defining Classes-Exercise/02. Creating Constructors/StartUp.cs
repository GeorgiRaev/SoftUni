namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        Person gosho = new();
        
        Console.WriteLine($"{gosho.Name} is {gosho.Age} years old");
    }
}