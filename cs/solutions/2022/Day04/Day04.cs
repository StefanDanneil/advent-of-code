namespace solutions._2022;

public static class Day04
{
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var pairs = input.Split('\n');

        return pairs.Where(pair =>
        {
            var idRanges = pair.Split(',');
            var firstRange = idRanges.First().Trim().Split('-');
            var secondRange = idRanges.Last().Trim().Split('-');
            var firstIds = GetSectionEnumerable(int.Parse(firstRange.First()), int.Parse(firstRange.Last())).ToList();
            var secondIds = GetSectionEnumerable(int.Parse(secondRange.First()), int.Parse(secondRange.Last())).ToList();

            var intersection = firstIds.Intersect(secondIds).ToList();

            return !firstIds.Except(intersection).Any() || !secondIds.Except(intersection).Any();

        }).Count();
    }

    private static IEnumerable<int> GetSectionEnumerable(int lower, int upper)
    {
        var output = new List<int>();

        for (var i = lower; i <= upper; i++)
        {
            output.Add(i);
        }

        return output;
    }

    public static int Part_2(string? input = null)
    {
        input ??= GetInput();
        var pairs = input.Split('\n');

        return pairs.Where(pair =>
        {
            var idRanges = pair.Split(',');
            var firstRange = idRanges.First().Trim().Split('-');
            var secondRange = idRanges.Last().Trim().Split('-');
            var firstIds = GetSectionEnumerable(int.Parse(firstRange.First()), int.Parse(firstRange.Last())).ToList();
            var secondIds = GetSectionEnumerable(int.Parse(secondRange.First()), int.Parse(secondRange.Last())).ToList();

            return firstIds.Intersect(secondIds).Any();

        }).Count();
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day04/input.txt");
    }
}
