namespace solutions._2015;

public class Day1
{

    public static int Part_1(string? input = null)
    {
        input = input ?? GetInput();

        return input.Aggregate(0, (current, character) => character == '(' ? current + 1 : current - 1);
    }
    
    public static int Part_2(string? input = null)
    {
        input = input ?? GetInput();

        var currentFloor = 0;
        var characterPosition = 1;
        foreach (var character in input)
        {
        
            currentFloor = character == '(' ? currentFloor + 1 : currentFloor - 1;
            if (currentFloor == -1)
            {
                return characterPosition;
            }

            characterPosition++;
        }

        throw new Exception("did not find the correct position");
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2015/day1/input.txt");
    }
}