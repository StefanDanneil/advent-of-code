namespace solutions._2022;

public static class Day02
{
    private static readonly Dictionary<string, int> ShapeScores = new()
    {
        { "A", 1 }, // rock
        { "B", 2 }, // paper
        { "C", 3 }, // scissors
        { "X", 1 }, // rock
        { "Y", 2 }, // paper
        { "Z", 3 }  //scissors
    };
    
    public static int Part_1(string? input = null)
    {
        input ??= GetInput();
        var instructions = input.Split('\n');
        

        var rounds = instructions.Select(i =>
        {
            var shapes = i.Split(' ').Select(s => s.Trim()).ToList();

            ShapeScores.TryGetValue(shapes[0], out var opponentShapeValue);
            ShapeScores.TryGetValue(shapes[1], out var playerShapeValue);

            return CalculateScore(opponentShapeValue, playerShapeValue);
        });
        
        return rounds.Sum();
    }

    private static int CalculateScore(int opponentValue, int playerValue)
    {
        // tie
        if (opponentValue == playerValue)
            return playerValue + 3;

        return playerValue switch
        {
            // paper beats rock
            1 when opponentValue == 2 => playerValue,
            // scissors beat paper
            2 when opponentValue == 3 => playerValue,
            // rock beats scissors
            3 when opponentValue == 1 => playerValue,
            //win
            _ => playerValue + 6 
        };
    }
    
    public static int Part_2(string? input = null)
    {
        input ??=  GetInput();
        var instructions = input.Split('\n');


        var rounds = instructions.Select(i =>
        {
            var shapes = i.Split(' ').Select(s => s.Trim()).ToList();

            ShapeScores.TryGetValue(shapes[0], out var opponentShapeValue);

            return shapes[1] switch
            {
                "X" => CalculateScore(opponentShapeValue, GetLosingValue(opponentShapeValue)),
                "Y" => CalculateScore(opponentShapeValue, opponentShapeValue),
                "Z" => CalculateScore(opponentShapeValue, GetWinningValue(opponentShapeValue)),
                _ => throw new ArgumentOutOfRangeException()
            };
        });

        return rounds.Sum();
    }

    private static int GetWinningValue(int valueToBeat)
    {
        return valueToBeat switch
        {
            1 => 2,
            2 => 3,
            3 => 1,
            _ => throw new ArgumentException()
        };
    }
    
    private static int GetLosingValue(int valueToLoseTo)
    {
        return valueToLoseTo switch
        {
            1 => 3,
            2 => 1,
            3 => 2,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    
    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day2/input.txt");
    }
}
