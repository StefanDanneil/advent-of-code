namespace solutions._2015;

public class Day5
{

    public int Part_1(string? input = null)
    {
        input = input ?? GetInput();
        string[] inputs = input.Split('\n');
        int niceCount = 0;
        
        foreach (var s in inputs)
        {
            if (HasRepeatingCharacter(s) && HasAtLeastThreeVowels(s) && !ContainsForbiddenString(s))
            {
                niceCount++;
            }
        }

        return niceCount;
    }
    
    public int Part_2(string? input = null)
    {
        input = input ?? GetInput();
        string[] inputs = input.Split('\n');
        int niceCount = 0;
        
        foreach (var s in inputs)
        {
            if (HasRepeatingLetterSandwich(s) && HasNonOverlappingRepeatingPair(s))
            {
                niceCount++;
            }
        }

        return niceCount;
    }

    private string GetInput()
    {
        return File.ReadAllText("./2015/Day5/input.txt");
    }

    private bool HasAtLeastThreeVowels(string input)
    {
        const string vowels = "aeiou";
        var occurrences = 0;
        foreach (var c in input.Where(c => vowels.Contains(c)))
        {
            occurrences++;
            if (occurrences >= 3)
            {
                return true;
            }
        }

        return false;
    }

    private bool ContainsForbiddenString(string input)
    {
        var forbiddenStrings = new string[]
        {
            "ab", 
            "cd", 
            "pq", 
            "xy"
        };

        return forbiddenStrings.Any(input.Contains);
    }
    
    private bool HasRepeatingCharacter(string input)
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

    private bool HasRepeatingLetterSandwich(string input)
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

    private bool HasNonOverlappingRepeatingPair(string input)
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
