using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Participant
    {
        public string Name { get; set; }
        public uint Distance { get; set; }
    }
    class Program
    {
        static void Main()
        {
            List<Participant> participants = new List<Participant>();
            string[] namesArr = Console.ReadLine().Split(", ");

            for (int i = 0; i < namesArr.Length; i++)
            {
                Participant participant = new Participant();
                participant.Name = namesArr[i];
                participant.Distance = 0;
                participants.Add(participant);
            }

            string lettersPattern = @"[A-Za-z]";
            string digitPattern = @"\d";

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of race")
            {
                StringBuilder name = new StringBuilder();

                foreach (Match match in Regex.Matches(command, lettersPattern))
                {
                    name.Append(match.Value);
                }
                uint distance = 0;
                foreach (Match match in Regex.Matches(command, digitPattern))
                {
                    distance += uint.Parse(match.Value);
                }

                Participant foundParticipant = participants.FirstOrDefault(p => p.Name == name.ToString());
                if (foundParticipant != null)
                {
                    foundParticipant.Distance += distance;
                }
            }
            List<Participant> OrderedParticipants = participants
                .OrderByDescending(participant => participant.Distance)
                .Take(3)
                .ToList();

            Console.WriteLine($"1st place: {OrderedParticipants[0].Name}");
            Console.WriteLine($"2nd place: {OrderedParticipants[1].Name}");
            Console.WriteLine($"3rd place: {OrderedParticipants[2].Name}");
        }
    }
}
