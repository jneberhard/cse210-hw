using System;


public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse;  // must use the ? after int to make it possible to be null -- refernce:  https://stackoverflow.com/questions/6191339/why-type-int-is-never-equal-to-null
    
    public Reference(string book, int chapter, int verse)  // for a single verse
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = null;

    }
    public Reference(string book, int chapter, int startVerse, int endVerse)  //for a scripture with more than one verse
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;

    }

    public string GetDisplayText() //this is to display the scripture reference
    {
        if (_endVerse.HasValue)    //  checks to see if it has an end verse or not
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        else
            return $"{_book} {_chapter}:{_verse}";
        
    }
}