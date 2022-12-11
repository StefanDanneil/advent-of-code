namespace solutions._2022;

public static class Day10
{
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var instructions = input.Split('\n').Select(i => i.Split(' ')).ToArray();
        var currentInstructionIndex = -1;
        var x = 1;
        var cyclesToPick = new int[] { 20, 60, 100, 140, 180, 220 };
        var selectedCycleValues = new List<int>();
        string[]? signalToFinish = null; 
        
        for (var cycle = 1; cycle <= 220; cycle++)
        {
            if (cyclesToPick.Contains(cycle))
            {
                selectedCycleValues.Add(x*cycle);
            }
            
            if (signalToFinish is not null)
            {
                var currentInstruction = instructions[currentInstructionIndex];
                x += int.Parse(currentInstruction[1]);
                signalToFinish = null;
            }
            else
            {
                currentInstructionIndex++;
                var currentInstruction = instructions[currentInstructionIndex];

                signalToFinish = currentInstruction[0] switch
                {
                    "noop" => null,
                    "addx" => currentInstruction,
                    _ => throw new Exception("not valid instruction")
                };
            }
        }
        
        return selectedCycleValues.Sum();
    }

    public static IEnumerable<string> Part_2(string? input = null)
    {
        input ??= GetInput();
        var instructions = input.Split('\n').Select(i => i.Split(' ')).ToArray();
        var currentInstructionIndex = -1;
        var x = 1;
        var cyclesThatStartsNewRow = new int[] { 41, 81, 121, 161, 201, 241 };
        var crtRows = new List<string>();
        var currentCrtRow = "";
        string[]? signalToFinish = null;

        for (var cycle = 1; cycle <= 241; cycle++)
        {
            if (cyclesThatStartsNewRow.Contains(cycle))
            {
                crtRows.Add(currentCrtRow);
                currentCrtRow = "";
            }
            
            var crtPosition = cycle-1-(40*crtRows.Count);
            currentCrtRow += crtPosition.IsBetween(x - 1, x + 1) ? "#" : ".";

            if (signalToFinish is not null)
            {
                var currentInstruction = instructions[currentInstructionIndex];
                x += int.Parse(currentInstruction[1]);
                signalToFinish = null;
            }
            else
            {
                currentInstructionIndex++;

                if (currentInstructionIndex < instructions.Length)
                {
                    var currentInstruction = instructions[currentInstructionIndex];

                    signalToFinish = currentInstruction[0] switch
                    {
                        "noop" => null,
                        "addx" => currentInstruction,
                        _ => throw new Exception("not valid instruction")
                    };   
                }
            }
        }

        return crtRows;
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day10/input.txt");
    }
}
