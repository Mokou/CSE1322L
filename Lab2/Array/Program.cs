using System;

namespace pmcgoran_Lab1BArray {
    class Program {
        static void Main(string[] args) {
            int [,] data = new int[5,5];
            Console.WriteLine($"Creating {data.GetLength(0)}x{data.GetLength(1)} array from user input.");
            for (int y = 0; y < data.GetLength(1); y++) {
                for (int x = 0; x < data.GetLength(0); x++) {
                    Console.Write($"Enter data for position ({x},{y}): ");
                    data[x,y] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine($"The longest series of positive numbers is {LongestPositiveSeries(data)} for the following array: ");
            for (int y = 0; y < data.GetLength(1); y++) {
                for (int x = 0; x < data.GetLength(0); x++) {
                    Console.Write($"{data[x,y]} ");
                }
                Console.Write(Environment.NewLine);
            }
        }

        static int LongestPositiveSeries(int[,] array) {
            int longest = 0;
            int current = 0;
            for (int y = 0; y < array.GetLength(1); y++) {
                for (int x = 0; x < array.GetLength(0); x++) {
                    if (array[x,y] > 0) {
                        current++;
                    } else {
                        if (current > longest) {
                            longest = current;
                        }
                        current = 0;
                    }
                }
            }
            if (current > longest) {
                longest = current;
            }
            return longest;
        }
    }
}

