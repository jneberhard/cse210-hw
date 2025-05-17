using System;

public class GeneratePrompt
{
    private Random _random;    // learned to make it private so it doesn't break the code. This is only needed in this cs file so it is private.
    public List<string> _prompts;

    public GeneratePrompt()
    {
        _prompts = new List<string>  //could easily add more prompts here
        {
            "Who was the most interesting person I talked with today?",
            "What was the favorite thing I ate today?",
            "What did I learn today?",
            "What was the best part of my day?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What did I learn the last time I studied the scriptures?",
            "What is the biggest news of the day and how did I feel about it?",
            "How did I see the hand of the Lord in my life today?",
            "What are the biggest fears I have had in the past week?",
            "What is my next 'big' thing I are looking forward to?",
            "In the past month, what is one of the difficulties I faced and how did I overcome it?"
        };

        _random = new Random();
    }
public string GetRandomPrompt()
{
    int index = _random.Next(_prompts.Count);
    return _prompts[index];
}
}
