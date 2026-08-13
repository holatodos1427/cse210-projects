using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make one of each activity and put them all in the same list.
            List<Activity> activities = new List<Activity>();

            activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
            activities.Add(new Cycling(new DateTime(2022, 11, 3), 45, 12.0));
            activities.Add(new Swimming(new DateTime(2022, 11, 3), 30, 40));

            // Doesn't matter what type each one is, GetSummary() just works.
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
