using System.Security.Claims;

namespace solutions._2024;

public static class Day02
{
    public static int Part_1(string? input = null)
    {
        input ??= GetInput();

        var rows = input.Split('\n')
            .Select(row => row.Split(" ").Select(int.Parse).ToList());

        return rows.Count(IsSafe);
    }

    private static bool IsSafe(List<int> numbers)
    {
        for (var i = 0; i < numbers.Count - 1; i++)
        {
            int? previousNumber = i > 0 ? numbers[i - 1] : null;

            var currentNumber = numbers[i];
            var nextNumber = numbers[i + 1];

            if (currentNumber == nextNumber)
            {
                Console.WriteLine($"row {String.Join(", ", numbers)} is unsafe because of equal numbers");
                return false;
            }

            var diff = currentNumber - nextNumber;

            if (Math.Abs(diff) > 3)
            {
                Console.WriteLine($"row {String.Join(", ", numbers)} is unsafe because of diff larger than 3");
                return false;
            }

            if (previousNumber is null) continue;

            var previousDiff = previousNumber - currentNumber;

            if ((previousDiff < 0 && diff > 0) || (previousDiff > 0 && diff < 0))
            {
                Console.WriteLine($"row {String.Join(", ", numbers)} is unsafe because of change in direction");
                return false;
            }
        }

        Console.WriteLine($"row {String.Join(", ", numbers)} is safe");
        return true;
    }


    public static int Part_2(string? input = null)
    {
        input ??= GetInput();

        var rows = input.Split('\n')
            .Select(row => row.Split(" ").Select(int.Parse).ToList());

        var output = 0;

        foreach (var row in rows)
        {
            if (IsSafe(row))
            {
                output++;
            }
            else
            {
                for (var i = 0; i < row.Count; i++)
                {
                    var clonedRow = row.ToList();
                    clonedRow.RemoveAt(i);
                    if (!IsSafe(clonedRow)) continue;
                    output++;
                    break;
                } 
            }
        }

        return output;
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2024/Day02/input.txt");
    }
}