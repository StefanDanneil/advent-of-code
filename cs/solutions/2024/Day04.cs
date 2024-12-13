namespace solutions._2024;

public class Day04 : IDay
{
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var rows = input.Split('\n');
        const string targetString = "XMAS";
        const string reversedTargetString = "SAMX";
        var output = 0;

        for (var i = 0; i < rows.Length; i++)
        {
            for (var j = 0; j < rows[i].Length; j++)
            {
                var currentLetter = rows[i][j];

                if (currentLetter == targetString.First())
                {
                    if (rows[i][j..].StartsWith(targetString))
                        output++;
                    
                    var verticalString = BuildVerticalStringFromIndex(rows, i, j);
                    if (verticalString == targetString)
                        output++;
                    
                    var downWardRightDiagonalString = BuildDownRightDiagonalFromIndex(rows, i, j);
                    if (downWardRightDiagonalString == targetString)
                        output++;
                    
                    var downWardLeftDiagonalString = BuildDownLeftDiagonalFromIndex(rows, i, j);
                    if (downWardLeftDiagonalString == targetString)
                        output++;
                }
                
                if (currentLetter == targetString.Last())
                {
                    if (rows[i][j..].StartsWith(reversedTargetString))
                        output++;
                    
                    var verticalString = BuildVerticalStringFromIndex(rows, i, j);
                    if (verticalString == reversedTargetString)
                        output++;
                    
                    var downWardDiagonalString = BuildDownRightDiagonalFromIndex(rows, i, j);
                    if (downWardDiagonalString == reversedTargetString)
                        output++;
                    
                    var downWardLeftDiagonalString = BuildDownLeftDiagonalFromIndex(rows, i, j);
                    if (downWardLeftDiagonalString == reversedTargetString)
                        output++;
                }
            }
        }
        
        return output;
    }

    private static string BuildVerticalStringFromIndex(string[] rows, int rowIndex, int columnIndex)
    {
        var output = "";
        
        for (var i = rowIndex; i < rows.Length && output.Length < 4; i++)
        {
            output += rows[i][columnIndex];
        };
        
        return output;
    }
    
    private static string BuildDownRightDiagonalFromIndex(string[] rows, int rowIndex, int columnIndex)
    {
        var output = "";
        
        for (var i = rowIndex; i < rows.Length && output.Length < 4; i++)
        {
            if (columnIndex + output.Length >= rows[i].Length)
                break;
            
            output += rows[i][columnIndex + output.Length];
        };
        
        return output;
    }
    
    private static string BuildDownLeftDiagonalFromIndex(string[] rows, int rowIndex, int columnIndex)
    {
        var output = "";
        
        for (var i = rowIndex; i < rows.Length && output.Length < 4; i++)
        {
            if (columnIndex - output.Length < 0)
                break;
            
            output += rows[i][columnIndex-output.Length];
        };
        
        return output;
    }
    
    
    public static int Part_2(string? input = null)
    {
        input ??= GetInput();
        var rows = input.Split("\r\n");
        var targetStrings = new List<string>{ "MAS", "SAM" };
        var output = 0;

        for (var i = 0; i < rows.Length; i++)
        {
            for (var j = 0; j < rows[i].Length; j++)
            {
                var currentLetter = rows[i][j];

                if (currentLetter == 'A' && i != 0 && i != rows.Length - 1 && j != 0 && j != rows[i].Length - 1)
                {
                    var downWardRightDiagonalString = BuildDownRightDiagonalFromIndex(rows, i - 1, j - 1);
                    var downWardLeftDiagonalString = BuildDownLeftDiagonalFromIndex(rows, i - 1, j + 1);
                    
                    downWardRightDiagonalString = downWardRightDiagonalString.Length < 3 ? downWardRightDiagonalString : downWardRightDiagonalString[..3];
                    downWardLeftDiagonalString = downWardLeftDiagonalString.Length < 3 ? downWardLeftDiagonalString : downWardLeftDiagonalString[..3];
                    
                    Console.WriteLine( "{0} {1} {2} {3}", i, j, downWardRightDiagonalString, downWardLeftDiagonalString);
                    
                    if (targetStrings.Contains(downWardRightDiagonalString) &&
                        targetStrings.Contains(downWardLeftDiagonalString))
                        output++;
                }
            }
        }

        return output;
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2024/Input/Day04.txt");
    }
}
