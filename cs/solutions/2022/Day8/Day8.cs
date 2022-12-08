namespace solutions._2022;

public static class Day8
{
    private class Tree
    {
        public bool Visible { get; set; } = false;
        public int ScenicScore { get; set; }
        public required int Height { get; init; }
    }
    
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var grid =  input.Split('\n').Select(row => row.ToCharArray().Select(c => int.Parse(c.ToString())));

        return GetTrees(grid).Count(t => t.Visible);
    }

    private static IEnumerable<Tree> GetTrees(IEnumerable<IEnumerable<int>> grid)
    {
        var trees =  new List<Tree>();
        
        var enumerable = grid as IEnumerable<int>[] ?? grid.ToArray();

        for (var rowIndex = 0; rowIndex < enumerable.Length; rowIndex++)
        {
            var currentRow = enumerable[rowIndex].ToArray();
            for (var columnIndex = 0; columnIndex < enumerable[rowIndex].Count(); columnIndex++)
            {
                var currentTree = new Tree{ Height = currentRow[columnIndex]};
                var outerTree = columnIndex == 0 || columnIndex == currentRow.Length-1 || rowIndex == 0 || rowIndex == enumerable.Length-1;

                int left = 0, top = 0, right = 0, down = 0;
                bool visibleLeft = true, visibleTop = true, visibleRight = true, visibleDown = true;
                
                if (outerTree)
                {
                    currentTree.Visible = true;
                    currentTree.ScenicScore = 0;
                    trees.Add(currentTree);
                    continue;
                }
                
                // go left
                for (var k = 1; k <= columnIndex; k++)
                {
                    left = k;
                    if (currentRow[columnIndex - k] < currentTree.Height) continue;
                    visibleLeft = false;
                    break;
                }

                // go up
                for (var k = 1; k <= rowIndex; k++)
                {
                    top = k;
                    if (enumerable[rowIndex-k].ToArray()[columnIndex] < currentTree.Height) continue;
                    visibleTop = false;
                    break;
                }

                // go right
                for (var k = 1; k < currentRow.Length - columnIndex; k++)
                {
                    right = k;
                    if (currentRow[columnIndex + k] < currentTree.Height) continue;
                    visibleRight = false;
                    break;
                }

                // go down
                for (var k = 1; k < enumerable.Length - rowIndex; k++)
                {
                    down = k;
                    if (enumerable[rowIndex + k].ToArray()[columnIndex] < currentTree.Height) continue;
                    visibleDown = false;
                    break;
                }

                currentTree.Visible = visibleLeft || visibleTop || visibleRight || visibleDown;
                
                currentTree.ScenicScore = left * top * right * down;
                
                trees.Add(currentTree);
            }
        }

        return trees;
    }

    public static int Part_2(string? input = null)
    {
        input ??= GetInput();
        var grid =  input.Split('\n').Select(row => row.ToCharArray().Select(c => int.Parse(c.ToString())));

        return GetTrees(grid).Max(t => t.ScenicScore);
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day8/input.txt");
    }
}
