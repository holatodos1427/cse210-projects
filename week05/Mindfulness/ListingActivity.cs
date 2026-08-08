using System;
using System.Collections.Generic;

namespace Mindfulness
{
    class ListingActivity : Activity
    {
        private int _count;
        private List<string> _prompts;
        private static Random _random = new Random();

        public ListingActivity()
            : base("Listing",
                   "This activity will help you reflect on the good things in your life by having you list " +
                   "as many things as you can in a certain area.")
        {
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        }

        public override void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine();
            Console.WriteLine(GetRandomPrompt());
            Console.WriteLine("You will have a few seconds to think of items.");
            ShowCountDown(5);

            Console.WriteLine();
            Console.WriteLine("Start listing items, one per line!");
            List<string> items = GetListFromUser();
            _count = items.Count;

            Console.WriteLine();
            Console.WriteLine($"You listed {_count} items!");
            ShowSpinner(3);

            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            return _prompts[_random.Next(_prompts.Count)];
        }

        private List<string> GetListFromUser()
        {
            List<string> items = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(Duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string item = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(item))
                {
                    items.Add(item);
                }
            }

            return items;
        }
    }
}
