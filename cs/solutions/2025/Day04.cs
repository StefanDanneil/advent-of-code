namespace solutions._2025;

public static class Day04
{
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var rows = input.Split("\n");

        var grid = new List<List<char>>();
        var accessibleRolls = 0;
        for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
        {
            grid.Add([]); 
            grid[rowIndex] = [];
            
            for (var columnIndex = 0; columnIndex < rows[rowIndex].Length; columnIndex++)
            {
                grid[rowIndex].Add(rows[rowIndex][columnIndex]);
            }
        }
        
        for (var rowIndex = 0; rowIndex < grid.Count; rowIndex++)
        {
            for (var columnIndex = 0; columnIndex < grid[rowIndex].Count; columnIndex++)
            {
                var currentChar = grid[rowIndex][columnIndex];
                if (currentChar != '@') continue;
                if (SurroundedByNRolls(rowIndex, columnIndex, grid, 4)) accessibleRolls++;
            }
        }

        return accessibleRolls;
    }

    private static bool SurroundedByNRolls(int x, int y, List<List<char>> grid, int lessThan)
    {
        var totalRollsAround = 0;

       
            for (var i = -1; i < 2; i++)
            {
                for (var j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0) continue;
                    try
                    {
                        if (grid[x+i][y+j] == '@') totalRollsAround++;
                    }
                    catch (Exception)
                    {
                        // absorb to avoid having to care ArgumentOUtOfRangeException
                    }
                }
            }
        

        return totalRollsAround < lessThan;
    }

    public static int Part_2(string? input = null)
    {
        input ??= GetInput();
        var rows = input.Split("\n");

        var grid = new List<List<char>>();
        var accessibleRolls = 0;
        
        for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
        {
            grid.Add([]); 
            grid[rowIndex] = [];
            
            for (var columnIndex = 0; columnIndex < rows[rowIndex].Length; columnIndex++)
            {
                grid[rowIndex].Add(rows[rowIndex][columnIndex]);
            }
        }

        var canRemoveRolls = true;
        var rollsToRemove = new List<(int, int)>();
        while (canRemoveRolls)
        {
            for (var rowIndex = 0; rowIndex < grid.Count; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < grid[rowIndex].Count; columnIndex++)
                {
                    var currentChar = grid[rowIndex][columnIndex];
                    if (currentChar != '@') continue;
                    if (SurroundedByNRolls(rowIndex, columnIndex, grid, 4))
                    {
                        accessibleRolls++;
                        rollsToRemove.Add((rowIndex, columnIndex));
                    }
                }
            }

            if (rollsToRemove.Count > 0)
            {
                canRemoveRolls = true;
                foreach (var coordinates in rollsToRemove)
                {
                    grid[coordinates.Item1][coordinates.Item2] = '.';
                }
                rollsToRemove.Clear();
            }
            else
            {
                canRemoveRolls = false;   
            }
        }

        return accessibleRolls;
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2025/Input/Day04.txt");
    }
}
