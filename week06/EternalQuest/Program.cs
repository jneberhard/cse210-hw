// exceeding requirements
// Added more options.  After a while the list of goals could get quite long..  
//Created an option to save a completed goal to a completed goal list and also to view that list
//Also created option to Save and Quit instead of just quit.... I quit out so many times without saving and lost
//what I was doing.  Wanted to save it automatically or have the option to save without the updates.
//Added remove a goal from list - maybe you decide it is no longer a goal and you just want it removed.  You can now do it.
//   1. Create New Goal
//   2. List Goals
//   3. Save Goals
//   4. Load Goals
//   5. Record Event
//   6. Remove a goal
//   7. Move Completed Goal to Completed Goal list
//   8. List Completed Goal List
//   9. Save Progress and Quit
//   10. Quit without saving
// Future things to add:
//      Automatically put the completion date
//      Set a date to complete the goal

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}