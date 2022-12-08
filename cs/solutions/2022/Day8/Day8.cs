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

    private static IEnumerable<Tree> GetTrees(IEnumerable<IEnumerable<int>> grid)
    {
        var trees =  new List<Tree>();
        
        var enumerable = grid as IEnumerable<int>[] ?? grid.ToArray();

        for (var y = 0; y < enumerable.Length; y++)
        {
            var currentRow = enumerable[y].ToArray();
            for (var x = 0; x < enumerable[y].Count(); x++)
            {
                var currentTree = new Tree{ Height = currentRow[x]};
                int left = 0, up = 0, right = 0, down = 0;
                bool visibleLeft = true, visibleUp = true, visibleRight = true, visibleDown = true;
                
                if (x == 0 || x == currentRow.Length-1 || y == 0 || y == enumerable.Length-1)
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
                    if (currentRow[k] < currentTree.Height) continue;
                    visibleLeft = false;
                    break;
                }

                // go up
                for (var k = y -1; k >= 0; k--)
                {
                    up++;
                    if (enumerable[k].ToArray()[x] < currentTree.Height) continue;
                    visibleUp = false;
                    break;
                }

                // go right
                for (var k = x + 1; k < currentRow.Length; k++)
                {
                    right++;
                    if (currentRow[k] < currentTree.Height) continue;
                    visibleRight = false;
                    break;
                }

                // go down
                for (var k = y + 1; k < enumerable.Length; k++)
                {
                    down++;
                    if (enumerable[k].ToArray()[x] < currentTree.Height) continue;
                    visibleDown = false;
                    break;
                }

                currentTree.Visible = visibleLeft || visibleUp || visibleRight || visibleDown;
                
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
