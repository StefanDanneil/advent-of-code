namespace solutions._2015;

public static class Day07
{

    public static int Part_1(string? input = null, string targetWire = "a")
    {
        input = input ?? GetInput();
        var wires = new Dictionary<string, Wire>();
        var rows = input.Split('\n');
        
        foreach (var row in rows)
        {
            var instructionParts = row.Split("->");
            var wireName = instructionParts[1].Trim();
            if (!wires.ContainsKey(wireName))
            {
                wires[wireName] = new Wire(instructionParts[0], wires);
            }
        }

        return wires[targetWire].GetSignal();
    }
    
    public static int Part_2(string? input = null, string targetWire = "a")
    {
        input = input ?? GetInput();
        var wires = new Dictionary<string, Wire>();
        var rows = input.Split('\n');

        wires["b"] = new Wire("16076", wires); 
        
        foreach (var row in rows)
        {
            var instructionParts = row.Split("->");
            var wireName = instructionParts[1].Trim();
            if (!wires.ContainsKey(wireName))
            {
                wires[wireName] = new Wire(instructionParts[0], wires);
            }
        }

        return wires[targetWire].GetSignal();
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2015/Day7/input.txt");
    }
}
