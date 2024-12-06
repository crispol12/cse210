using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;
    private PromptGenerator _promptGenerator;

    public Journal()
    {
        _entries = new List<Entry>();
        _promptGenerator = new PromptGenerator();
    }

    public void AddEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry(prompt, response);
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile()
    {
        string filename = "journal.txt";
        try
        {
            // Abrir el archivo y escribir los prompts, incluso si no hay entradas
            using (StreamWriter writer = new StreamWriter(filename))
            {
                if (_entries.Count == 0)
                {
                    // Si no hay entradas, aún escribimos un mensaje inicial
                    writer.WriteLine("No journal entries available yet.");
                }
                else
                {
                    foreach (Entry entry in _entries)
                    {
                        writer.WriteLine(entry.ToCSV());
                    }
                }
            }

            Console.WriteLine($"Journal saved to {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving the journal: {ex.Message}");
        }
    }

    public void LoadFromFile()
    {
        string filename = "journal.txt";
        if (File.Exists(filename))
        {
            try
            {
                _entries.Clear();
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines)
                {
                    Entry entry = Entry.FromCSV(line);
                    if (entry != null)
                    {
                        _entries.Add(entry);
                    }
                }
                Console.WriteLine($"Journal loaded from {filename}.\n");

                DisplayAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading the journal: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"File {filename} not found.\n");
        }
    }
}