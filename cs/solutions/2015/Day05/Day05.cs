namespace solutions._2015;

public static class Day05
{

    public static int Part_1(string? input = null)
    {
        input = input ?? GetInput();
        var inputs = input.Split('\n');

        return inputs.Count(s => HasRepeatingCharacter(s) && HasAtLeastThreeVowels(s) && !ContainsForbiddenString(s));
    }
    
    public static int Part_2(string? input = null)
    {
        input = input ?? GetInput();
        var inputs = input.Split('\n');

        return inputs.Count(s => HasRepeatingLetterSandwich(s) && HasNonOverlappingRepeatingPair(s));
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2015/Day5/input.txt");
    }

    private static bool HasAtLeastThreeVowels(string input)
    {
        const string vowels = "aeiou";
        var occurrences = 0;
        foreach (var unused in input.Where(c => vowels.Contains(c)))
        {
            occurrences++;
            if (occurrences >= 3)
            {
                return true;
            }
        }

        return false;
    }

    private static bool ContainsForbiddenString(string input)
    {
        var forbiddenStrings = new []
        {
            "ab", 
            "cd", 
            "pq", 
            "xy"
        };

        return forbiddenStrings.Any(input.Contains);
    }
    
    private static bool HasRepeatingCharacter(string input)
    {
        for (var i = 1; i < input.Length; i++)
        {
            if (input[i] == input[i - 1])
            {
                return true;
            }
        }

        return false;
    }

    private static bool HasRepeatingLetterSandwich(string input)
    {
        for (var i = 2; i < input.Length; i++)
        {
            if (input[i] == input[i - 2])
            {
                return true;
            }
        }
        
        return false;
    }

    private static bool HasNonOverlappingRepeatingPair(string input)
    {
        for (var i = 2; i < input.Length; i++)
        {
            var currentTest = input.Substring(i - 2, 2);
            for (var j = i + 2; j <= input.Length; j++)
            {
                if (currentTest == input.Substring(j - 2, 2))
                {
                    return true;
                }
            }
        }
        
        return false;
    }
}
