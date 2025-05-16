public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(string date, string prompt, string response)
    {
        _entries.Add(new Entry { _date = date, _promptText = prompt, _entryText = response });
    }
    public void DisplayAll()
    {
        Console.WriteLine("\nHere are your journal entries:");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine("Date|Prompt|Response");  //adds a header to the CSV File -- https://www.makeuseof.com/csv-file-c-sharp-save-data/
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }

        }

    }
    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            try   //   source for try/catch   https://www.w3schools.com/cs/cs_exceptions.php   I had a index outsieof bounds error
            {
                string[] lines = File.ReadAllLines(file);
                lines = lines.Skip(1).ToArray(); // where I found skip header row:  https://stackoverflow.com/questions/43048819/skip-first-line-using-system-io-file-readalllinesfil-in-c-sharp
                _entries.Clear();

                foreach (string line in lines)
                {
                    string[] parts = line.Split("|");   // making the delimiter to | instead of comma because commas can be in the responses

                    string date = parts[0];
                    string prompt = parts[1];
                    string response = parts[2];
                    _entries.Add(new Entry { _date = date, _promptText = prompt, _entryText = response});
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"There was an error loading the file {file}.");
            }
        }

        else
        {
            Console.WriteLine("File not found.");
        }
    }
}