using System.Security.Cryptography;

namespace solutions._2015;

public class Day4
{

    public int Part_1(string? input = null)
    {
        input = input ?? GetInput();
        var i = 1;

        while (i < 10000000) // limit at 10 million
        {
            var hash = CreateMD5(input + i.ToString());
            if (hash.Substring(0, 5) == "00000")
            {
                return i;
            }
            i++;
        }

        return i;
    }
    
    public int Part_2(string? input = null)
    {
        input = input ?? GetInput();
        var i = 1;

        while (i < 10000000) // limit at 10 million
        {
            var hash = CreateMD5(input + i.ToString());
            if (hash.Substring(0, 6) == "000000")
            {
                return i;
            }
            i++;
        }

        return i;
    }

    private string GetInput()
    {
        return File.ReadAllText("./2015/Day4/input.txt");
    }
    
    public static string CreateMD5(string input)
    {
        // Use input string to calculate MD5 hash
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }
    }
}
