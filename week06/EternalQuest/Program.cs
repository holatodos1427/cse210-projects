using System;

namespace EternalQuest
{
    class Program
    {
        // ---------------------------------------------------------------
        // How I exceeded the requirements (David):
        //
        // 1. Leveling system - the score turns into a "level", and each
        //    level has a silly title (like the "Ninja Unicorn" example
        //    from the assignment). It shows on the main menu every time
        //    and prints a "Level up!" message when you cross into a new
        //    level.
        //
        // 2. Added a whole new goal type that wasn't asked for:
        //    NegativeGoal. It's for bad habits - instead of earning
        //    points, you lose them every time you record it. It still
        //    inherits from the same base Goal class and gets treated
        //    just like any other goal everywhere else in the program.
        //
        // 3. EternalGoal and NegativeGoal both keep a running count of
        //    how many times they've been recorded and show it in the
        //    goal details, so it doesn't feel like nothing is happening
        //    even though those goals never technically finish.
        // ---------------------------------------------------------------
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Eternal Quest program!");
            Console.WriteLine("Track your goals, earn points, and level up along the way.");

            GoalManager manager = new GoalManager();
            manager.Start();
        }
    }
}
