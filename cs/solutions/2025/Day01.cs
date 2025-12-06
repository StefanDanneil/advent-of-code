namespace solutions._2025;

public class Day01 : IDay
{
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var currentPosition = 50;
        var seenZeroes = 0;
        
        foreach (var line in lines)
        {
            var direction = line[0];
            var number = int.Parse(line[1..]);

            if (direction == 'L')
            {
                currentPosition -= number;
                currentPosition = (currentPosition % 100 + 100) % 100;
            }
            else
            {
                currentPosition += number;
                currentPosition %= 100;
            }
            
            if (currentPosition == 0) { seenZeroes++; }
        }
        
        return seenZeroes;
    }

    public static int Part_2(string? input = null)
    {
        input ??= GetInput();
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        var currentPosition = 50;
        var seenZeroes = 0;
        
        foreach (var line in lines)
        {
            var direction = line[0];
            var number = int.Parse(line[1..]);

            if (direction == 'L')
            {
                while (number > 0)
                {
                    currentPosition--;
                    if (currentPosition == 0) seenZeroes++;
                    if (currentPosition < 0) currentPosition = 99;
                    number--;
                } 
            }
            else
            {
                while (number > 0)
                {
                    currentPosition++;
                    if (currentPosition > 99) currentPosition = 0;
                    if (currentPosition == 0) seenZeroes++;
                    number--;
                }
                currentPosition += number;
                seenZeroes += currentPosition / 100;
                currentPosition %= 100;
            }
        }
        
        return seenZeroes;
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2025/Input/Day01.txt");
    }
}
