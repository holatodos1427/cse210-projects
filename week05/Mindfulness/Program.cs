using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    class Program
    {
        // extra feature added to exceed core requirements:
        // The program keeps a session log of how many times each activity
        // has been completed, and displays a short summary when the user quits.
        static void Main(string[] args)
        {
            Dictionary<string, int> sessionLog = new Dictionary<string, int>
            {
                { "Breathing", 0 },
                { "Reflecting", 0 },
                { "Listing", 0 }
            };

            bool quit = false;

            while (!quit)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflecting Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Select a choice: ");
                string choice = Console.ReadLine();

                Activity activity = null;
                string logKey = null;

                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        logKey = "Breathing";
                        break;
                    case "2":
                        activity = new ReflectingActivity();
                        logKey = "Reflecting";
                        break;
                    case "3":
                        activity = new ListingActivity();
                        logKey = "Listing";
                        break;
                    case "4":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        Thread.Sleep(1000);
                        break;
                }

                if (activity != null)
                {
                    activity.Run();
                    sessionLog[logKey]++;
                }
            }

            Console.Clear();
            Console.WriteLine("Session summary:");
            foreach (KeyValuePair<string, int> entry in sessionLog)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value} time(s)");
            }
            Console.WriteLine();
            Console.WriteLine("Goodbye!");
        }
    }
}
