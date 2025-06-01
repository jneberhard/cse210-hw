using System;
using System.Diagnostics;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();   // creating a list of the videos that will store the objects

        Video video1 = new Video("The Lincoln Shield Cent", "BlueRidge Silverhoud", 948);
        Video video2 = new Video("War Time Jefferson Nickels", "Rob Finds Treasures", 1256);
        Video video3 = new Video("Coin Roll Hunting Halfs", "Coin Zone", 532);

        video1.AddComment(new Comment("Paul", "I have a ton of copper cents. I'm sure the value will go up. "));
        video1.AddComment(new Comment("SusieQ", "This could be bad for those that use cash only. Will round up to the nickel."));
        video1.AddComment(new Comment("Jimbo", "I guess I better start saving my pennies. They could be worth something."));
        video1.AddComment(new Comment("Paula", "A penny saved now, is 10 pennies later."));

        video2.AddComment(new Comment("Aaron", "Most people don't know there is silver in those."));
        video2.AddComment(new Comment("Gus", "And they thought silver was cheaper than copper/nickel."));
        video2.AddComment(new Comment("Sheila", "I found one on the locker room floor.  SCORE!!!!."));


        video3.AddComment(new Comment("Lynette", "Seems like a waste of time."));
        video3.AddComment(new Comment("George", "I can work and make money to buy the silver instead"));
        video3.AddComment(new Comment("Michael", "I love to find cheap silver."));
        video3.AddComment(new Comment("Max", "10 to 25 times face value, depending on the half."));
        video3.AddComment(new Comment("Katie", "Love the sound of silver coins."));

//must add videos to the list in order for it to go through the videos.
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);


        foreach (Video video in videos)   //go through each video and list video with attributes - title, author, length, total # of reviews
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Number of reviews: {video.GetCommentCount()}");

            foreach (Comment comment in video.GetAllComments())
            {
                Console.WriteLine($"{comment.Name}: {comment.CommentText}");  // writes each comment
            }

            Console.WriteLine(new string('-', 40));  //to separate videos
        }

    }
}