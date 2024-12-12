using System.Text.RegularExpressions;

namespace solutions._2024;

public static class Day03
{
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
                                
        var matches = regex.Matches(input);

        var output = 0;
        
        foreach (Match match in matches)
        {
            output += int.Parse(match.Groups[1].Captures.First().Value) * int.Parse(match.Groups[2].Captures.First().Value);
        }
        
        return output;
    }

    public static int Part_2(string? input = null)
    {
        input ??=  GetInput();
        
        var modifiedInput = Regex.Replace(input, @"don't\(\).*?do\(\)", "", RegexOptions.Singleline);
        
        var regex = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
                                
        var matches = regex.Matches(modifiedInput);

        var output = 0;
        
        foreach (Match match in matches)
        {
            output += int.Parse(match.Groups[1].Captures.First().Value) * int.Parse(match.Groups[2].Captures.First().Value);
        }
        
        return output;
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2024/Day03/input.txt");
    }
}
