using System.Numerics;

namespace solutions._2025;

public static class Day02
{
    public static BigInteger Part_1(string? input = null)
    {
        input ??=  GetInput();
        var ranges = input.Split(',');

        BigInteger sum = 0;
        
        foreach (var range in ranges)
        {
            var split = range.Split('-');
            var lower = BigInteger.Parse(split[0]);
            var upper = BigInteger.Parse(split[1]);

            for (var i = lower; i <= upper; i++)
            {
                var numberString = i.ToString();

                if (numberString.Length % 2 != 0) continue;
                
                var half = numberString.Length / 2;
                if (numberString[..half] == numberString[half..])
                {
                    sum += i;
                }
            }
        }

        return sum;
    }

    public static BigInteger Part_2(string? input = null)
    {
        input ??= GetInput();
        var ranges = input.Split(',');

        BigInteger sum = 0;
        
        foreach (var range in ranges)
        {
            var split = range.Split('-');
            var lower = BigInteger.Parse(split[0]);
            var upper = BigInteger.Parse(split[1]);

            for (var i = lower; i <= upper; i++)
            {
                if (i < 10) continue;
                var numberString = i.ToString();
                
                // all numbers are equal
                if (numberString.AsEnumerable().Distinct().Count() == 1)
                {
                    sum += i;
                    continue;
                } 
                if ( numberString.Length != 5 && numberString.Length % 5 == 0)
                {
                    var setsOfFive = SplitBy(numberString, 5);
                    if (setsOfFive.AsEnumerable().Distinct().Count() == 1)
                    {
                        sum += i;
                        continue;
                    };
                } 
                if ( numberString.Length != 4 && numberString.Length % 4 == 0)
                {
                    var setsOfFour = SplitBy(numberString, 4);
                    if (setsOfFour.AsEnumerable().Distinct().Count() == 1)
                    {
                        sum += i;
                        continue;
                    };
                } 
                if (numberString.Length != 3 && numberString.Length % 3 == 0)
                {
                    var setsOfThree = SplitBy(numberString, 3);
                    if (setsOfThree.AsEnumerable().Distinct().Count() == 1)
                    {
                        sum += i;
                        continue;
                    }
                }

                if (numberString.Length == 2 || numberString.Length % 2 != 0) continue;
                var setsOfTwo = SplitBy(numberString, 2);
                if (setsOfTwo.AsEnumerable().Distinct().Count() == 1) sum += i;
            }
        }

        return sum;
    }

    private static List<string> SplitBy(string input, int divisor)
    {
        if (input.Length % divisor != 0) throw new FormatException("Input length must be a multiple of divisor");
        var output = new List<string>();

        for (var i = 0; i + divisor <= input.Length; i += divisor)
        {
            output.Add(input.Substring(i, divisor));    
        }

        return output;
    }
    
    private static string GetInput()
    {
        return File.ReadAllText("./2025/Input/Day02.txt");
    }
}