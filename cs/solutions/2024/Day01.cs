namespace solutions._2024;

public class Day01 : IDay
{
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var rows = input.Split('\n');
        var left = new List<int>();
        var right = new List<int>();

        foreach (var row in rows)
        {            
            var numbers = row.Split("   ");
            left.Add(int.Parse(numbers.First()));
            right.Add(int.Parse(numbers.Last()));
        }
        
        left.Sort();
        right.Sort();

        var sum = 0;
        
        for (var i = 0; i < left.Count; i++)
        {
            var leftNumber = left[i];
            var rightNumber = right[i];
            sum += Math.Abs(leftNumber - rightNumber);
        }

        return sum;
    }
    
    public static int Part_2(string? input = null)
    {
        input ??= GetInput();
        var rows = input.Split('\n');
        var left = new List<int>();
        var right = new List<int>();

        foreach (var row in rows)
        {            
            var numbers = row.Split("   ");
            left.Add(int.Parse(numbers.First()));
            right.Add(int.Parse(numbers.Last()));
        }

        var sum = 0;
        
        for (var i = 0; i < left.Count; i++)
        {
            var leftNumber = left[i];
            var occurences = right.Where(n => n == leftNumber).Count();
            sum += leftNumber * occurences;
        }

        return sum;
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2024/Input/day01.txt");
    }
}
