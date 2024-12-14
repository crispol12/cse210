using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Crear videos
        Video video1 = new Video("Introduction to C#", "CodeTeacher", 600);
        Video video2 = new Video("Building a Console App", "DevMaster", 900);
        Video video3 = new Video("Advanced OOP Concepts", "TechGuru", 1200);
        Video video4 = new Video("C# Best Practices", "ProCoder", 750);

        // Agregar comentarios a video1
        video1.AddComment(new Comment("Alice", "Great introduction, very clear!"));
        video1.AddComment(new Comment("Bob", "This helped me understand C# basics."));
        video1.AddComment(new Comment("Charlie", "Loved the examples!"));

        // Agregar comentarios a video2
        video2.AddComment(new Comment("Diana", "Excellent explanation."));
        video2.AddComment(new Comment("Ethan", "Now I can build my own console app!"));
        video2.AddComment(new Comment("Fiona", "Thanks for the detailed steps."));

        // Agregar comentarios a video3
        video3.AddComment(new Comment("George", "Advanced but well explained."));
        video3.AddComment(new Comment("Hannah", "I appreciate the clear definitions."));
        video3.AddComment(new Comment("Ian", "The examples helped a lot."));

        // Agregar comentarios a video4
        video4.AddComment(new Comment("Jenny", "Awesome tips for clean code."));
        video4.AddComment(new Comment("Kevin", "Really useful best practices!"));
        video4.AddComment(new Comment("Laura", "I'll apply these techniques right away."));

        // Lista de videos
        List<Video> videos = new List<Video>() { video1, video2, video3, video4 };

        // Mostrar información de todos los videos
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
            Console.WriteLine(); // Línea en blanco para separar videos
        }
    }
}
