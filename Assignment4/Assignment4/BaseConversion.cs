/*
Class: CSE 1322L
Section: 02
Term: Spring 2020
Instructor: Kevin Markley
Name: Pierce McGoran
Assignment 4A
*/

using System;

namespace Assignment4 {
    public class BaseConversion {
        public static void Main(string[] args) {
            int n, b;
            bool loop = true;
            while (loop) {
                if (args.Length < 2) {
                    Console.Write("Enter number to convert: ");
                    n = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"Enter base to convert {n} to: ");
                    b = Convert.ToInt32(Console.ReadLine());
                } else {
                    n = Convert.ToInt32(args[0]);
                    b = Convert.ToInt32(args[1]);
                }
                try {
                    Console.WriteLine($"{n} in decimal is {RecursiveBaseConversion(n, b)} in base{b}.");
                } catch (NotSupportedException) {
                    Console.WriteLine($"Base{b} is invalid, try a number from 1-36 inclusively.");
                }
                string cont;
                do {
                    Console.Write($"Continue? [y/n] ");
                    cont = Console.ReadLine();
                } while (!(cont.ToLower().Contains("y") || cont.ToLower().Contains("n")));
                if (cont.ToLower().Contains("n"))
                    break;
            }
        }

        //Complete the below method according to the instructions found on the FYE website for assignment 4.
        //You MAY NOT CHANGE the below method signature or create your own methods or functions.
        /**
            * Method that will return the value of any number converted to any other base number system, as long as the base number system is from 2 - 36.
            *
            * @param  numberToConvert   The number that will be converted to a different base number system. Must start in the decimal number system (base 10).
            * @param  numberSystemToConvertTo   The base number system to convert the base 10 number into.
            * @return             The final return will be a complete number in the other base number system (saved as a string to hold anything from 0 - 9, and A - Z).
         */
        public static String RecursiveBaseConversion(int numberToConvert, int numberSystemToConvertTo) {
            if (numberSystemToConvertTo < 1 || numberSystemToConvertTo > 36)
                throw new NotSupportedException("Base to convert must be 1-36 inclusively");
            int mod = (numberToConvert % numberSystemToConvertTo);
            if (numberToConvert < numberSystemToConvertTo)
                return mod <= 9 ? Convert.ToString(mod) : Char.ToString((char)(mod + 55));
            return RecursiveBaseConversion(numberToConvert / numberSystemToConvertTo, numberSystemToConvertTo) + (mod <= 9 ? Convert.ToString(mod) : Char.ToString((char)(mod + 55)));
        }
    }
}
