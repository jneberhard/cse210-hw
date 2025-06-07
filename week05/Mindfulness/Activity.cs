
using System;

public class Activity
{
    private string _name;
    private string _description;  // private only the class can access it
    protected int _duration;   // protected only class and subclass can access 

    public Activity(string name, string description, int duration)   //public - accesible from anywhere in the program.
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);

    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("Well Done!!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed the {_name} Activity.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int Seconds)    
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");


     
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(Seconds);

        while (DateTime.Now < endTime)
        {
            foreach (string s in animationStrings)
            {
                if (DateTime.Now >= endTime)
                {
                    break;
                }
                
                Console.Write(s);
                Thread.Sleep(250);   //adjust speed - this is in milliseconds 1000 milliseconds to a second
                Console.Write("\b \b");
            }
            
        }


    }
    
    public void ShowCountDown(int seconds)
    {
        for (int i=seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}