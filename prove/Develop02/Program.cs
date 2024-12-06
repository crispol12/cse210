using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal (to journal.txt)");
            Console.WriteLine("4. Load the journal (from journal.txt)");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
            {
                Console.WriteLine("\nInvalid input. Please enter a number between 1 and 5.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n-- Write a New Entry --");
                    journal.AddEntry();
                    break;
                case 2:
                    Console.WriteLine("\n-- Display the Journal --");
                    journal.DisplayAll();
                    break;
                case 3:
                    Console.WriteLine("\n-- Save the Journal --");
                    journal.SaveToFile(); // Crea y guarda en journal.txt
                    break;
                case 4:
                    Console.WriteLine("\n-- Load the Journal --");
                    journal.LoadFromFile(); // Carga y muestra journal.txt
                    break;
                case 5:
                    Console.WriteLine("\nGoodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please select a number between 1 and 5.");
                    break;
            }

            Console.WriteLine();
        }
    }
}