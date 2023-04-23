namespace OokCodeAnalyzer.Core;

public static class OokWord
{
    private static readonly List<string> Words = new List<string>();

    static OokWord()
    {
        Words.Add("Ook. Ook.");
        Words.Add("Ook! Ook!");
        Words.Add("Ook. Ook?");
        Words.Add("Ook? Ook.");
        Words.Add("Ook! Ook?");
        Words.Add("Ook? Ook!");
        Words.Add("Ook! Ook.");
        Words.Add("Ook. Ook!");
    }

    public static bool IsOokWord(string possibleWord) =>
        Words.Contains(possibleWord);

    public static int CountWords() =>
        Words.Count;
    public static string GetWordByIndex(int index)
    {
        if (index < 0 || index >= Words.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }
        
        return Words[index];
    }
}