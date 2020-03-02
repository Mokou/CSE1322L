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
            Console.WriteLine(RecursiveBaseConversion(8543, 38));
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
            if (numberSystemToConvertTo > 36)
                throw new UnsupportedBaseChangeException(numberSystemToConvertTo);
            if (numberToConvert <= numberSystemToConvertTo)
                return DecToChar(numberToConvert % numberSystemToConvertTo);
            return RecursiveBaseConversion((numberToConvert / numberSystemToConvertTo), numberSystemToConvertTo) + DecToChar(numberToConvert % numberSystemToConvertTo);
        }

        private static string DecToChar(int num) {
            if (num <= 9)
                return Convert.ToString(num);
            return Char.ToString((char)(num + 55));
        }
    }

    public class UnsupportedBaseChangeException : Exception {
        public UnsupportedBaseChangeException() { }
        public UnsupportedBaseChangeException(int baseSystem) : base($"base{baseSystem} is not supported. Try a base <= 36.") { }
    }
}
