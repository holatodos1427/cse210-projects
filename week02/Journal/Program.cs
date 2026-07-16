using System;
using System.Text.Json;

// the journal now saves and loads as JSON instead of a plain text file, using System.Text.Json.
class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine();

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("What is the filename? ");
                    string saveName = Console.ReadLine();
                    journal.SaveToFile(saveName);
                    break;
                case "4":
                    Console.Write("What is the filename? ");
                    string loadName = Console.ReadLine();
                    journal.LoadFromFile(loadName);
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }

    // shows a random prompt, collect the response, and stores a new entry
    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry();
        newEntry._promptText = prompt;
        newEntry._entryText = response;
        newEntry._date = DateTime.Now.ToShortDateString();

        journal.AddEntry(newEntry);
    }
}