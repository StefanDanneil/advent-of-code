using System.Reflection;
using solutions;
using solutions._2025;

// var days = Assembly.GetAssembly(typeof(Day01))
//     ?.GetTypes()
//     .Where(t => typeof(IDay).IsAssignableFrom(t) && t is { IsInterface: false, IsAbstract: false }) ?? [];
//
// foreach (var day in days)
// {
//     var part1Method = day.GetMethod("Part_1", BindingFlags.Public | BindingFlags.Static, null, [typeof(string)], null);
//     var part2Method = day.GetMethod("Part_2", BindingFlags.Public | BindingFlags.Static, null, [typeof(string)], null);
//
//     // Invoke static methods with null input
//     var result1 = (int)part1Method!.Invoke(null, [null])!;
//     var result2 = (int)part2Method!.Invoke(null, [null])!;
//
//     Console.WriteLine($"{day.Name} - Part 1: {result1}, Part 2: {result2}");
// }

var result1 = Day04.Part_1();
var result2 = Day04.Part_2();

Console.WriteLine($"{nameof(Day04)} - Part 1: {result1}, Part 2: {result2}");