//going above and beyond - questions on the reflecting activity are not repeated until all questions have been used.

using System;

class Program
{
    static void Main(string[] args)
    {
        int selection = 0;
        while (selection !=4)
        {
            Console.Clear();
            Console.WriteLine("Menu Options: ");
            Console.WriteLine("   1. Start breathing activity ");
            Console.WriteLine("   2. Start reflecting activity ");
            Console.WriteLine("   3. Start listing activity ");
            Console.WriteLine("   4. Quit ");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();

            if (int.TryParse(input,out selection))  // checks to see if a digit was entered
            {
                switch (selection)   // makes the input to a digit
                {
                    case 1:  // case is a keyword used inside a switch statemnt to match a specific variable   https://stackoverflow.com/questions/14304591/check-if-user-input-is-a-number
                        BreathingActivity breathing = new BreathingActivity();
                        breathing.Run(); //doing the Run function fromt the BreathingActivity class
                        break;  //tels the program to stop here and return - terminates the loop  https://www.programiz.com/csharp-programming/break-statement#:~:text=In%20C%23%2C%20we%20use%20the,without%20checking%20the%20test%20expression.
                    case 2:
                        ReflectingActivity reflecting = new ReflectingActivity();
                        reflecting.Run();
                        break;
                    case 3:
                        ListingActivity listing = new ListingActivity();
                        listing.Run();
                        break;
                    case 4:
                        Console.WriteLine("Thank you. Have a good day. ");
                        break;

                }
            }

        }
    }
}