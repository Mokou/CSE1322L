using System;

namespace Lab8 {
    class Program {
        static void Main(string[] args) {
            string str;
            if (args.Length == 0) {
                Console.Write("Enter a string: ");
                str = Console.ReadLine();
            }
            else
                str = String.Join(" ", args);
            Console.WriteLine($"The string '{str}' is {(IsPalindrome(str) ? "a" : "not a" )} palindrome.");
        }

        static bool IsPalindrome(ReadOnlySpan<char> s) {
            if (s.Length <= 1)
                return true;
            else if (s[0] == s[^1])
                return IsPalindrome(s.Slice(1, s.Length - 2));
            return false;
        }
    }
}
