using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    public int _count;
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", 0)
    {
    }


    public void Run()
    {
        DisplayStartMessage();

        string prompt = GetRandomPrompt();  //getting a random prompt
        Console.WriteLine($"\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine($"You may begin in: ");
        ShowCountDown(5);

        List<string> responses = new List<string>();  //getting the inputs
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        int count = 1;
        while (DateTime.Now < endTime)
        {
            Console.Write($"{count}. ");
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))  // checks to see if there is an input  https://www.tutorialspoint.com/csharp/csharp_string_isnullorwhitespace_method.htm
            {
                responses.Add(input);
                count++;   // adds to responseNumber if there is input
            }

        }
        _count = responses.Count;
        Console.WriteLine($"\nYou listed {_count} items.");
        DisplayEndMessage();

    }

    private string GetRandomPrompt()
    {
        Random prompting = new Random();
        int index = prompting.Next(_prompts.Count); //generates random number to pick from for the index
        return _prompts[index];
    }
}