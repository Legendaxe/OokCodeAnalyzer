using System.Text;
using OokCodeAnalyzer.Core;

namespace Synthesizer;

public static class Synthesizer
{
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