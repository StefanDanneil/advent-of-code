using System.Security.Cryptography;

namespace solutions._2015;

public static class Day04
{
    public static int Part_1(string? input = null)
    {
        input = input ?? GetInput();
        var i = 1;

        while (i < 10000000) // limit at 10 million
        {
            var hash = CreateMd5(input + i.ToString());
            if (hash.Substring(0, 5) == "00000")
            {
                return i;
            }
            i++;
        }

        return i;
    }
    
    public static int Part_2(string? input = null)
    {
        input = input ?? GetInput();
        var i = 1;

        while (i < 10000000) // limit at 10 million
        {
            var hash = CreateMd5(input + i.ToString());
            if (hash.Substring(0, 6) == "000000")
            {
                return i;
            }
            i++;
        }

        return i;
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2015/Day04/input.txt");
    }
    
    private static string CreateMd5(string input)
    {
        using var md5 = MD5.Create();
        var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        var hashBytes = md5.ComputeHash(inputBytes);

        return Convert.ToHexString(hashBytes);
    }
}
