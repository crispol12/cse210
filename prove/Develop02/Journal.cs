using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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

    // Guardar en formato JSON
    public void SaveToFile()
    {
        string filename = "journal.json"; // Guardar en formato JSON
        try
        {
            string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filename, json); // Guardar el JSON en el archivo
            Console.WriteLine($"Journal saved to {filename}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving the journal: {ex.Message}");
        }
    }

    // Cargar desde formato JSON
    public void LoadFromFile()
    {
        string filename = "journal.json"; // Cargar desde archivo JSON
        if (File.Exists(filename))
        {
            try
            {
                string json = File.ReadAllText(filename); // Leer el contenido del archivo
                _entries = JsonSerializer.Deserialize<List<Entry>>(json) ?? new List<Entry>(); // Convertir de JSON a objetos
                Console.WriteLine($"Journal loaded from {filename}.\n");

                DisplayAll(); // Mostrar las entradas cargadas
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
