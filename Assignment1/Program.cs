using System;
using System.Collections;

namespace Assignment1 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Calculating grades and class average of 10 students.");
            var grades = new Tests[10];
            var classSum = 0.0;
            for (var i = 0; i < grades.Length; i++) {
                grades[i] = new Tests();
                Console.Write("Enter first name: ");
                grades[i].FirstName = Console.ReadLine();
                Console.Write("Enter last name: ");
                grades[i].LastName = Console.ReadLine();
                for (var j = 0; j < 5; j++) {
                    Console.Write($"Enter {grades[i].FirstName} {grades[i].LastName}'s grade for Test {j + 1}: ");
                    grades[i].TestScore[j] = Convert.ToDouble(Console.ReadLine());
                }
            }
            Console.WriteLine("First name: Last name: Test 1: Test 2: Test 3: Test 4: Test 5: Average: Letter Grade:");
            foreach (Tests student in grades) {
                student.CalculateAverage();
                Console.WriteLine(student);
                classSum += student.Average;
            }
            Console.WriteLine($"The Class Average = {classSum / 10:f2}");
        }
    }

    class Scores : IEnumerable {
        private double[] _arr = new double[5] {-1.0, -1.0, -1.0, -1.0, -1.0};

        public int Length { get => _arr.Length; }
        public IEnumerator GetEnumerator() { return _arr.GetEnumerator(); }
        public double this[int i] {
            get => _arr[i];
            set => _arr[i] = value;
        }
    }

    class Tests {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public Scores TestScore {get; set;}
        public double Average {get; private set;}
        public char FinalGrade {get; private set;}

        public Tests() {
            FirstName = "";
            LastName = "";
            TestScore = new Scores();
            Average = -1.0;
            FinalGrade = 'I';
        }

        public void CalculateAverage() {
            var sum = 0.0;
            var items = 0;
            foreach (double score in TestScore) {
                if (score >= 0.0) {
                    sum += score;
                    items++;
                }
            }
            if (items != 0) {
                Average = sum / items;
            }
            if (items == TestScore.Length) {
                DetermineFinalGrade();
            }
        }

        public void DetermineFinalGrade() {
            if (Average >= 90.0) {
                FinalGrade = 'A';
            } else if (Average >= 80.0) {
                FinalGrade = 'B';
            } else if (Average >= 70.0) {
                FinalGrade = 'C';
            } else if (Average >= 60.0) {
                FinalGrade = 'D';
            } else {
                FinalGrade = 'F';
            }
        }

        public override string ToString() {
            return $"{FirstName,-11} {LastName,-10} {TestScore[0],6:f2}  {TestScore[1],6:f2}  {TestScore[2],6:f2}  {TestScore[3],6:f2}  {TestScore[4],6:f2}  {Average,7:f2}  {FinalGrade}";
        }
    }
}
