using System;

namespace Mindfulness
{
    class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base("Breathing",
                   "This activity will help you relax by walking your through breathing in and out slowly. " +
                   "Clear your mind and focus on your breathing.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();

            int elapsed = 0;
            bool breatheIn = true;

            while (elapsed < Duration)
            {
                Console.WriteLine();
                Console.WriteLine(breatheIn ? "Breathe in..." : "Breathe out...");
                ShowCountDown(4);
                elapsed += 4;
                breatheIn = !breatheIn;
            }

            DisplayEndingMessage();
        }
    }
}
