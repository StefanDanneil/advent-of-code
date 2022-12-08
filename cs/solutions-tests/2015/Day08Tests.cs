using System.IO;
using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class Day08Tests
{
    private static string GetInput()
    {
        return File.ReadAllText("./2015/Day08TestInput.txt");
    }
    
    [TestCase("", 12)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        var testInput = GetInput();
        Day08.Part_1(testInput).Should().Be(expected);
    }



    [TestCase("", 19)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        var testInput = GetInput();
        Day08.Part_2(testInput).Should().Be(expected);
    }
}
