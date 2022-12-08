namespace solutions._2015;

public static class Day02
{
    public static int Part_1(string? input = null)
    {
        input ??= GetInput();
        var rows = input.Split('\n');
        var output = 0;
        
        foreach (var row in rows)
        {
            var dimensions = row
                .Split('x')
                .Select(int.Parse)
                .ToArray();

            var sides = new []
            {
                dimensions[0] * dimensions[1],
                dimensions[1] * dimensions[2],
                dimensions[0] * dimensions[2]
            };

            output += sides.Sum(side => side * 2);

            Array.Sort(sides);

            output += sides[0];
        }

        return output;
    }
    
    public static int Part_2(string? input = null)
    {
        input = input ?? GetInput(); 
        var rows = input.Split('\n');
        var output = 0;
        
        foreach (var row in rows)
        {   
            var dimensions = row
                .Split('x')
                .Select(int.Parse)
                .ToArray();
            
            Array.Sort(dimensions);

            output += dimensions[0] * 2;
            output += dimensions[1] * 2;
            output += dimensions.Aggregate(1, (a, b) => a * b);
        }

        return output;
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2015/Day2/input.txt");
    }
}
