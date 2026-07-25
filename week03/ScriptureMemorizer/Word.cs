using System.Text;

// one word in a scripture. the word can be shown normally or hidden
public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public override string ToString()
    {
        if (!_isHidden)
        {
            return _text;
        }

        var hidden = new StringBuilder();
        foreach (char c in _text)
        {
            hidden.Append(char.IsLetterOrDigit(c) ? '_' : c);
        }
        return hidden.ToString();
    }
}