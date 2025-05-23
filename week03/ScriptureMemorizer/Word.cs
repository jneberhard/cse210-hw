using System;


public class Word  // looking at each word? 
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }
    public void Show()
    {
        _isHidden = false;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()   // this is used to display the text
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);  // if the word is hidden it will return the underscore
        }
        else
        {
            return _text;    // returns the word if it is not hidden. 
        }
    }
}