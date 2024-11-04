using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Students

{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int numberStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberStudents; i++)
            {
                string studentInfo = Console.ReadLine();
                string[] currentStudent = studentInfo
                    .Split(" ")
                    .ToArray();
                string firtsName = currentStudent[0];
                string lastName = currentStudent[1];
                double grade = double.Parse(currentStudent[2]);
                Student student = new Student(firtsName, lastName, grade);
                students.Add(student);
            }
            students = students.OrderByDescending(student => student.Grade).ToList();
            double[] grades = students.Select(student => student.Grade).ToArray();
            for (int i = 0; i < numberStudents; i++)
            {
                Console.WriteLine(students[i]);
            }
        }
    }
}
