namespace Demo
{
    internal class Student
    {
        private string firstName;
        private string lastName;
        private int age;
        private string city;

        public Student(string firstName, string lastName, int age, string city)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.city = city;
        }

        public string City { get; internal set; }
        public object FirstName { get; internal set; }
        public object LastName { get; internal set; }
        public object Age { get; internal set; }
    }
}