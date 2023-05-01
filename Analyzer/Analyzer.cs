using System.Text;
using System.Text.RegularExpressions;
using OokCodeAnalyzer.Core;
using Synthesizer;

namespace Analyzer;

public static class Analyzer
{
    public static IEnumerable<string> ScrapTextForLexemes(string text)
    {
        List<string> lexemes = new List<string>();

        OokStateMachine ookStateMachine = new OokStateMachine();
        OokStateMachine.State state = OokStateMachine.State.Begin;
        
        char[] ch = new Char[1];

        int i = 1;

        using (StringReader stringReader = new StringReader(text))
        {
            while (stringReader.Read(ch, 0, 1) >= 1 && state != OokStateMachine.State.Error)
            {
                state = ookStateMachine.Funcs[state].Item1(ch[0]);
                switch (state)
                {
                    case OokStateMachine.State.OokDOokD:
                        lexemes.Add($"Lexeme: \"Ook. Ook.\" #{i++}.");
                        break;
                    case OokStateMachine.State.OokDOokE:
                        lexemes.Add($"Lexeme: \"Ook. Ook!\" #{i++}.");
                        break;
                    case OokStateMachine.State.OokDOokQ:
                        lexemes.Add($"Lexeme: \"Ook. Ook?\" #{i++}.");
                        break;
                    case OokStateMachine.State.OokEOokD:
                        lexemes.Add($"Lexeme: \"Ook! Ook.\" #{i++}.");
                        break;
                    case OokStateMachine.State.OokEOokE:
                        lexemes.Add($"Lexeme: \"Ook! Ook!\" #{i++}.");
                        break;
                    case OokStateMachine.State.OokEOokQ:
                        lexemes.Add($"Lexeme: \"Ook! Ook?\" #{i++}.");
                        break;
                    case OokStateMachine.State.OokQOokD:
                        lexemes.Add($"Lexeme: \"Ook? Ook.\" #{i++}.");
                        break;
                    case OokStateMachine.State.OokQOokE:
                        lexemes.Add($"Lexeme: \"Ook? Ook!\" #{i++}.");
                        break;
                }
            }
            if (state == OokStateMachine.State.Error)
            {
                lexemes.Add("Error occured"); 
            }
        }

        return lexemes;
    }
}