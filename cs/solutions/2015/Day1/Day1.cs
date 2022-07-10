namespace solutions._2015;

public class Day1
{

    public int Part_1(string? input = null)
    {
        input = input ?? GetInput();

        int currentFloor = 0;

        foreach (var character in input)
        {
            currentFloor = character == '(' ? currentFloor + 1 : currentFloor - 1;
        }
        
        return currentFloor;
    }
    
        public int Part_2(string? input = null)
    {
        input = input ?? GetInput();

        int currentFloor = 0;
        int characterPosition = 1;
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

    private string GetInput()
    {
        return File.ReadAllText("./2015/day1/input.txt");
    }
}