using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        //int magic = -2;
        //Console.Write("What is the magic number? ");
        // magic = int.Parse(Console.ReadLine());
        Random randomGenerator = new Random();
        int magic = randomGenerator.Next(1, 100);
        int guess = -1;

        while (guess != magic)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (magic > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (magic < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You got it");
            }

        }
    }
}