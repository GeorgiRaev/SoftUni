using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Student_Academy
{
    class Student
    {
        public Student(string name)
        {
            Grades = new List<decimal>();
            Name = name;
        }

        public string Name { get; set; }

        public List<decimal> Grades { get; set; }

        public override string ToString()
        {

            return $"{Name} -> {Grades.Average():F2}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> students = new Dictionary<string, Student>();

            int strudentsCount = int.Parse(Console.ReadLine());

            string studentName;
            decimal grade;

            for (int i = 0; i < strudentsCount; i++)
            {
                studentName = Console.ReadLine();
                grade = decimal.Parse(Console.ReadLine());

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new Student(studentName));
                }

                students[studentName].Grades.Add(grade);
            }

            IEnumerable<KeyValuePair<string, Student>> filteredStudents = students.Where(g => g.Value.Grades.Average() >= 4.50m);

            foreach (KeyValuePair<string, Student> pair in filteredStudents)
            {
                Console.WriteLine($"{pair.Value}");
            }
        }
    }
}
