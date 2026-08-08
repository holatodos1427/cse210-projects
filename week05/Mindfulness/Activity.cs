using System;
using System.Collections.Generic;
using System.Threading;

namespace Mindfulness
{
    //inheritance + encapsulation + polymorphism
    abstract class Activity
    {
        private string _name;
        private string _description;
        private int _duration;

        public Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        // derived classes
        protected int Duration
        {
            get { return _duration; }
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_name} Activity.");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
            Console.Write("Enter the duration in seconds: ");
            int.TryParse(Console.ReadLine(), out _duration);

            Console.WriteLine();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        public void DisplayEndingMessage()
        {
            Console.Clear();
            Console.WriteLine("Well done!");
            ShowSpinner(3);
            Console.WriteLine();
            Console.WriteLine($"You have completed the {_name} Activity for {_duration} seconds.");
            ShowSpinner(3);
        }

        public void ShowSpinner(int seconds)
        {
            List<string> spinnerFrames = new List<string> { "/", "-", "\\", "|" };
            int frame = 0;
            int totalMs = seconds * 1000;

            for (int elapsed = 0; elapsed < totalMs; elapsed += 250)
            {
                Console.Write(spinnerFrames[frame % spinnerFrames.Count]);
                Thread.Sleep(250);
                Console.Write("\b \b");
                frame++;
            }
        }

        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);

                int digits = i.ToString().Length;
                Console.Write(new string('\b', digits));
                Console.Write(new string(' ', digits));
                Console.Write(new string('\b', digits));
            }
        }

        public abstract void Run();
    }
}
