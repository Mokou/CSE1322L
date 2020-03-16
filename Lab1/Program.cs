using System;

namespace Lab1A
{
    class Program
    {
        static void Main(string[] args) {
            Console.Write("Please enter a frequency in Hertz: ");
            int frequency = Convert.ToInt32(Console.ReadLine());

            Console.Write("Please enter a duration in seconds: ");
            int duration = Convert.ToInt32(Console.ReadLine());

            Console.Write("Playing " + frequency + "Hz tone for ");
            if (duration == 1) {
                Console.WriteLine(duration + " second.");
            } else {
                Console.WriteLine(duration + " seconds.");
            }
            Console.Beep(frequency, duration * 1000);

            int[] nums = {1, 4, 13, 43, -25, 17, 22, -37, 29};
            int[] data = new int[20];
            FillRandom(data);

            int numsMax = FindLargest(nums);
            int dataMax = FindLargest(data);

            Console.WriteLine("Largest int in array 'nums': " + numsMax);
            Console.WriteLine("Largest int in array 'data': " + dataMax);
            Console.WriteLine("Sum of previous two: " + (numsMax + dataMax));
            Console.WriteLine("Contents of array 'data': {" + String.Join(", ", data) + "}");
        }

        static int FindLargest(int[] array) {
            int largest = array[0];

            for (int i = 0; i < array.Length; i++) {
                if (largest < array[i]) {
                    largest = array[i];
                }
            }
            return largest;
        }

        static void FillRandom(int[] array) {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++) {
                array[i] = random.Next(-100, 101);
            }
        }
    }
}
