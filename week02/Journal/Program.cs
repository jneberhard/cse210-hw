using System;
using System.IO;
using System.Linq; //source https://stackoverflow.com/questions/43048819/skip-first-line-using-system-io-file-readalllinesfil-in-c-sharp

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("If you have already written in your journal, please load that \nformer journal unless you plan on having several different journal files.");
        Console.WriteLine("Before quitting, make sure you save your journal entries or they will be lost.");
        int inputNumber = -1;
        GeneratePrompt generatePrompt = new GeneratePrompt();

        // part 1 - adding if the number is not five
        while (inputNumber != 5)
        {
            Console.WriteLine("\nPlease select one of the following choices.");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display currently loaded entries");
            Console.WriteLine("3. Load former entries");
            Console.WriteLine("4. Save journal entries ");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");  //asking for a number
            string userResponse = Console.ReadLine();
            inputNumber = int.Parse(userResponse);

            if (inputNumber == 1)  //checks to see if it is this number selected
            {
                string prompt = generatePrompt.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string journalEntry = Console.ReadLine();

                DateTime currentTime = DateTime.Now;    // got this information from the lesson material -- very nice
                string dateTime = currentTime.ToLongDateString();
                journal.AddEntry(dateTime, prompt, journalEntry);

            }
            else if (inputNumber == 2)
            {
                journal.DisplayAll();
            }
            else if (inputNumber == 3)
            {
                Console.Write("\nWhat is the name of the file to load? ");
                string file = Console.ReadLine();
                journal.LoadFromFile(file);

            }
            else if (inputNumber == 4)
            {
                Console.Write("\nWhat is the name of the file to save? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);

                Console.WriteLine($"Your file has been saved as {filename}.");

            }


            else if (inputNumber == 5)
            {
                Console.WriteLine("Thank you. Goodbye");
                break;
            }
            else
            {
                Console.WriteLine("Invalid number. Please enter a correct number.");
            }
        }

    }
}