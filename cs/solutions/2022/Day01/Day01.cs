using System.Collections.Immutable;

namespace solutions._2022;

public static class Day01
{
    public static int Part_1(string? input = null)
    {
        input = input ?? GetInput();

        var elfCalories = GetElfCalories(input); 
        
        return elfCalories.Max();
    }

    private static IEnumerable<int> GetElfCalories(string input)
    {
        var elfInventories = input.Split("\n\n");
        return elfInventories
            .Select(elfInventory => elfInventory.Split("\n"))
            .Select(foods => foods.Select(int.Parse).Sum());
    }
    
    public static int Part_2(string? input = null)
    {
        input = input ?? GetInput();
        var caloriesPerElfOrderedDescending = GetElfCalories(input).OrderByDescending(elf => elf);

        return caloriesPerElfOrderedDescending.Take(3).Sum();
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2022/Day1/input.txt");
    }
}
