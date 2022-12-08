namespace solutions._2022;

public static class Day06
{
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();

        return FindFirstPositionOfUniqueString(4, input);
    }

    private static int FindFirstPositionOfUniqueString(int stringLength, string input)
    {
        var upper = input.Length;
        var lengthIndex = stringLength -1;
        
        for (var i = lengthIndex; i < upper; i++)
        {
            var currentCharacters = input.Skip(i - lengthIndex).Take(stringLength).Distinct();
            if (currentCharacters.Count() == stringLength)
            {
                return i + 1; // +1 to accomodate for starting index 0
            }
        }

        throw new Exception("Could not find correct value. Solution is wrong");
    }

    public static int Part_2(string? input = null)
    {
        input ??= GetInput();
        return FindFirstPositionOfUniqueString(14, input);
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day6/input.txt");
    }
}
