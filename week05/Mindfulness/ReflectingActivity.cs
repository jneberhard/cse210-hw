// above and beyond -- won't repeat the same question until it has gone through all the questions.
using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else. ",
        "Think of a time when you did something really difficult. ",
        "Think of a time when you helped someone in need. ",
        "Think of a time when you did something truly selfless. "
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?  ",
        "Have you ever done anything like this before?  ",
        "How did you get started?  ",
        "How did you feel when it was complete?  ",
        "What made this time different than other times when you were not as successful?  ",
        "What is your favorite thing about this experience?  ",
        "What could you learn from this experience that applies to other situations?  ",
        "What did you learn about yourself through this experience?  ",
        "How can you keep this experience in mind in the future?  "
    };

    private List<string> _unusedQuestions;   //preparing to be able to remove duplicate questions 
    
    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", 0)
    {
        _unusedQuestions = new List<string>(_questions);   //makes a copy of the questions - to use to make sure questions aren't duplicated
    }

    public void Run()
    {
        DisplayStartMessage();
        
        string prompt = GetRandomPrompt();  //getting a random prompt
        Console.WriteLine($"\nConsider the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine($"\nWhen you have something in mind,press enter to continue. ");
        Console.ReadLine();
        Console.WriteLine("Now Ponder on each of the following questions as they related to this experience.");
        Console.WriteLine($"You may begin in: ");
        ShowCountDown(5);



        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.WriteLine($"\n> {question} ");
            ShowSpinner(3); // this is giving 3 seconds of spinner
            ShowCountDown(5); // followed by 5 seconds of countDown
        }

        DisplayEndMessage();
    }


    private string GetRandomPrompt()
    {
        Random prompting = new Random();
        int index = prompting.Next(_prompts.Count); //generates random number to pick from for the index
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        if (_unusedQuestions.Count == 0)
        {
            _unusedQuestions = new List<string>(_questions);
        }
        Random question = new Random();
        int index = question.Next(_unusedQuestions.Count);
        string selectedQuestion = _unusedQuestions[index];
        _unusedQuestions.RemoveAt(index);  //removes that question for the future
        return selectedQuestion;
    }
}

