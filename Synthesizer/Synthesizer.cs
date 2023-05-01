using System.Text;
using OokCodeAnalyzer.Core;

namespace Synthesizer;

public static class Synthesizer
{

    public static void Main()
    {
        Console.WriteLine(SynthesizeOokCodeByStateMachine(30));
    }
    
    public static string SynthesizeOokCodeByStateMachine(int tokensLen)
    {
        if (tokensLen <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(tokensLen));
        }
        
        StringBuilder ookCode = new StringBuilder();
        OokStateMachine ookStateMachine = new OokStateMachine();

        for (int i = 0; i < tokensLen; i++)
        {
            OokStateMachine.State state = OokStateMachine.State.Word;
            while (state != OokStateMachine.State.End)
            {
                state = ookStateMachine.Funcs[state].Item2();
                switch (state)
                {
                    case OokStateMachine.State.OokDOokD:
                        ookCode.Append("Ook. Ook. ");
                        break;
                    case OokStateMachine.State.OokDOokE:
                        ookCode.Append("Ook. Ook! ");
                        break;
                    case OokStateMachine.State.OokDOokQ:
                        ookCode.Append("Ook. Ook? ");
                        break;
                    case OokStateMachine.State.OokEOokD:
                        ookCode.Append("Ook! Ook. ");
                        break;
                    case OokStateMachine.State.OokEOokE:
                        ookCode.Append("Ook! Ook! ");
                        break;
                    case OokStateMachine.State.OokEOokQ:
                        ookCode.Append("Ook! Ook? ");
                        break;
                    case OokStateMachine.State.OokQOokD:
                        ookCode.Append("Ook? Ook. ");
                        break;
                    case OokStateMachine.State.OokQOokE:
                        ookCode.Append("Ook? Ook! ");
                        break;
                }
            }
        }

        return ookCode.ToString();
    }
    
    public static string SynthesizeOokCode(int tokensLen)
    {
        if (tokensLen <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(tokensLen));
        }
        
        StringBuilder ookCode = new StringBuilder();
        Random random = new Random();
        int wordsCount = OokWord.CountWords();
        
        ookCode.Append(OokWord.GetWordByIndex(random.Next(wordsCount)));
        
        for (int i = 1; i < tokensLen; i++)
        {
        ookCode.Append(' ').Append(OokWord.GetWordByIndex(random.Next(wordsCount)));
        }

        return ookCode.ToString();
    }
}