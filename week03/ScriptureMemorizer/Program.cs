using System;


class Program
{
    static void Main(string[] args)
    {
        var scriptures = new List<Scripture>();

        scriptures.Add(new Scripture(
            new Reference("1 Nephi", 3, 7),
            "I will go and do the things which the Lord hath commanded, for " +   // found about the + operator from https://ironpdf.com/blog/net-help/csharp-multiline-string/#:~:text=Handling%20Long%20Strings&text=To%20make%20the%20code%20more,lines%20using%20the%20'%2B'%20operator.&text=We%20split%20the%20long%20single,making%20the%20code%20more%20readable.
            "I know that the Lord giveth no commandments unto the children " +
            "of men, save he shall prepare a way for them that " +
            "they may accomplish the thing which he commandeth them."
        ));

        scriptures.Add(new Scripture(
            new Reference("Moroni", 10, 3, 5),
            "Behold, I would exhort you that when ye shall read these things, " +
            "if it be wisdom in God that ye should read them, that ye would " +
            "remember how merciful the Lord hath been unto the children of men, " +
            "from the creation of Adam even down until the time that ye shall " +
            "receive these things, and ponder it in your hearts. \r\n\nAnd when ye shall " +     //add \rand\n to create a blank line to separate the verses
            "receive these things, I would exhort you that ye would ask God, the " +
            "Eternal Father, in the name of Christ, if these things are not true; " +
            "and if ye shall ask with a sincere heart, with real intent, having faith in Christ, " +
            "he will manifest the truth of it unto you, by the power of the Holy Ghost. " +
            "\n\r\nAnd by the power of the Holy Ghost ye may know the truth of all things."
        ));

        scriptures.Add(new Scripture(
            new Reference("Mosiah", 2, 7),
            "And behold, I tell you these things that ye may learn wisdom; that ye " +
            "may learn that when ye are in the service of your fellow beings ye are only in the service of your God."
        ));

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];   // picking a random scripture

        while (!scripture.IsCompletelyHidden())
        {
            scripture.DisplayText();
            Console.Write("Press the enter key to continue or type quit: ");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")   // checking the user input -- stopping if quit is typed or else it will go on
            {
                Console.WriteLine("Thank You");  // give a thank you
                return;
            }

            scripture.HideRandomWords(3);    // change the number in ( ) to decide how many words to omit each time
        }
        scripture.DisplayText();
        Console.WriteLine("You are done. The program will now exit"); //quitting now explanation
        return;
  }
}

