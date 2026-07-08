using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        string playAgain = "yes";

        while (playAgain == "yes")
        {
            int magicNumber = random.Next(1, 101);
            int guess = 0;
            int guessCount = 0;

            while (guess != magicNumber)
            {
                Console.Write("Welcome to the Magic Number guess! Guess a number between 1 and 100. Try it!\n");
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                    Console.WriteLine("It is higher");
                else if (guess > magicNumber)
                    Console.WriteLine("It is lower");
                else
                    Console.WriteLine("You guessed it!");
            }

            Console.WriteLine($"It took you {guessCount} guesses.");
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine().ToLower();
        }
    }
}