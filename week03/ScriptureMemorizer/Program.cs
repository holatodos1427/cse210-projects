using System;

class Program
{
    static void Main(string[] args)
    {
        var library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();

        int wordsPerRound = ChooseDifficulty();

        while (true)
        {
            Console.Clear();
            DisplayScripture(scripture);

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("You've hidden the whole scripture. Great work memorizing!");
                break;
            }

            Console.Write("\nPress Enter to hide more words, or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (string.Equals(input?.Trim(), "quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            scripture.HideRandomWords(wordsPerRound);
        }
    }

    // This should allot the user pick how many words disappear each round, so they can control the pace of the challenge.
    static int ChooseDifficulty()
    {
        Console.Clear();
        Console.WriteLine("Scripture Memorizer");
        Console.WriteLine("===================");
        Console.WriteLine("How many words should disappear each round?");
        Console.WriteLine("  1) Easy   (1 word)");
        Console.WriteLine("  2) Medium (3 words)");
        Console.WriteLine("  3) Hard   (6 words)");
        Console.Write("Choose 1, 2, or 3: ");

        string choice = Console.ReadLine()?.Trim();
        return choice switch
        {
            "1" => 1,
            "3" => 6,
            _ => 3,
        };
    }

    static void DisplayScripture(Scripture scripture)
    {
        Console.WriteLine(scripture);
        Console.WriteLine($"\n[Progress: {scripture.PercentHidden()}% hidden]");
    }
}