using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction(1);  // f1 represents the first problem - of the example of 1 as in the lesson
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        Fraction f5 = new Fraction(7, 8);  // created a fifth example and decided on 7/8 - just to understand what I'm doing.
        Console.WriteLine(f5.GetFractionString());  // taking the first or top value
        Console.WriteLine(f5.GetDecimalValue());  // taking the second or bottom value
    }
}