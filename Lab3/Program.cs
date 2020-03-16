using System;

namespace Lab3 {
    class Program {
        static void Main(string[] args) {
            Person person = new Person("Paulie Person", "123 Normal Rd.", "555-555-5555", "paulie@example.com");
            Student student = new Student("Suzie Student", "123 Dorm Way", "555-555-5554", "suzie@example.com", "Sophomore");
            Employee employee = new Employee("Emanuel Employee", "123 Employment Ct.", "555-555-5553", "emanuel@example.com", "J 101", 100000.0, 2020, 01, 01);
            Faculty faculty = new Faculty("Felix Faculty", "123 Facilities Dr.", "555-555-5552", "felix@example.com", "I 101", 200000.0, 2019, 01, 01, 6, "Senior");
            Staff staff = new Staff("Sarah Staff", "123 Corperation Ln.", "555-555-5551", "sarah@example.com", "H 101", 300000.0, 2018, 01, 01, "Provhost");

            Console.WriteLine(person + Environment.NewLine + student + Environment.NewLine + employee + Environment.NewLine + faculty + Environment.NewLine + staff);
        }
    }

    class Person {
        private string Name {get; set;}
        private string Address {get; set;}
        private string PhoneNumber {get; set;}
        private string Email {get; set;}

        public Person(string name, string address, string phoneNumber, string email) {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override string ToString() {
            return $"{this.GetType().Name} info: Name = {Name}, Address = {Address}, PhoneNumber = {PhoneNumber}, Email = {Email}";
        }
    }

    class Student : Person {
        private string ClassStatus {get; set;}

        public Student(string name, string address, string phoneNumber, string email, string classStatus) : base(name, address, phoneNumber, email) {
            ClassStatus = classStatus;
        }

        public override string ToString() {
            return $"{base.ToString()}, ClassStatus = {ClassStatus}";
        }
    }

    class Employee : Person {
        private string Office {get; set;}
        private double Salary {get; set;}
        private int YearHired {get; set;}
        private int MonthHired {get; set;}
        private int DayHired {get; set;}

        public Employee(string name, string address, string phoneNumber, string email,
                        string office, double salary, int yearHired, int monthHired,
                        int dayHired) : base(name, address, phoneNumber, email) {
            Office = office;
            Salary = salary;
            YearHired = yearHired;
            MonthHired = monthHired;
            DayHired = dayHired;
        }

        public override string ToString() {
            return $"{base.ToString()}, Office = {Office}, Salary = {Salary}, HireDate = {YearHired}/{MonthHired}/{DayHired}";
        }
    }

    class Faculty : Employee {
        private int OfficeHours {get; set;}
        private string Rank {get; set;}

        public Faculty(string name, string address, string phoneNumber, string email,
                        string office, double salary, int yearHired, int monthHired,
                        int dayHired, int officeHours, string rank) : base(name, address, phoneNumber, email,
                                                                           office, salary, yearHired, monthHired,
                                                                           dayHired) {
            OfficeHours = officeHours;
            Rank = rank;
        }

        public override string ToString() {
            return $"{base.ToString()}, OfficeHours = {OfficeHours}, Rank = {Rank}";
        }
    }

    class Staff : Employee {
        private string Title {get; set;}

        public Staff(string name, string address, string phoneNumber, string email,
                        string office, double salary, int yearHired, int monthHired,
                        int dayHired, string title) : base(name, address, phoneNumber, email,
                                                           office, salary, yearHired, monthHired,
                                                           dayHired) {
            Title = title;
        }

        public override string ToString() {
            return $"{base.ToString()}, Title = {Title}";
        }
    }
}
