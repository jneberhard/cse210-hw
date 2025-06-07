using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", 0)
    {
    }

    public void Run()
    {
        DisplayStartMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        bool breathingIn = true;

        while (DateTime.Now < endTime)
        {
            if (breathingIn)
            {
                Console.WriteLine("\nBreathe in...");
            }
            else
            {
                Console.WriteLine("\nBreathe out...");
            }
            ShowCountDown(5);
            breathingIn = !breathingIn;
        }
        DisplayEndMessage();
    }

}    