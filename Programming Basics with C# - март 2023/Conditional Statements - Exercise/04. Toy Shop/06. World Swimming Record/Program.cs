using System;

namespace _06._World_Swimming_Record
{
	class Program
	{
		static void Main(string[] args)
		{
			double worldRecord = double.Parse(Console.ReadLine());
			double distanceInMeters = double.Parse(Console.ReadLine());
			double distanceSwimPerSecond = double.Parse(Console.ReadLine());
			double ivansResult = distanceInMeters * distanceSwimPerSecond;
			double delay = Math.Floor(distanceInMeters / 15);
			double totalDelay = delay * 12.5;
			double totalTime = ivansResult + totalDelay;
			if (worldRecord > totalTime)
			{
				Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
			}
			else
			{
				Console.WriteLine($"No, he failed! He was {totalTime - worldRecord:F2} seconds slower.");
			}
		}
	}
}
