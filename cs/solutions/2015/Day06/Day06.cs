namespace solutions._2015;

public static class Day06
{

    public static int Part_1(string? input = null)
    {
        input = input ?? GetInput();
        var grid = new Grid();
        var instructions = input.Split('\n');

        foreach (var instruction in instructions)
        {
            var instructionComponents = instruction.Split(' ');
            
            if (instructionComponents.Contains("toggle"))
            {
                grid.DoOperationOnRange("toggle", instructionComponents[1],instructionComponents[3]);
            }
            else
            {                
                grid.DoOperationOnRange(instructionComponents[1], instructionComponents[2] ,instructionComponents[4]);
            }
            
        }
        return grid.CountLightsThatAreOn();
    }
    
    public static int Part_2(string? input = null)
    {
        input = input ?? GetInput();
        Grid grid = new Grid();
        var instructions = input.Split('\n');
        foreach (var instruction in instructions)
        {
            var instructionComponents = instruction.Split(' ');
            
            if (instructionComponents.Contains("toggle"))
            {
                grid.DoOperationOnRange("toggle", instructionComponents[1],instructionComponents[3]);
            }
            else
            {                
                grid.DoOperationOnRange(instructionComponents[1], instructionComponents[2] ,instructionComponents[4]);
            }
            
        }
        return grid.CalculateBrightness();
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2015/Day6/input.txt");
    }
}


