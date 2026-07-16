using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

// the Journal should class holds the list of entries and the operations that act on that list.
public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        IncludeFields = true,
        WriteIndented = true
    };

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty. Write an entry first!");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        string json = JsonSerializer.Serialize(_entries, _jsonOptions);
        File.WriteAllText(filename, json);
        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string json = File.ReadAllText(filename);
        _entries = JsonSerializer.Deserialize<List<Entry>>(json, _jsonOptions) ?? new List<Entry>();
        Console.WriteLine("Journal loaded.");
    }
}
