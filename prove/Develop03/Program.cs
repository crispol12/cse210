using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creamos una biblioteca de escrituras
            ScriptureLibrary library = new ScriptureLibrary();

            // Agregamos algunas escrituras de ejemplo a la biblioteca
            library.AddScripture(
                new Scripture(
                    new Reference("Proverbs", 3, 5, 6),
                    "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                    "In all thy ways acknowledge him, and he shall direct thy paths."
                )
            );

            library.AddScripture(
                new Scripture(
                    new Reference("John", 3, 16),
                    "For God so loved the world, that he gave his only begotten Son, " +
                    "that whosoever believeth in him should not perish, but have everlasting life."
                )
            );

            library.AddScripture(
                new Scripture(
                    new Reference("James", 1, 5),
                    "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, " +
                    "and upbraideth not; and it shall be given him."
                )
            );

            // Obtenemos una escritura al azar de la biblioteca
            
            Scripture selectedScripture = library.GetRandomScripture();

            Console.Clear();
            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine("-------------------");
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press ENTER to hide a few words or type 'quit' to exit.");

            // Bucle principal
            while (true)
            {
                string userInput = Console.ReadLine().Trim().ToLower();

                if (userInput == "quit")
                {
                    Console.WriteLine("Thanks for using the Scripture Memorizer. Goodbye!");
                    break;
                }

                if (string.IsNullOrEmpty(userInput))
                {
                    // Ocultar algunas palabras
                    selectedScripture.HideRandomWords(3);
                    Console.Clear();
                    Console.WriteLine("Scripture Memorizer");
                    Console.WriteLine("-------------------");
                    Console.WriteLine(selectedScripture.GetDisplayText());
                    Console.WriteLine();

                    if (selectedScripture.IsCompletelyHidden())
                    {
                        Console.WriteLine("All words are now hidden. See if you can recite it from memory!");
                        Console.WriteLine("Program will now end. Great job!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Press ENTER to hide more words or type 'quit' to exit.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Press ENTER to continue hiding words or type 'quit' to exit.");
                }
            }
        }
    }
}
