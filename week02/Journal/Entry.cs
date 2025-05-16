public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;


    public void Display()
    {
        Console.WriteLine("****************************************");
        Console.WriteLine($"Date: {_date} Prompt: {_promptText} \nResponse: {_entryText}\n");

        }
}