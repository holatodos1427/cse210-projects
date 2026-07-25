using System;
using System.Collections.Generic;
using System.Linq;


/// represent full scripture ; a reference plus the text, broken into individual Word objects. Handles hiding random words and reporting whether the whole scripture is fully hidden.
public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private static readonly Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(w => new Word(w))
            .ToList();
    }

    // this will hide up the <paramref name="count"/> words that are not already hidden, chosing randomly
    public void HideRandomWords(int count)
    {
        List<int> visibleIndices = Enumerable.Range(0, _words.Count)
            .Where(i => !_words[i].IsHidden)
            .ToList();

        int numberToHide = Math.Min(count, visibleIndices.Count);

        for (int i = 0; i < numberToHide; i++)
        {
            int pick = _random.Next(visibleIndices.Count);
            int wordIndex = visibleIndices[pick];
            _words[wordIndex].Hide();
            visibleIndices.RemoveAt(pick);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }

    // Percentage (0-100) of words currently hidden. Used to show progress.
    public int PercentHidden()
    {
        if (_words.Count == 0) return 100;
        int hiddenCount = _words.Count(w => w.IsHidden);
        return (int)Math.Round(100.0 * hiddenCount / _words.Count);
    }

    public override string ToString()
    {
        string verseText = string.Join(' ', _words.Select(w => w.ToString()));
        return $"{_reference}\n\n{verseText}";
    }
}