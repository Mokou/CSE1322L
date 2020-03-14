using System;

namespace pmcgoran_Lab1BClass {
    class Program {
        static void Main(string[] args) {
            Person person1 = new Person();
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();
            Person person2 = new Person(firstName, lastName);
            Console.WriteLine($"Default constructor name: {person1}");
            Console.WriteLine($"Your name: {person2}");
            person1.FirstName = "Aly";
            person2.LastName = "Sanchez";
            Console.WriteLine($"Modified names: {person1.FirstName} {person1.LastName} and {person2.FirstName} {person2.LastName}.");
        }
    }

    class Person {
        public string FirstName {get; set;}
        public string LastName {get; set;}

        public Person() {
            FirstName = "Bob";
            LastName = "Smith";
        }

        public Person(string FirstName, string LastName) {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }

        public override string ToString() {
            return $"{FirstName} {LastName}";
        }
    }
}
