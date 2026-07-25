using System;
using System.Collections.Generic;

// creativity, this keeps a small library of the scriptures that the user can memorize, and this also allow the random selection of one of them.

public class ScriptureLibrary
{
    private readonly List<Scripture> _scriptures;
    private static readonly Random _random = new Random();

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart, and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."),

            new Scripture(
                new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me."),

            new Scripture(
                new Reference("Joshua", 1, 9),
                "Have not I commanded thee? Be strong and of a good courage; be not afraid, " +
                "neither be thou dismayed: for the Lord thy God is with thee whithersoever thou goest."),

            new Scripture(
                new Reference("Psalm", 23, 1, 4),
                "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: " +
                "he leadeth me beside the still waters. He restoreth my soul: he leadeth me in the paths " +
                "of righteousness for his name's sake. Yea, though I walk through the valley of the shadow " +
                "of death, I will fear no evil: for thou art with me."),
        };
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
