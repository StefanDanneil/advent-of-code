namespace solutions._2015;

public class Day6
{

    public int Part_1(string? input = null)
    {
        input = input ?? GetInput();
        var grid = new Grid();
        var instructions = input.Split('\n');
        // split into meaningful steps
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
    
    public int Part_2(string? input = null)
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

    private string GetInput()
    {
        return File.ReadAllText("./2015/Day6/input.txt");
    }
}

public class Grid
{
    private readonly List<List<Light>> _lights = new();

    public Grid()
    {
        for (var i = 0; i < 1000; i++)
        {
            var currentRow = new List<Light>();
            _lights.Add(currentRow);
            for (var j = 0; j < 1000; j++)
            {
                currentRow.Add(new Light());
            }
        }
    }

    public int CountLightsThatAreOn()
    {
        var count = 0;
        
        for (var i = 0; i < 1000; i++)
        {
            var currentRow = _lights[i];
            for (var j = 0; j < 1000; j++)
            {
                if (currentRow[j].IsOn)
                {
                    count++;
                }
            }
        }

        return count;
    }
    
    public int CalculateBrightness()
    {
        var totalBrightness = 0;
        
        for (int i = 0; i < 1000; i++)
        {
            var currentRow = _lights[i];
            for (var j = 0; j < 1000; j++)
            {
                totalBrightness += currentRow[j].Brightness;
            }
        }

        return totalBrightness;
    }
    
    public void DoOperationOnRange(string operation, string from, string to)
    {
        var allowedOperations = new List<string>()
        {
            "on",
            "off",
            "toggle"
        };

        if (!allowedOperations.Contains(operation))
        {
            throw new NotSupportedException($"{operation} is not a valid operation");
        }
        
        var fromPositions = from.Split(',');
        var toPositions = to.Split(',');

        var fromX = int.Parse(fromPositions[0]);
        var fromY = int.Parse(fromPositions[1]);
        
        var toX = int.Parse(toPositions[0]);
        var toY = int.Parse(toPositions[1]);

        var lowerX = fromX < toX ? fromX : toX;
        var upperX = fromX < toX ?  toX : fromX;
        
        var lowerY = fromY < toY ? fromY : toY;
        var upperY = fromY < toY ?  toY : fromY;
        
        for (int i = lowerX; i <= upperX; i++)
        {
            var currentRow = _lights[i];
            for (int j = lowerY; j <= upperY; j++)
            {
                if (operation == "on")
                {
                    currentRow[j].IsOn = true;
                    currentRow[j].Brightness++;
                }

                if (operation == "off")
                {
                    currentRow[j].IsOn = false;
                    if (currentRow[j].Brightness != 0)
                    {
                        currentRow[j].Brightness--;   
                    }
                }

                if (operation == "toggle")
                {
                    currentRow[j].IsOn = !currentRow[j].IsOn;
                    currentRow[j].Brightness += 2;
                }
            }
        }
    }
}
public class Light
{
    public bool IsOn { get; set; }
    
    public int Brightness { get; set; }
}
