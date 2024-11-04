using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, uint> resourseMap = new Dictionary<string, uint>();
            string resourse;
            uint quantity;
            while ((resourse = Console.ReadLine()) != "stop")
            {
                quantity = uint.Parse(Console.ReadLine());
                
                if (!resourseMap.ContainsKey(resourse))
                {
                    resourseMap.Add(resourse, 0);
                }
                resourseMap[resourse] += quantity;
            }
            foreach (KeyValuePair<string,uint> pair in resourseMap)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}
