using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class Day2Tests
{
    private Day2 _day;

    public Day2Tests()
    {
        _day = new Day2();
    }

    [TestCase("2x3x4", 58)]
    [TestCase("1x1x10", 43)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        _day.Part_1(input).Should().Be(expected);
    }
    
    [TestCase("2x3x4", 34)]
    [TestCase("1x1x10", 14)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        _day.Part_2(input).Should().Be(expected);
    }
}
