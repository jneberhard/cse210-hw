using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals  = new List<Goal>();
    private List<Goal> _completedGoals = new List<Goal>();

    private int _score;

    public void Start()
    {
        bool quit = false;
        Console.WriteLine("\nIf you are returning, make sure you LOAD your goals before proceeding.\n");

        while (!quit)
        {
        Console.WriteLine($"You have {_score} points.");
                Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("   1. Create New Goal\n   2. List Goals\n   3. Save Goals\n   4. Load Goals\n   5. Record Event"); 
        Console.WriteLine("   6. Remove a goal \n   7. Move Completed Goal to Completed Goal list");
        Console.WriteLine("   8. List Completed Goal List \n   9. Save Progress and Quit\n   10. Quit without saving");
        Console.Write("Select a choice from the menu: ");

        string input = Console.ReadLine();
            if (int.TryParse(input, out int selection))  // checks to see if a digit was entered
            {
                switch (selection)   // makes the input to a digit
                {
                    case 1:  // case is a keyword used inside a switch statement to match a specific variable   https://stackoverflow.com/questions/14304591/check-if-user-input-is-a-number
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        RemoveGoal();
                        break;
                    case 7:
                       MoveGoal();
                       break;
                    case 8:
                        ShowCompletedList();
                        break;
                    case 9:
                        SaveAndQuit();
                        quit = true;
                        break;
                    case 10:
                        Console.WriteLine("Nice job for looking at your goals. Come back often to record your progress.");
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("That is not an option. Options are the numbers 1 through 10");
                        break;
                }
            }
            else
            {
                Console.WriteLine("That option is not available. Try again.");
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine();
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetName()}");
            index ++;
        }
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("There are no goals listed. You need to create a goal or load your goals from a file.");
            Console.WriteLine();
            return;
        }
        
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"  {index}. {goal.GetDetailsString()}");
            index++;
        }

    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:  ");
        Console.WriteLine("   1. Simple Goal");
        Console.WriteLine("   2. Eternal Goal");
        Console.WriteLine("   3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int selection))  // checks to see if a digit was entered
            {
                Console.Write("What is the name of your goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of your goal? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points this goal is worth? ");
                string pointsInput = Console.ReadLine();  
                if (int.TryParse(pointsInput, out int points)) // checks to make sure it is a number     
                {  
                    switch (selection)   // makes the input to a digit
                    {
                        case 1:
                            _goals.Add(new SimpleGoal(name, description, points));
                            break;
                        case 2:
                            _goals.Add(new EternalGoal(name, description, points));
                            break;
                        case 3:
                            Console.WriteLine("How many times do you want to achieve this goal for a bonus? ");
                            int target = int.Parse(Console.ReadLine());
                            Console.WriteLine("How many bonus points are awarded when you achieve this goal? ");
                            int bonus = int.Parse(Console.ReadLine());
                            _goals.Add(new ChecklistGoal(name, description, points, target, bonus, 0));
                            break;
                        default:
                            Console.WriteLine("That is not an option. Try again.");
                            return;                    
                    }
                }
                else
                {
                    Console.WriteLine("You must enter a number value.");
                    return;
                }
            }
        else
        {
            Console.WriteLine("That was not a correct option. Try again.");
            return;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)  //checks to see if there are any goals and responds if not
        {
            Console.WriteLine("There are no goals to record. You need to create or import your goals first.");
            return;
        }
        ListGoalDetails();

        Console.Write("Which goal did you accomplish? ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int goalNumber))
        {
            if (goalNumber > 0 && goalNumber <= _goals.Count)
            {
                Goal goal = _goals[goalNumber - 1];
                int earnedPoints = goal.RecordEvent();
                _score += earnedPoints;
            }
            else
            {
                Console.WriteLine("That number is not linked to a goal. Please try again.");
                return;
            }
        }
        else
        {
            Console.WriteLine("That is not a valid input. Please enter a number.");
            return;
        }
    }

    public void SaveGoals()
    {
        if (_goals.Count == 0 && _completedGoals.Count == 0)  //checks to see if there are any goals and responds if not
        {
            Console.WriteLine();
            Console.WriteLine("There are no goals to save. You need to create or import your goals first.");
            Console.WriteLine();
            return;
        }
        Console.Write("What is the filename for the goal file? ");
        string fileinput = Console.ReadLine();
        string filename = fileinput;

        using (StreamWriter outputFile = new StreamWriter (filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }

            outputFile.WriteLine("COMPLETED");

            foreach (Goal goal in _completedGoals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        //checks to see if the file is found
        try
        {
            string[] lines = System.IO.File.ReadAllLines (fileName);

            _goals.Clear();
            _completedGoals.Clear();
            _score = int.Parse(lines[0]);

            bool loadingCompleted = false;

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];

                if (line == "COMPLETED")
                {
                    loadingCompleted = true;
                    continue;
                }

                string[] parts = line.Split("|");   // change the comma to | when ready to compile the txt file
                string goalType = parts[0];

                Goal goal = null;  //this had to be added to not get a compile error. The variable goal needs to exis.

                switch (goalType)
                {
                    case "SimpleGoal":
                        goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                        break;

                    case "EternalGoal":
                        goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                        break;

                    case "ChecklistGoal":
                        goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                        break;
                    
                    default:
                        Console.WriteLine("That is an unknown goal type.");
                        continue;

                }
                if (loadingCompleted)
                    _completedGoals.Add(goal);
                else
                    _goals.Add(goal);
            }
            Console.WriteLine("Your goals have been loaded.");
        }
        //what if it can't find the file?
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Error: the file '{fileName}' was not found.");
        }
        // what if the file is not in the correct format?
        catch (FormatException)
        {
            Console.WriteLine("Error. There is at least one line that is not in the correct format.");
        }
        // any other errors that keep it from loading the file?
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occured: {ex.Message}");
        }
    }
    public void RemoveGoal(){
  
        if (_goals.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("There are no goals listed. You need to create a goal or load your goals from a file.");
            Console.WriteLine();
            return;
        }
        
        ListGoalDetails();

        Console.WriteLine("Enter the number of the goal to remove: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int selection))
        {
            if (selection > 0 && selection <= _goals.Count)
            {
                string removedGoalName = _goals[selection - 1].GetName();
                _goals.RemoveAt(selection - 1);
                Console.WriteLine($"Goal \"{removedGoalName}\" has been removed.");
            }
            else{
                Console.WriteLine("That is not an option to remove. ");
            }
        }
        else 
        {
            Console.WriteLine("Invalid input. Please enter a number. ");
        }
        

    }
    
    public void MoveGoal()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine();
            Console.WriteLine("There are no goals listed. You need to create a goal or load your goals from a file.");
            Console.WriteLine();
            return;
        
        }

        ListGoalDetails();  // call the goal details so I don't have to write the code out again

        Console.WriteLine("What goal number to you want to move to the completed list? ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int selection))
        {
            if (selection > 0 && selection <= _goals.Count)
            {
                Goal completedGoal = _goals[selection -1];
                _completedGoals.Add(completedGoal);
                _goals.RemoveAt(selection -1);
                Console.WriteLine($"Goal \"{completedGoal.GetName()}\" has been moved to completed goals.");
            }
            else{
                Console.WriteLine("That is not an option to move. ");
            }
        }
        else 
        {
            Console.WriteLine("Invalid input. Please enter a number. ");
        }
    }

    public void ShowCompletedList()
    {
        if (_completedGoals.Count == 0)
        {
            Console.WriteLine("\nThere are no completed goals yet.\n");
            return;
        }

        Console.WriteLine("\nCompleted Goals: ");
        int index = 1;
        foreach (Goal goal in _completedGoals)
        {
            Console.WriteLine($"  {index}. {goal.GetDetailsString()}");
            index++;
        }
        Console.WriteLine();
    }

    public void SaveAndQuit()
    {
        SaveGoals();  //call SaveGoal instead of having to write the code out.
        Console.WriteLine("Goals have been saved. Come back soon!!!");
    }

}

