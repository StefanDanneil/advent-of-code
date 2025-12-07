using System.Numerics;

namespace solutions._2025;

public static class Day03
{
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var rows = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        return rows.Sum(row => FindLargestDoubleJoltage(row.ToArray()));
    }

    private static int FindLargestDoubleJoltage(char[] input)
    {
        var firstPosition = 0;
        var firstNumber = "";
        var secondNumber = "";

        // skip last position
        for (var i = 0; i < input.Length -1; i++)
        {
            var number = int.Parse(input[i].ToString());
            
            if (firstNumber == "" || number > int.Parse(firstNumber))
            {
                firstPosition = i;
                firstNumber = input[i].ToString();
            }

            if (number == 9)
            {
                break;
            }
        }
        
        // skip first position
        for (var i = firstPosition +1; i < input.Length; i++)
        {
            var number = int.Parse(input[i].ToString());
            
            if (secondNumber == "" || number > int.Parse(secondNumber))
            {
                secondNumber = input[i].ToString();
            }

            if (number == 9)
            {
                break;
            }
        }
        
        return int.Parse(firstNumber + secondNumber);
    }
    
    public static BigInteger Part_2(string? input = null)
    {
        input ??= GetInput();
        var rows = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        BigInteger totalJoltage = 0;
        foreach (var row in rows)
        {
            totalJoltage += FindLargestTwelveJoltage(row.ToArray());
        }

        return totalJoltage;
    }
    
    private static BigInteger FindLargestTwelveJoltage(char[] input)
    {
        var numbers = new List<int>();
        var previousLargestPosition = -1;
        var numbersLeft = 12;

        for (var i = 0; i < 12; i++)
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
