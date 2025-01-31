using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace lab0
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1: Create variables
            int low = GetPositiveNumber("Enter the low number (positive): ");
            int high = GetHighNumber("Enter the high number (greater than low): ", low);

            // Task 2: Create and populate a list
            List<double> numbers = new List<double>();
            for (int i = low; i <= high; i++)
            {
                numbers.Add(i);
            }

            // Task 3 : Write to file in reverse order
            string filePath = "numbers.txt";
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    writer.WriteLine(numbers[i]);
                }
            }
            Console.WriteLine($"Numbers written to {"numbers.txt"} in reverse order.");

            //Additional Task 2: Read back and calculate the sum 
            double sum = 0;
            using (StreamReader reader = new StreamReader("numbers.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    sum += double.Parse(line);
                }
            }
            Console.WriteLine($"The sum of numbers from the file is: {sum}");

            //Additional Task 5: Print prime numbers
            Console.WriteLine("Prime numbers between low and high: ");
            foreach (double number in numbers)
            {
                if (IsPrime((int)number))
                {
                    Console.WriteLine(number);
                }
            }
        }

        static int GetPositiveNumber(string message)
        {
            int number;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out number) || number <= 0);
            return number;
        }

        static int GetHighNumber(string message, int low)
        {
            int number;
            do
            {
                Console.Write(message);
            }while (!int.TryParse(Console.ReadLine(), out number) || number < low);
            return number;
        }

        static bool IsPrime(int number)
        {
            if (number < 2) return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }
}
