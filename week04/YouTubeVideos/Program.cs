using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Unboxing the New Wireless Earbuds", "TechReviewsDaily", 612);
        video1.AddComment(new Comment("Alex Turner", "These look way better than the last model."));
        video1.AddComment(new Comment("Priya Nair", "Can you do a battery life test next?"));
        video1.AddComment(new Comment("Marcus Lee", "The case design is so clean."));
        video1.AddComment(new Comment("Sofia Diaz", "Waiting for the price drop before I buy."));
        videos.Add(video1);

        Video video2 = new Video("5 Minute Meal Prep for Busy Weeks", "KitchenWithKate", 305);
        video2.AddComment(new Comment("Daniel Osei", "Tried this last night, so easy to follow!"));
        video2.AddComment(new Comment("Emily Chen", "What container brand are you using?"));
        video2.AddComment(new Comment("Jordan Blake", "This saved my lunch routine, thank you."));
        videos.Add(video2);

        Video video3 = new Video("Building a Gaming PC in 2026", "CircuitCraft", 1487);
        video3.AddComment(new Comment("Nina Popov", "The cable management at the end is oddly satisfying."));
        video3.AddComment(new Comment("Tyler Grant", "Which motherboard did you end up choosing?"));
        video3.AddComment(new Comment("Hana Kobayashi", "First build ever, this made it way less scary."));
        video3.AddComment(new Comment("Owen Michaels", "Subscribed after this one video."));
        videos.Add(video3);

        Video video4 = new Video("A Beginner's Guide to Watercolor Painting", "ArtWithAmara", 842);
        video4.AddComment(new Comment("Grace Whitfield", "Your shading technique is so calming to watch."));
        video4.AddComment(new Comment("Liam Foster", "What paper weight do you recommend for beginners?"));
        video4.AddComment(new Comment("Isabella Rossi", "I finally understand wet-on-wet, thank you!"));
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  - {comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine(new string('-', 50));
        }
    }
}