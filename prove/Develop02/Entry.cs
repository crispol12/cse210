using System;

public class Entry
{
    // Attributes
    private string _date;
    private string _promptText;
    private string _entryText;

    // Constructor
    public Entry(string promptText, string entryText)
    {
        _date = DateTime.Now.ToShortDateString();
        _promptText = promptText;
        _entryText = entryText;
    }

    // Display method
    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine();
    }

    // CSV serialization for saving
    public string ToCSV()
    {
        return $"{_date}|{_promptText}|{_entryText}";
    }

    // CSV deserialization for loading
    public static Entry FromCSV(string csv)
    {
        string[] parts = csv.Split('|');
        if (parts.Length == 3)
        {
            return new Entry(parts[1], parts[2]) { _date = parts[0] };
        }
        return null;
    }
}