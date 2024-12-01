using System;

class Program
{
    static void Main()
    {
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();


        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Mostrar el resultado en el formato deseado
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
