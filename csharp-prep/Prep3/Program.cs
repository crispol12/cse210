using System;

class Program
{
    static void Main()
    {
        Random randomGenerator = new Random();
        string playAgain = "yes";

        while (playAgain == "yes")
        {
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("\nWelcome to the 'Guess My Number' game!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string userInput = Console.ReadLine();

                bool isValidNumber = int.TryParse(userInput, out guess);

                if (!isValidNumber)
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! The number was {magicNumber}.");
                    Console.WriteLine($"It took you {guessCount} tries.");
                }
            }

            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine().ToLower();

            while (playAgain != "yes" && playAgain != "no")
            {
                Console.Write("Please answer 'yes' or 'no': ");
                playAgain = Console.ReadLine().ToLower();
            }
        }

        Console.WriteLine("Thanks for playing! See you next time!");
    }
}