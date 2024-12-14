using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Introduction to C#", "Archie Moore", 800);
        Video video2 = new Video("Building a Console App", "Taylor Fletcher", 1000);
        Video video3 = new Video("Advanced OOP Concepts", "Ignacio Johns", 1500);

        // Add comments to video1
        video1.AddComment(new Comment("Ferran", "Excellent class, Wonderful!"));
        video1.AddComment(new Comment("Eva", "This helped me understand the basics of the program."));
        video1.AddComment(new Comment("Titus", "I understand perflectly the concepts, Thank You!"));

        video2.AddComment(new Comment("Sharon", "This was very informative, thank you!"));
        video2.AddComment(new Comment("Michael", "I finally understand how to structure my console app!"));
        video2.AddComment(new Comment("Laura", "Your step-by-step approach made it simple to follow along."));

        // Add comments to video3
        video3.AddComment(new Comment("Oliver", "These concepts seemed complex, but you made them easy."));
        video3.AddComment(new Comment("Nina", "Your examples cleared up a lot of confusion I had."));
        video3.AddComment(new Comment("Victor", "I appreciate the deep dive into advanced OOP patterns."));

        // Store videos in a list
        List<Video> videos = new List<Video>() { video1, video2, video3 };

        // Display all information for each video
        foreach (Video vid in videos)
        {
            Console.WriteLine("Title: " + vid.Title);
            Console.WriteLine("Author: " + vid.Author);
            Console.WriteLine("Length: " + vid.Length + " seconds");
            Console.WriteLine("Number of Comments: " + vid.GetCommentCount());
            Console.WriteLine("Comments:");

            foreach (Comment c in vid.Comments)
            {
                Console.WriteLine("  - " + c.Name + ": " + c.Text);
            }

            Console.WriteLine();
        }
    }
}
