namespace solutions._2015;

public class Day3
{

    public static int Part_1(string? input = null)
    {
        input = input ?? GetInput();
        var santa = new Santa();
        var visited = new List<string>()
        {
            "x0y0"
        };
        foreach (var c in input)
        {
            santa.Move(c);
            visited.Add(santa.GetCoordinateString());
        }
        return visited.Distinct().Count();
    }
    
    public static int Part_2(string? input = null)
    {
        input = input ?? GetInput();
        var santa = new Santa();
        var roboSanta = new Santa();
        var visited = new List<string>()
        {
            "x0y0"
        };
        for (var i = 0; i < input.Count(); i++)
        {
            var currentSanta = i % 2 == 0 ? santa : roboSanta;
            currentSanta.Move(input[i]);
            visited.Add(currentSanta.GetCoordinateString());
        }

        return visited.Distinct().Count();
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2015/Day3/input.txt");
    }
}

public class Santa
{
    private int _x;
    private int _y;

    public void Move(char direction)
    {
        switch (direction)
        {
            case '>':
                _x++;
                break;
            case 'v':
                _y--;
                break;
            case '<':
                _x--;
                break;
            case '^':
                _y++;
                break;
            default:
                throw new Exception("Invalid direction given, was: " + direction);
        }
    }

    public string GetCoordinateString()
    {
        return 'x' + _x.ToString() + 'y' + _y.ToString();
    }
}