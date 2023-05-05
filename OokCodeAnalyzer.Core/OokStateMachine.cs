namespace OokCodeAnalyzer.Core;

public static class OokStateMachine
{
    public enum State
    {
        Begin,
        Word,
        O,
        Oo,
        Ook,
        OokD,
        OokE,
        OokQ,
        OokDO,
        OokDOo,
        OokDOok,
        OokDOokD,
        OokDOokE,
        OokDOokQ,
        OokEO,
        OokEOo,
        OokEOok,
        OokEOokD,
        OokEOokE,
        OokEOokQ,
        OokQO,
        OokQOo,
        OokQOok,
        OokQOokD,
        OokQOokE,
        Error
    }

    private static Random _random = new Random();
    public static Dictionary<State,  (Func<char, State>, Func<State>)> Funcs { get; }


    private static State RandomState(State[] states) =>
        states[_random.Next(states.Length)];
        
    static OokStateMachine()
    {
        Funcs = new Dictionary<State, (Func<char, State>, Func<State>)>
        {
            { State.Begin, (ch => char.IsWhiteSpace(ch) ? State.Begin : ch == 'O' ? State.O : State.Word, () => State.Word) },
            { State.Word, ( ch => ch == 'O' ? State.O : State.Error, () => State.O ) },
            { State.O, ( ch => ch == 'o' ? State.Oo : State.Error, () => State.Oo ) },
            { State.Oo, ( ch => ch == 'k' ? State.Ook : State.Error, () => State.Ook ) },
            {
                State.Ook, ( ch => ch switch
                {
                    '.' => State.OokD,
                    '!' => State.OokE,
                    '?' => State.OokQ,
                    _ => State.Error
                },
                () => RandomState(new []{State.OokD, State.OokE, State.OokQ})
            ) },
            { State.OokD, ( ch => char.IsWhiteSpace(ch) ? State.OokD : (ch == 'O' ? State.OokDO : State.Error), () => State.OokDO ) },
            { State.OokDO, ( ch => ch == 'o' ? State.OokDOo : State.Error, () => State.OokDOo ) },
            { State.OokDOo, ( ch => ch == 'k' ? State.OokDOok : State.Error, () => State.OokDOok ) },
            {
                State.OokDOok, ( ch => ch switch
                {
                    '.' => State.OokDOokD,
                    '!' => State.OokDOokE,
                    '?' => State.OokDOokQ,
                    _ => State.Error
                },
                () => RandomState(new [] {State.OokDOokD, State.OokDOokE, State.OokDOokQ})
            ) },
            { State.OokDOokD, ( ch => State.Begin, () => State.Begin ) },
            { State.OokDOokE, ( ch => State.Begin, () => State.Begin ) },
            { State.OokDOokQ, ( ch => State.Begin, () => State.Begin ) },
            { State.OokE, ( ch => char.IsWhiteSpace(ch) ? State.OokE : (ch == 'O' ? State.OokEO : State.Error), () => State.OokEO ) },
            { State.OokEO, ( ch => ch == 'o' ? State.OokEOo : State.Error, () => State.OokEOo ) },
            { State.OokEOo, ( ch => ch == 'k' ? State.OokEOok : State.Error, () => State.OokEOok ) },
            {
                State.OokEOok, ( ch => ch switch
                {
                    '.' => State.OokEOokD,
                    '!' => State.OokEOokE,
                    '?' => State.OokEOokQ,
                    _ => State.Error
                },
                () => RandomState(new [] {State.OokEOokD, State.OokEOokE, State.OokEOokQ})
            ) },
            { State.OokEOokD, ( ch => State.Begin, () => State.Begin ) },
            { State.OokEOokE, ( ch => State.Begin, () => State.Begin ) },
            { State.OokEOokQ, ( ch => State.Begin, () => State.Begin ) },
            { State.OokQ, ( ch => char.IsWhiteSpace(ch) ? State.OokQ : (ch == 'O' ? State.OokQO : State.Error), () => State.OokQO ) },
            { State.OokQO, ( ch => ch == 'o' ? State.OokQOo : State.Error, () => State.OokQOo ) },
            { State.OokQOo, ( ch => ch == 'k' ? State.OokQOok : State.Error, () => State.OokQOok ) },
            {
                State.OokQOok, ( ch => ch switch
                {
                    '.' => State.OokQOokD,
                    '!' => State.OokQOokE,
                    _ => State.Error
                },
                () => RandomState(new [] { State.OokQOokD, State.OokQOokE})
            ) },
            { State.OokQOokD, ( ch => State.Begin, () => State.Begin ) },
            { State.OokQOokE, ( ch => State.Begin, () => State.Begin ) },
        };
    }



}