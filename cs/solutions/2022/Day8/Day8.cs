namespace solutions._2022;

public static class Day8
{
    private class Tree
    {
        public bool Visible { get; set; }
        public int ScenicScore { get; set; }
        public required int Height { get; init; }
    }
    
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var grid =  input.Split('\n').Select(row => row.ToCharArray().Select(c => int.Parse(c.ToString())));

        return GetTrees(grid).Count(t => t.Visible);
    }

    private static IEnumerable<Tree> GetTrees(IEnumerable<IEnumerable<int>> enumerableInt)
    {
        var trees =  new List<Tree>();
        
        var grid = enumerableInt as IEnumerable<int>[] ?? enumerableInt.ToArray();

        for (var y = 0; y < grid.Length; y++)
        {
            var currentRow = grid[y].ToArray();
            for (var x = 0; x < grid[y].Count(); x++)
            {
                var currentTree = new Tree{ Height = currentRow[x]};
                int left = 0, up = 0, right = 0, down = 0;

                if (x == 0 || x == currentRow.Length-1 || y == 0 || y == grid.Length-1)
                {
                    currentTree.Visible = true;
                    currentTree.ScenicScore = 0;
                    trees.Add(currentTree);
                    continue;
                }
                
                // go left
                for (var k = x-1; k >= 0; k--)
                {
                    left++;
                    if (currentRow[k] >= currentTree.Height) break;
                    if (k == 0) currentTree.Visible = true;
                }

                // go up
                for (var k = y -1; k >= 0; k--)
                {
                    up++;
                    if (grid[k].ToArray()[x] >= currentTree.Height) break;
                    if (k == 0) currentTree.Visible = true;
                }

                // go right
                for (var k = x + 1; k < currentRow.Length; k++)
                {
                    right++;
                    if (currentRow[k] >= currentTree.Height) break;
                    if (k == currentRow.Length -1) currentTree.Visible = true;
                }

                // go down
                for (var k = y + 1; k < grid.Length; k++)
                {
                    down++;
                    if (grid[k].ToArray()[x] >= currentTree.Height) break;
                    if (k == grid.Length -1) currentTree.Visible = true;
                }

                currentTree.ScenicScore = left * up * right * down;
                
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
