using System.IO;
using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class Day8Tests
{
    private readonly Day8 _day;
    private readonly string _testInput;
    
    public Day8Tests()
    {
        _day = new Day8();
        _testInput = GetInput();
    }

    private static string GetInput()
    {
        return File.ReadAllText("./2015/Day8TestInput.txt");
    }
    
    [TestCase("", 12)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        _day.Part_1(_testInput).Should().Be(expected);
    }



    [TestCase("", 19)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        _day.Part_2(_testInput).Should().Be(expected);
    }
}
