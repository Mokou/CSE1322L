using System;

namespace Lab7 {
    class Program {
        static void Main(string[] args) {
            string str;
            if (args.Length == 0) {
                Console.Write("Enter a string: ");
                str = Console.ReadLine();
            }
            else
                str = String.Join(" ", args);
            Console.WriteLine($"The number of vowels in '{str}' is {VowelCount(str)}.");
        }

        private static int VowelCount(ReadOnlySpan<char> s) {
            if (s.Length == 0)
                return 0;
            else
                return VowelCount(s.Slice(1)) + (IsVowel(s[0]) ? 1 : 0);
        }

        private static bool IsVowel(char c) => "aeiouyAEIUOY".Contains(c);
    }
}
