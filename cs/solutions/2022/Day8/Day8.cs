namespace solutions._2022;

public static class Day8
{
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var grid =  input.Split('\n').Select(row => row.ToCharArray().Select(c => int.Parse(c.ToString())));

        return FindVisibleTrees(grid).Count();
    }

    private static IEnumerable<int> FindVisibleTrees(IEnumerable<IEnumerable<int>> grid)
    {
        var enumerable = grid as IEnumerable<int>[] ?? grid.ToArray();
        var visibleTreeHeights = new List<int>();

        for (var rowIndex = 0; rowIndex < enumerable.Length; rowIndex++)
        {
            var currentRow = enumerable[rowIndex].ToArray();
            for (var columnIndex = 0; columnIndex < enumerable[rowIndex].Count(); columnIndex++)
            {
                var currentHeight = currentRow[columnIndex];
                var visible = columnIndex == 0 || columnIndex == currentRow.Length-1 || rowIndex == 0 || rowIndex == enumerable.Length-1;
                
                if (visible)
                {
                    visibleTreeHeights.Add(currentHeight);
                    continue;
                }
                
                // go left
                for (var k = columnIndex - 1; k >= 0; k--)
                {
                    if (currentRow[k] >= currentHeight)
                    {
                        visible = false;
                        break;
                    }
                
                    visible = true;
                }
                
                if (visible)
                {
                    visibleTreeHeights.Add(currentHeight);
                    continue;
                }
                
                // go up
                for (var k = rowIndex - 1; k >= 0; k--)
                {
                    if (enumerable[k].ToArray()[columnIndex] >= currentHeight)
                    {
                        visible = false;
                        break;
                    }
                
                    visible = true;
                }

                if (visible)
                {
                    visibleTreeHeights.Add(currentHeight);
                    continue;
                }
                
                // go right
                for (var k = columnIndex + 1; k < currentRow.Length; k++)
                {
                    if (currentRow[k] >= currentHeight)
                    {
                        visible = false;
                        break;
                    }
                
                    visible = true;
                }
                
                if (visible)
                {
                    visibleTreeHeights.Add(currentHeight);
                    continue;
                }
                
                // go down
                for (var k = rowIndex + 1; k < enumerable.Length; k++)
                {
                    if (enumerable[k].ToArray()[columnIndex] >= currentHeight)
                    {
                        visible = false;
                        break;
                    }
                
                    visible = true;
                }
                
                if (visible)
                {
                    visibleTreeHeights.Add(currentHeight);
                }
            }
        }
        
        return visibleTreeHeights;
    }

    public static int Part_2(string? input = null)
    {
        input ??= GetInput();
        var grid =  input.Split('\n').Select(row => row.ToCharArray().Select(c => int.Parse(c.ToString())));

        return GetScenicScores(grid).Max();
    }

    private static IEnumerable<int> GetScenicScores(IEnumerable<IEnumerable<int>> grid)
    {
        var enumerable = grid as IEnumerable<int>[] ?? grid.ToArray();
        var scenicScores = new List<int>();

        for (var rowIndex = 0; rowIndex < enumerable.Length; rowIndex++)
        {
            var currentRow = enumerable[rowIndex].ToArray();
            for (var columnIndex = 0; columnIndex < enumerable[rowIndex].Count(); columnIndex++)
            {
                var currentHeight = currentRow[columnIndex];
                var outerTree = columnIndex == 0 || columnIndex == currentRow.Length-1 || rowIndex == 0 || rowIndex == enumerable.Length-1;

                var left = 0;
                var top = 0;
                var right = 0;
                var down = 0;
                
                if (outerTree)
                {
                    scenicScores.Add(0); // all our outer stuff is going to be 0
                    continue;
                }
                
                // go left
                for (var k = 1; k <= columnIndex; k++)
                {
                    left = k;
                    if (currentRow[columnIndex - k] < currentHeight) continue;
                    break;
                }

                // go up
                for (var k = 1; k <= rowIndex; k++)
                {
                    top = k;
                    if (enumerable[rowIndex-k].ToArray()[columnIndex] < currentHeight) continue;
                    break;
                }

                // go right
                for (var k = 1; k < currentRow.Length - columnIndex; k++)
                {
                    right = k;
                    if (currentRow[columnIndex + k] < currentHeight) continue;
                    break;
                }

                // go down
                for (var k = 1; k < enumerable.Length - rowIndex; k++)
                {
                    down = k;
                    if (enumerable[rowIndex + k].ToArray()[columnIndex] < currentHeight) continue;
                    break;
                }

                var scenicScore = left * top * right * down;
                
                scenicScores.Add(scenicScore);
            }
        }

        return scenicScores;
    }
    
    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day8/input.txt");
    }
}
