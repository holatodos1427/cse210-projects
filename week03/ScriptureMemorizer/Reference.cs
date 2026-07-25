using System;

// shows the reference for a part of a scripture, supporting both single-verse and verse-range references through separate constructors.

public class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _startVerse;
    private readonly int _endVerse;

    public Reference(string book, int chapter, int verse)
        : this(book, chapter, verse, verse)
    {
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        if (string.IsNullOrWhiteSpace(book))
        {
            throw new ArgumentException("Book name cannot be empty.", nameof(book));
        }
        if (endVerse < startVerse)
        {
            throw new ArgumentException("End verse cannot be before start verse.");
        }

        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        return _startVerse == _endVerse
            ? $"{_book} {_chapter}:{_startVerse}"
            : $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}