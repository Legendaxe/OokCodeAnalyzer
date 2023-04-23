using OokCodeAnalyzer.Core;
using Synthesizer;

namespace Analyzer;

public class Analyzer
{

    private enum State
    {
        
    }
    
    public static void Main()
    {
        ScrapTextForLexemes(Synthesizer.Synthesizer.SynthesizeOokCode(5) + "asdasdsdfsadfs" + Synthesizer.Synthesizer.SynthesizeOokCode(5));
    }
    public static IEnumerable<string> ScrapTextForLexemes(string text)
    {
        List<string> lexemes = new List<string>();
        string lexeme;
        
        text = text.ReplaceLineEndings("").Replace(" ", "");
        int i = 0;
        while (i < text.Length)
        {
            if (i + 9 > text.Length)
            {
                lexemes.Add($"Error occured, this is not a lexeme: {text.Substring(i)}");
                break;
            }

            lexeme = text.Substring(i, 9);
            if (OokWord.IsOokWord(lexeme))
            {
                lexemes.Add($"Lexeme: \"{lexeme}\" #{lexemes.Count + 1}");
            }
            else
            {
                lexemes.Add($"Error occured, this is not a lexeme: {lexeme}");
                break;
            }

            i += 9;
        }

        return lexemes;
    }
}