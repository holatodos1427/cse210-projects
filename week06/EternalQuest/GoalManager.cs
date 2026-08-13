using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        private static readonly string[] _levelTitles = new string[]
        {
            "Sleepy Sloth",
            "Wandering Wanderer",
            "Rookie Adventurer",
            "Scripture Scout",
            "Diligent Disciple",
            "Faithful Follower",
            "Steady Saint",
            "Quiet Warrior",
            "Covenant Keeper",
            "Ninja Unicorn",
            "Radiant Guardian",
            "Eternal Champion",
            "Legendary Soul"
        };

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }
        public void Start()
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine();
                DisplayPlayerInfo();
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goal Names");
                Console.WriteLine("  3. List Goal Details");
                Console.WriteLine("  4. Record Event");
                Console.WriteLine("  5. Save Goals");
                Console.WriteLine("  6. Load Goals");
                Console.WriteLine("  7. Quit");
                Console.Write("Select a choice from the menu: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoalNames();
                        break;
                    case "3":
                        ListGoalDetails();
                        break;
                    case "4":
                        RecordEvent();
                        break;
                    case "5":
                        SaveGoals();
                        break;
                    case "6":
                        LoadGoals();
                        break;
                    case "7":
                        keepGoing = false;
                        Console.WriteLine("Keep working toward your Eternal Quest. See you next time!");
                        break;
                    default:
                        Console.WriteLine("That's not a valid choice, try again.");
                        break;
                }
            }
        }

        public void DisplayPlayerInfo()
        {
            int level = (_score / 1000) + 1;

            int titleIndex = Math.Min(level - 1, _levelTitles.Length - 1);
            string title = _levelTitles[titleIndex];

            Console.WriteLine($"Score: {_score} points");
            Console.WriteLine($"Level {level}: {title}");
        }

        public void ListGoalNames()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("You don't have any goals yet. Create one first!");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
            }
        }

        public void ListGoalDetails()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("You don't have any goals yet. Create one first!");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        public void CreateGoal()
        {
            Console.WriteLine("What type of goal would you like to create?");
            Console.WriteLine("  1. Simple Goal (done once, like running a marathon)");
            Console.WriteLine("  2. Eternal Goal (never finishes, like reading scriptures)");
            Console.WriteLine("  3. Checklist Goal (done a set number of times, like temple visits)");
            Console.WriteLine("  4. Negative Goal (a bad habit you're trying to avoid)");
            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            Console.Write("What is the name of the goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("How many points is this goal worth? ");
            int points = int.Parse(Console.ReadLine());

            Goal newGoal = null;

            switch (choice)
            {
                case "1":
                    newGoal = new SimpleGoal(name, description, points);
                    break;
                case "2":
                    newGoal = new EternalGoal(name, description, points);
                    break;
                case "3":
                    Console.Write("How many times does this goal need to be completed? ");
                    int target = int.Parse(Console.ReadLine());
                    Console.Write("What bonus should the user get for finishing it? ");
                    int bonus = int.Parse(Console.ReadLine());
                    newGoal = new ChecklistGoal(name, description, points, target, bonus);
                    break;
                case "4":
                    newGoal = new NegativeGoal(name, description, points);
                    break;
                default:
                    Console.WriteLine("That's not a valid goal type.");
                    return;
            }

            _goals.Add(newGoal);
            Console.WriteLine("Goal added!");
        }

        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("You don't have any goals yet. Create one first!");
                return;
            }

            ListGoalNames();
            Console.Write("Which goal did you accomplish? ");
            string input = Console.ReadLine();
            int index;

            if (!int.TryParse(input, out index) || index < 1 || index > _goals.Count)
            {
                Console.WriteLine("That's not a valid goal number.");
                return;
            }

            Goal goal = _goals[index - 1];
            int levelBefore = (_score / 1000) + 1;

            goal.RecordEvent();
            _score += goal.PointsEarned;

            if (goal.PointsEarned >= 0)
            {
                Console.WriteLine($"Nice work! You earned {goal.PointsEarned} points.");
            }
            else
            {
                Console.WriteLine($"That's ok, it happens. You lost {-goal.PointsEarned} points, keep trying!");
            }

            if (goal.IsComplete())
            {
                Console.WriteLine($"Congratulations, you finished the goal: {goal.GetName()}!");
            }

            int levelAfter = (_score / 1000) + 1;
            if (levelAfter > levelBefore)
            {
                Console.WriteLine($"Level up! You are now level {levelAfter}!");
            }
        }

        public void SaveGoals()
        {
            Console.Write("What file would you like to save to? ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved!");
        }

        public void LoadGoals()
        {
            Console.Write("What file would you like to load from? ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("That file doesn't seem to exist.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);

            _goals = new List<Goal>();
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                Goal goal = CreateGoalFromString(lines[i]);
                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }

            Console.WriteLine("Goals loaded!");
        }

        private Goal CreateGoalFromString(string line)
        {
            string[] pieces = line.Split(':');
            string type = pieces[0];
            string[] details = pieces[1].Split(',');

            switch (type)
            {
                case "SimpleGoal":
                    return new SimpleGoal(details[0], details[1], int.Parse(details[2]), bool.Parse(details[3]));
                case "EternalGoal":
                    return new EternalGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]));
                case "ChecklistGoal":
                    return new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]), int.Parse(details[4]), int.Parse(details[5]));
                case "NegativeGoal":
                    return new NegativeGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[3]));
                default:
                    return null;
            }
        }
    }
}
