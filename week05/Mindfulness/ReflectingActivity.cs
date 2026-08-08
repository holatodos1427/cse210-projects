using System;
using System.Collections.Generic;

namespace Mindfulness
{
    class ReflectingActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;
        private static Random _random = new Random();

        public ReflectingActivity()
            : base("Reflecting",
                   "This will help you reflect on times in your life when you have shown strength "+
                   "and resilience. This will help you recognize the power you have and how you can use it "+
                   "in other aspects of your life.")
        {
            _prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            _questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };
        }

        public override void Run()
        {
            DisplayStartingMessage();
            DisplayPrompt();
            DisplayQuestions();
            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            return _prompts[_random.Next(_prompts.Count)];
        }

        private string GetRandomQuestion()
        {
            return _questions[_random.Next(_questions.Count)];
        }

        private void DisplayPrompt()
        {
            Console.WriteLine();
            Console.WriteLine(GetRandomPrompt());
            ShowCountDown(5);
        }

        private void DisplayQuestions()
        {
            int elapsed = 0;

            while (elapsed < Duration)
            {
                Console.WriteLine();
                Console.WriteLine(GetRandomQuestion());
                ShowSpinner(4);
                elapsed += 4;
            }
        }
    }
}
