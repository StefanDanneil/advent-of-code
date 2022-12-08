namespace solutions._2015;


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
            count += currentRow.Count(light => light.IsOn);
        }

        return count;
    }
    
    public int CalculateBrightness()
    {
        var totalBrightness = 0;
        
        for (var i = 0; i < 1000; i++)
        {
            var currentRow = _lights[i];
            totalBrightness += currentRow.Sum(light => light.Brightness);
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
                switch (operation)
                {
                    case "on":
                        currentRow[j].IsOn = true;
                        currentRow[j].Brightness++;
                        break;
                    case "off":
                    {
                        currentRow[j].IsOn = false;
                        if (currentRow[j].Brightness != 0)
                        {
                            currentRow[j].Brightness--;   
                        }

                        break;
                    }
                    case "toggle":
                        currentRow[j].IsOn = !currentRow[j].IsOn;
                        currentRow[j].Brightness += 2;
                        break;
                }
            }
        }
    }
}