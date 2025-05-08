using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int inputNumber = -1;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        // part 1 - adding if the number is not zero
        while (inputNumber != 0)
        {
            Console.Write("Enter number: ");
            string userResponse = Console.ReadLine();
            inputNumber = int.Parse(userResponse);

            if (inputNumber != 0)
            {
                numbers.Add(inputNumber);
            }
        }
        // part 2 -- summing the numbers
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");



        // part 3 -- counting how many numbers there are and averaging
        int count = 0;
        foreach (int item in numbers)
        {
            count += 1;
        }
        float average = ((float)sum / (float)count);
        Console.WriteLine($"The average is: {average}");

        //part 4- find the max
        int maxNumber = 0;
        foreach (int item in numbers)
            if (item > maxNumber)
            {
                maxNumber = item;
            }
        Console.WriteLine($"The max number is: {maxNumber}");

    }
}
