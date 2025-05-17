public class Entry
{                          //3 items it will be calling. If it was a shared journel, add another one called "_name" to see who wrote it.
    public string _date;
    public string _promptText;
    public string _entryText;


    public void Display()
    {
        Console.WriteLine("****************************************"); // makes it easy to separate responses
        Console.WriteLine($"Date: {_date} Prompt: {_promptText} \nResponse: {_entryText}\n"); // /n creates a new line

        }
}