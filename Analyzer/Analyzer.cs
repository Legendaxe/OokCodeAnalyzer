using System.Text;
using System.Text.RegularExpressions;
using OokCodeAnalyzer.Core;
using Synthesizer;

namespace Analyzer;

public static class Analyzer
{
    public static IEnumerable<string> ScrapTextForLexemes(string text)
    {
        Regex regex = new Regex("(((Ook[!?.]\\s*Ook[!.])|(Ook[!.]\\s*Ook\\?))\\s*)+");
        
        int i = 1;
        Match match = regex.Match(text); 
        
        List<string> lexemes = match.Groups[2].Captures.Select(lex => $"Lexeme: \"{lex.Value}\" #{i++}").ToList();
        if (match.Length < text.Length)
        {
            lexemes.Add($"Error occured on {match.Length + 1} symbol");
        }

        return lexemes;
    }
}