using System;


public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();   // going to randomly pick words to make hidden

    public Scripture(Reference reference, string text)  //constructor
    {
        _reference = reference;   //contains the book, chapter, and scripture
        _words = text.Split(' ').Select(w => new Word(w)).ToList();   //takes the scripture string and breaks it by the space. 
        // then for each word in array (w) creates new word(w) object to a list of words
    }

    public void HideRandomWords(int numberToHide) //will only hide words not already hidden - input is the number of words to hide
    {
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList(); //makes sure it selects only words that aren't hidden and makes that list
        for (int i = 0; i < numberToHide && visibleWords.Count > 0; i++)   // for loop -- will stop if there aren't any words left to hide
        {
            int index = _random.Next(visibleWords.Count); // picks random index from words
            visibleWords[index].Hide(); // calls the hide method on the word from the random index which will make it _isHidden
            visibleWords.RemoveAt(index);    // removes the word so it can't be chosen again  

        }
    }
    public void DisplayText()
    {
        Console.Clear();  // clears the console before writing text
        Console.WriteLine(_reference.GetDisplayText());  //printingthe reference (book, chapter, verses)
        Console.WriteLine();   // prints blank line
        foreach (Word word in _words)  // this will write the scripture
        {
            Console.Write(word.GetDisplayText() + " ");  //calls GetDisplay and adds a space between each word - GetDisplay is in the word class
        }
        Console.WriteLine("\n");  // adds a line after it writes
    }
    public bool IsCompletelyHidden()  // used to know if the game should automatically end
    {
        return _words.All(w => w.IsHidden());
    }


}