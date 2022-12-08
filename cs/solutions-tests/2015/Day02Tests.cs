using FluentAssertions;
using NUnit.Framework;
using solutions._2015;

namespace solutions_tests._2015;

public class Day02Tests
{
    [TestCase("2x3x4", 58)]
    [TestCase("1x1x10", 43)]
    public void it_solves_part_1_according_to_examples(string input, int expected)
    {
        Day02.Part_1(input).Should().Be(expected);
    }
    
    [TestCase("2x3x4", 34)]
    [TestCase("1x1x10", 14)]
    public void it_solves_part_2_according_to_examples(string input, int expected)
    {
        Day02.Part_2(input).Should().Be(expected);
    }
}
