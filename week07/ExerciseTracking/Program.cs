using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>()  // making the list of activites
        {
            new Running(new DateTime(2025, 6, 14), 60, 4.5),      //date, minutes, distance (miles)    -- DateTime == Year, Month, Day
            new Biking(new DateTime(2025, 6, 13), 45, 20),    // date, minutes, speed (mph)
            new Swimming(new DateTime(2025, 6, 12), 30, 15),    //date, minutes, laps
            new Running(new DateTime(2025, 6, 16), 57, 2.75),
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}