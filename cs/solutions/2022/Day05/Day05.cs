namespace solutions._2022;

public static class Day05
{
    public static string Part_1(string? input = null)
    {
        input ??=  GetInput();
        var splitInput = input.Split("\n\n");
        var state = ParseStacks(splitInput[0]).ToList();
        
        var instructions = splitInput[1].Split('\n').ToList();
        
        foreach (var instruction in instructions)
        {
            var instructionParts = instruction.Split(' ');
            var amountOfCratesToMove = int.Parse(instructionParts[1]);
            var stackToMoveFrom = state[int.Parse(instructionParts[3])-1];
            var stackToMoveTo = state[int.Parse(instructionParts[5])-1];

            var movingCrates = stackToMoveFrom.GetRange(0,amountOfCratesToMove);
            movingCrates.Reverse();
            stackToMoveFrom.RemoveRange(0, amountOfCratesToMove);
            stackToMoveTo.InsertRange(0, movingCrates);
        }

        var firstCrates = state.Where(s => s.Count != 0).Select(i => i.First());

        return firstCrates.Aggregate("", (current, firstCrate) => current + firstCrate);
    }

    public static IEnumerable<List<char>> ParseStacks(string input)
    {
        var lines = input.Split('\n').ToList();
        var stackNumbers = lines.Last().Split("   ").Select(int.Parse).ToList();
        lines.Remove(lines.Last());

        var stacks = new List<List<char>>();
        
        for (var i = 0; i < stackNumbers.Count; i++)
        {
            var stack = lines
                .Select(line => line.Skip(4 * i + 1).Take(1).First())
                .Where(character => character != ' ')
                .ToList();

            stacks.Add(stack);
        }
        
        return stacks;
    }

    public static string Part_2(string? input = null)
    {
        input ??= GetInput();
        var splitInput = input.Split("\n\n");
        var state = ParseStacks(splitInput[0]).ToList();
        
        var instructions = splitInput[1].Split('\n').ToList();
        
        
        foreach (var instruction in instructions)
        {
            var instructionParts = instruction.Split(' ');
            var amountOfCratesToMove = int.Parse(instructionParts[1]);
            var stackToMoveFrom = state[int.Parse(instructionParts[3])-1];
            var stackToMoveTo = state[int.Parse(instructionParts[5])-1];

            var movingCrates = stackToMoveFrom.GetRange(0,amountOfCratesToMove);
            stackToMoveFrom.RemoveRange(0, amountOfCratesToMove);
            stackToMoveTo.InsertRange(0, movingCrates);
        }

        var firstCrates = state.Where(s => s.Count != 0).Select(i => i.First());

        return firstCrates.Aggregate("", (current, firstCrate) => current + firstCrate);
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day5/input.txt");
    }
}
