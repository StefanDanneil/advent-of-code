using System.Text.RegularExpressions;

namespace solutions._2015;

public static class Day10
{
    public static int Part_1(string input = "3113322113", int iterations = 40)
    {
        var say = input;
        
        for (var i = 1; i <= iterations; i++)
        {
            say = LookAndSay(say);
        }

        return say.Length;
    }

    public static string LookAndSay(string say) {
        // blatantly stolen from https://www.reddit.com/r/adventofcode/comments/3w6h3m/comment/cxtso95/?utm_source=share&utm_medium=web2x&context=3 
        // This was after I couldn't make it performant enough for part 2. This regex is still black magic for me...
        var captures = Regex.Match(say, @"((.)\2*)+").Groups[1].Captures;
        
        return string.Concat(
            from c in captures
            let v = c.Value
            select v.Length + v[..1]);
    }

    public static IEnumerable<string> LookAndSay(IEnumerable<string> lookParts)
    {
        return lookParts.Select(LookAndSay).ToList();
    }
}
