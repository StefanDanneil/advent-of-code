namespace solutions._2015;

public class Day2
{

    public int Part_1(string? input = null)
    {
        input = input ?? GetInput();
        string[] rows = input.Split('\n');
        Int32 output = 0;
        
        foreach (var row in rows)
        {
            int[] dimensions = row
                .Split('x')
                .Select(i => Int32.Parse(i))
                .ToArray();

            int[] sides = new int[]
            {
                dimensions[0] * dimensions[1],
                dimensions[1] * dimensions[2],
                dimensions[0] * dimensions[2]
            };
            
            foreach (var side in sides)
            {
                output += side * 2;
            }
            
            Array.Sort(sides);

            output += sides[0];
        }

        return output;
    }
    
    public int Part_2(string? input = null)
    {
        input = input ?? GetInput(); 
        string[] rows = input.Split('\n');
        Int32 output = 0;
        
        foreach (var row in rows)
        {   
            int[] dimensions = row
                .Split('x')
                .Select(i => Int32.Parse(i))
                .ToArray();
            
            Array.Sort(dimensions);

            output += dimensions[0] * 2;
            output += dimensions[1] * 2;
            output += dimensions.Aggregate(1, (a, b) => a * b);
        }

        return output;
    }

    private string GetInput()
    {
        return File.ReadAllText("./2015/Day2/input.txt");
    }
}
