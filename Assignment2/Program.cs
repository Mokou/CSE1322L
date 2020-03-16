using System;
using System.Collections.Generic;

namespace Program {
    class Program {
        static void Main(string[] args) {
            decimal aibudget, aiprice, pbudget;
            string aidest, aibrand, pdest;
            int airating;
            var pexpenses = new List<(string name, decimal cost)>();
            Console.Write("Please enter All-Inclusive Vacation’s budget: ");
            aibudget = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Please enter All-Inclusive Vacation’s destination: ");
            aidest = Console.ReadLine();
            Console.Write("Please enter All-Inclusive Vacation’s brand: ");
            aibrand = Console.ReadLine();
            Console.Write("Please enter All-Inclusive Vacation’s rating: ");
            airating = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter All-Inclusive Vacation’s price: ");
            aiprice = Convert.ToDecimal(Console.ReadLine());
            var ai = new AllInclusiveVacation(aibudget, aidest, aibrand, airating, aiprice);
            Console.WriteLine(ai);
            Console.WriteLine(ai.Budget());

            Console.Write("Please enter Piecemeal Vacation’s budget: ");
            pbudget = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Please enter Piecemeal Vacation’s destination: ");
            pdest = Console.ReadLine();
            var endLoop = false;
            while (!endLoop) {
                Console.Write("Please enter a Piecemeal Vacation’s item: ");
                var name = Console.ReadLine();
                Console.Write($"Please enter {name}'s cost: ");
                pexpenses.Add((name, Convert.ToDecimal(Console.ReadLine())));
                string k;
                do {
                    Console.Write("Have you finished entering all items [y/n]? ");
                    k = Console.ReadLine().ToLower();
                    if (k == "y") {
                        endLoop = true;
                    }
                } while (!(k == "y" || k == "n"));
            }
            var piece = new PiecemealVacation(pbudget, pdest, pexpenses);
            Console.WriteLine(piece);
            Console.WriteLine(piece.Budget());
        }
    }

    abstract class Vacation {
        protected decimal budget;
        protected string destination;

        public override string ToString() {
            return $"{this.GetType().Name} to {destination} with a budget of ${budget}";
        }

        public abstract string Budget();
    }

    class AllInclusiveVacation : Vacation {
        protected string brand;
        protected int rating;
        protected decimal price;

        public AllInclusiveVacation(decimal budget, string destination, string brand, int rating, decimal price) {
            this.budget = budget;
            this.destination = destination;
            this.brand = brand;
            this.rating = rating;
            this.price = (price < 1000) ? 1000 : price;
        }

        public override string Budget() {
            return $"The vacation is ${(price <= budget ? $"{budget - price} under" : $"{price - budget} over")} budget";
        }

        public override string ToString() {
            return $"{base.ToString()} from {brand} rated {rating} stars for a price of ${price}.";
        }
    }

    class PiecemealVacation : Vacation {
        List<(string name, decimal cost)> expenses;

        public PiecemealVacation(decimal budget, string destination, List<(string name, decimal cost)> expenses) {
            this.budget = budget;
            this.destination = destination;
            this.expenses = new List<(string name, decimal cost)>(expenses);
        }

        public override string ToString() {
            var ret = $"{base.ToString()} with the following costs associated with it:";
            if (expenses.Count == 1) {
                return $"{ret} a(n) {expenses[0].name} that costs ${expenses[0].cost}.";
            }
            for (var i = 0; i < expenses.Count; i++) {
                if (i < expenses.Count - 1) {
                    ret = $"{ret} a(n) {expenses[i].name} that costs ${expenses[i].cost},";
                } else {
                    ret = $"{ret} and a(n) {expenses[i].name} that costs {expenses[i].cost}.";
                }
            }
            return ret;
        }

        public override string Budget() {
            decimal totalCost = 0;
            foreach ((string name, decimal cost) expense in expenses) {
                totalCost += expense.cost;
            }
            return $"The vacation is ${(totalCost <= budget ? $"{budget - totalCost} under" : $"{totalCost - budget} over")} budget.";
        }
    }
}
