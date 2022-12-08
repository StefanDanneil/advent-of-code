namespace solutions._2022;

public static class Day03
{
    public static int Part_1(string? input = null)
    {
        input ??=  GetInput();
        var rucksacks = input.Split('\n');

        return rucksacks
            .Select(content =>
            {
                var firstCompartment = content.Take(content.Length / 2);
                var secondCompartment = content.Skip(content.Length / 2);
                var misplacedItem = FindMisplacedItem(firstCompartment, secondCompartment);
                
                return GetPriorityForItem(misplacedItem);
            }).Sum();
    }

    private static char FindMisplacedItem(IEnumerable<char> firstCompartment, IEnumerable<char> secondCompartment)
    {
        foreach (var c in firstCompartment.Where(secondCompartment.Contains))
        {
            return c;
        }

        throw new KeyNotFoundException("Could not find");
    }

    private static int GetPriorityForItem(char item)
    {
        const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowercase = "abcdefghijklmnopqrstuvwxyz";
        
        if (uppercase.Contains(item))
            return 27 + uppercase.IndexOf(item);

        if (lowercase.Contains(item))
            return 1 + lowercase.IndexOf(item);

        throw new KeyNotFoundException();
    }
    
    public static int Part_2(string? input = null)
    {
        input ??= GetInput();
        var rucksacks = input.Split('\n');
        var priorities = new List<int>();

        for (var i = 0; i < rucksacks.Length; i+=3)
        {
            var group = rucksacks.Skip(i).Take(3);
            var badge = FindGroupBadge(group);
            priorities.Add(GetPriorityForItem(badge));
        }

        return priorities.Sum();
    }

    private static char FindGroupBadge(IEnumerable<string> group)
    {
        var enumerable = group as string[] ?? group.ToArray();
        var first = enumerable[0];
        var second = enumerable[1];
        var third = enumerable[2];
        
        foreach (var c in first.Where(c => second.Contains(c) && third.Contains(c)))
        {
            return c;
        }

        throw new KeyNotFoundException("Could not find badge");
    }
    
    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day3/input.txt");
    }
}
