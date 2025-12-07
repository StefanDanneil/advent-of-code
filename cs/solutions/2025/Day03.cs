using System.Numerics;

namespace solutions._2025;

public static class Day03
{
    public static BigInteger Part_1(string? input = null)
    {
        input ??=  GetInput();
        var rows = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        BigInteger totalJoltage = 0;
        
        foreach (var row in rows)
        {
            totalJoltage += FindLargestNJoltage(row.ToArray(), 2);
        }

        return totalJoltage;
    }
    
    public static BigInteger Part_2(string? input = null)
    {
        input ??= GetInput();
        var rows = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        BigInteger totalJoltage = 0;
        foreach (var row in rows)
        {
            totalJoltage += FindLargestNJoltage(row.ToArray(), 12);
        }

        return totalJoltage;
    }
    
    private static BigInteger FindLargestNJoltage(char[] input, int n)
    {
        var numbers = new List<int>();
        var previousLargestPosition = -1;
        var numbersLeft = n;

        for (var i = 0; i < n; i++)
        {
            var largestNumber = 0;
            for (var j = previousLargestPosition + 1; j < input.Length - (numbersLeft-1); j++)
            {
                if (int.Parse(input[j].ToString()) > largestNumber)
                {
                    largestNumber = int.Parse(input[j].ToString());
                    previousLargestPosition = j;
                }

                if (largestNumber == 9)
                {
                    break;
                }
            } 
            
            numbers.Add(largestNumber);
            numbersLeft--;
        }
        
        return BigInteger.Parse(string.Join("", numbers.Select(n => n.ToString())));
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2025/Input/Day03.txt");
    }
}
