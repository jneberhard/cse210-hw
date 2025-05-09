using System;
using System.Collections.Specialized;
using System.Configuration.Assemblies;
using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main(string[] args)
    {
        //call these 5 functions
        WelcomeMessage();
        string userName = PromptName();
        int userNumber = PromptNumber();
        int squaredNumber = SquaredNumber(userNumber);
        DisplayResult(userName, squaredNumber);
    }

    //Welcome message function 1
    static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    //ask for the name function 2
    static string PromptName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    //ask for a number function 3
    static int PromptNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    //square the number function 4
    static int SquaredNumber(int number)
    {
        int square = number * number;
        return square;
    }

    //results to print function 5
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }

}
