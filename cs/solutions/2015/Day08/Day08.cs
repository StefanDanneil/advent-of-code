namespace solutions._2015;

public static class Day08
{

    public static int Part_1(string? input = null)
    {
        input = input ?? GetInput();
        var rows = input.Split('\n');
        var output = 0;
        
        foreach (var row in rows)
        {
            
            var literalLength = row.Length;
            var trueCharacterCount = 0;
            
            for (var i = 0; i < row.Length; i++)
            {
                if (row[i] == '"')
                {
                    // just don't count
                } 
                else if (row[i] == '\\')
                {
                    if (row[i + 1] == '"' || row[i + 1] == '\\')
                    {
                        trueCharacterCount++;
                        i++; // extra step
                    } 
                    else
                    {
                        trueCharacterCount++;
                        i += 3;
                    }
                } 
                else
                {
                    trueCharacterCount++;
                }
            }
            output += literalLength - trueCharacterCount;
        }
        
        return output;
    }

    public static int Part_2(string? input = null)
    {
        input = input ?? GetInput();
        var rows = input.Split('\n');
        var output = 0;

        foreach (var row in rows)
        {
            var literalLength = row.Length;
            var encodedRow = "\"";
            
            foreach (var c in row)
            {
                var charactersToEncode = new List<char>()
                {
                    '\\',
                    '"'
                };

                if (charactersToEncode.Contains(c))
                {
                    encodedRow += '\\';
                }

                encodedRow += c;
            }
            
            encodedRow += "\"";

            output += encodedRow.Length - literalLength;
        }
        
        return output;
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2015/Day08/input.txt");
    }
}
